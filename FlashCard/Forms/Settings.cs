using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;


namespace FlashCard
{
    internal partial class Settings : Form
    {
        FlashCardController Controller;
        SpeechSynthesizer SpeechSample;

        public Settings(FlashCardController sender)
        {
            this.SetAppIcon();
            InitializeComponent();
            Controller = sender;

            //Read Settings
            chkHintSpelling.Checked = Controller.SpellingModePlayHint;
            NumericHintInterval.Enabled = NumericInitialHintInterval.Enabled = chkHintSpelling.Checked;
            NumericInitialHintInterval.Value = Controller.SpellingModeHintIntervalInitial / 1000;
            NumericHintInterval.Value = Controller.SpellingModeHintInterval / 1000;
            TrackSpeechSpeed.Value = Controller.Speech.Rate;

            CbVoices.Items.Clear();
            CbVoices.Items.AddRange(Controller.Speech.GetInstalledVoices().Select(x => x.VoiceInfo.Name).ToArray());
            CbVoices.SelectedIndex = CbVoices.Items.IndexOf(Controller.Speech.Voice.Name);

            SpeechSample = new SpeechSynthesizer();
            SpeechSample.SelectVoice(Controller.Speech.Voice.Name);
            SpeechSample.Rate = Controller.Speech.Rate;
        }

        private void BtOK_Click(object sender, EventArgs e)
        {
            //Update Settings
            Controller.SpellingModePlayHint = chkHintSpelling.Checked;
            Controller.SpellingModeHintIntervalInitial = (int)(NumericInitialHintInterval.Value * 1000);
            Controller.SpellingModeHintInterval = (int)(NumericHintInterval.Value * 1000);
            Controller.Speech.Rate = TrackSpeechSpeed.Value;

            if (!CbVoices.Text.Equals(Controller.Speech.Voice.Name)) Controller.Speech.SelectVoice(CbVoices.Text);
            Controller.Speech.Rate = TrackSpeechSpeed.Value;
        }

        private void chkHintSpelling_CheckedChanged(object sender, EventArgs e)
        {
            NumericHintInterval.Enabled = NumericInitialHintInterval.Enabled = chkHintSpelling.Checked;
        }

        #region [ Speech Synthesizer ]

        private void TrackSpeechSpeed_Scroll(object sender, EventArgs e)
        {
            SpeechSample.Rate = TrackSpeechSpeed.Value;
        }

        private void CbVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpeechSample?.SelectVoice(CbVoices.Text);
        }

        private void BtSpeak_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtSpeechSample.Text)) return;
            SpeechSample.Speak(TxtSpeechSample.Text);
        }

        #endregion

    }
}
