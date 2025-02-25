namespace BakasaClient.Forms
{
    partial class MainForm
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
            panelContainer = new Panel();
            btnShowScore = new CustomComponents.CustomButton();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Top;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(589, 322);
            panelContainer.TabIndex = 0;
            // 
            // btnShowScore
            // 
            btnShowScore.BackColor = Color.Transparent;
            btnShowScore.FlatAppearance.BorderSize = 0;
            btnShowScore.FlatStyle = FlatStyle.Flat;
            btnShowScore.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnShowScore.ForeColor = Color.White;
            btnShowScore.Location = new Point(457, 330);
            btnShowScore.Name = "btnShowScore";
            btnShowScore.Size = new Size(120, 40);
            btnShowScore.TabIndex = 1;
            btnShowScore.Text = "إظهار السكور";
            btnShowScore.UseVisualStyleBackColor = false;
            btnShowScore.Click += btnShowScore_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 382);
            Controls.Add(btnShowScore);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "بكاسة";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
        private CustomComponents.CustomButton btnShowScore;
    }
}