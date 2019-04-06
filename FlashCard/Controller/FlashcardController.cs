using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Media;
using System.Speech.Synthesis;
using CodeArtEng.PerformanceTools;
using System.Windows.Forms;

//ToDo: Language Support.

namespace FlashCard
{
    internal enum FlashCardMode
    {
        Vocabulary,
        Spelling,
        Puzzle,
        Match,
    }

    internal class FlashCardController : IDisposable
    {
        #region [ Private Fields ]
        private string RootPath;
        private string LessonBasePath;
        private SelectionDialog OptionDialog;
        private Dictionary<char, NAudioPlayerWrapper> Characters;
        private bool UseThread { get; set; }
        #endregion

        #region [ Public Properties ]
        /// <summary>
        /// Indicate controller is busy, not safe to terminate.
        /// </summary>
        /// <remarks>Temp solutions for PlaySync to avoid unexpected close. </remarks>
        public bool Busy { get; set; }
        public bool CaseSensitive { get; set; }
        public FlashCardMode Mode { get; private set; }
        public IFlashCardLayout SelectedLayout { get; private set; }
        public string SelectedLesson { get; private set; }

        public bool SpellingModePlayHint { get; set; } = true;
        public int SpellingModeHintIntervalInitial { get; set; }
        public int SpellingModeHintInterval { get; set; }
        public SpeechSynthesizer Speech { get; private set; }
        #endregion

        #region [ Constructors ]
        public FlashCardController()
        {
            RootPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            RootPath = Path.GetDirectoryName(RootPath);
            LessonBasePath = RootPath + "\\Lessons\\";
            Initialize();

            Speech = new SpeechSynthesizer();
            Speech.Volume = 100;
            Speech.Rate = -5;

            LoadSettings();
        }

        public FlashCardController(string lessonPath) { LessonBasePath = lessonPath; Initialize(); }
        private void Initialize()
        {
            Cards = new FlashCardCollection();
            OptionDialog = new SelectionDialog();
            UseThread = true;

            SpellingModeHintInterval = 5000;
            SpellingModeHintIntervalInitial = 1000;

            CodeProfiler.Start("Load Characters");
            Debug.WriteLine("Loading characters audio...");
            string soundPath = RootPath + "\\System\\Characters\\";
            Characters = new Dictionary<char, NAudioPlayerWrapper>();
            for (char tChar = 'A'; tChar <= 'Z'; tChar++)
            {
                try
                {
                    string audioFile = soundPath + "Char_" + tChar.ToString() + ".mp3";
                    if (File.Exists(audioFile))
                    {
                        NAudioPlayerWrapper charPlayer = new NAudioPlayerWrapper(audioFile);
                        charPlayer.Load();
                        Characters.Add(tChar, charPlayer);
                    }
                    Debug.WriteLine("WARNING: Audio file for char " + tChar + "not found!");
                }
                catch
                {
                    Debug.WriteLine("WARNING: Unable to load audio file for char " + tChar);
                }
            }
            CodeProfiler.Stop("Load Characters");
        }
        #endregion

        #region [ Application Settings ]

        private void LoadSettings()
        {
            SpellingModePlayHint = Properties.Settings.Default.SpellingModeHintEnabled;   
            SpellingModeHintIntervalInitial = Properties.Settings.Default.SpellingModeHintIntervalInitial;
            SpellingModeHintInterval = Properties.Settings.Default.SpellingModeHintInterval;
            if (!String.IsNullOrEmpty(Properties.Settings.Default.SpeechVoice))
            {
                if (Speech.Voice.Name.Equals(Properties.Settings.Default.SpeechVoice))
                    Speech.SelectVoice(Properties.Settings.Default.SpeechVoice);
                Speech.Rate = Properties.Settings.Default.SpeechRate;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.SpellingModeHintEnabled = SpellingModePlayHint;
            Properties.Settings.Default.SpellingModeHintIntervalInitial = SpellingModeHintIntervalInitial;
            Properties.Settings.Default.SpellingModeHintInterval = SpellingModeHintInterval;
            Properties.Settings.Default.SpeechRate = Speech.Rate;
            Properties.Settings.Default.SpeechVoice = Speech.Voice.Name;
            Properties.Settings.Default.Save();
        }
        
        #endregion  

        #region [ MENU Control ]
        private string[] SupportedImageType = new string[] { ".jpg", ".jpeg", ".png", ".bmp" };
        private bool IsImageTypeSupported(string inputExt)
        {
            foreach (string ext in SupportedImageType)
                if (ext == inputExt) return true;
            return false;
        }
        public void ShowMenuDialog()
        {
            if (Busy) return;
            while (true)
            {
                OnMenuLoad();
                if (string.IsNullOrEmpty(SelectedLesson))
                {
                    //Main Menu
                    OptionDialog.Title = "Main Menu - Choose An Activity.";
                    OptionDialog.ShowDescription = true;
                    OptionDialog.ClearItems();
                    OptionDialog.ItemsBackColor = Color.FromArgb(192, 255, 192);
                    OptionDialog.ItemsForeColor = Color.DarkGreen;
                    OptionDialog.AllowToCancel = true;
                    OptionDialog.CancelButtonText = "Exit";

                    string[] modes = Enum.GetNames(typeof(FlashCardMode));
                    SelectionDialogItem ptrMenuItem;
                    string imagePath = RootPath + "\\System\\Art\\ApplicationModes\\";
                    foreach (string ptrMode in modes)
                    {
                        ptrMenuItem = OptionDialog.AddItem(ptrMode);
                        //ptrMenuItem.DescriptionImage = Image.FromFile(imagePath + ptrMode + ".png");
                    }
                    OptionDialog.AddItem("Settings");
                    OptionDialog.AddItem("About");

                    if (OptionDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Enum.IsDefined(typeof(FlashCardMode), OptionDialog.SelectedItem))
                        {
                            SelectMode((FlashCardMode)Enum.Parse(typeof(FlashCardMode),
                                OptionDialog.SelectedItem), false);
                        }
                        else if (OptionDialog.SelectedItem == "Settings")
                        {
                            Settings Settings = new Settings(this);
                            Settings.ShowDialog();
                            continue;
                        }
                        else if (OptionDialog.SelectedItem == "About")
                        {
                            AboutFlashCard AboutDlg = new AboutFlashCard();
                            AboutDlg.ShowDialog();
                            continue;
                        }
                        else throw new InvalidOperationException("Unknown menu option : " + OptionDialog.SelectedItem);
                    }
                    else //Cancel button clicked. Exit Application.
                    {
                        System.Windows.Forms.Application.Exit();
                        return;
                    }
                }
                //Lesson Menu
                if (SelectLesson() == true) return;
            }
        }
        private void SelectMode(FlashCardMode mode, bool initializeLayout)
        {
            //Select Mode. Both vocabulary and spelling are using same layout
            if (SelectedLayout != null) SelectedLayout.Close();
            Mode = mode;
            SelectedLayout = (mode == FlashCardMode.Match) ? (IFlashCardLayout)new Layout_02(this) : new Layout_01(this);
            OnLayoutChanged();
            if (initializeLayout) SelectedLayout.InitializeControls();
        }
        private bool SelectLesson()
        {
            SelectedLesson = string.Empty;
            OptionDialog = new SelectionDialog();
            OptionDialog.Text = "Select Lessons";
            OptionDialog.ShowDescription = true;
            OptionDialog.ItemsBackColor = Color.LightSkyBlue;
            OptionDialog.ItemsForeColor = Color.DarkBlue;

            if (Directory.Exists(LessonBasePath))
            {
                Debug.WriteLine("Loading lessons from " + LessonBasePath);
                string[] lessonFolders = Directory.GetDirectories(LessonBasePath);
                Dictionary<string, string> lessons = new Dictionary<string, string>();
                foreach (string ptrPath in lessonFolders)
                {
                    //Skip hidden folders
                    DirectoryInfo ptrDir = new DirectoryInfo(ptrPath);
                    if ((ptrDir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) continue;
                    lessons.Add(ptrPath.Replace(LessonBasePath, ""), ptrPath);
                }

                Debug.WriteLine("Found " + lessons.Count.ToString() + " lessons.");
                foreach (string ptrKey in lessons.Keys) Debug.WriteLine("> " + ptrKey.ToString());

                //Select lesson
                SelectionDialogItem ptrMenuItem;
                OptionDialog.ClearItems();
                foreach (string ptrItem in lessons.Keys)
                {
                    ptrMenuItem = OptionDialog.AddItem(ptrItem);
                    if (Directory.GetFiles(LessonBasePath + ptrItem).Length == 0)
                        OptionDialog.DisableItem(ptrItem);
                    else
                    {
                        string[] files = Directory.GetFiles(LessonBasePath + ptrItem);
                        foreach (string ptrFile in files)
                        {
                            if (IsImageTypeSupported(ptrFile)) continue;
                            ptrMenuItem.DescriptionImage = Image.FromFile(ptrFile);
                            break;
                        }
                    }
                }
            }

            //Add additional system menu            
            OptionDialog.AllowToCancel = true;
            OptionDialog.CancelButtonText = "Back to Main Menu";

            SelectedLesson = null;
            if (OptionDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedLesson = OptionDialog.SelectedItem;
                LoadSelectedLesson();
                CaseSensitive = false;
                return true;
            }
            return false;
        }
        private void LoadSelectedLesson()
        {
            CodeProfiler.Start("LoadLesson");
            Debug.WriteLine("Loading lesson: " + SelectedLesson);
            KillImageLoader();

            string lessonPath = LessonBasePath + SelectedLesson;
            string[] files = Directory.GetFiles(lessonPath);
            Array.Sort(files);

            //Clean up old cards. Dispose Audio object.
            foreach (FlashCardItem ptrItem in Cards)
                ptrItem.Dispose();
            Cards.Clear();
            FlashCardItem newItem;

            //Load and sort cards.
            CodeProfiler.Start("Generate Items");
            string CardName;
            string CardText;
            string CardImageType;
            foreach (string ptrFile in files)
            {
                //Card Format
                //[CardIndex]#<Card Name>.<Image type>
                CardImageType = Path.GetExtension(ptrFile).ToLower();
                if (!IsImageTypeSupported(CardImageType)) continue;

                CardName = CardText = Path.GetFileNameWithoutExtension(ptrFile);
                if (CardName.Contains("#")) CardText = CardName.Substring(CardName.IndexOf("#") + 1);
                newItem = new FlashCardItem(CardName, CardText, ptrFile);
                Debug.WriteLine("> " + newItem.Text);
                Cards.Add(newItem);
            }
            CodeProfiler.Stop("Generate Items");

            //Load card contents.
            if (UseThread)
            {
                //Use threading to load images.
                CardsLoader = new Thread(LoadCardsData);
                CardsLoader.Start();
                CodeProfiler.Start("LoadCard1");
                Cards[0].Load(); //Make sure first image is loaded
                CodeProfiler.Stop("LoadCard1");
            }
            else
            {
                //Single thread operation (Slower) - Keep for debugging purpose
                foreach (FlashCardItem ptrItem in Cards)
                {
                    CodeProfiler.Start("Load Card " + ptrItem.Name);
                    ptrItem.Load();
                    CodeProfiler.Stop("Load Card " + ptrItem.Name);
                }
            }

            Cards.ResetIndex();
            CardsLoader.Join();
            OnLessonLoaded();
            Debug.WriteLine("Lesson loaded.");
            CodeProfiler.Stop("LoadLesson");
        }
        #endregion

        #region [ Public Functions ]
        public FlashCardCollection Cards { get; private set; }
        public FlashCardItem GetNextCard() { return Cards.Next; }
        public FlashCardItem SelectedCard { get { return Cards.Selected; } }
        public void PlayCharSound(char key)
        {
            key = char.ToUpper(key);
            if (Characters.ContainsKey(key))
            {
                try { Characters[key].Play(); }
                catch { }
            }
            else
            {
                Speech.Speak(key.ToString());
            }
        }
        public void PlayCharSoundSync(char key)
        {
            key = char.ToUpper(key);
            if (Characters.ContainsKey(key))
            {
                try { Characters[key].PlaySync(); }
                catch { }
            }
            else
            {
                Speech.Speak(key.ToString());
            }
        }
        #endregion

        #region [ Thread: Cards Loader ]
        private Thread CardsLoader;
        private void LoadCardsData()
        {
            for (int x = 1; x < Cards.Count; x++)
            {
                CodeProfiler.Start("LoadCard " + Cards[x].Name);
                Cards[x].Load();
                CodeProfiler.Stop("LoadCard " + Cards[x].Name);
            }
            Debug.WriteLine("All cards loaded.");
        }
        private void KillImageLoader()
        {
            if (!UseThread) return;
            if (CardsLoader == null) return;
            if (CardsLoader.IsAlive) CardsLoader.Abort();
        }
        #endregion

        #region [ Events ]
        private void HandleEvent(EventHandler eventHandle)
        {
            EventHandler handler = eventHandle;
            if (handler == null) return;
            handler(this, new EventArgs());
        }

        public event EventHandler LessonLoaded;
        private void OnLessonLoaded() { HandleEvent(LessonLoaded); }

        public event EventHandler LayoutChanged;
        private void OnLayoutChanged() { HandleEvent(LayoutChanged); }

        public event EventHandler MenuLoad;
        private void OnMenuLoad() { HandleEvent(MenuLoad); }
        #endregion

        #region [ Dispose Pattern ]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing) ReleaseManagedResources();
        }
        private void ReleaseManagedResources()
        {
            SaveSettings();

            //Release managed resources
            foreach (NAudioPlayerWrapper ptrPlayer in Characters.Values)
                ptrPlayer.Dispose();
            Characters.Clear();
            Cards.Dispose(); Cards = null;
            OptionDialog.Dispose(); OptionDialog = null;

            if (SelectedLayout != null)
            {
                SelectedLayout.Close();
                SelectedLayout = null;
            }
        }
        private void ReleaseUnmanagedResources()
        {
            //Release unmanaged resources
        }
        #endregion
    }
}
