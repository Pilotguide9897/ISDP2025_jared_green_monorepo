namespace idsp2025_jared_green.Forms
{
    partial class frmReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturn));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtReasonForReturn = new TextBox();
            btnCompleteReturn = new Button();
            btnExitReturn = new Button();
            cboProductName = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            chkResalePossible = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(26, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 177);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(238, 76);
            label1.Name = "label1";
            label1.Size = new Size(353, 65);
            label1.TabIndex = 1;
            label1.Text = "Process Return";
            // 
            // txtReasonForReturn
            // 
            txtReasonForReturn.BorderStyle = BorderStyle.FixedSingle;
            txtReasonForReturn.Location = new Point(136, 372);
            txtReasonForReturn.Multiline = true;
            txtReasonForReturn.Name = "txtReasonForReturn";
            txtReasonForReturn.Size = new Size(431, 267);
            txtReasonForReturn.TabIndex = 2;
            txtReasonForReturn.Text = "\r\n";
            txtReasonForReturn.TextChanged += txtReasonForReturn_TextChanged;
            // 
            // btnCompleteReturn
            // 
            btnCompleteReturn.Location = new Point(439, 721);
            btnCompleteReturn.Name = "btnCompleteReturn";
            btnCompleteReturn.Size = new Size(112, 34);
            btnCompleteReturn.TabIndex = 4;
            btnCompleteReturn.Text = "&Complete";
            btnCompleteReturn.UseVisualStyleBackColor = true;
            // 
            // btnExitReturn
            // 
            btnExitReturn.Location = new Point(439, 772);
            btnExitReturn.Name = "btnExitReturn";
            btnExitReturn.Size = new Size(112, 34);
            btnExitReturn.TabIndex = 5;
            btnExitReturn.Text = "&Exit";
            btnExitReturn.UseVisualStyleBackColor = true;
            // 
            // cboProductName
            // 
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboProductName.FormattingEnabled = true;
            cboProductName.Location = new Point(285, 259);
            cboProductName.MaxDropDownItems = 15;
            cboProductName.Name = "cboProductName";
            cboProductName.Size = new Size(282, 33);
            cboProductName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 342);
            label2.Name = "label2";
            label2.Size = new Size(227, 25);
            label2.TabIndex = 7;
            label2.Text = "Reason for Return / Details:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 262);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 9;
            label4.Text = "Product Name:";
            // 
            // chkResalePossible
            // 
            chkResalePossible.AutoSize = true;
            chkResalePossible.Location = new Point(136, 670);
            chkResalePossible.Name = "chkResalePossible";
            chkResalePossible.Size = new Size(139, 29);
            chkResalePossible.TabIndex = 10;
            chkResalePossible.Text = "Fit for Resale";
            chkResalePossible.UseVisualStyleBackColor = true;
            // 
            // frmReturn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 833);
            Controls.Add(chkResalePossible);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(cboProductName);
            Controls.Add(btnExitReturn);
            Controls.Add(btnCompleteReturn);
            Controls.Add(txtReasonForReturn);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmReturn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Process Return";
            Load += frmReturn_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtReasonForReturn;
        private Button btnCompleteReturn;
        private Button btnExitReturn;
        private ComboBox cboProductName;
        private Label label2;
        private Label label4;
        private CheckBox chkResalePossible;
    }
}