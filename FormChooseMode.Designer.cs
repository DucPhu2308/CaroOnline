namespace CaroLAN
{
    partial class FormChooseMode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.txtPlayerName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocalPlay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPlayerName);
            this.panel1.Controls.Add(this.labelPlayerName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 715);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(499, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 52);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnLocalPlay);
            this.panel3.Controls.Add(this.txtPlayerName2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(499, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(809, 223);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(499, 275);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(809, 250);
            this.panel4.TabIndex = 3;
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelPlayerName.Location = new System.Drawing.Point(12, 239);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(258, 36);
            this.labelPlayerName.TabIndex = 4;
            this.labelPlayerName.Text = "Nhập tên của bạn:";
            this.labelPlayerName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPlayerName.Location = new System.Drawing.Point(12, 294);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(474, 41);
            this.txtPlayerName.TabIndex = 5;
            this.txtPlayerName.Leave += new System.EventHandler(this.txtPlayerName_Leave);
            // 
            // txtPlayerName2
            // 
            this.txtPlayerName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPlayerName2.Location = new System.Drawing.Point(23, 156);
            this.txtPlayerName2.Name = "txtPlayerName2";
            this.txtPlayerName2.Size = new System.Drawing.Size(474, 41);
            this.txtPlayerName2.TabIndex = 7;
            this.txtPlayerName2.Leave += new System.EventHandler(this.txtPlayerName2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(23, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nhập tên của người chơi 2:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLocalPlay
            // 
            this.btnLocalPlay.BackColor = System.Drawing.Color.Wheat;
            this.btnLocalPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocalPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLocalPlay.FlatAppearance.BorderSize = 3;
            this.btnLocalPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalPlay.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnLocalPlay.ForeColor = System.Drawing.Color.Brown;
            this.btnLocalPlay.Location = new System.Drawing.Point(547, 147);
            this.btnLocalPlay.Name = "btnLocalPlay";
            this.btnLocalPlay.Size = new System.Drawing.Size(250, 56);
            this.btnLocalPlay.TabIndex = 8;
            this.btnLocalPlay.Text = "Bắt đầu";
            this.btnLocalPlay.UseVisualStyleBackColor = false;
            this.btnLocalPlay.Click += new System.EventHandler(this.btnLocalPlay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chọn chế độ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chơi cùng máy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormChooseMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 715);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormChooseMode";
            this.Text = "FormChooseMode";
            this.Load += new System.EventHandler(this.FormChooseMode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.TextBox txtPlayerName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLocalPlay;
    }
}