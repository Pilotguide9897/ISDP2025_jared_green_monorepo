namespace idsp2025_jared_green.Forms
{
    partial class frmUpdateEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateEmployee));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblUser = new Label();
            lblLocation = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            chkEditEmployeeActive = new CheckBox();
            chkEditEmployeeLocked = new CheckBox();
            label12 = new Label();
            label13 = new Label();
            btnSaveEmployeeUpdates = new Button();
            btnExitEmployeeUpdates = new Button();
            lblEmployeeID = new Label();
            txtUpdateFirstName = new TextBox();
            txtUpdateLastName = new TextBox();
            txtUpdateEmail = new TextBox();
            cboUpdatePosition = new ComboBox();
            cboUpdateLocation = new ComboBox();
            lblUpdateFirstNameError = new Label();
            lblUpdateLastNameError = new Label();
            lblUpdateEmailError = new Label();
            chkResetPassword = new CheckBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(43, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(121, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 59);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 1;
            label1.Text = "User:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(429, 59);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 2;
            label2.Text = "Location:";
            label2.Visible = false;
            // 
            // lblUser
            // 
            lblUser.BorderStyle = BorderStyle.FixedSingle;
            lblUser.Location = new Point(239, 59);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(152, 25);
            lblUser.TabIndex = 3;
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            lblUser.Visible = false;
            // 
            // lblLocation
            // 
            lblLocation.BorderStyle = BorderStyle.FixedSingle;
            lblLocation.Location = new Point(518, 59);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(117, 25);
            lblLocation.TabIndex = 4;
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;
            lblLocation.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(78, 137);
            label3.Name = "label3";
            label3.Size = new Size(588, 65);
            label3.TabIndex = 5;
            label3.Text = "Edit Employee Information";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 234);
            label4.Name = "label4";
            label4.Size = new Size(117, 25);
            label4.TabIndex = 6;
            label4.Text = "Employee ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 294);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 7;
            label5.Text = "First Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(78, 347);
            label6.Name = "label6";
            label6.Size = new Size(99, 25);
            label6.TabIndex = 8;
            label6.Text = "Last Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(182, 575);
            label8.Name = "label8";
            label8.Size = new Size(138, 25);
            label8.TabIndex = 5;
            label8.Text = "Reset Password:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(119, 409);
            label9.Name = "label9";
            label9.Size = new Size(58, 25);
            label9.TabIndex = 11;
            label9.Text = "Email:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(98, 461);
            label10.Name = "label10";
            label10.Size = new Size(79, 25);
            label10.TabIndex = 12;
            label10.Text = "Position:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(94, 514);
            label11.Name = "label11";
            label11.Size = new Size(83, 25);
            label11.TabIndex = 13;
            label11.Text = "Location:";
            // 
            // chkEditEmployeeActive
            // 
            chkEditEmployeeActive.AutoSize = true;
            chkEditEmployeeActive.Location = new Point(348, 627);
            chkEditEmployeeActive.Name = "chkEditEmployeeActive";
            chkEditEmployeeActive.Size = new Size(22, 21);
            chkEditEmployeeActive.TabIndex = 6;
            chkEditEmployeeActive.UseVisualStyleBackColor = true;
            // 
            // chkEditEmployeeLocked
            // 
            chkEditEmployeeLocked.AutoSize = true;
            chkEditEmployeeLocked.Location = new Point(348, 679);
            chkEditEmployeeLocked.Name = "chkEditEmployeeLocked";
            chkEditEmployeeLocked.Size = new Size(22, 21);
            chkEditEmployeeLocked.TabIndex = 7;
            chkEditEmployeeLocked.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(182, 623);
            label12.Name = "label12";
            label12.Size = new Size(134, 25);
            label12.TabIndex = 6;
            label12.Text = "Account Active:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(178, 675);
            label13.Name = "label13";
            label13.Size = new Size(142, 25);
            label13.TabIndex = 7;
            label13.Text = "Account Locked:";
            // 
            // btnSaveEmployeeUpdates
            // 
            btnSaveEmployeeUpdates.Location = new Point(449, 593);
            btnSaveEmployeeUpdates.Name = "btnSaveEmployeeUpdates";
            btnSaveEmployeeUpdates.Size = new Size(112, 34);
            btnSaveEmployeeUpdates.TabIndex = 8;
            btnSaveEmployeeUpdates.Text = "&Save";
            btnSaveEmployeeUpdates.UseVisualStyleBackColor = true;
            btnSaveEmployeeUpdates.Click += btnSaveEmployeeUpdates_Click;
            // 
            // btnExitEmployeeUpdates
            // 
            btnExitEmployeeUpdates.Location = new Point(449, 654);
            btnExitEmployeeUpdates.Name = "btnExitEmployeeUpdates";
            btnExitEmployeeUpdates.Size = new Size(112, 34);
            btnExitEmployeeUpdates.TabIndex = 9;
            btnExitEmployeeUpdates.Text = "&Exit";
            btnExitEmployeeUpdates.UseVisualStyleBackColor = true;
            btnExitEmployeeUpdates.Click += btnExitEmployeeUpdates_Click;
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.Location = new Point(203, 227);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(104, 38);
            lblEmployeeID.TabIndex = 20;
            lblEmployeeID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUpdateFirstName
            // 
            txtUpdateFirstName.Location = new Point(203, 294);
            txtUpdateFirstName.MaxLength = 20;
            txtUpdateFirstName.Name = "txtUpdateFirstName";
            txtUpdateFirstName.Size = new Size(379, 31);
            txtUpdateFirstName.TabIndex = 0;
            txtUpdateFirstName.TextChanged += txtUpdateFirstName_TextChanged;
            // 
            // txtUpdateLastName
            // 
            txtUpdateLastName.Location = new Point(203, 347);
            txtUpdateLastName.MaxLength = 20;
            txtUpdateLastName.Name = "txtUpdateLastName";
            txtUpdateLastName.Size = new Size(379, 31);
            txtUpdateLastName.TabIndex = 1;
            txtUpdateLastName.TextChanged += txtUpdateLastName_TextChanged;
            // 
            // txtUpdateEmail
            // 
            txtUpdateEmail.Location = new Point(203, 406);
            txtUpdateEmail.MaxLength = 88;
            txtUpdateEmail.Name = "txtUpdateEmail";
            txtUpdateEmail.Size = new Size(269, 31);
            txtUpdateEmail.TabIndex = 2;
            txtUpdateEmail.TextChanged += txtUpdateEmail_TextChanged;
            // 
            // cboUpdatePosition
            // 
            cboUpdatePosition.FormattingEnabled = true;
            cboUpdatePosition.Location = new Point(203, 458);
            cboUpdatePosition.Name = "cboUpdatePosition";
            cboUpdatePosition.Size = new Size(379, 33);
            cboUpdatePosition.TabIndex = 3;
            // 
            // cboUpdateLocation
            // 
            cboUpdateLocation.FormattingEnabled = true;
            cboUpdateLocation.Location = new Point(203, 511);
            cboUpdateLocation.Name = "cboUpdateLocation";
            cboUpdateLocation.Size = new Size(379, 33);
            cboUpdateLocation.TabIndex = 4;
            // 
            // lblUpdateFirstNameError
            // 
            lblUpdateFirstNameError.ForeColor = Color.Red;
            lblUpdateFirstNameError.Location = new Point(588, 294);
            lblUpdateFirstNameError.Name = "lblUpdateFirstNameError";
            lblUpdateFirstNameError.Size = new Size(151, 31);
            lblUpdateFirstNameError.TabIndex = 28;
            lblUpdateFirstNameError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUpdateLastNameError
            // 
            lblUpdateLastNameError.ForeColor = Color.Red;
            lblUpdateLastNameError.Location = new Point(588, 347);
            lblUpdateLastNameError.Name = "lblUpdateLastNameError";
            lblUpdateLastNameError.Size = new Size(151, 31);
            lblUpdateLastNameError.TabIndex = 29;
            lblUpdateLastNameError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUpdateEmailError
            // 
            lblUpdateEmailError.ForeColor = Color.Red;
            lblUpdateEmailError.Location = new Point(588, 406);
            lblUpdateEmailError.Name = "lblUpdateEmailError";
            lblUpdateEmailError.Size = new Size(151, 31);
            lblUpdateEmailError.TabIndex = 32;
            lblUpdateEmailError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkResetPassword
            // 
            chkResetPassword.AutoSize = true;
            chkResetPassword.Location = new Point(348, 578);
            chkResetPassword.Name = "chkResetPassword";
            chkResetPassword.Size = new Size(22, 21);
            chkResetPassword.TabIndex = 5;
            chkResetPassword.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(472, 408);
            label7.Name = "label7";
            label7.Size = new Size(114, 25);
            label7.TabIndex = 36;
            label7.Text = "@bullseye.ca";
            // 
            // frmUpdateEmployee
            // 
            AcceptButton = btnSaveEmployeeUpdates;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitEmployeeUpdates;
            ClientSize = new Size(746, 738);
            Controls.Add(label7);
            Controls.Add(chkResetPassword);
            Controls.Add(lblUpdateEmailError);
            Controls.Add(lblUpdateLastNameError);
            Controls.Add(lblUpdateFirstNameError);
            Controls.Add(cboUpdateLocation);
            Controls.Add(cboUpdatePosition);
            Controls.Add(txtUpdateEmail);
            Controls.Add(txtUpdateLastName);
            Controls.Add(txtUpdateFirstName);
            Controls.Add(lblEmployeeID);
            Controls.Add(btnExitEmployeeUpdates);
            Controls.Add(btnSaveEmployeeUpdates);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(chkEditEmployeeLocked);
            Controls.Add(chkEditEmployeeActive);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblLocation);
            Controls.Add(lblUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmUpdateEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Edit Employee";
            Load += frmUpdateEmployee_Load;
            HelpRequested += frmUpdateEmployee_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label lblUser;
        private Label lblLocation;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private CheckBox chkEditEmployeeActive;
        private CheckBox chkEditEmployeeLocked;
        private Label label12;
        private Label label13;
        private Button btnSaveEmployeeUpdates;
        private Button btnExitEmployeeUpdates;
        private Label lblEmployeeID;
        private TextBox txtUpdateFirstName;
        private TextBox txtUpdateLastName;
        private TextBox txtUpdateEmail;
        private ComboBox cboUpdatePosition;
        private ComboBox cboUpdateLocation;
        private Label lblUpdateFirstNameError;
        private Label lblUpdateLastNameError;
        private Label lblUpdateEmailError;
        private CheckBox chkResetPassword;
        private Label label7;
    }
}