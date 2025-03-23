namespace idsp2025_jared_green.Forms
{
    partial class frmEditLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditLocation));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnSubmitLocationUpdate = new Button();
            btnExitLocationUpdate = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            chkLocationActive = new CheckBox();
            txtUpdateNotes = new TextBox();
            label11 = new Label();
            txtUpdateLocation = new TextBox();
            txtUpdateAddress = new TextBox();
            txtUpdateCity = new TextBox();
            txtUpdatePhone = new TextBox();
            cboUpdateProvince = new ComboBox();
            cboUpdateCountry = new ComboBox();
            cboUpdateDeliveryDay = new ComboBox();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            txtUpdatePostalCode = new TextBox();
            lblSiteID = new Label();
            label9 = new Label();
            cboUpdateLocationType = new ComboBox();
            nudUpdateDistanceFromWarehouse = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUpdateDistanceFromWarehouse).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(51, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(225, 48);
            label1.Name = "label1";
            label1.Size = new Size(375, 65);
            label1.TabIndex = 1;
            label1.Text = "Update Location";
            // 
            // btnSubmitLocationUpdate
            // 
            btnSubmitLocationUpdate.Location = new Point(594, 1029);
            btnSubmitLocationUpdate.Name = "btnSubmitLocationUpdate";
            btnSubmitLocationUpdate.Size = new Size(112, 34);
            btnSubmitLocationUpdate.TabIndex = 11;
            btnSubmitLocationUpdate.Text = "&Submit";
            btnSubmitLocationUpdate.UseVisualStyleBackColor = true;
            btnSubmitLocationUpdate.Click += btnSubmitLocationUpdate_Click;
            // 
            // btnExitLocationUpdate
            // 
            btnExitLocationUpdate.Location = new Point(594, 1088);
            btnExitLocationUpdate.Name = "btnExitLocationUpdate";
            btnExitLocationUpdate.Size = new Size(112, 34);
            btnExitLocationUpdate.TabIndex = 12;
            btnExitLocationUpdate.Text = "&Exit";
            btnExitLocationUpdate.UseVisualStyleBackColor = true;
            btnExitLocationUpdate.Click += btnExitLocationUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 201);
            label2.Name = "label2";
            label2.Size = new Size(73, 25);
            label2.TabIndex = 4;
            label2.Text = "Side ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 265);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 5;
            label3.Text = "Location:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 330);
            label4.Name = "label4";
            label4.Size = new Size(81, 25);
            label4.TabIndex = 6;
            label4.Text = "Address:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 398);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 7;
            label5.Text = "City:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 471);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 8;
            label6.Text = "Province:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 537);
            label7.Name = "label7";
            label7.Size = new Size(110, 25);
            label7.TabIndex = 9;
            label7.Text = "Postal Code:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(51, 609);
            label8.Name = "label8";
            label8.Size = new Size(115, 25);
            label8.TabIndex = 10;
            label8.Text = "Delivery Day:";
            // 
            // chkLocationActive
            // 
            chkLocationActive.AutoSize = true;
            chkLocationActive.Location = new Point(433, 201);
            chkLocationActive.Name = "chkLocationActive";
            chkLocationActive.Size = new Size(86, 29);
            chkLocationActive.TabIndex = 13;
            chkLocationActive.Text = "Active";
            chkLocationActive.UseVisualStyleBackColor = true;
            // 
            // txtUpdateNotes
            // 
            txtUpdateNotes.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUpdateNotes.Location = new Point(51, 776);
            txtUpdateNotes.MaxLength = 255;
            txtUpdateNotes.Multiline = true;
            txtUpdateNotes.Name = "txtUpdateNotes";
            txtUpdateNotes.Size = new Size(655, 219);
            txtUpdateNotes.TabIndex = 10;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(51, 748);
            label11.Name = "label11";
            label11.Size = new Size(63, 25);
            label11.TabIndex = 15;
            label11.Text = "Notes:";
            // 
            // txtUpdateLocation
            // 
            txtUpdateLocation.Location = new Point(182, 265);
            txtUpdateLocation.MaxLength = 50;
            txtUpdateLocation.Name = "txtUpdateLocation";
            txtUpdateLocation.Size = new Size(524, 31);
            txtUpdateLocation.TabIndex = 0;
            // 
            // txtUpdateAddress
            // 
            txtUpdateAddress.Location = new Point(182, 330);
            txtUpdateAddress.MaxLength = 50;
            txtUpdateAddress.Name = "txtUpdateAddress";
            txtUpdateAddress.Size = new Size(524, 31);
            txtUpdateAddress.TabIndex = 1;
            // 
            // txtUpdateCity
            // 
            txtUpdateCity.Location = new Point(182, 398);
            txtUpdateCity.MaxLength = 50;
            txtUpdateCity.Name = "txtUpdateCity";
            txtUpdateCity.Size = new Size(524, 31);
            txtUpdateCity.TabIndex = 2;
            // 
            // txtUpdatePhone
            // 
            txtUpdatePhone.Location = new Point(475, 537);
            txtUpdatePhone.MaxLength = 14;
            txtUpdatePhone.Name = "txtUpdatePhone";
            txtUpdatePhone.PlaceholderText = "NNN-NNN-NNNN";
            txtUpdatePhone.Size = new Size(231, 31);
            txtUpdatePhone.TabIndex = 6;
            // 
            // cboUpdateProvince
            // 
            cboUpdateProvince.FormattingEnabled = true;
            cboUpdateProvince.Items.AddRange(new object[] { "AB", "BC", "MB", "NB", "NL", "NS", "ON", "PE", "QC", "SK" });
            cboUpdateProvince.Location = new Point(182, 468);
            cboUpdateProvince.Name = "cboUpdateProvince";
            cboUpdateProvince.Size = new Size(182, 33);
            cboUpdateProvince.TabIndex = 3;
            // 
            // cboUpdateCountry
            // 
            cboUpdateCountry.FormattingEnabled = true;
            cboUpdateCountry.Items.AddRange(new object[] { "Canada" });
            cboUpdateCountry.Location = new Point(475, 468);
            cboUpdateCountry.Name = "cboUpdateCountry";
            cboUpdateCountry.Size = new Size(231, 33);
            cboUpdateCountry.TabIndex = 4;
            // 
            // cboUpdateDeliveryDay
            // 
            cboUpdateDeliveryDay.FormattingEnabled = true;
            cboUpdateDeliveryDay.Items.AddRange(new object[] { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" });
            cboUpdateDeliveryDay.Location = new Point(182, 609);
            cboUpdateDeliveryDay.Name = "cboUpdateDeliveryDay";
            cboUpdateDeliveryDay.Size = new Size(182, 33);
            cboUpdateDeliveryDay.TabIndex = 7;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(381, 471);
            label13.Name = "label13";
            label13.Size = new Size(79, 25);
            label13.TabIndex = 25;
            label13.Text = "Country:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(381, 534);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 26;
            label14.Text = "Phone:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(381, 613);
            label15.Name = "label15";
            label15.Size = new Size(124, 25);
            label15.TabIndex = 27;
            label15.Text = "Distance (Km):";
            // 
            // txtUpdatePostalCode
            // 
            txtUpdatePostalCode.CharacterCasing = CharacterCasing.Upper;
            txtUpdatePostalCode.Location = new Point(182, 534);
            txtUpdatePostalCode.MaxLength = 6;
            txtUpdatePostalCode.Name = "txtUpdatePostalCode";
            txtUpdatePostalCode.PlaceholderText = "LNLNLN";
            txtUpdatePostalCode.Size = new Size(182, 31);
            txtUpdatePostalCode.TabIndex = 5;
            // 
            // lblSiteID
            // 
            lblSiteID.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSiteID.Location = new Point(182, 196);
            lblSiteID.Name = "lblSiteID";
            lblSiteID.Size = new Size(104, 38);
            lblSiteID.TabIndex = 29;
            lblSiteID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(51, 686);
            label9.Name = "label9";
            label9.Size = new Size(125, 25);
            label9.TabIndex = 30;
            label9.Text = "Location Type:";
            // 
            // cboUpdateLocationType
            // 
            cboUpdateLocationType.FormattingEnabled = true;
            cboUpdateLocationType.Items.AddRange(new object[] { "Store", "Warehouse", "Office", "Delivery", "Online" });
            cboUpdateLocationType.Location = new Point(182, 683);
            cboUpdateLocationType.Name = "cboUpdateLocationType";
            cboUpdateLocationType.Size = new Size(182, 33);
            cboUpdateLocationType.TabIndex = 9;
            // 
            // nudUpdateDistanceFromWarehouse
            // 
            nudUpdateDistanceFromWarehouse.Location = new Point(511, 613);
            nudUpdateDistanceFromWarehouse.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudUpdateDistanceFromWarehouse.Name = "nudUpdateDistanceFromWarehouse";
            nudUpdateDistanceFromWarehouse.Size = new Size(195, 31);
            nudUpdateDistanceFromWarehouse.TabIndex = 8;
            // 
            // frmEditLocation
            // 
            AcceptButton = btnSubmitLocationUpdate;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitLocationUpdate;
            ClientSize = new Size(762, 1164);
            Controls.Add(nudUpdateDistanceFromWarehouse);
            Controls.Add(cboUpdateLocationType);
            Controls.Add(label9);
            Controls.Add(lblSiteID);
            Controls.Add(txtUpdatePostalCode);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(cboUpdateDeliveryDay);
            Controls.Add(cboUpdateCountry);
            Controls.Add(cboUpdateProvince);
            Controls.Add(txtUpdatePhone);
            Controls.Add(txtUpdateCity);
            Controls.Add(txtUpdateAddress);
            Controls.Add(txtUpdateLocation);
            Controls.Add(label11);
            Controls.Add(txtUpdateNotes);
            Controls.Add(chkLocationActive);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnExitLocationUpdate);
            Controls.Add(btnSubmitLocationUpdate);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditLocation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Edit Location";
            Load += frmEditLocation_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUpdateDistanceFromWarehouse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button btnSubmitLocationUpdate;
        private Button btnExitLocationUpdate;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private CheckBox chkLocationActive;
        private TextBox txtUpdateNotes;
        private Label label11;
        private TextBox txtUpdateLocation;
        private TextBox txtUpdateAddress;
        private TextBox txtUpdateCity;
        private TextBox txtUpdatePhone;
        private ComboBox cboUpdateProvince;
        private ComboBox cboUpdateCountry;
        private ComboBox cboUpdateDeliveryDay;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtUpdatePostalCode;
        private Label lblSiteID;
        private Label label9;
        private ComboBox cboUpdateLocationType;
        private NumericUpDown nudUpdateDistanceFromWarehouse;
    }
}