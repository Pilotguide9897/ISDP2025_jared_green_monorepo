namespace idsp2025_jared_green.Forms
{
    partial class frmAddLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddLocation));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtLocationNotes = new TextBox();
            btnSubmitItemLocation = new Button();
            btnCancelLocationUpdate = new Button();
            label10 = new Label();
            lblSiteID = new Label();
            chkEditLocationActive = new CheckBox();
            txtLocation = new TextBox();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            txtPhone = new TextBox();
            txtPostalCode = new TextBox();
            cboProvince = new ComboBox();
            cboDeliveryDate = new ComboBox();
            cboCountry = new ComboBox();
            label9 = new Label();
            label12 = new Label();
            label13 = new Label();
            label11 = new Label();
            cboSiteType = new ComboBox();
            nudDistanceFromWarehouse = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDistanceFromWarehouse).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(85, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(137, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(269, 67);
            label1.Name = "label1";
            label1.Size = new Size(308, 65);
            label1.TabIndex = 1;
            label1.Text = "Add Location";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 202);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 2;
            label2.Text = "Site ID:";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 260);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 3;
            label3.Text = "Location:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 326);
            label4.Name = "label4";
            label4.Size = new Size(81, 25);
            label4.TabIndex = 4;
            label4.Text = "Address:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(85, 398);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 5;
            label5.Text = "City:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(85, 464);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 6;
            label6.Text = "Province:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(85, 530);
            label7.Name = "label7";
            label7.Size = new Size(110, 25);
            label7.TabIndex = 7;
            label7.Text = "Postal Code:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(80, 600);
            label8.Name = "label8";
            label8.Size = new Size(115, 25);
            label8.TabIndex = 8;
            label8.Text = "Delivery Day:";
            // 
            // txtLocationNotes
            // 
            txtLocationNotes.Location = new Point(85, 761);
            txtLocationNotes.MaxLength = 255;
            txtLocationNotes.Multiline = true;
            txtLocationNotes.Name = "txtLocationNotes";
            txtLocationNotes.Size = new Size(622, 169);
            txtLocationNotes.TabIndex = 10;
            // 
            // btnSubmitItemLocation
            // 
            btnSubmitItemLocation.Location = new Point(595, 970);
            btnSubmitItemLocation.Name = "btnSubmitItemLocation";
            btnSubmitItemLocation.Size = new Size(112, 34);
            btnSubmitItemLocation.TabIndex = 11;
            btnSubmitItemLocation.Text = "&Submit";
            btnSubmitItemLocation.UseVisualStyleBackColor = true;
            btnSubmitItemLocation.Click += btnSubmitItemLocation_Click;
            // 
            // btnCancelLocationUpdate
            // 
            btnCancelLocationUpdate.Location = new Point(595, 1029);
            btnCancelLocationUpdate.Name = "btnCancelLocationUpdate";
            btnCancelLocationUpdate.Size = new Size(112, 34);
            btnCancelLocationUpdate.TabIndex = 12;
            btnCancelLocationUpdate.Text = "&Exit";
            btnCancelLocationUpdate.UseVisualStyleBackColor = true;
            btnCancelLocationUpdate.Click += btnCancelLocationUpdate_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(85, 733);
            label10.Name = "label10";
            label10.Size = new Size(63, 25);
            label10.TabIndex = 13;
            label10.Text = "Notes:";
            // 
            // lblSiteID
            // 
            lblSiteID.BorderStyle = BorderStyle.FixedSingle;
            lblSiteID.Location = new Point(201, 202);
            lblSiteID.Name = "lblSiteID";
            lblSiteID.Size = new Size(69, 25);
            lblSiteID.TabIndex = 14;
            lblSiteID.Visible = false;
            // 
            // chkEditLocationActive
            // 
            chkEditLocationActive.AutoSize = true;
            chkEditLocationActive.Location = new Point(453, 198);
            chkEditLocationActive.Name = "chkEditLocationActive";
            chkEditLocationActive.Size = new Size(86, 29);
            chkEditLocationActive.TabIndex = 15;
            chkEditLocationActive.Text = "Active";
            chkEditLocationActive.UseVisualStyleBackColor = true;
            chkEditLocationActive.Visible = false;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(201, 260);
            txtLocation.MaxLength = 50;
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(480, 31);
            txtLocation.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(201, 326);
            txtAddress.MaxLength = 50;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(480, 31);
            txtAddress.TabIndex = 1;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(201, 398);
            txtCity.MaxLength = 50;
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(480, 31);
            txtCity.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(499, 527);
            txtPhone.MaxLength = 14;
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "NNN-NNN-NNNN";
            txtPhone.Size = new Size(182, 31);
            txtPhone.TabIndex = 6;
            // 
            // txtPostalCode
            // 
            txtPostalCode.CharacterCasing = CharacterCasing.Upper;
            txtPostalCode.Location = new Point(201, 527);
            txtPostalCode.MaxLength = 6;
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.PlaceholderText = "LNLNLN";
            txtPostalCode.Size = new Size(182, 31);
            txtPostalCode.TabIndex = 5;
            // 
            // cboProvince
            // 
            cboProvince.FormattingEnabled = true;
            cboProvince.Items.AddRange(new object[] { "AB", "BC", "MB", "NB", "NL", "NS", "ON", "PE", "QC", "SK" });
            cboProvince.Location = new Point(201, 461);
            cboProvince.Name = "cboProvince";
            cboProvince.Size = new Size(182, 33);
            cboProvince.TabIndex = 3;
            // 
            // cboDeliveryDate
            // 
            cboDeliveryDate.FormattingEnabled = true;
            cboDeliveryDate.Items.AddRange(new object[] { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" });
            cboDeliveryDate.Location = new Point(201, 597);
            cboDeliveryDate.Name = "cboDeliveryDate";
            cboDeliveryDate.Size = new Size(182, 33);
            cboDeliveryDate.TabIndex = 7;
            // 
            // cboCountry
            // 
            cboCountry.FormattingEnabled = true;
            cboCountry.Items.AddRange(new object[] { "Canada" });
            cboCountry.Location = new Point(499, 464);
            cboCountry.Name = "cboCountry";
            cboCountry.Size = new Size(182, 33);
            cboCountry.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(407, 600);
            label9.Name = "label9";
            label9.Size = new Size(132, 25);
            label9.TabIndex = 25;
            label9.Text = "Distance (Kms):";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(407, 530);
            label12.Name = "label12";
            label12.Size = new Size(66, 25);
            label12.TabIndex = 26;
            label12.Text = "Phone:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(407, 467);
            label13.Name = "label13";
            label13.Size = new Size(79, 25);
            label13.TabIndex = 27;
            label13.Text = "Country:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(85, 670);
            label11.Name = "label11";
            label11.Size = new Size(87, 25);
            label11.TabIndex = 29;
            label11.Text = "Site Type:";
            // 
            // cboSiteType
            // 
            cboSiteType.FormattingEnabled = true;
            cboSiteType.Items.AddRange(new object[] { "Store", "Warehouse", "Office", "Delivery", "Online" });
            cboSiteType.Location = new Point(201, 670);
            cboSiteType.Name = "cboSiteType";
            cboSiteType.Size = new Size(182, 33);
            cboSiteType.TabIndex = 9;
            // 
            // nudDistanceFromWarehouse
            // 
            nudDistanceFromWarehouse.Location = new Point(540, 599);
            nudDistanceFromWarehouse.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDistanceFromWarehouse.Name = "nudDistanceFromWarehouse";
            nudDistanceFromWarehouse.Size = new Size(141, 31);
            nudDistanceFromWarehouse.TabIndex = 8;
            // 
            // frmAddLocation
            // 
            AcceptButton = btnSubmitItemLocation;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelLocationUpdate;
            ClientSize = new Size(777, 1102);
            Controls.Add(nudDistanceFromWarehouse);
            Controls.Add(cboSiteType);
            Controls.Add(label11);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label9);
            Controls.Add(cboCountry);
            Controls.Add(cboDeliveryDate);
            Controls.Add(cboProvince);
            Controls.Add(txtPostalCode);
            Controls.Add(txtPhone);
            Controls.Add(txtCity);
            Controls.Add(txtAddress);
            Controls.Add(txtLocation);
            Controls.Add(chkEditLocationActive);
            Controls.Add(lblSiteID);
            Controls.Add(label10);
            Controls.Add(btnCancelLocationUpdate);
            Controls.Add(btnSubmitItemLocation);
            Controls.Add(txtLocationNotes);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddLocation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Add Location";
            Load += frmAddLocation_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDistanceFromWarehouse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtLocationNotes;
        private Button btnSubmitItemLocation;
        private Button btnCancelLocationUpdate;
        private Label label10;
        private Label lblSiteID;
        private CheckBox chkEditLocationActive;
        private TextBox txtLocation;
        private TextBox txtAddress;
        private TextBox txtCity;
        private TextBox txtPhone;
        private TextBox txtPostalCode;
        private ComboBox cboProvince;
        private ComboBox cboDeliveryDate;
        private ComboBox cboCountry;
        private Label label9;
        private Label label12;
        private Label label13;
        private Label label11;
        private ComboBox cboSiteType;
        private NumericUpDown nudDistanceFromWarehouse;
    }
}