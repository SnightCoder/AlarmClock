namespace bunifutest
{
    partial class HenGioUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HenGioUI));
            this.MinText = new System.Windows.Forms.NumericUpDown();
            this.HouText = new System.Windows.Forms.NumericUpDown();
            this.SecText = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.DuyetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Upbtn = new System.Windows.Forms.Button();
            this.Downbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DungBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MinText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HouText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecText)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinText
            // 
            this.MinText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(210)))), ((int)(((byte)(202)))));
            this.MinText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.MinText.Location = new System.Drawing.Point(135, 16);
            this.MinText.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MinText.Name = "MinText";
            this.MinText.Size = new System.Drawing.Size(92, 52);
            this.MinText.TabIndex = 0;
            this.MinText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HouText_KeyDown);
            // 
            // HouText
            // 
            this.HouText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(210)))), ((int)(((byte)(202)))));
            this.HouText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HouText.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.HouText.Location = new System.Drawing.Point(17, 16);
            this.HouText.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.HouText.Name = "HouText";
            this.HouText.Size = new System.Drawing.Size(92, 52);
            this.HouText.TabIndex = 0;
            this.HouText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HouText_KeyDown);
            // 
            // SecText
            // 
            this.SecText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(210)))), ((int)(((byte)(202)))));
            this.SecText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SecText.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.SecText.Location = new System.Drawing.Point(250, 16);
            this.SecText.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SecText.Name = "SecText";
            this.SecText.Size = new System.Drawing.Size(92, 52);
            this.SecText.TabIndex = 0;
            this.SecText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HouText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 62.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(236)))));
            this.label1.Location = new System.Drawing.Point(58, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 95);
            this.label1.TabIndex = 1;
            this.label1.Text = "00:00:00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(47)))), ((int)(((byte)(172)))), ((int)(((byte)(185)))));
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.DuyetButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.Upbtn);
            this.panel1.Controls.Add(this.Downbtn);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.HouText);
            this.panel1.Controls.Add(this.MinText);
            this.panel1.Controls.Add(this.SecText);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.panel1.Location = new System.Drawing.Point(59, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 131);
            this.panel1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Alarm",
            "Bells",
            "Cuckoo",
            "Flute",
            "MusicBox",
            "RengReng1",
            "RengReng2",
            "Không âm thanh"});
            this.comboBox1.Location = new System.Drawing.Point(103, 217);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(239, 21);
            this.comboBox1.TabIndex = 44;
            this.comboBox1.Text = "MusicBox";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ChuongBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label3.Location = new System.Drawing.Point(14, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhạc chuông";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.button6.Location = new System.Drawing.Point(221, 132);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 24);
            this.button6.TabIndex = 1;
            this.button6.Text = "Lấy thời gian hiện tại";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.GetNow_Click);
            // 
            // DuyetButton
            // 
            this.DuyetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.DuyetButton.FlatAppearance.BorderSize = 0;
            this.DuyetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DuyetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DuyetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.DuyetButton.Location = new System.Drawing.Point(17, 240);
            this.DuyetButton.Name = "DuyetButton";
            this.DuyetButton.Size = new System.Drawing.Size(325, 31);
            this.DuyetButton.TabIndex = 6;
            this.DuyetButton.Text = "Chọn nhạc chuông";
            this.DuyetButton.UseVisualStyleBackColor = false;
            this.DuyetButton.Click += new System.EventHandler(this.DuyetButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(14, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lời nhắc: ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(210)))), ((int)(((byte)(202)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(17, 156);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 59);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Hết giờ";
            // 
            // Upbtn
            // 
            this.Upbtn.BackColor = System.Drawing.Color.Transparent;
            this.Upbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Upbtn.BackgroundImage")));
            this.Upbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Upbtn.FlatAppearance.BorderSize = 0;
            this.Upbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Upbtn.Location = new System.Drawing.Point(15, 111);
            this.Upbtn.Name = "Upbtn";
            this.Upbtn.Size = new System.Drawing.Size(23, 23);
            this.Upbtn.TabIndex = 1;
            this.Upbtn.UseVisualStyleBackColor = false;
            this.Upbtn.Visible = false;
            this.Upbtn.Click += new System.EventHandler(this.Upbtn_Click);
            // 
            // Downbtn
            // 
            this.Downbtn.BackColor = System.Drawing.Color.Transparent;
            this.Downbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Downbtn.BackgroundImage")));
            this.Downbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Downbtn.FlatAppearance.BorderSize = 0;
            this.Downbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Downbtn.Location = new System.Drawing.Point(15, 111);
            this.Downbtn.Name = "Downbtn";
            this.Downbtn.Size = new System.Drawing.Size(23, 23);
            this.Downbtn.TabIndex = 1;
            this.Downbtn.UseVisualStyleBackColor = false;
            this.Downbtn.Click += new System.EventHandler(this.Downbtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.button2.Location = new System.Drawing.Point(181, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Reset1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.button1.Location = new System.Drawing.Point(17, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bắt Đầu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(0, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 63);
            this.panel3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chạy các  App sau khi hết thời gian";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.button5.Location = new System.Drawing.Point(17, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Nhấp để chọn";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.StatApp1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.button3.Location = new System.Drawing.Point(271, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Xoá hết";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.StatApp3);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.button4.Location = new System.Drawing.Point(144, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Nhấp để chọn";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.StatApp2);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(89)))), ((int)(((byte)(161)))));
            this.panel2.Location = new System.Drawing.Point(0, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 3643);
            this.panel2.TabIndex = 3;
            // 
            // DungBtn
            // 
            this.DungBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(2)))), ((int)(((byte)(68)))), ((int)(((byte)(88)))));
            this.DungBtn.FlatAppearance.BorderSize = 0;
            this.DungBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DungBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.DungBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.DungBtn.Location = new System.Drawing.Point(314, 193);
            this.DungBtn.Name = "DungBtn";
            this.DungBtn.Size = new System.Drawing.Size(75, 32);
            this.DungBtn.TabIndex = 1;
            this.DungBtn.Text = "Dừng";
            this.DungBtn.UseVisualStyleBackColor = false;
            this.DungBtn.Visible = false;
            this.DungBtn.Click += new System.EventHandler(this.Dungbtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(118, 134);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 20);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "Lặp chuông";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // HenGioUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(82)))), ((int)(((byte)(157)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DungBtn);
            this.Name = "HenGioUI";
            this.Size = new System.Drawing.Size(480, 4000);
            ((System.ComponentModel.ISupportInitialize)(this.MinText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HouText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecText)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MinText;
        private System.Windows.Forms.NumericUpDown HouText;
        private System.Windows.Forms.NumericUpDown SecText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Upbtn;
        private System.Windows.Forms.Button Downbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DuyetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button DungBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}
