using NAudio.Wave;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUi
{
    public class MusicPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private CancellationTokenSource cancellationTokenSource;

        private string audioFilePath1 = "music\\arcade_game_music.mp3";
        private string audioFilePath2 = "music\\score.mp3";
        private string audioFilePath3 = "music\\game_over.mp3";

        public void PlayBackgroundMusic1(bool repeat = false)
        {
            PlayBackgroundMusic(audioFilePath1, repeat);
        }

        public void PlayBackgroundMusic2(bool repeat = false)
        {
            PlayBackgroundMusic(audioFilePath2, repeat);
        }

        public void PlayBackgroundMusic3(bool repeat = false)
        {
            PlayBackgroundMusic(audioFilePath3, repeat);
        }

        private void PlayBackgroundMusic(string filePath, bool repeat)
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => PlayMusic(filePath, repeat), cancellationTokenSource.Token);
        }

        private void PlayMusic(string filePath, bool repeat)
        {
            PlayAudioFile(filePath, repeat);
        }

        private void PlayAudioFile(string filePath, bool repeat)
        {
            do
            {
                audioFile = new AudioFileReader(filePath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // Sleep until cancellation is requested
                while (outputDevice.PlaybackState == PlaybackState.Playing && !cancellationTokenSource.Token.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                }

                outputDevice.Stop();
                outputDevice.Dispose();
                audioFile.Dispose();
            }
            while (repeat && !cancellationTokenSource.Token.IsCancellationRequested);
        }

        public void StopBackgroundMusic()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
