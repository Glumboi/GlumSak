using EmuSak_Revive.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI.Generics
{
    /// <summary>
    /// Extra methods to play a sound, used in the gui
    /// </summary>
    internal static class PlayAudio
    {
        public static void Play(AudioPlayer audioPlayer, bool playAudio, string file)
        {
            if (playAudio)
            {
                audioPlayer.PlayFile(file);
            }
        }

        public static void PlayFromByteArr(AudioPlayer audioPlayer, bool playAudio, byte[] file)
        {
            if (playAudio)
            {
                audioPlayer.PlayFromByteArrAsync(file);
            }
        }
    }
}