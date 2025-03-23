namespace idsp2025_jared_green.Forms
{
    partial class frmResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResetPassword));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblUsername = new Label();
            btnResetPassword = new Button();
            btnExitPasswordReset = new Button();
            lblResetPasswordInfo = new Label();
            label5 = new Label();
            picResetPasswordFormLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picResetPasswordFormLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(176, 27);
            label1.Name = "label1";
            label1.Size = new Size(352, 65);
            label1.TabIndex = 0;
            label1.Text = "Reset Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 131);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 265);
            label3.Name = "label3";
            label3.Size = new Size(131, 25);
            label3.TabIndex = 2;
            label3.Text = "New Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 320);
            label4.Name = "label4";
            label4.Size = new Size(160, 25);
            label4.TabIndex = 3;
            label4.Text = "Confirm Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(216, 262);
            txtNewPassword.MaxLength = 255;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.PlaceholderText = "sUper$3cret";
            txtNewPassword.Size = new Size(378, 31);
            txtNewPassword.TabIndex = 0;
            txtNewPassword.MouseLeave += txtNewPassword_MouseLeave;
            txtNewPassword.MouseHover += txtNewPassword_MouseHover;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(216, 314);
            txtConfirmPassword.MaxLength = 255;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.PlaceholderText = "sUper$3cret";
            txtConfirmPassword.Size = new Size(378, 31);
            txtConfirmPassword.TabIndex = 1;
            txtConfirmPassword.MouseLeave += txtConfirmPassword_MouseLeave;
            txtConfirmPassword.MouseHover += txtConfirmPassword_MouseHover;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(144, 125);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(434, 38);
            lblUsername.TabIndex = 7;
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(450, 466);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(144, 34);
            btnResetPassword.TabIndex = 3;
            btnResetPassword.Text = "&Reset Password";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnExitPasswordReset
            // 
            btnExitPasswordReset.Location = new Point(318, 466);
            btnExitPasswordReset.Name = "btnExitPasswordReset";
            btnExitPasswordReset.Size = new Size(112, 34);
            btnExitPasswordReset.TabIndex = 2;
            btnExitPasswordReset.Text = "&Exit";
            btnExitPasswordReset.UseVisualStyleBackColor = true;
            btnExitPasswordReset.Click += btnExitPasswordReset_Click;
            // 
            // lblResetPasswordInfo
            // 
            lblResetPasswordInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResetPasswordInfo.ForeColor = Color.Red;
            lblResetPasswordInfo.Location = new Point(50, 377);
            lblResetPasswordInfo.Name = "lblResetPasswordInfo";
            lblResetPasswordInfo.Size = new Size(544, 58);
            lblResetPasswordInfo.TabIndex = 10;
            lblResetPasswordInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 167);
            label5.Name = "label5";
            label5.Size = new Size(535, 90);
            label5.TabIndex = 11;
            label5.Text = "*Note: All passwords must be a minimum of eight characters. \r\nThey must contain at least one capital letter, at least one number, \r\nand one or more non-numeric characters. ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picResetPasswordFormLogo
            // 
            picResetPasswordFormLogo.Image = Properties.Resources.bullseye;
            picResetPasswordFormLogo.Location = new Point(62, 22);
            picResetPasswordFormLogo.Name = "picResetPasswordFormLogo";
            picResetPasswordFormLogo.Size = new Size(83, 75);
            picResetPasswordFormLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picResetPasswordFormLogo.TabIndex = 12;
            picResetPasswordFormLogo.TabStop = false;
            // 
            // frmResetPassword
            // 
            AcceptButton = btnResetPassword;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitPasswordReset;
            ClientSize = new Size(660, 541);
            Controls.Add(picResetPasswordFormLogo);
            Controls.Add(label5);
            Controls.Add(lblResetPasswordInfo);
            Controls.Add(btnExitPasswordReset);
            Controls.Add(btnResetPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmResetPassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Password Reset";
            FormClosing += frmResetPassword_FormClosing;
            Load += frmResetPassword_Load;
            HelpRequested += frmResetPassword_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)picResetPasswordFormLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Label lblUsername;
        private Button btnResetPassword;
        private Button btnExitPasswordReset;
        private Label lblResetPasswordInfo;
        private Label label5;
        private PictureBox picResetPasswordFormLogo;
    }
}