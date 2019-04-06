using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using CodeArtEng.GameControls;
using CodeArtEng.PerformanceTools;

namespace FlashCard
{
    public partial class MainForm : Form
    {
        private FlashCardController Controller;
        private IFlashCardLayout CurrentLayout;
        private string CaptionBuffer;
        public MainForm()
        {
            InitializeComponent();
            Controller = new FlashCardController();
            Controller.LessonLoaded += new EventHandler(Controller_LessonLoaded);
            Controller.LayoutChanged += new EventHandler(Controller_LayoutChanged);
            CaptionBuffer = Text;
        }

        #region [ Event Handler ]
        void Controller_LayoutChanged(object sender, EventArgs e)
        {
            CurrentLayout = Controller.SelectedLayout;
            if (CurrentLayout == null) { Application.Exit(); return; }

            //Speed up to reduce flickering
            Image ptrImage = BackgroundImage;
            BackgroundImage = null;

            CodeProfiler.Start("MainForm::LayoutChanged");
            UserControl ptrControl = (UserControl)CurrentLayout;
            ptrControl.Dock = DockStyle.Fill;
            ptrControl.Parent = this;

            BackgroundImage = ptrImage;
            CodeProfiler.Stop("MainForm::LayoutChanged");
        }
        void Controller_LessonLoaded(object sender, EventArgs e)
        {
            CurrentLayout.InitializeControls();
            //CurrentLayout.GetNextCard(); //Moved to Layout_01
            Text = Controller.SelectedLesson + " - " + CaptionBuffer;
        }
        #endregion

        private void StartupTimer_Tick(object sender, EventArgs e)
        {
            StartupTimer.Enabled = false;
            Controller.ShowMenuDialog();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tKey = e.KeyChar;

            if (tKey == 0x001b) //ESC key pressed
            {
                Controller.ShowMenuDialog();
                return;
            }

            CurrentLayout.KeyPressed(this, tKey);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Controller.Busy) { e.Cancel = true; return; }
            if (Controller != null) { Controller.Dispose(); Controller = null; }
        }

    }
}
