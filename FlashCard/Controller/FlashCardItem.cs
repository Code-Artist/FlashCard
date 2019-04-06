using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;

//ToDo: Language Support.

namespace FlashCard
{
    internal class FlashCardItem : IDisposable
    {
        public FlashCardItem(string name, string text, string imagePath)
        {
            Name = name;
            Text = text;
            ImagePath = imagePath;
            AudioPath = Path.GetDirectoryName(imagePath) + "\\Audio\\" + Text;
        }
        public string Name { get; private set; }
        public string Text { get; private set; }

        public Image Image { get; set; }
        public string ImagePath { get; set; }

        public NAudioPlayerWrapper Audio { get; set; }
        public string AudioPath { get; set; }

        public void Load()
        {
            try { if (Image == null) Image = Image.FromFile(ImagePath); }
            catch { Image = null; Debug.WriteLine("Unable to load image for " + Name); }
            try
            {
                if (Audio == null)
                {
                    string[] SupportedAudioFileType = { ".mp3", ".wav" };
                    foreach (string ext in SupportedAudioFileType)
                    {
                        if (File.Exists(AudioPath + ext))
                        {
                            Audio = new NAudioPlayerWrapper(AudioPath + ext);
                            Audio.Load();
                            return;
                        }
                    }
                    Debug.WriteLine("Audio not exists " + Name);
                }
            }
            catch { Audio = null; Debug.WriteLine("Unable to load audio for " + Name); }
        }

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
            //Release managed resources
            if (Audio != null) { Audio.Dispose(); Audio = null; }
        }
        private void ReleaseUnmanagedResources()
        {
            //Release unmanaged resources
        }
        #endregion
    }
}
