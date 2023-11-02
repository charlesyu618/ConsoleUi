using NAudio.Wave;
using System.Reflection;
using System.Threading;

namespace ConsoleUi
{
    public class MusicPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private string audioFilePath1 = "arcade_game_music.mp3";

        public void PlayBackgroundMusic1()
        {
            while (true)
            {
                PlayMusic();
            }
        }

        private void PlayMusic()
        {
            audioFile = new AudioFileReader(audioFilePath1);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            // Sleep until the audio file reaches the end
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
        }

        public void StopBackgroundMusic()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                audioFile.Dispose();
            }
        }
    }
}


