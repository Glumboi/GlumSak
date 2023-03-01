using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace EmuSak_Revive.Audio
{
    public class AudioPlayer
    {
        private WaveOut player = new WaveOut();

        /// <summary>
        /// Volume for our audio player (0.0f - 1f).
        /// </summary>
        public float Volume
        { get => player.Volume; set { player.Volume = value; } }

        /// <summary>
        /// List of files for the audio player to play.
        /// </summary>
        public List<string> AudioFiles { get; set; }

        /// <summary>
        /// Volume must be a value between 0 and 100.
        /// </summary>
        /// <param name="volume"></param>
        public AudioPlayer(int volume)
        {
            Volume = volume / 100f;
        }

        /// <summary>
        /// Volume must be a value between 0 and 100.
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

        /// <summary>
        /// Used to play an mp3 file from the embedded resources or a byte array
        /// </summary>
        /// <param name="mp3FileFromRes"></param>
        public void PlayFromByteArr(byte[] mp3FileFromRes)
        {
            MemoryStream mp3file = new MemoryStream(mp3FileFromRes);
            Mp3FileReader mp3reader = new Mp3FileReader(mp3file);
            player.Init(mp3reader);
            player.Play();
        }

        public void PlayFromByteArrAsync(byte[] mp3FileFromRes)
        {
            Task.Run(() => PlayFromByteArr(mp3FileFromRes));
        }

        /// <summary>
        /// Stops the current playing audio.
        /// </summary>
        public void Stop()
        {
            player.Stop();
        }
    }
}