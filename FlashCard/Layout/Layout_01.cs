using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CodeArtEng.PerformanceTools;
using System.Speech.Synthesis;

namespace FlashCard
{
    internal partial class Layout_01 : UserControl, IFlashCardLayout
    {
        private SpeechSynthesizer Synth;

        public Layout_01(FlashCardController controller)
        {
            CodeProfiler.Start("Begin Create Layout");
            InitializeComponent();

            Controller = controller;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Controller.LessonLoaded += new EventHandler(Controller_LessonLoaded);
            Controller.MenuLoad += new EventHandler(Controller_MenuLoad);

            BackColor = Color.Transparent;
            Stars.DimmedImageIndex = 2;
            InitializeControls();

            BtMenu.Text = "Menu";
            lbCardCounter.Text = string.Empty;
            CodeProfiler.Stop("Begin Create Layout");

            Synth = new SpeechSynthesizer();
            Synth.Volume = 100;
            Synth.Rate = -5;
        }

        void Controller_MenuLoad(object sender, EventArgs e)
        {
            hintTimer.Enabled = false; Debug.WriteLine("Timer stopped. Menu Loaded.");
        }
        void Controller_LessonLoaded(object sender, EventArgs e)
        {
            try
            {
                GetNextCard();
            }
            catch { MainPicture.SizeMode = PictureBoxSizeMode.Zoom; }
        }

        private string ExpectedText;
        private int CurrentIndex;
        private int Score;

        public FlashCardController Controller { get; set; }
        public void InitializeControls()
        {
            Stars.Value = 0;
            Score = 0;
            LbScore.Text = "0";
            MainPicture.Image = null;
            CardLabel.Text = string.Empty;
            PuzzleHint.Text = string.Empty;

            switch (Controller.Mode)
            {
                case FlashCardMode.Vocabulary:
                    CardLabel.ShowHint = true;
                    PuzzleHint.Visible = false;
                    break;

                case FlashCardMode.Spelling:
                    CardLabel.ShowHint = false;
                    PuzzleHint.Visible = false;
                    break;

                case FlashCardMode.Puzzle:
                    CardLabel.ShowHint = false;
                    PuzzleHint.Visible = true;
                    break;

                default: throw new NotSupportedException("Layout_01 did not support " + Controller.Mode.ToString() + " mode.");
            }
        }
        public FlashCardItem SelectedCard { get; set; }
        public void GetNextCard()
        {
            try
            {
                //Stop hint timer
                #region [ Spelling Mode ]
                if (Controller.Mode == FlashCardMode.Spelling)
                {
                    hintTimer.Enabled = false;
                    Debug.WriteLine("Timer Suspended");
                }
                #endregion

                Controller.Busy = true;
                SelectedCard = Controller.GetNextCard();
                if (SelectedCard != null)
                {
                    CodeProfiler.Start("GetNextCard-LoadCard");
                    lbCardCounter.Text = Controller.Cards.IndexOf(SelectedCard).ToString() +
                        " / " + Controller.Cards.Count.ToString();

                    MainPicture.Image = SelectedCard.Image;

                    //In Spelling mode, spell each characters
                    #region [ Spelling Mode Only ]
                    if (Controller.Mode == FlashCardMode.Spelling)
                    {
                        CardLabel.Text = String.Empty;
                        Cursor = Cursors.WaitCursor;
                        if (SelectedCard.Audio != null) SelectedCard.Audio.PlaySync();
                        else Synth.Speak(SelectedCard.Text);

                        foreach (char ptrChar in SelectedCard.Text)
                            Controller.PlayCharSoundSync(ptrChar);
                        hintTimer.Interval = Controller.SpellingModeHintIntervalInitial;
                        Cursor = Cursors.Default;
                    }
                    #endregion

                    if (Controller.CaseSensitive)
                    {
                        CardLabel.Text = SelectedCard.Text;
                        ExpectedText = CardLabel.Text;
                        CurrentIndex = 0;
                    }
                    else
                    {
                        CardLabel.Text = SelectedCard.Text.ToUpper();
                        ExpectedText = CardLabel.Text;
                        CurrentIndex = 0;
                    }

                    //Create puzzle hint
                    #region [ Puzzle Mode Only ]
                    if (Controller.Mode == FlashCardMode.Puzzle)
                    {
                        PuzzleHint.Text = CardLabel.Text;
                        PuzzleHint.Shuffle();
                        for (int x = 0; x < PuzzleHint.Text.Length; x++)
                            PuzzleHint.HighlightChar(x);
                    }
                    #endregion

                    MainPicture.Refresh();
                    CardLabel.Refresh();
                    CodeProfiler.Stop("GetNextCard-LoadCard");

                    //Read selected card
                    if (SelectedCard.Audio != null) SelectedCard.Audio.PlaySync();
                    else Synth.Speak(SelectedCard.Text);

                    //Start hint timer
                    #region [ Spelling Mode Only ]
                    if (Controller.Mode == FlashCardMode.Spelling)
                        hintTimer.Enabled = Controller.SpellingModePlayHint; Debug.WriteLine("Timer Enabled");
                    #endregion
                }
            }
            finally { Controller.Busy = false; }
        }
        public void KeyPressed(object sender, char key)
        {
            if (Controller.Busy) return; //Stop responding to key press when controller is busy, e.g Loading card.
            try
            {
                Controller.Busy = true;
                if (SelectedCard == null) return;

                if (!Controller.CaseSensitive) key = char.ToUpper(key);
                if (key == ExpectedText[CurrentIndex])
                {
                    //Character Matched

                    //Stop hint timer
                    #region [ Spelling Mode Only ]
                    if (Controller.Mode == FlashCardMode.Spelling)
                    {
                        hintTimer.Enabled = false;
                        Debug.WriteLine("Timer Suspended");
                    }
                    #endregion

                    //Remove selected character from puzzle hint
                    #region [ Puzzle Mode Only ]
                    if (Controller.Mode == FlashCardMode.Puzzle)
                    {
                        int keyIndex = PuzzleHint.Text.IndexOf(key);
                        PuzzleHint.HideChar(keyIndex);
                    }
                    #endregion

                    CardLabel.HighlightChar(CurrentIndex);
                    CurrentIndex++;
                    Application.DoEvents();

                    //Is End of Word
                    if (CurrentIndex == ExpectedText.Length)
                    {
                        //Spell Character
                        #region [ Vocabulary and Puzzle Mode Only ]
                        if ((Controller.Mode == FlashCardMode.Vocabulary) ||
                            (Controller.Mode == FlashCardMode.Puzzle))
                        {
                            Controller.PlayCharSoundSync(key);
                        }
                        #endregion

                        //Word matched.
                        if (Stars.Count == Stars.Value) Stars.Value = 1; else Stars.Value++;

                        Score++;
                        LbScore.Text = Score.ToString();
                        //Read word for current card
                        Thread.Sleep(200);
                        if (SelectedCard.Audio != null) SelectedCard.Audio.PlaySync();
                        else Synth.Speak(SelectedCard.Text);
                        Thread.Sleep(1000);

                        GetNextCard();
                        if (SelectedCard == null)
                        {
                            //Finished...
                            CardLabel.Text = String.Empty;
                            MainPicture.SizeMode = PictureBoxSizeMode.Zoom; //Override size mode
                            MainPicture.Image = Image.FromFile(".\\System\\GoodJob.png");
                        }
                    }
                    else
                    {
                        switch (Controller.Mode)
                        {
                            case FlashCardMode.Vocabulary:
                                Controller.PlayCharSound(key);
                                break;

                            case FlashCardMode.Puzzle:
                                Controller.PlayCharSound(key);
                                break;

                            case FlashCardMode.Spelling:
                                hintTimer.Interval = Controller.SpellingModeHintIntervalInitial;
                                hintTimer.Enabled = Controller.SpellingModePlayHint;
                                Debug.WriteLine("Timer Enabled");
                                break;
                        }
                    }
                }
            }
            finally { Controller.Busy = false; }
        }
        public void Close()
        {
            Controller.LessonLoaded -= Controller_LessonLoaded;
            Controller.MenuLoad -= Controller_MenuLoad;
            this.Dispose();
        }

        private void BtMenu_Click(object sender, EventArgs e)
        {
            Controller.ShowMenuDialog();
        }
        private void hintTimer_Tick(object sender, EventArgs e)
        {
            Controller.PlayCharSound(ExpectedText[CurrentIndex]);
            hintTimer.Interval = Controller.SpellingModeHintInterval;
        }

    }
}
