﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Gameplay gameplay;
        private void Form1_Load(object sender, EventArgs e)
        {
            gameplay = new Gameplay(panelBoard, pbTurn, GameMode.PvP);
            gameplay.BoardInit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
