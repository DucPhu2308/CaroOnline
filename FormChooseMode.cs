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
    public partial class FormChooseMode : Form
    {
        public FormChooseMode()
        {
            InitializeComponent();
        }

        private void btnLocalPlay_Click(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
            Form form = new Form1();
            Hide();
            form.ShowDialog();
            Close();
        }

        private void txtPlayerName_Leave(object sender, EventArgs e)
        {
            // Save player name
            Properties.Settings.Default.PlayerName = txtPlayerName.Text;
            Properties.Settings.Default.Save();
        }

        private void txtPlayerName2_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.PlayerName2 = txtPlayerName2.Text;
            Properties.Settings.Default.Save();
        }

        private void FormChooseMode_Load(object sender, EventArgs e)
        {
            txtPlayerName.Text = Properties.Settings.Default.PlayerName;
            txtPlayerName2.Text = Properties.Settings.Default.PlayerName2;

            // get IP address
            txtIPAddress.Text = SocketManager.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIPAddress.Text))
            {
                txtIPAddress.Text = SocketManager.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
            }
        }

        private void btnLANPlay_Click(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
            Form form = new FormPvPLan(txtIPAddress.Text);
            Hide();
            form.ShowDialog();
            Close();
        }

        private void btnPvC_Click(object sender, EventArgs e)
        {
            SoundSystem.PlaySound(SoundSystem.pencilSound);
            bool playerFirst = rbPlayerFirst.Checked;
            Form form = new FormPvC(playerFirst);
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
