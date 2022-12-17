using EmuSak_Revive.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI.Generics
{
    internal static class PlayAudio
    {
        public static void Play(AudioPlayer audioPlayer, bool playAudio, string file)
        {
            if (playAudio)
            {
                audioPlayer.PlayFile(file);
            }
        }
    }
}