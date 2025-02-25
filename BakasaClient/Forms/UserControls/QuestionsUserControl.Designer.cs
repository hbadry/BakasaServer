namespace BakasaClient.Forms.UserControls
{
    partial class QuestionsUserControl
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
            lblText = new CustomComponents.CustomLabel();
            btnIAsked = new CustomComponents.CustomButton();
            btnReadyToVote = new CustomComponents.CustomButton();
            customLabel1 = new CustomComponents.CustomLabel();
            customLabel2 = new CustomComponents.CustomLabel();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe Script", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.IndianRed;
            lblText.Location = new Point(202, 162);
            lblText.Name = "lblText";
            lblText.RightToLeft = RightToLeft.Yes;
            lblText.Size = new Size(186, 27);
            lblText.TabIndex = 0;
            lblText.Text = "سيقوم محمد بسوال احمد";
            lblText.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnIAsked
            // 
            btnIAsked.BackColor = Color.Transparent;
            btnIAsked.Enabled = false;
            btnIAsked.FlatAppearance.BorderSize = 0;
            btnIAsked.FlatStyle = FlatStyle.Flat;
            btnIAsked.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIAsked.ForeColor = Color.White;
            btnIAsked.Location = new Point(373, 258);
            btnIAsked.Name = "btnIAsked";
            btnIAsked.Size = new Size(120, 40);
            btnIAsked.TabIndex = 1;
            btnIAsked.Text = "تم السوال";
            btnIAsked.UseVisualStyleBackColor = false;
            btnIAsked.Click += btnIAsked_Click;
            // 
            // btnReadyToVote
            // 
            btnReadyToVote.BackColor = Color.Transparent;
            btnReadyToVote.FlatAppearance.BorderSize = 0;
            btnReadyToVote.FlatStyle = FlatStyle.Flat;
            btnReadyToVote.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReadyToVote.ForeColor = Color.White;
            btnReadyToVote.Location = new Point(86, 258);
            btnReadyToVote.Name = "btnReadyToVote";
            btnReadyToVote.Size = new Size(120, 40);
            btnReadyToVote.TabIndex = 2;
            btnReadyToVote.Text = "جاهز للتصويت";
            btnReadyToVote.UseVisualStyleBackColor = false;
            btnReadyToVote.Click += btnReadyToVote_Click;
            // 
            // customLabel1
            // 
            customLabel1.AutoSize = true;
            customLabel1.Font = new Font("Segoe Script", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            customLabel1.ForeColor = Color.IndianRed;
            customLabel1.Location = new Point(86, 68);
            customLabel1.Name = "customLabel1";
            customLabel1.RightToLeft = RightToLeft.Yes;
            customLabel1.Size = new Size(427, 27);
            customLabel1.TabIndex = 4;
            customLabel1.Text = "في هذه المرحلة سيقوم كل لعيب بسوال اللعيب الاخر سوال";
            customLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // customLabel2
            // 
            customLabel2.AutoSize = true;
            customLabel2.Font = new Font("Segoe Script", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            customLabel2.ForeColor = Color.IndianRed;
            customLabel2.Location = new Point(86, 112);
            customLabel2.Name = "customLabel2";
            customLabel2.RightToLeft = RightToLeft.Yes;
            customLabel2.Size = new Size(443, 27);
            customLabel2.TabIndex = 5;
            customLabel2.Text = "اذا كنت جاهزا للتصويت برجاء الضغط علي جاهز للتصويت";
            customLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // QuestionsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(customLabel2);
            Controls.Add(customLabel1);
            Controls.Add(btnReadyToVote);
            Controls.Add(btnIAsked);
            Controls.Add(lblText);
            Name = "QuestionsUserControl";
            Size = new Size(605, 361);
            Load += QuestionsUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomComponents.CustomLabel lblText;
        private CustomComponents.CustomButton btnIAsked;
        private CustomComponents.CustomButton btnReadyToVote;
        private CustomComponents.CustomLabel customLabel1;
        private CustomComponents.CustomLabel customLabel2;
    }
}
