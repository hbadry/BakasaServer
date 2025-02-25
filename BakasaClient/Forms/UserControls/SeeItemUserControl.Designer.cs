namespace BakasaClient.Forms.UserControls
{
    partial class SeeItemUserControl
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
            card = new FlipCard();
            customLabel1 = new CustomComponents.CustomLabel();
            btnReady = new CustomComponents.CustomButton();
            SuspendLayout();
            // 
            // card
            // 
            card.BackImage = null;
            card.BackText = "";
            card.FrontImage = null;
            card.Location = new Point(218, 37);
            card.Name = "card";
            card.Size = new Size(152, 176);
            card.TabIndex = 0;
            // 
            // customLabel1
            // 
            customLabel1.AutoSize = true;
            customLabel1.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            customLabel1.ForeColor = Color.Black;
            customLabel1.Location = new Point(144, 216);
            customLabel1.Name = "customLabel1";
            customLabel1.RightToLeft = RightToLeft.Yes;
            customLabel1.Size = new Size(310, 19);
            customLabel1.TabIndex = 2;
            customLabel1.Text = "يرجي الضغط علي الصورة لمعرفة الكلمة";
            customLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnReady
            // 
            btnReady.BackColor = Color.Transparent;
            btnReady.FlatAppearance.BorderSize = 0;
            btnReady.FlatStyle = FlatStyle.Flat;
            btnReady.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReady.ForeColor = Color.White;
            btnReady.Location = new Point(218, 260);
            btnReady.Name = "btnReady";
            btnReady.Size = new Size(120, 40);
            btnReady.TabIndex = 3;
            btnReady.Text = "جاهز";
            btnReady.UseVisualStyleBackColor = false;
            btnReady.Click += btnReady_Click;
            // 
            // SeeItemUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReady);
            Controls.Add(customLabel1);
            Controls.Add(card);
            Name = "SeeItemUserControl";
            Size = new Size(605, 361);
            Load += SeeItemUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlipCard card;
        private CustomComponents.CustomLabel customLabel1;
        private CustomComponents.CustomButton btnReady;
    }
}
