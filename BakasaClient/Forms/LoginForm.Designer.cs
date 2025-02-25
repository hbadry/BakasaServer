namespace BakasaClient
{
    partial class LoginForm
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
            txtIP = new TextBox();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnConnect = new Button();
            pbStatus = new PictureBox();
            btnPaste = new Button();
            ((System.ComponentModel.ISupportInitialize)pbStatus).BeginInit();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.Location = new Point(137, 75);
            txtIP.Name = "txtIP";
            txtIP.RightToLeft = RightToLeft.Yes;
            txtIP.Size = new Size(474, 23);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.1.1.1";
            // 
            // txtName
            // 
            txtName.Location = new Point(137, 25);
            txtName.Name = "txtName";
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.Size = new Size(474, 23);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(647, 28);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "الاسم";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(632, 78);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 3;
            label2.Text = "سيرفر IP";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(329, 114);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(99, 35);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "الاتصال";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // pbStatus
            // 
            pbStatus.Location = new Point(370, 164);
            pbStatus.Name = "pbStatus";
            pbStatus.Size = new Size(20, 20);
            pbStatus.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStatus.TabIndex = 4;
            pbStatus.TabStop = false;
            pbStatus.Paint += pbStatus_Paint;
            // 
            // btnPaste
            // 
            btnPaste.Location = new Point(12, 68);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(99, 35);
            btnPaste.TabIndex = 5;
            btnPaste.Text = "لصق";
            btnPaste.UseVisualStyleBackColor = true;
            btnPaste.Click += btnPaste_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnConnect;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 196);
            Controls.Add(btnPaste);
            Controls.Add(pbStatus);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(txtIP);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "بكاسة";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIP;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private Button btnConnect;
        private PictureBox pbStatus;
        private Button btnPaste;
    }
}
