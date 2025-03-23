namespace idsp2025_jared_green.Forms
{
    partial class frmConfirmUserDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmUserDelete));
            btnConfirmUserDelete = new Button();
            btnCancelUserDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            picAlertIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picAlertIcon).BeginInit();
            SuspendLayout();
            // 
            // btnConfirmUserDelete
            // 
            btnConfirmUserDelete.Location = new Point(376, 323);
            btnConfirmUserDelete.Name = "btnConfirmUserDelete";
            btnConfirmUserDelete.Size = new Size(112, 34);
            btnConfirmUserDelete.TabIndex = 1;
            btnConfirmUserDelete.Text = "Confirm";
            btnConfirmUserDelete.UseVisualStyleBackColor = true;
            btnConfirmUserDelete.Click += btnConfirmUserDelete_Click;
            // 
            // btnCancelUserDelete
            // 
            btnCancelUserDelete.Location = new Point(167, 323);
            btnCancelUserDelete.Name = "btnCancelUserDelete";
            btnCancelUserDelete.Size = new Size(112, 34);
            btnCancelUserDelete.TabIndex = 0;
            btnCancelUserDelete.Text = "Exit";
            btnCancelUserDelete.UseVisualStyleBackColor = true;
            btnCancelUserDelete.Click += btnCancelUserDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(64, 32);
            label1.Name = "label1";
            label1.Size = new Size(546, 65);
            label1.TabIndex = 2;
            label1.Text = "Set Employee Inactive?";
            // 
            // label2
            // 
            label2.Location = new Point(113, 169);
            label2.Name = "label2";
            label2.Size = new Size(436, 123);
            label2.TabIndex = 3;
            label2.Text = "You have chosen to set this employee as inactive. They will not be able to log in or access their account.\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(211, 267);
            label3.Name = "label3";
            label3.Size = new Size(221, 25);
            label3.TabIndex = 4;
            label3.Text = "Do you wish to proceed?";
            // 
            // picAlertIcon
            // 
            picAlertIcon.Image = Properties.Resources.AlertIcon;
            picAlertIcon.Location = new Point(248, 113);
            picAlertIcon.Name = "picAlertIcon";
            picAlertIcon.Size = new Size(150, 75);
            picAlertIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picAlertIcon.TabIndex = 5;
            picAlertIcon.TabStop = false;
            // 
            // frmConfirmUserDelete
            // 
            AcceptButton = btnConfirmUserDelete;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelUserDelete;
            ClientSize = new Size(658, 394);
            Controls.Add(picAlertIcon);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelUserDelete);
            Controls.Add(btnConfirmUserDelete);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfirmUserDelete";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Confirm User Inactive";
            HelpRequested += frmConfirmUserDelete_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)picAlertIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirmUserDelete;
        private Button btnCancelUserDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox picAlertIcon;
    }
}