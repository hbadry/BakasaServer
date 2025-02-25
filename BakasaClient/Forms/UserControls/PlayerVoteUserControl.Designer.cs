namespace BakasaClient.Forms.UserControls
{
    partial class PlayerVoteUserControl
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
            listControl = new SelectableListControl();
            btnUserSelected = new CustomComponents.CustomButton();
            SuspendLayout();
            // 
            // listControl
            // 
            listControl.Dock = DockStyle.Top;
            listControl.Location = new Point(0, 0);
            listControl.Name = "listControl";
            listControl.Padding = new Padding(5);
            listControl.Size = new Size(605, 285);
            listControl.TabIndex = 0;
            // 
            // btnUserSelected
            // 
            btnUserSelected.BackColor = Color.Transparent;
            btnUserSelected.Enabled = false;
            btnUserSelected.FlatAppearance.BorderSize = 0;
            btnUserSelected.FlatStyle = FlatStyle.Flat;
            btnUserSelected.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUserSelected.ForeColor = Color.White;
            btnUserSelected.Location = new Point(231, 266);
            btnUserSelected.Name = "btnUserSelected";
            btnUserSelected.Size = new Size(120, 40);
            btnUserSelected.TabIndex = 1;
            btnUserSelected.Text = "تم الاختيار";
            btnUserSelected.UseVisualStyleBackColor = false;
            btnUserSelected.Click += btnUserSelected_Click;
            // 
            // PlayerVoteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUserSelected);
            Controls.Add(listControl);
            Name = "PlayerVoteUserControl";
            Size = new Size(605, 361);
            Load += PlayerVoteUserControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private SelectableListControl listControl;
        private CustomComponents.CustomButton btnUserSelected;
    }
}
