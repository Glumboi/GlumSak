using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmuSak_Revive.Audio
{
    public class AudioPlayer
    {
        private WaveOut player = new WaveOut();

        public float Volume
        { get => player.Volume; set { player.Volume = value; } }

        public List<string> AudioFiles { get; set; }

        /// <summary>
        /// Volume must be a value between 0 and 100
        /// </summary>
        /// <param name="volume"></param>
        public AudioPlayer(int volume)
        {
            Volume = volume / 100f;
        }

        /// <summary>
        /// Volume must be a value between 0 and 100
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(int volume)
        {
            Volume = volume / 100f;
        }

        /// <summary>
        /// File must be a path!
        /// For example: C:\yourfile.wav
        /// It has to be WAV!
        /// </summary>
        /// <param name="fileName"></param>
        public void PlayFile(string fileName)
        {
            try
            {
                var reader = new WaveFileReader(fileName);
                player.Init(reader);
                player.Play();
            }
            catch (Exception e)
            {
                //Do nothing
                Debug.WriteLine("There was an error playing an audio file!\nDetailed error: " + e);
            }
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}