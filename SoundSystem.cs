using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WMPLib;

namespace CaroLAN
{
    internal class SoundSystem
    {
        public static string pencilSound = "Soundtracks\\pencil.wav";
        public static string menuBGM = "Soundtracks\\menu.mp3";
        public static WindowsMediaPlayer bgmPlayer = new WindowsMediaPlayer();
        public static WindowsMediaPlayer sfxPlayer = new WindowsMediaPlayer();
        public static void PlaySound(string path, bool loop = false, bool isBGM = false)
        {
            var player = isBGM ? bgmPlayer : sfxPlayer;
            if (player != null && player.URL == Path.GetFullPath(pencilSound))
                StopSound();

            player.URL = path;
            // loop mode
            player.settings.setMode("loop", loop);
            // apply volume
            int volume = isBGM ? Properties.Settings.Default.BGMVolume : Properties.Settings.Default.SFXVolume;
            player.settings.volume = volume;
            player.controls.play();
        }
        public static void StopSound(bool isBGM = false)
        {
            var player = isBGM ? bgmPlayer : sfxPlayer;
            player.controls.stop();
        }
    }
}
