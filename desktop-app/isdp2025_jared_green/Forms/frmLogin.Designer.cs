namespace idsp2025_jared_green
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lbl = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSignin = new Button();
            btnExitSignin = new Button();
            lnkLblForgotPassword = new LinkLabel();
            lblInfo = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            picSignInFormLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picSignInFormLogo).BeginInit();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl.Location = new Point(312, 22);
            lbl.Name = "lbl";
            lbl.Size = new Size(174, 65);
            lbl.TabIndex = 0;
            lbl.Text = "Sign In";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 116);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 174);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // btnSignin
            // 
            btnSignin.Location = new Point(622, 315);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(112, 34);
            btnSignin.TabIndex = 2;
            btnSignin.Text = "&Sign In";
            btnSignin.UseVisualStyleBackColor = true;
            btnSignin.Click += btnSignin_Click;
            // 
            // btnExitSignin
            // 
            btnExitSignin.Location = new Point(490, 315);
            btnExitSignin.Name = "btnExitSignin";
            btnExitSignin.Size = new Size(112, 34);
            btnExitSignin.TabIndex = 3;
            btnExitSignin.Text = "&Exit";
            btnExitSignin.UseVisualStyleBackColor = true;
            btnExitSignin.Click += btnExitSignin_Click;
            // 
            // lnkLblForgotPassword
            // 
            lnkLblForgotPassword.AutoSize = true;
            lnkLblForgotPassword.Location = new Point(61, 315);
            lnkLblForgotPassword.Name = "lnkLblForgotPassword";
            lnkLblForgotPassword.Size = new Size(154, 25);
            lnkLblForgotPassword.TabIndex = 4;
            lnkLblForgotPassword.TabStop = true;
            lnkLblForgotPassword.Text = "Forgot Password?";
            lnkLblForgotPassword.LinkClicked += lnkLblForgotPassword_LinkClicked;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.ForeColor = Color.Red;
            lblInfo.Location = new Point(61, 225);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(667, 71);
            lblInfo.TabIndex = 6;
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(177, 116);
            txtUsername.MaxLength = 255;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(551, 31);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(177, 168);
            txtPassword.MaxLength = 255;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(551, 31);
            txtPassword.TabIndex = 1;
            txtPassword.HelpRequested += txtPassword_HelpRequested;
            txtPassword.MouseLeave += txtPassword_MouseLeave;
            txtPassword.MouseHover += txtPassword_MouseHover;
            // 
            // picSignInFormLogo
            // 
            picSignInFormLogo.Image = Properties.Resources.bullseye;
            picSignInFormLogo.Location = new Point(70, 22);
            picSignInFormLogo.Name = "picSignInFormLogo";
            picSignInFormLogo.Size = new Size(82, 75);
            picSignInFormLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picSignInFormLogo.TabIndex = 7;
            picSignInFormLogo.TabStop = false;
            // 
            // frmLogin
            // 
            AcceptButton = btnSignin;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitSignin;
            ClientSize = new Size(807, 389);
            Controls.Add(picSignInFormLogo);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblInfo);
            Controls.Add(lnkLblForgotPassword);
            Controls.Add(btnExitSignin);
            Controls.Add(btnSignin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Sign In";
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)picSignInFormLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl;
        private Label label2;
        private Label label3;
        private Button btnSignin;
        private Button btnExitSignin;
        private LinkLabel lnkLblForgotPassword;
        private Label lblInfo;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private PictureBox picSignInFormLogo;
    }
}