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
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            cboProductName = new ComboBox();
            label2 = new Label();
            label3 = new Label();
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
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(238, 76);
            label1.Name = "label1";
            label1.Size = new Size(340, 65);
            label1.TabIndex = 1;
            label1.Text = "Process Return";
            // 
            // txtReasonForReturn
            // 
            txtReasonForReturn.Location = new Point(136, 484);
            txtReasonForReturn.Multiline = true;
            txtReasonForReturn.Name = "txtReasonForReturn";
            txtReasonForReturn.Size = new Size(431, 267);
            txtReasonForReturn.TabIndex = 2;
            txtReasonForReturn.Text = "\r\n";
            txtReasonForReturn.TextChanged += txtReasonForReturn_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(285, 381);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(282, 33);
            comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(439, 842);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Complete";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(439, 893);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 5;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            // 
            // cboProductName
            // 
            cboProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboProductName.FormattingEnabled = true;
            cboProductName.Location = new Point(285, 294);
            cboProductName.Name = "cboProductName";
            cboProductName.Size = new Size(282, 33);
            cboProductName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 456);
            label2.Name = "label2";
            label2.Size = new Size(227, 25);
            label2.TabIndex = 7;
            label2.Text = "Reason for Return / Details:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 384);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 8;
            label3.Text = "Condition:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 297);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 9;
            label4.Text = "Product Name:";
            // 
            // chkResalePossible
            // 
            chkResalePossible.AutoSize = true;
            chkResalePossible.Location = new Point(136, 792);
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
            ClientSize = new Size(681, 938);
            Controls.Add(chkResalePossible);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboProductName);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(txtReasonForReturn);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmReturn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Process Return";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtReasonForReturn;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private ComboBox cboProductName;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox chkResalePossible;
    }
}