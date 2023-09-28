namespace CaroLAN
{
    partial class FormOption
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
            this.label1 = new System.Windows.Forms.Label();
            this.numMinute = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numSecond = new System.Windows.Forms.NumericUpDown();
            this.trackSFX = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBGM = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSFX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBGM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(27, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thời gian mỗi bên:";
            // 
            // numMinute
            // 
            this.numMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.numMinute.Location = new System.Drawing.Point(368, 148);
            this.numMinute.Name = "numMinute";
            this.numMinute.Size = new System.Drawing.Size(103, 45);
            this.numMinute.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.label2.Location = new System.Drawing.Point(478, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "phút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.label3.Location = new System.Drawing.Point(675, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 38);
            this.label3.TabIndex = 5;
            this.label3.Text = "giây";
            // 
            // numSecond
            // 
            this.numSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.numSecond.Location = new System.Drawing.Point(565, 148);
            this.numSecond.Name = "numSecond";
            this.numSecond.Size = new System.Drawing.Size(103, 45);
            this.numSecond.TabIndex = 4;
            // 
            // trackSFX
            // 
            this.trackSFX.Location = new System.Drawing.Point(368, 241);
            this.trackSFX.Maximum = 100;
            this.trackSFX.Name = "trackSFX";
            this.trackSFX.Size = new System.Drawing.Size(384, 56);
            this.trackSFX.TabIndex = 6;
            this.trackSFX.Scroll += new System.EventHandler(this.trackSFX_Scroll);
            this.trackSFX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackSFX_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(253, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 38);
            this.label4.TabIndex = 7;
            this.label4.Text = "SFX:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(242, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 38);
            this.label5.TabIndex = 9;
            this.label5.Text = "BGM:";
            // 
            // trackBGM
            // 
            this.trackBGM.Location = new System.Drawing.Point(368, 314);
            this.trackBGM.Maximum = 100;
            this.trackBGM.Name = "trackBGM";
            this.trackBGM.Size = new System.Drawing.Size(384, 56);
            this.trackBGM.TabIndex = 8;
            this.trackBGM.Scroll += new System.EventHandler(this.trackBGM_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(329, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 38);
            this.label6.TabIndex = 10;
            this.label6.Text = "TÙY CHỌN";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Wheat;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.BorderSize = 3;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnSave.ForeColor = System.Drawing.Color.Brown;
            this.btnSave.Location = new System.Drawing.Point(470, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(253, 56);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu và thoát";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Wheat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatAppearance.BorderSize = 3;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnCancel.ForeColor = System.Drawing.Color.Brown;
            this.btnCancel.Location = new System.Drawing.Point(136, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(253, 56);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 488);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBGM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackSFX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numMinute);
            this.Controls.Add(this.label1);
            this.Name = "FormOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tùy chọn";
            this.Load += new System.EventHandler(this.FormOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSFX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBGM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMinute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSecond;
        private System.Windows.Forms.TrackBar trackSFX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBGM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}