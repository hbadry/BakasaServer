namespace BakasaClient.Forms.UserControls
{
    partial class WelcomeUserControl
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
            lbWelcome = new CustomComponents.CustomLabel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbWelcome
            // 
            lbWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbWelcome.AutoSize = true;
            lbWelcome.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lbWelcome.ForeColor = Color.Black;
            lbWelcome.Location = new Point(225, 63);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.RightToLeft = RightToLeft.Yes;
            lbWelcome.Size = new Size(99, 19);
            lbWelcome.TabIndex = 2;
            lbWelcome.Text = "مرحبا حسن";
            lbWelcome.TextAlign = ContentAlignment.TopRight;
            lbWelcome.Click += lbWelcome_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbWelcome);
            panel1.Location = new Point(58, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 248);
            panel1.TabIndex = 4;
            // 
            // WelcomeUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "WelcomeUserControl";
            Size = new Size(642, 405);
            Load += WelcomeUserControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomComponents.CustomLabel lbWelcome;
        private Panel panel1;
    }
}
