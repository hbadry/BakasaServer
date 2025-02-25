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
            SuspendLayout();
            // 
            // lbWelcome
            // 
            lbWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbWelcome.AutoSize = true;
            lbWelcome.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lbWelcome.ForeColor = Color.Black;
            lbWelcome.Location = new Point(267, 156);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.RightToLeft = RightToLeft.Yes;
            lbWelcome.Size = new Size(99, 19);
            lbWelcome.TabIndex = 2;
            lbWelcome.Text = "مرحبا حسن";
            lbWelcome.TextAlign = ContentAlignment.TopRight;
            lbWelcome.Click += lbWelcome_Click;
            // 
            // WelcomeUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbWelcome);
            Name = "WelcomeUserControl";
            Size = new Size(642, 405);
            Load += WelcomeUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomComponents.CustomLabel lbWelcome;
    }
}
