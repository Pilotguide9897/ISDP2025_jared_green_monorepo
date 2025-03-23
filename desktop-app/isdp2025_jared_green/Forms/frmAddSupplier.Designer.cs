namespace idsp2025_jared_green.Forms
{
    partial class frmAddSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSupplier));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtAddSupplierName = new TextBox();
            txtAddSupplierAddress = new TextBox();
            txtAddSupplierCity = new TextBox();
            txtAddSupplierPostalCode = new TextBox();
            txtAddSupplierContact = new TextBox();
            txtAddSupplierNotes = new TextBox();
            btnAddSupplier = new Button();
            btnCancelAddSupplier = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cboAddSupplierProvince = new ComboBox();
            cboAddSupplierCountry = new ComboBox();
            txtAddSupplierPhone = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(84, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(310, 77);
            label1.Name = "label1";
            label1.Size = new Size(313, 65);
            label1.TabIndex = 2;
            label1.Text = "Add Supplier";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAddSupplierName
            // 
            txtAddSupplierName.Location = new Point(240, 241);
            txtAddSupplierName.Name = "txtAddSupplierName";
            txtAddSupplierName.Size = new Size(492, 31);
            txtAddSupplierName.TabIndex = 4;
            // 
            // txtAddSupplierAddress
            // 
            txtAddSupplierAddress.Location = new Point(240, 320);
            txtAddSupplierAddress.Name = "txtAddSupplierAddress";
            txtAddSupplierAddress.Size = new Size(492, 31);
            txtAddSupplierAddress.TabIndex = 5;
            // 
            // txtAddSupplierCity
            // 
            txtAddSupplierCity.Location = new Point(240, 399);
            txtAddSupplierCity.Name = "txtAddSupplierCity";
            txtAddSupplierCity.Size = new Size(492, 31);
            txtAddSupplierCity.TabIndex = 6;
            // 
            // txtAddSupplierPostalCode
            // 
            txtAddSupplierPostalCode.Location = new Point(240, 552);
            txtAddSupplierPostalCode.Name = "txtAddSupplierPostalCode";
            txtAddSupplierPostalCode.Size = new Size(182, 31);
            txtAddSupplierPostalCode.TabIndex = 7;
            // 
            // txtAddSupplierContact
            // 
            txtAddSupplierContact.Location = new Point(240, 631);
            txtAddSupplierContact.Name = "txtAddSupplierContact";
            txtAddSupplierContact.Size = new Size(492, 31);
            txtAddSupplierContact.TabIndex = 8;
            // 
            // txtAddSupplierNotes
            // 
            txtAddSupplierNotes.Location = new Point(137, 720);
            txtAddSupplierNotes.Multiline = true;
            txtAddSupplierNotes.Name = "txtAddSupplierNotes";
            txtAddSupplierNotes.Size = new Size(595, 195);
            txtAddSupplierNotes.TabIndex = 9;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(620, 946);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(112, 34);
            btnAddSupplier.TabIndex = 10;
            btnAddSupplier.Text = "&Save";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnCancelAddSupplier
            // 
            btnCancelAddSupplier.Location = new Point(620, 1003);
            btnCancelAddSupplier.Name = "btnCancelAddSupplier";
            btnCancelAddSupplier.Size = new Size(112, 34);
            btnCancelAddSupplier.TabIndex = 11;
            btnCancelAddSupplier.Text = "&Cancel";
            btnCancelAddSupplier.UseVisualStyleBackColor = true;
            btnCancelAddSupplier.Click += btnCancelAddSupplier_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 244);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 13;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(137, 323);
            label4.Name = "label4";
            label4.Size = new Size(81, 25);
            label4.TabIndex = 14;
            label4.Text = "Address:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(137, 402);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 15;
            label5.Text = "City:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(137, 634);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 16;
            label6.Text = "Contact:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(137, 692);
            label7.Name = "label7";
            label7.Size = new Size(63, 25);
            label7.TabIndex = 17;
            label7.Text = "Notes:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(137, 481);
            label8.Name = "label8";
            label8.Size = new Size(83, 25);
            label8.TabIndex = 18;
            label8.Text = "Province:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(443, 484);
            label9.Name = "label9";
            label9.Size = new Size(79, 25);
            label9.TabIndex = 19;
            label9.Text = "Country:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(443, 555);
            label10.Name = "label10";
            label10.Size = new Size(66, 25);
            label10.TabIndex = 20;
            label10.Text = "Phone:";
            // 
            // cboAddSupplierProvince
            // 
            cboAddSupplierProvince.FormattingEnabled = true;
            cboAddSupplierProvince.Items.AddRange(new object[] { "AB", "BC", "MB", "NB", "NL", "NT", "NS", "NU", "ON", "PE", "QC", "SK", "YT" });
            cboAddSupplierProvince.Location = new Point(240, 481);
            cboAddSupplierProvince.Name = "cboAddSupplierProvince";
            cboAddSupplierProvince.Size = new Size(182, 33);
            cboAddSupplierProvince.TabIndex = 21;
            // 
            // cboAddSupplierCountry
            // 
            cboAddSupplierCountry.FormattingEnabled = true;
            cboAddSupplierCountry.Items.AddRange(new object[] { "Canada" });
            cboAddSupplierCountry.Location = new Point(550, 481);
            cboAddSupplierCountry.Name = "cboAddSupplierCountry";
            cboAddSupplierCountry.Size = new Size(182, 33);
            cboAddSupplierCountry.TabIndex = 22;
            // 
            // txtAddSupplierPhone
            // 
            txtAddSupplierPhone.Location = new Point(550, 552);
            txtAddSupplierPhone.Name = "txtAddSupplierPhone";
            txtAddSupplierPhone.Size = new Size(182, 31);
            txtAddSupplierPhone.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 558);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 24;
            label2.Text = "Postal Code:";
            // 
            // frmAddSupplier
            // 
            AcceptButton = btnAddSupplier;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelAddSupplier;
            ClientSize = new Size(884, 1061);
            Controls.Add(label2);
            Controls.Add(txtAddSupplierPhone);
            Controls.Add(cboAddSupplierCountry);
            Controls.Add(cboAddSupplierProvince);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCancelAddSupplier);
            Controls.Add(btnAddSupplier);
            Controls.Add(txtAddSupplierNotes);
            Controls.Add(txtAddSupplierContact);
            Controls.Add(txtAddSupplierPostalCode);
            Controls.Add(txtAddSupplierCity);
            Controls.Add(txtAddSupplierAddress);
            Controls.Add(txtAddSupplierName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAddSupplier";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Add Supplier";
            Load += frmAddSupplier_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtAddSupplierName;
        private TextBox txtAddSupplierAddress;
        private TextBox txtAddSupplierCity;
        private TextBox txtAddSupplierPostalCode;
        private TextBox txtAddSupplierContact;
        private TextBox txtAddSupplierNotes;
        private Button btnAddSupplier;
        private Button btnCancelAddSupplier;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cboAddSupplierProvince;
        private ComboBox cboAddSupplierCountry;
        private TextBox txtAddSupplierPhone;
        private Label label2;
    }
}