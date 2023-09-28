using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroLAN
{
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
            btnCancel.Click += ButtonSound;
            btnSave.Click += ButtonSound;
        }
        private void ButtonSound(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
        }
        private void FormOption_Load(object sender, EventArgs e)
        {
            int time = (int)Properties.Settings.Default.TotalTime;
            numMinute.Value = time / 60;
            numSecond.Value = time % 60;

            trackBGM.Value = Properties.Settings.Default.BGMVolume;
            trackSFX.Value = Properties.Settings.Default.SFXVolume;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TotalTime = (int)numMinute.Value * 60 + (int)numSecond.Value;
            Properties.Settings.Default.BGMVolume = trackBGM.Value;
            Properties.Settings.Default.SFXVolume = trackSFX.Value;
            Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // restore settings
            SoundSystem.bgmPlayer.settings.volume = Properties.Settings.Default.BGMVolume;
            SoundSystem.sfxPlayer.settings.volume = Properties.Settings.Default.SFXVolume;

            Close();
        }

        private void trackBGM_Scroll(object sender, EventArgs e)
        {
            SoundSystem.bgmPlayer.settings.volume = trackBGM.Value;
        }

        private void trackSFX_Scroll(object sender, EventArgs e)
        {
            SoundSystem.sfxPlayer.settings.volume = trackSFX.Value;
            //SoundSystem.sfxPlayer.controls.play();
        }

        private void trackSFX_MouseUp(object sender, MouseEventArgs e)
        {
            SoundSystem.sfxPlayer.controls.play();
        }
    }
}
