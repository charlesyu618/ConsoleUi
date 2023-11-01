using NAudio.Wave;
using System.Reflection;
using System.Threading;

namespace ConsoleUi
{
    public class MusicPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public void PlayBackgroundMusic1()
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Current Directory: " + currentDirectory);
            
            string audioFilePath = "arcade_game_music.mp3";

            audioFile = new AudioFileReader(audioFilePath);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            //Sleep to keep the music playing
            while (true)
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


