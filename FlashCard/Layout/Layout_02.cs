using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CodeArtEng.GameControls;
using System.Speech.Synthesis;

//ToDo: Design Word list

namespace FlashCard
{
    internal partial class Layout_02 : UserControl, IFlashCardLayout
    {
        private OptionButton[] Options;
        private int AnswerIndex;
        private NAudioPlayerWrapper CorrectAnswerSound;
        private NAudioPlayerWrapper WrongAnswerSound;
        private SpeechSynthesizer Synth;

        public Layout_02(FlashCardController controller)
        {
            InitializeComponent();
            MainPicture.SizeMode = PictureBoxSizeMode.Zoom;
            Controller = controller;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Controller.LessonLoaded += new EventHandler(Controller_LessonLoaded);
            Controller.MenuLoad += new EventHandler(Controller_MenuLoad);
            BtMenu.Text = "Menu";
            lbCardCounter.Text = string.Empty;

            BackColor = Color.Transparent;
            Options = new OptionButton[] { optionButton1, optionButton2, optionButton3 , optionButton4};
            InitializeControls();

            WrongAnswerSound = TryLoadSound("WrongAnswer.mp3");
            CorrectAnswerSound = TryLoadSound("CorrectAnswer.mp3");

            tbResults.ColumnHeadersVisible = false;
            tbResults.Rows.Clear();

            Synth = new SpeechSynthesizer();
            Synth.Volume = 100;
            Synth.Rate = -5;
        }

        private NAudioPlayerWrapper TryLoadSound(string fileName)
        {
            try
            {
                NAudioPlayerWrapper audio = new NAudioPlayerWrapper(".\\System\\" + fileName);
                audio.Load();
                return audio;
            }
            catch { return null; }
        }

        void Controller_MenuLoad(object sender, EventArgs e)
        {
            //Do Nothing
        }
        void Controller_LessonLoaded(object sender, EventArgs e)
        {
            tbResults.Rows.Clear();
            if (Controller.Cards.Count < 3)
            {
                MessageBox.Show("ERROR! Lesson must contains at least 3 cards.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Controller.ShowMenuDialog();
                return;
            }
            Controller.Cards.Shuffle();
            foreach (OptionButton ptrButton in Options) ptrButton.Show();
            GetNextCard();
        }
        public FlashCardController Controller { get; set; }

        private void BtMenu_Click(object sender, EventArgs e)
        {
            Controller.ShowMenuDialog();
        }
        public void InitializeControls()
        {
            foreach (Control ptrControl in this.optionPanel.Controls)
            {
                if (ptrControl is CodeArtEng.GameControls.OptionButton)
                    ptrControl.Text = string.Empty;
            }
            MainPicture.Image = null;
        }
        public FlashCardItem SelectedCard { get; set; }

        private Random rand = new Random(DateTime.Now.Millisecond);
        private int Points;
        public void GetNextCard()
        {
            Controller.Busy = true;
            foreach (OptionButton ptrButton in Options)
            {
                ptrButton.Enabled = true;
                ptrButton.Selected = false;
                ptrButton.HighlightColor = Color.Red;
            }

            try
            {
                SelectedCard = Controller.GetNextCard();
                if (SelectedCard == null)
                {
                    foreach (OptionButton ptrButton in Options)
                    {
                        ptrButton.Text = string.Empty;
                        ptrButton.Enabled = false;
                    }

                    //Finished...
                    foreach (OptionButton ptrButton in Options) ptrButton.Hide();
                    MainPicture.SizeMode = PictureBoxSizeMode.Zoom; //Override size mode
                    MainPicture.Image = Image.FromFile(".\\System\\GoodJob.png");
                    return;
                }

                Points = Options.Length - 1;
                lbCardCounter.Text = Controller.Cards.IndexOf(SelectedCard).ToString() +
                    " / " + Controller.Cards.Count.ToString();

                MainPicture.Image = SelectedCard.Image;
                AnswerIndex = rand.Next(Options.Length); 
                Options[AnswerIndex].Tag = SelectedCard;
                Options[AnswerIndex].Text = SelectedCard.Text.ToUpper();
                Options[AnswerIndex].HighlightColor = Color.Lime;

                List<FlashCardItem> usedCards = new List<FlashCardItem>();
                usedCards.Add(SelectedCard);
                for (int x = 0; x < Options.Length; x++)
                {
                    if (x != AnswerIndex)
                    {
                        FlashCardItem randCard ;
                        do
                        {
                            randCard = Controller.Cards.GetRandomCard();
                            Options[x].Tag = randCard;
                            Options[x].Text = randCard.Text.ToUpper();
                        } while (usedCards.Contains(randCard));
                        usedCards.Add(randCard);
                    }
                }
                if (SelectedCard.Audio != null) SelectedCard.Audio.PlaySync();
                else Synth.Speak(SelectedCard.Text);
            }
            finally { Controller.Busy = false; }
        }
        public void KeyPressed(object sender, char key) { /*Do Nothing*/ }
        public void Close()
        {
            Controller.LessonLoaded -= Controller_LessonLoaded;
            Controller.MenuLoad -= Controller_MenuLoad;

            if (CorrectAnswerSound != null) { CorrectAnswerSound.Dispose(); CorrectAnswerSound = null; }
            if (WrongAnswerSound != null) { WrongAnswerSound.Dispose(); WrongAnswerSound = null; }
            
            this.Dispose();
        }

        private void optionButton_Click(object sender, EventArgs e)
        {
            Controller.Busy = true;
            OptionButton ptrButton = (OptionButton)sender;
            FlashCardItem ptrItem = (FlashCardItem)((OptionButton)sender).Tag;

            ptrButton.Refresh(); //Force button to repaint
            if (ptrItem.Audio != null) ptrItem.Audio.PlaySync();
            else Synth.Speak(ptrItem.Text);

            if (sender != Options[AnswerIndex])
            {
                WrongAnswerSound.PlaySync();
                ptrButton.Selected = false;
                ptrButton.Enabled = false;
                Points--;
            }
            else
            {
                int rowIndex = tbResults.Rows.Add();
                DataGridViewRow tRow = tbResults.Rows[rowIndex];
                tRow.Cells[0].Value = ptrItem.Text;
                tRow.Cells[1].Value = (Points + 1) * 25;

                CorrectAnswerSound.PlaySync();
                GetNextCard();
            }
            Controller.Busy = false;
        }

        private void Layout_02_SizeChanged(object sender, EventArgs e)
        {
            AlignOptionPanelToCenter();
        }

        private void AlignOptionPanelToCenter()
        {
            int newX =(OptionPanelFrame.Width - optionPanel.Width)/ 2;
            optionPanel.Left = (newX < 0) ? 0 : newX;
        }

        private void tbResults_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

    }
}
