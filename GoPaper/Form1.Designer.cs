namespace GoPaper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            txtinputfile = new TextBox();
            btnbrowseSend = new Button();
            label1 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            radfile = new RadioButton();
            radtext = new RadioButton();
            btnsend = new Button();
            txtInputtext = new TextBox();
            label5 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            btnscan = new Button();
            groupBox2 = new GroupBox();
            radfilerecieve = new RadioButton();
            radscanrecieve = new RadioButton();
            txtinputfilerecieve = new TextBox();
            btnbrowserecieve = new Button();
            label4 = new Label();
            btnsave = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(13, 230);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(420, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtinputfile
            // 
            txtinputfile.Location = new Point(66, 141);
            txtinputfile.Name = "txtinputfile";
            txtinputfile.ReadOnly = true;
            txtinputfile.Size = new Size(383, 23);
            txtinputfile.TabIndex = 2;
            // 
            // btnbrowseSend
            // 
            btnbrowseSend.Location = new Point(16, 141);
            btnbrowseSend.Name = "btnbrowseSend";
            btnbrowseSend.Size = new Size(44, 23);
            btnbrowseSend.TabIndex = 3;
            btnbrowseSend.Text = "...";
            btnbrowseSend.UseVisualStyleBackColor = true;
            btnbrowseSend.Click += btnbrowseSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(387, 121);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "إختر الملف:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.OldLace;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnsend);
            panel1.Controls.Add(txtInputtext);
            panel1.Controls.Add(txtinputfile);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnbrowseSend);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(463, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 573);
            panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radfile);
            groupBox1.Controls.Add(radtext);
            groupBox1.Location = new Point(16, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.Yes;
            groupBox1.Size = new Size(433, 57);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "نوع الرسالة";
            // 
            // radfile
            // 
            radfile.AutoSize = true;
            radfile.Checked = true;
            radfile.Location = new Point(371, 26);
            radfile.Name = "radfile";
            radfile.RightToLeft = RightToLeft.Yes;
            radfile.Size = new Size(48, 19);
            radfile.TabIndex = 6;
            radfile.TabStop = true;
            radfile.Text = "ملف";
            radfile.UseVisualStyleBackColor = true;
            radfile.CheckedChanged += radfile_CheckedChanged;
            // 
            // radtext
            // 
            radtext.AutoSize = true;
            radtext.Location = new Point(306, 26);
            radtext.Name = "radtext";
            radtext.RightToLeft = RightToLeft.Yes;
            radtext.Size = new Size(45, 19);
            radtext.TabIndex = 8;
            radtext.Text = "نص";
            radtext.UseVisualStyleBackColor = true;
            radtext.CheckedChanged += radfile_CheckedChanged;
            // 
            // btnsend
            // 
            btnsend.Location = new Point(16, 517);
            btnsend.Name = "btnsend";
            btnsend.Size = new Size(433, 41);
            btnsend.TabIndex = 11;
            btnsend.Text = "إرسال";
            btnsend.UseVisualStyleBackColor = true;
            btnsend.Click += btnsend_Click;
            // 
            // txtInputtext
            // 
            txtInputtext.Enabled = false;
            txtInputtext.Location = new Point(16, 190);
            txtInputtext.Multiline = true;
            txtInputtext.Name = "txtInputtext";
            txtInputtext.RightToLeft = RightToLeft.Yes;
            txtInputtext.Size = new Size(433, 321);
            txtInputtext.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(412, 169);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(37, 15);
            label5.TabIndex = 9;
            label5.Text = "النص:";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(224, 224, 224);
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(462, 40);
            label2.TabIndex = 5;
            label2.Text = "إرسال";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BackColor = Color.GhostWhite;
            panel2.Controls.Add(btnscan);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(txtinputfilerecieve);
            panel2.Controls.Add(btnbrowserecieve);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnsave);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(445, 573);
            panel2.TabIndex = 6;
            // 
            // btnscan
            // 
            btnscan.Enabled = false;
            btnscan.Location = new Point(13, 171);
            btnscan.Name = "btnscan";
            btnscan.Size = new Size(420, 48);
            btnscan.TabIndex = 17;
            btnscan.Text = "مسح";
            btnscan.UseVisualStyleBackColor = true;
            btnscan.Click += btnscan_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radfilerecieve);
            groupBox2.Controls.Add(radscanrecieve);
            groupBox2.Location = new Point(13, 55);
            groupBox2.Name = "groupBox2";
            groupBox2.RightToLeft = RightToLeft.Yes;
            groupBox2.Size = new Size(420, 57);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "نوع الرسالة";
            // 
            // radfilerecieve
            // 
            radfilerecieve.AutoSize = true;
            radfilerecieve.Checked = true;
            radfilerecieve.Location = new Point(348, 26);
            radfilerecieve.Name = "radfilerecieve";
            radfilerecieve.RightToLeft = RightToLeft.Yes;
            radfilerecieve.Size = new Size(48, 19);
            radfilerecieve.TabIndex = 6;
            radfilerecieve.TabStop = true;
            radfilerecieve.Text = "ملف";
            radfilerecieve.UseVisualStyleBackColor = true;
            radfilerecieve.CheckedChanged += radfilerecieve_CheckedChanged;
            // 
            // radscanrecieve
            // 
            radscanrecieve.AutoSize = true;
            radscanrecieve.Location = new Point(283, 26);
            radscanrecieve.Name = "radscanrecieve";
            radscanrecieve.RightToLeft = RightToLeft.Yes;
            radscanrecieve.Size = new Size(49, 19);
            radscanrecieve.TabIndex = 8;
            radscanrecieve.Text = "مسح";
            radscanrecieve.UseVisualStyleBackColor = true;
            radscanrecieve.CheckedChanged += radfilerecieve_CheckedChanged;
            // 
            // txtinputfilerecieve
            // 
            txtinputfilerecieve.Location = new Point(63, 142);
            txtinputfilerecieve.Name = "txtinputfilerecieve";
            txtinputfilerecieve.ReadOnly = true;
            txtinputfilerecieve.Size = new Size(370, 23);
            txtinputfilerecieve.TabIndex = 13;
            // 
            // btnbrowserecieve
            // 
            btnbrowserecieve.Location = new Point(13, 142);
            btnbrowserecieve.Name = "btnbrowserecieve";
            btnbrowserecieve.Size = new Size(44, 23);
            btnbrowserecieve.TabIndex = 14;
            btnbrowserecieve.Text = "...";
            btnbrowserecieve.UseVisualStyleBackColor = true;
            btnbrowserecieve.Click += btnbrowserecieve_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(371, 122);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(62, 15);
            label4.TabIndex = 15;
            label4.Text = "إختر الملف:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnsave
            // 
            btnsave.Location = new Point(13, 517);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(420, 41);
            btnsave.TabIndex = 12;
            btnsave.Text = "حفظ";
            btnsave.UseVisualStyleBackColor = true;
            btnsave.Click += btnsave_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(224, 224, 224);
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(445, 40);
            label3.TabIndex = 6;
            label3.Text = "إستقبال";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 597);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "GoPaper";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtinputfile;
        private Button btnbrowseSend;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private TextBox txtInputtext;
        private Label label5;
        private RadioButton radtext;
        private RadioButton radfile;
        private GroupBox groupBox1;
        private Button btnsend;
        private TextBox txtinputfilerecieve;
        private Button btnbrowserecieve;
        private Label label4;
        private Button btnsave;
        private GroupBox groupBox2;
        private RadioButton radfilerecieve;
        private RadioButton radscanrecieve;
        private Button btnscan;
    }
}