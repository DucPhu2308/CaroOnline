using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CaroLAN
{
    internal class FormPvPLan : Form1
    {
        SocketManager socket;
        bool isServer = true;
        public FormPvPLan(string ip) : base()
        {
            socket = new SocketManager();
            socket.IP = ip;
            this.Shown += FormPvPLan_Shown;

        }
        void FormPvPLan_Shown(object sender, EventArgs e)
        {
            InitConnection();
        }
        async void InitConnection()
        {
            if (!socket.ConnectServer())
            {
                socket.CreateServer();
                await Listen(); //Listen for name
                socket.Send(new SocketData((int)SocketCommand.SEND_NAME, player1.Name, null));
            }
            else
            {
                isServer = false;
                panelBoard.Enabled = false; // server goes first

                socket.Send(new SocketData((int)SocketCommand.SEND_NAME, player1.Name, null));
                await Listen(); //Listen for name
                await Listen(); //Listen for first move
            }
        }
        protected override void MatrixButton_Click(object sender, EventArgs e)
        {
            base.MatrixButton_Click(sender, e);
            Button btn = sender as Button;
            //send point to opponent
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", new Point(int.Parse(btn.Tag.ToString().Split(' ')[0]), int.Parse(btn.Tag.ToString().Split(' ')[1]))));
            panelBoard.Enabled = false;
            Listen();
        }
        private Task Listen()
        {
            Task listenThread = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        SocketData data = (SocketData)socket.Receive();
                        ProcessData(data);
                        break;
                    }
                    catch (SocketException e)
                    {
                        Thread.Sleep(500);
                    }
                }
            });
            listenThread.Start();
            return listenThread;
        }
        void ProcessData(SocketData data)
        {
            switch(data.Command)
            {
                case (int) SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        panelBoard.Enabled = true;
                        base.MatrixButton_Click(matrixButton[data.Point.Value.X, data.Point.Value.Y], null);
                    }));
                    break;
                case (int) SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.SEND_NAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (isServer)
                        {
                            player2 = new Player(data.Message, lbTimer2, lbName2);
                            player2.LabelName.Text = player2.Name;
                        }
                        else
                        {
                            player2 = new Player(player1.Name, lbTimer2, lbName2);
                            player1 = new Player(data.Message, lbTimer1, lbName1);
                            player2.LabelName.Text = player2.Name;
                            player1.LabelName.Text = player1.Name;
                        }
                    }));
                    break;
            }
        }
    }
}
