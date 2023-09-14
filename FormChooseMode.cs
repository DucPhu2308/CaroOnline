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
            Form form = new Form1();
            Hide();
            form.ShowDialog();
            Show();
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
        }
    }
}
