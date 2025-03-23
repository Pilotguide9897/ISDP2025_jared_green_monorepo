namespace idsp2025_jared_green
{
    partial class frmAddEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEmployee));
            label1 = new Label();
            label2 = new Label();
            lblUser = new Label();
            lblLocation = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            btnSubmit = new Button();
            btnExit = new Button();
            cboPosition = new ComboBox();
            cboLocation = new ComboBox();
            label14 = new Label();
            lblFirstNameError = new Label();
            lblLastNameError = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 66);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 0;
            label1.Text = "User:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(540, 63);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 1;
            label2.Text = "Location:";
            label2.Visible = false;
            // 
            // lblUser
            // 
            lblUser.BorderStyle = BorderStyle.FixedSingle;
            lblUser.Location = new Point(256, 63);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(118, 32);
            lblUser.TabIndex = 8;
            lblUser.Visible = false;
            // 
            // lblLocation
            // 
            lblLocation.BorderStyle = BorderStyle.FixedSingle;
            lblLocation.Location = new Point(629, 59);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(117, 32);
            lblLocation.TabIndex = 3;
            lblLocation.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(36, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(124, 115);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(165, 151);
            label3.Name = "label3";
            label3.Size = new Size(505, 54);
            label3.TabIndex = 5;
            label3.Text = "New Employee Information";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(85, 247);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 7;
            label5.Text = "First Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(85, 311);
            label6.Name = "label6";
            label6.Size = new Size(99, 25);
            label6.TabIndex = 8;
            label6.Text = "Last Name:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(85, 374);
            label10.Name = "label10";
            label10.Size = new Size(79, 25);
            label10.TabIndex = 12;
            label10.Text = "Position:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(85, 438);
            label11.Name = "label11";
            label11.Size = new Size(83, 25);
            label11.TabIndex = 13;
            label11.Text = "Location:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(208, 247);
            txtFirstName.MaxLength = 20;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(364, 31);
            txtFirstName.TabIndex = 9;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(208, 311);
            txtLastName.MaxLength = 20;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(364, 31);
            txtLastName.TabIndex = 10;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(584, 504);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "&Create";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(584, 563);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 34);
            btnExit.TabIndex = 14;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Location = new Point(208, 374);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(364, 33);
            cboPosition.TabIndex = 11;
            cboPosition.SelectedIndexChanged += cboPosition_SelectedIndexChanged;
            // 
            // cboLocation
            // 
            cboLocation.FormattingEnabled = true;
            cboLocation.Location = new Point(208, 435);
            cboLocation.Name = "cboLocation";
            cboLocation.Size = new Size(364, 33);
            cboLocation.TabIndex = 12;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(587, 253);
            label14.Name = "label14";
            label14.Size = new Size(0, 25);
            label14.TabIndex = 30;
            // 
            // lblFirstNameError
            // 
            lblFirstNameError.ForeColor = Color.Red;
            lblFirstNameError.Location = new Point(584, 244);
            lblFirstNameError.Name = "lblFirstNameError";
            lblFirstNameError.Size = new Size(133, 38);
            lblFirstNameError.TabIndex = 31;
            lblFirstNameError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLastNameError
            // 
            lblLastNameError.ForeColor = Color.Red;
            lblLastNameError.Location = new Point(584, 307);
            lblLastNameError.Name = "lblLastNameError";
            lblLastNameError.Size = new Size(133, 38);
            lblLastNameError.TabIndex = 32;
            lblLastNameError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmAddEmployee
            // 
            AcceptButton = btnSubmit;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(800, 633);
            Controls.Add(lblLastNameError);
            Controls.Add(lblFirstNameError);
            Controls.Add(label14);
            Controls.Add(cboLocation);
            Controls.Add(cboPosition);
            Controls.Add(btnExit);
            Controls.Add(btnSubmit);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(lblLocation);
            Controls.Add(lblUser);
            Controls.Add(label2);
            Controls.Add(label1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Add Employee";
            Load += frmAddEmployee_Load;
            HelpRequested += frmAddEmployee_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblUser;
        private Label lblLocation;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label10;
        private Label label11;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button btnSubmit;
        private Button btnExit;
        private ComboBox cboPosition;
        private ComboBox cboLocation;
        private Label label14;
        private Label lblFirstNameError;
        private Label lblLastNameError;
    }
}