namespace CaroLAN
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.lbScore2 = new System.Windows.Forms.Label();
            this.lbName2 = new System.Windows.Forms.Label();
            this.lbTimer2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.lbScore1 = new System.Windows.Forms.Label();
            this.lbName1 = new System.Windows.Forms.Label();
            this.lbTimer1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbTurn = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.changeFirstPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBoard.Location = new System.Drawing.Point(0, 0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(1053, 670);
            this.panelBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelPlayer2);
            this.panel2.Controls.Add(this.panelPlayer1);
            this.panel2.Controls.Add(this.pbTurn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1053, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 670);
            this.panel2.TabIndex = 1;
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayer2.Controls.Add(this.lbScore2);
            this.panelPlayer2.Controls.Add(this.lbName2);
            this.panelPlayer2.Controls.Add(this.lbTimer2);
            this.panelPlayer2.Controls.Add(this.pictureBox2);
            this.panelPlayer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayer2.Location = new System.Drawing.Point(0, 446);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(327, 181);
            this.panelPlayer2.TabIndex = 2;
            // 
            // lbScore2
            // 
            this.lbScore2.AutoSize = true;
            this.lbScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore2.Location = new System.Drawing.Point(107, 56);
            this.lbScore2.Name = "lbScore2";
            this.lbScore2.Size = new System.Drawing.Size(147, 38);
            this.lbScore2.TabIndex = 6;
            this.lbScore2.Tag = "score";
            this.lbScore2.Text = "Score: 0";
            // 
            // lbName2
            // 
            this.lbName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName2.Location = new System.Drawing.Point(5, 7);
            this.lbName2.Name = "lbName2";
            this.lbName2.Size = new System.Drawing.Size(275, 36);
            this.lbName2.TabIndex = 5;
            this.lbName2.Tag = "name";
            this.lbName2.Text = "Player 2";
            this.lbName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimer2
            // 
            this.lbTimer2.AutoSize = true;
            this.lbTimer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer2.Location = new System.Drawing.Point(190, 115);
            this.lbTimer2.Name = "lbTimer2";
            this.lbTimer2.Size = new System.Drawing.Size(124, 46);
            this.lbTimer2.TabIndex = 4;
            this.lbTimer2.Tag = "time";
            this.lbTimer2.Text = "00:00";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::CaroLAN.Properties.Resources.o;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(6, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 81);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.panelPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayer1.Controls.Add(this.lbScore1);
            this.panelPlayer1.Controls.Add(this.lbName1);
            this.panelPlayer1.Controls.Add(this.lbTimer1);
            this.panelPlayer1.Controls.Add(this.pictureBox1);
            this.panelPlayer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayer1.Location = new System.Drawing.Point(0, 261);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(327, 185);
            this.panelPlayer1.TabIndex = 1;
            // 
            // lbScore1
            // 
            this.lbScore1.AutoSize = true;
            this.lbScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore1.Location = new System.Drawing.Point(107, 59);
            this.lbScore1.Name = "lbScore1";
            this.lbScore1.Size = new System.Drawing.Size(147, 38);
            this.lbScore1.TabIndex = 4;
            this.lbScore1.Tag = "score";
            this.lbScore1.Text = "Score: 0";
            // 
            // lbName1
            // 
            this.lbName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName1.Location = new System.Drawing.Point(5, 11);
            this.lbName1.Name = "lbName1";
            this.lbName1.Size = new System.Drawing.Size(275, 36);
            this.lbName1.TabIndex = 3;
            this.lbName1.Tag = "name";
            this.lbName1.Text = "Player 1";
            this.lbName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimer1
            // 
            this.lbTimer1.AutoSize = true;
            this.lbTimer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer1.Location = new System.Drawing.Point(190, 118);
            this.lbTimer1.Name = "lbTimer1";
            this.lbTimer1.Size = new System.Drawing.Size(124, 46);
            this.lbTimer1.TabIndex = 2;
            this.lbTimer1.Tag = "time";
            this.lbTimer1.Text = "00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CaroLAN.Properties.Resources.x;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(6, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 81);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbTurn
            // 
            this.pbTurn.BackgroundImage = global::CaroLAN.Properties.Resources.x;
            this.pbTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTurn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbTurn.Location = new System.Drawing.Point(0, 0);
            this.pbTurn.Name = "pbTurn";
            this.pbTurn.Size = new System.Drawing.Size(327, 261);
            this.pbTurn.TabIndex = 0;
            this.pbTurn.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1380, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.changeFirstPlayerToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToMenuToolStripMenuItem,
            this.exitToDesktopToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // changeFirstPlayerToolStripMenuItem
            // 
            this.changeFirstPlayerToolStripMenuItem.Name = "changeFirstPlayerToolStripMenuItem";
            this.changeFirstPlayerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.changeFirstPlayerToolStripMenuItem.Text = "Change first player";
            this.changeFirstPlayerToolStripMenuItem.Click += new System.EventHandler(this.changeFirstPlayerToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToMenuToolStripMenuItem
            // 
            this.exitToMenuToolStripMenuItem.Name = "exitToMenuToolStripMenuItem";
            this.exitToMenuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToMenuToolStripMenuItem.Text = "Exit to menu";
            this.exitToMenuToolStripMenuItem.Click += new System.EventHandler(this.exitToMenuToolStripMenuItem_Click);
            // 
            // exitToDesktopToolStripMenuItem
            // 
            this.exitToDesktopToolStripMenuItem.Name = "exitToDesktopToolStripMenuItem";
            this.exitToDesktopToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToDesktopToolStripMenuItem.Text = "Exit to desktop";
            this.exitToDesktopToolStripMenuItem.Click += new System.EventHandler(this.exitToDesktopToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.howToPlayToolStripMenuItem.Text = "How to play";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelBoard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1380, 670);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbTurn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.Panel panelPlayer2;
        protected System.Windows.Forms.Panel panelPlayer1;
        protected System.Windows.Forms.Panel panelBoard;
        protected System.Windows.Forms.Label lbName2;
        protected System.Windows.Forms.Label lbTimer2;
        protected System.Windows.Forms.Label lbName1;
        protected System.Windows.Forms.Label lbTimer1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        protected System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.Label lbScore2;
        private System.Windows.Forms.Label lbScore1;
        protected System.Windows.Forms.ToolStripMenuItem changeFirstPlayerToolStripMenuItem;
    }
}

