using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace CaroLAN
{
    internal class MessageBoxCancel : Form
    {
        public MessageBoxCancel(string message, string title = "Thông báo")
        {
            Text = title;
            Size = new System.Drawing.Size(300, 100);

            Label label = new Label();
            label.Text = message;
            label.Dock = DockStyle.Fill;

            Button cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Dock = DockStyle.Bottom;
            cancelButton.DialogResult = DialogResult.Cancel;

            cancelButton.Click += (sender, e) => Close();

            Controls.Add(label);
            Controls.Add(cancelButton);
        }
    }
}
