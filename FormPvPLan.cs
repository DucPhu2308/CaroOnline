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
        bool connected = false;
        public FormPvPLan(string ip) : base()
        {
            socket = new SocketManager();
            socket.IP = ip;
            this.Shown += FormPvPLan_Shown;
            this.FormClosed += FormPvPLan_FormClosed;

        }

        private void FormPvPLan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connected)
            {
                socket.Send(new SocketData((int)SocketCommand.QUIT, "", null));
                Console.WriteLine("Sent quit");
            }
            if (isServer)
                socket.CloseServer();
        }

        void FormPvPLan_Shown(object sender, EventArgs e)
        {
            InitConnection();
        }
        protected override async void ResetGame()
        {
            base.ResetGame();
            if (isServer)
            {
                panelBoard.Enabled = true;
                socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", null));
            }
            else
            {
                panelBoard.Enabled = false;
                await Listen(); //Listen for first move
            }
        }
        protected override void EndGame(Player winner)
        {
            PauseGame();
            if (isServer)
            {
                DialogResult dr = MessageBox.Show(winner.Name + " thắng! Bắt đầu lại?", "Trò chơi kết thúc", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    ResetGame();
                }
            }
            else
            {
                MessageBox.Show(winner.Name + " thắng! Chờ host bắt đầu lại.");
                Listen(); //Listen for new game
            }
        }
        async void InitConnection()
        {
            if (!socket.ConnectServer())
            {
                try
                { 
                    socket.CreateServer();
                }
                catch (SocketException e)
                {
                    DialogResult dr = MessageBox.Show(String.Format("Không tìm thấy host với IP {0}. Thử lại?",socket.IP),"Không thể kết nối", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Retry)
                    {
                        InitConnection();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                lbName2.Text = "Đang chờ đối thủ...";
                panelBoard.Enabled = false;
                await Listen(); //Listen for name
                connected = true;
                socket.Send(new SocketData((int)SocketCommand.SEND_NAME, player1.Name, null));
                panelBoard.Enabled = true;
            }
            else
            {
                isServer = false;
                connected = true;
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
                    Listen();
                    break;
                case (int) SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.SEND_NAME:
                    if (IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            if (isServer)
                            {
                                player2 = new Player(data.Message, panelPlayer2);
                                player2.LabelName.Text = player2.Name;
                                player2.TimeOut += base.Player_TimeOut;
                            }
                            else
                            {
                                player2 = new Player(player1.Name, panelPlayer2);
                                player1 = new Player(data.Message, panelPlayer1);
                                player2.LabelName.Text = player2.Name;
                                player1.LabelName.Text = player1.Name;
                                player1.TimeOut += base.Player_TimeOut;
                                player2.TimeOut += base.Player_TimeOut;
                            }
                        }));
                    }
                    break;
                case (int)SocketCommand.QUIT:
                    PauseGame();
                    connected = false;
                    MessageBox.Show("Đối thủ đã thoát");
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Close();
                    }));
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        ResetGame();
                    }));
                    break;
            }
        }
    }
}
