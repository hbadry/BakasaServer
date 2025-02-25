namespace BakasaClient.Forms.UserControls
{
    partial class BakesResultsControl
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
            pictureBox1 = new PictureBox();
            lblBakes = new CustomComponents.CustomLabel();
            btnSelectItem = new CustomComponents.CustomButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(605, 212);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblBakes
            // 
            lblBakes.AutoSize = true;
            lblBakes.Font = new Font("Segoe Script", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBakes.ForeColor = Color.Red;
            lblBakes.Location = new Point(223, 215);
            lblBakes.Name = "lblBakes";
            lblBakes.RightToLeft = RightToLeft.Yes;
            lblBakes.Size = new Size(116, 27);
            lblBakes.TabIndex = 1;
            lblBakes.Text = "البكس هو فلان";
            lblBakes.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSelectItem
            // 
            btnSelectItem.BackColor = Color.Transparent;
            btnSelectItem.Enabled = false;
            btnSelectItem.FlatAppearance.BorderSize = 0;
            btnSelectItem.FlatStyle = FlatStyle.Flat;
            btnSelectItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSelectItem.ForeColor = Color.White;
            btnSelectItem.Location = new Point(223, 265);
            btnSelectItem.Name = "btnSelectItem";
            btnSelectItem.Size = new Size(147, 40);
            btnSelectItem.TabIndex = 2;
            btnSelectItem.Text = "اختار الحاجه المتوقعة";
            btnSelectItem.UseVisualStyleBackColor = false;
            btnSelectItem.Click += btnSelectItem_Click_1;
            // 
            // BakesResultsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSelectItem);
            Controls.Add(lblBakes);
            Controls.Add(pictureBox1);
            Name = "BakesResultsControl";
            Size = new Size(605, 361);
            Load += BakesResultsControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CustomComponents.CustomLabel lblBakes;
        private CustomComponents.CustomButton btnSelectItem;
    }
}
