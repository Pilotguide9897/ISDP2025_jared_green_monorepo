namespace idsp2025_jared_green.Forms
{
    partial class frmModifyTxnRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyTxnRecord));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnUpdateTransaction = new Button();
            btnCancelTransactionEdit = new Button();
            label2 = new Label();
            lblEditTxnID = new Label();
            cboUpdateTxnStatus = new ComboBox();
            cboUpdateSiteFrom = new ComboBox();
            cboUpdateSiteTo = new ComboBox();
            txtUpdateBarcode = new TextBox();
            txtUpdateDelivery = new TextBox();
            chkSetEmergency = new CheckBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            dtpUpdateTxnDate = new DateTimePicker();
            label7 = new Label();
            lstTxnRecord = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(116, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(254, 40);
            label1.Name = "label1";
            label1.Size = new Size(515, 65);
            label1.TabIndex = 1;
            label1.Text = "Edit Transaction Details";
            // 
            // btnUpdateTransaction
            // 
            btnUpdateTransaction.Location = new Point(1041, 780);
            btnUpdateTransaction.Name = "btnUpdateTransaction";
            btnUpdateTransaction.Size = new Size(112, 34);
            btnUpdateTransaction.TabIndex = 2;
            btnUpdateTransaction.Text = "Save";
            btnUpdateTransaction.UseVisualStyleBackColor = true;
            btnUpdateTransaction.Click += btnUpdateTransaction_Click;
            // 
            // btnCancelTransactionEdit
            // 
            btnCancelTransactionEdit.Location = new Point(870, 780);
            btnCancelTransactionEdit.Name = "btnCancelTransactionEdit";
            btnCancelTransactionEdit.Size = new Size(112, 34);
            btnCancelTransactionEdit.TabIndex = 3;
            btnCancelTransactionEdit.Text = "Cancel";
            btnCancelTransactionEdit.UseVisualStyleBackColor = true;
            btnCancelTransactionEdit.Click += btnCancelTransactionEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(108, 162);
            label2.Name = "label2";
            label2.Size = new Size(169, 32);
            label2.TabIndex = 4;
            label2.Text = "Transaction ID:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEditTxnID
            // 
            lblEditTxnID.AutoSize = true;
            lblEditTxnID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditTxnID.Location = new Point(283, 162);
            lblEditTxnID.Name = "lblEditTxnID";
            lblEditTxnID.Size = new Size(78, 32);
            lblEditTxnID.TabIndex = 5;
            lblEditTxnID.Text = "label3";
            lblEditTxnID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboUpdateTxnStatus
            // 
            cboUpdateTxnStatus.FormattingEnabled = true;
            cboUpdateTxnStatus.Items.AddRange(new object[] { "ASSEMBLED", "ASSEMBLING", "CANCELLED", "COMPLETE", "DELIVERED", "IN TRANSIT", "NEW", "RECEIVED", "REJECTED", "SUBMITTED" });
            cboUpdateTxnStatus.Location = new Point(254, 312);
            cboUpdateTxnStatus.Name = "cboUpdateTxnStatus";
            cboUpdateTxnStatus.Size = new Size(378, 33);
            cboUpdateTxnStatus.TabIndex = 6;
            // 
            // cboUpdateSiteFrom
            // 
            cboUpdateSiteFrom.FormattingEnabled = true;
            cboUpdateSiteFrom.Location = new Point(254, 391);
            cboUpdateSiteFrom.Name = "cboUpdateSiteFrom";
            cboUpdateSiteFrom.Size = new Size(378, 33);
            cboUpdateSiteFrom.TabIndex = 8;
            // 
            // cboUpdateSiteTo
            // 
            cboUpdateSiteTo.FormattingEnabled = true;
            cboUpdateSiteTo.Location = new Point(254, 469);
            cboUpdateSiteTo.Name = "cboUpdateSiteTo";
            cboUpdateSiteTo.Size = new Size(378, 33);
            cboUpdateSiteTo.TabIndex = 9;
            // 
            // txtUpdateBarcode
            // 
            txtUpdateBarcode.Location = new Point(254, 547);
            txtUpdateBarcode.Name = "txtUpdateBarcode";
            txtUpdateBarcode.Size = new Size(378, 31);
            txtUpdateBarcode.TabIndex = 11;
            // 
            // txtUpdateDelivery
            // 
            txtUpdateDelivery.Location = new Point(254, 623);
            txtUpdateDelivery.Name = "txtUpdateDelivery";
            txtUpdateDelivery.Size = new Size(378, 31);
            txtUpdateDelivery.TabIndex = 12;
            // 
            // chkSetEmergency
            // 
            chkSetEmergency.AutoSize = true;
            chkSetEmergency.Location = new Point(439, 707);
            chkSetEmergency.Name = "chkSetEmergency";
            chkSetEmergency.Size = new Size(193, 29);
            chkSetEmergency.TabIndex = 13;
            chkSetEmergency.Text = "Emergency Delivery";
            chkSetEmergency.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 320);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 14;
            label3.Text = "Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(108, 399);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 16;
            label5.Text = "Site From:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(108, 477);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 17;
            label6.Text = "Site To:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(108, 553);
            label8.Name = "label8";
            label8.Size = new Size(80, 25);
            label8.TabIndex = 19;
            label8.Text = "Barcode:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(108, 629);
            label9.Name = "label9";
            label9.Size = new Size(102, 25);
            label9.TabIndex = 20;
            label9.Text = "Delivery ID:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(108, 242);
            label10.Name = "label10";
            label10.Size = new Size(53, 25);
            label10.TabIndex = 21;
            label10.Text = "Date:";
            // 
            // dtpUpdateTxnDate
            // 
            dtpUpdateTxnDate.Location = new Point(254, 236);
            dtpUpdateTxnDate.Name = "dtpUpdateTxnDate";
            dtpUpdateTxnDate.Size = new Size(204, 31);
            dtpUpdateTxnDate.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(721, 237);
            label7.Name = "label7";
            label7.Size = new Size(182, 28);
            label7.TabIndex = 24;
            label7.Text = "Transaction History:";
            // 
            // lstTxnRecord
            // 
            lstTxnRecord.FormattingEnabled = true;
            lstTxnRecord.ItemHeight = 25;
            lstTxnRecord.Location = new Point(721, 307);
            lstTxnRecord.Name = "lstTxnRecord";
            lstTxnRecord.Size = new Size(432, 429);
            lstTxnRecord.TabIndex = 25;
            // 
            // frmModifyTxnRecord
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 856);
            Controls.Add(lstTxnRecord);
            Controls.Add(label7);
            Controls.Add(dtpUpdateTxnDate);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(chkSetEmergency);
            Controls.Add(txtUpdateDelivery);
            Controls.Add(txtUpdateBarcode);
            Controls.Add(cboUpdateSiteTo);
            Controls.Add(cboUpdateSiteFrom);
            Controls.Add(cboUpdateTxnStatus);
            Controls.Add(lblEditTxnID);
            Controls.Add(label2);
            Controls.Add(btnCancelTransactionEdit);
            Controls.Add(btnUpdateTransaction);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmModifyTxnRecord";
            Text = "Bullseye Inventory Management System - Modify Transaction";
            Load += frmModifyTxnRecord_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button btnUpdateTransaction;
        private Button btnCancelTransactionEdit;
        private Label label2;
        private Label lblEditTxnID;
        private ComboBox cboUpdateTxnStatus;
        private ComboBox cboUpdateSiteFrom;
        private ComboBox cboUpdateSiteTo;
        private TextBox txtUpdateBarcode;
        private TextBox txtUpdateDelivery;
        private CheckBox chkSetEmergency;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private DateTimePicker dtpUpdateTxnDate;
        private Label label7;
        private ListBox lstTxnRecord;
    }
}