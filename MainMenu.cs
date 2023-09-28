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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
            Form form = new FormChooseMode();
            Hide();
            form.ShowDialog();
            // show if not disposed
            if (!IsDisposed)
                Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Close();
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
            Form form = new FormOption();
            form.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.menuBGM, true, true);
        }
    }
}
