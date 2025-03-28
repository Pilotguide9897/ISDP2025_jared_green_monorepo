namespace idsp2025_jared_green.Forms
{
    partial class frmEditSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditSupplier));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtEditSupplierName = new TextBox();
            txtEditSupplierAddress = new TextBox();
            txtEditSupplierCity = new TextBox();
            txtEditSupplierPostalCode = new TextBox();
            txtEditSupplierContact = new TextBox();
            txtEditSupplierNotes = new TextBox();
            btnUpdateSupplier = new Button();
            btnCancelSupplierUpdate = new Button();
            txtEditSupplierPhone = new TextBox();
            cboEditSupplierProvince = new ComboBox();
            cboEditSupplierCountry = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            chkSupplierActive = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(113, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 142);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(294, 62);
            label1.Name = "label1";
            label1.Size = new Size(307, 65);
            label1.TabIndex = 1;
            label1.Text = "Edit Supplier";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEditSupplierName
            // 
            txtEditSupplierName.Location = new Point(250, 239);
            txtEditSupplierName.Name = "txtEditSupplierName";
            txtEditSupplierName.Size = new Size(532, 31);
            txtEditSupplierName.TabIndex = 1;
            // 
            // txtEditSupplierAddress
            // 
            txtEditSupplierAddress.Location = new Point(250, 327);
            txtEditSupplierAddress.Name = "txtEditSupplierAddress";
            txtEditSupplierAddress.Size = new Size(532, 31);
            txtEditSupplierAddress.TabIndex = 2;
            // 
            // txtEditSupplierCity
            // 
            txtEditSupplierCity.Location = new Point(250, 417);
            txtEditSupplierCity.Name = "txtEditSupplierCity";
            txtEditSupplierCity.Size = new Size(532, 31);
            txtEditSupplierCity.TabIndex = 3;
            // 
            // txtEditSupplierPostalCode
            // 
            txtEditSupplierPostalCode.Location = new Point(288, 570);
            txtEditSupplierPostalCode.Name = "txtEditSupplierPostalCode";
            txtEditSupplierPostalCode.Size = new Size(184, 31);
            txtEditSupplierPostalCode.TabIndex = 6;
            // 
            // txtEditSupplierContact
            // 
            txtEditSupplierContact.Location = new Point(250, 659);
            txtEditSupplierContact.Name = "txtEditSupplierContact";
            txtEditSupplierContact.Size = new Size(532, 31);
            txtEditSupplierContact.TabIndex = 8;
            // 
            // txtEditSupplierNotes
            // 
            txtEditSupplierNotes.Location = new Point(172, 750);
            txtEditSupplierNotes.Multiline = true;
            txtEditSupplierNotes.Name = "txtEditSupplierNotes";
            txtEditSupplierNotes.Size = new Size(610, 152);
            txtEditSupplierNotes.TabIndex = 9;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.Location = new Point(670, 928);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(112, 34);
            btnUpdateSupplier.TabIndex = 10;
            btnUpdateSupplier.Text = "Update";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;
            // 
            // btnCancelSupplierUpdate
            // 
            btnCancelSupplierUpdate.Location = new Point(670, 987);
            btnCancelSupplierUpdate.Name = "btnCancelSupplierUpdate";
            btnCancelSupplierUpdate.Size = new Size(112, 34);
            btnCancelSupplierUpdate.TabIndex = 11;
            btnCancelSupplierUpdate.Text = "Cancel";
            btnCancelSupplierUpdate.UseVisualStyleBackColor = true;
            btnCancelSupplierUpdate.Click += btnCancelSupplierUpdate_Click;
            // 
            // txtEditSupplierPhone
            // 
            txtEditSupplierPhone.Location = new Point(607, 567);
            txtEditSupplierPhone.Name = "txtEditSupplierPhone";
            txtEditSupplierPhone.Size = new Size(193, 31);
            txtEditSupplierPhone.TabIndex = 7;
            // 
            // cboEditSupplierProvince
            // 
            cboEditSupplierProvince.FormattingEnabled = true;
            cboEditSupplierProvince.Items.AddRange(new object[] { "AB", "BC", "MB", "NB", "NL", "NT", "NS", "NU", "ON", "PE", "QC", "SK", "YT" });
            cboEditSupplierProvince.Location = new Point(288, 500);
            cboEditSupplierProvince.Name = "cboEditSupplierProvince";
            cboEditSupplierProvince.Size = new Size(184, 33);
            cboEditSupplierProvince.TabIndex = 4;
            // 
            // cboEditSupplierCountry
            // 
            cboEditSupplierCountry.FormattingEnabled = true;
            cboEditSupplierCountry.Items.AddRange(new object[] { "Canada" });
            cboEditSupplierCountry.Location = new Point(607, 500);
            cboEditSupplierCountry.Name = "cboEditSupplierCountry";
            cboEditSupplierCountry.Size = new Size(193, 33);
            cboEditSupplierCountry.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 242);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 14;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 333);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 15;
            label3.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(172, 420);
            label4.Name = "label4";
            label4.Size = new Size(46, 25);
            label4.TabIndex = 16;
            label4.Text = "City:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(172, 500);
            label5.Name = "label5";
            label5.Size = new Size(83, 25);
            label5.TabIndex = 17;
            label5.Text = "Province:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(172, 573);
            label6.Name = "label6";
            label6.Size = new Size(110, 25);
            label6.TabIndex = 18;
            label6.Text = "Postal Code:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(172, 665);
            label7.Name = "label7";
            label7.Size = new Size(77, 25);
            label7.TabIndex = 19;
            label7.Text = "Contact:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(172, 722);
            label9.Name = "label9";
            label9.Size = new Size(63, 25);
            label9.TabIndex = 21;
            label9.Text = "Notes:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(499, 505);
            label10.Name = "label10";
            label10.Size = new Size(79, 25);
            label10.TabIndex = 22;
            label10.Text = "Country:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(499, 573);
            label11.Name = "label11";
            label11.Size = new Size(66, 25);
            label11.TabIndex = 23;
            label11.Text = "Phone:";
            // 
            // chkSupplierActive
            // 
            chkSupplierActive.AutoSize = true;
            chkSupplierActive.Location = new Point(696, 168);
            chkSupplierActive.Name = "chkSupplierActive";
            chkSupplierActive.Size = new Size(86, 29);
            chkSupplierActive.TabIndex = 0;
            chkSupplierActive.Text = "Active";
            chkSupplierActive.UseVisualStyleBackColor = true;
            // 
            // frmEditSupplier
            // 
            AcceptButton = btnUpdateSupplier;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelSupplierUpdate;
            ClientSize = new Size(952, 1045);
            Controls.Add(chkSupplierActive);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboEditSupplierCountry);
            Controls.Add(cboEditSupplierProvince);
            Controls.Add(txtEditSupplierPhone);
            Controls.Add(btnCancelSupplierUpdate);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(txtEditSupplierNotes);
            Controls.Add(txtEditSupplierContact);
            Controls.Add(txtEditSupplierPostalCode);
            Controls.Add(txtEditSupplierCity);
            Controls.Add(txtEditSupplierAddress);
            Controls.Add(txtEditSupplierName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEditSupplier";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Edit Supplier";
            Load += frmEditSupplier_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtEditSupplierName;
        private TextBox txtEditSupplierAddress;
        private TextBox txtEditSupplierCity;
        private TextBox txtEditSupplierPostalCode;
        private TextBox txtEditSupplierContact;
        private TextBox txtEditSupplierNotes;
        private Button btnUpdateSupplier;
        private Button btnCancelSupplierUpdate;
        private TextBox txtEditSupplierPhone;
        private ComboBox cboEditSupplierProvince;
        private ComboBox cboEditSupplierCountry;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label label11;
        private CheckBox chkSupplierActive;
    }
}