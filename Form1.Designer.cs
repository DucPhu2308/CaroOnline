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
            this.components = new System.ComponentModel.Container();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.txtPlayerName2 = new System.Windows.Forms.Label();
            this.txtTimer2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.txtPlayerName1 = new System.Windows.Forms.Label();
            this.txtTimer1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbTurn = new System.Windows.Forms.PictureBox();
            this.timerPlayer1 = new System.Windows.Forms.Timer(this.components);
            this.timerPlayer2 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBoard.Location = new System.Drawing.Point(0, 0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(1087, 747);
            this.panelBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelPlayer2);
            this.panel2.Controls.Add(this.panelPlayer1);
            this.panel2.Controls.Add(this.pbTurn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1087, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 747);
            this.panel2.TabIndex = 1;
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayer2.Controls.Add(this.txtPlayerName2);
            this.panelPlayer2.Controls.Add(this.txtTimer2);
            this.panelPlayer2.Controls.Add(this.pictureBox2);
            this.panelPlayer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayer2.Location = new System.Drawing.Point(0, 472);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(293, 181);
            this.panelPlayer2.TabIndex = 2;
            // 
            // txtPlayerName2
            // 
            this.txtPlayerName2.AutoSize = true;
            this.txtPlayerName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPlayerName2.Location = new System.Drawing.Point(79, 8);
            this.txtPlayerName2.Name = "txtPlayerName2";
            this.txtPlayerName2.Size = new System.Drawing.Size(124, 36);
            this.txtPlayerName2.TabIndex = 5;
            this.txtPlayerName2.Text = "Player 2";
            // 
            // txtTimer2
            // 
            this.txtTimer2.AutoSize = true;
            this.txtTimer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimer2.Location = new System.Drawing.Point(129, 68);
            this.txtTimer2.Name = "txtTimer2";
            this.txtTimer2.Size = new System.Drawing.Size(124, 46);
            this.txtTimer2.TabIndex = 4;
            this.txtTimer2.Text = "00:00";
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
            this.panelPlayer1.Controls.Add(this.txtPlayerName1);
            this.panelPlayer1.Controls.Add(this.txtTimer1);
            this.panelPlayer1.Controls.Add(this.pictureBox1);
            this.panelPlayer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayer1.Location = new System.Drawing.Point(0, 287);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(293, 185);
            this.panelPlayer1.TabIndex = 1;
            // 
            // txtPlayerName1
            // 
            this.txtPlayerName1.AutoSize = true;
            this.txtPlayerName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPlayerName1.Location = new System.Drawing.Point(79, 11);
            this.txtPlayerName1.Name = "txtPlayerName1";
            this.txtPlayerName1.Size = new System.Drawing.Size(124, 36);
            this.txtPlayerName1.TabIndex = 3;
            this.txtPlayerName1.Text = "Player 1";
            // 
            // txtTimer1
            // 
            this.txtTimer1.AutoSize = true;
            this.txtTimer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimer1.Location = new System.Drawing.Point(129, 71);
            this.txtTimer1.Name = "txtTimer1";
            this.txtTimer1.Size = new System.Drawing.Size(124, 46);
            this.txtTimer1.TabIndex = 2;
            this.txtTimer1.Text = "00:00";
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
            this.pbTurn.Size = new System.Drawing.Size(293, 287);
            this.pbTurn.TabIndex = 0;
            this.pbTurn.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 747);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbTurn;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtPlayerName2;
        private System.Windows.Forms.Label txtTimer2;
        private System.Windows.Forms.Label txtPlayerName1;
        private System.Windows.Forms.Label txtTimer1;
        private System.Windows.Forms.Timer timerPlayer1;
        private System.Windows.Forms.Timer timerPlayer2;
    }
}

