using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using NAudio.Wave;

//ToDo: BUG - Wave Player Crash when application launch from Document folder. NAudio package updated, check if issue still persist.

namespace FlashCard
{
    /// <summary>
    /// NAudio player warpper, replacement for System.Media.SoundPlayer
    /// </summary>
    internal class NAudioPlayerWrapper : IDisposable
    {
        #region [ Private Fields ]
        private string AudioFile;
        private AudioFileReader fileReader;
        private IWavePlayer wavePlayer;
        #endregion

        #region [ Constructor and Events ]
        public NAudioPlayerWrapper(string audioFile) { AudioFile = System.IO.Path.GetFullPath(audioFile); }
        private void wavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (wavePlayer != null) { wavePlayer.Stop(); wavePlayer.Dispose(); wavePlayer = null; }
        }
        #endregion

        #region [ Public Functions ]
        /// <summary>
        /// Load Audio file.
        /// </summary>
        public void Load() { fileReader = new AudioFileReader(AudioFile); }
        /// <summary>
        /// Play audio file from beginning. (Async)
        /// </summary>
        public void Play()
        {
            if (wavePlayer != null) wavePlayer.Dispose();
            fileReader.Position = 0;
            wavePlayer = new WaveOut();
            wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
            wavePlayer.Init(fileReader);
            wavePlayer.Stop();
            wavePlayer.Play();
        }

        /// <summary>
        /// Stop player.
        /// </summary>
        public void Stop() { wavePlayer.Stop(); }
        /// <summary>
        /// Synchronous play audio file from begining until end.
        /// </summary>
        public void PlaySync()
        {
            Play();
            //Wait until stopped
            while (wavePlayer != null) System.Windows.Forms.Application.DoEvents();
        }
        #endregion

        #region [ Dispose Pattern ]
        /// <summary>
        /// Manually dispose instance.
        /// </summary>
        public void Dispose()
        {
            //Do not modify
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            //Do not modify
            ReleaseUnmanagedResources();
            if (disposing) ReleaseManagedResources();
        }
        /// <summary>
        /// Dispose function. Release manage resources.
        /// </summary>
        protected virtual void ReleaseManagedResources()
        {
            Debug.WriteLine(System.IO.Path.GetFileName(AudioFile) + " disposed.");
            //Release unamanged resources
            if (wavePlayer != null) { wavePlayer.Stop(); wavePlayer.Dispose(); wavePlayer = null; }
            if (fileReader != null) { fileReader.Dispose(); fileReader = null; }
        }
        /// <summary>
        /// Dispose function. Release unmanaged resources.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources()
        {
            //Release managed resources
        }
        #endregion

    }
}
