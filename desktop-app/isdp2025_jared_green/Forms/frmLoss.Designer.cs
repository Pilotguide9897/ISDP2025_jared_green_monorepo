namespace idsp2025_jared_green.Forms
{
    partial class frmLoss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoss));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            cboLossCategory = new ComboBox();
            textBox2 = new TextBox();
            cboProductName = new ComboBox();
            btnConfirmLoss = new Button();
            btnExitReportLoss = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cboLossSite = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(43, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 204);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(264, 91);
            label1.Name = "label1";
            label1.Size = new Size(274, 65);
            label1.TabIndex = 2;
            label1.Text = "Report Loss";
            // 
            // cboLossCategory
            // 
            cboLossCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLossCategory.FormattingEnabled = true;
            cboLossCategory.Items.AddRange(new object[] { "LOSS (e.g., Stolen, Missing)", "DAMAGE (e.g., Damaged Inventory)" });
            cboLossCategory.Location = new Point(225, 389);
            cboLossCategory.Name = "cboLossCategory";
            cboLossCategory.Size = new Size(301, 33);
            cboLossCategory.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(74, 479);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(454, 196);
            textBox2.TabIndex = 4;
            // 
            // cboProductName
            // 
            cboProductName.FormattingEnabled = true;
            cboProductName.Location = new Point(225, 275);
            cboProductName.Name = "cboProductName";
            cboProductName.Size = new Size(301, 33);
            cboProductName.TabIndex = 5;
            // 
            // btnConfirmLoss
            // 
            btnConfirmLoss.Location = new Point(395, 722);
            btnConfirmLoss.Name = "btnConfirmLoss";
            btnConfirmLoss.Size = new Size(112, 34);
            btnConfirmLoss.TabIndex = 6;
            btnConfirmLoss.Text = "Confirm";
            btnConfirmLoss.UseVisualStyleBackColor = true;
            btnConfirmLoss.Click += button1_Click;
            // 
            // btnExitReportLoss
            // 
            btnExitReportLoss.Location = new Point(395, 777);
            btnExitReportLoss.Name = "btnExitReportLoss";
            btnExitReportLoss.Size = new Size(112, 34);
            btnExitReportLoss.TabIndex = 7;
            btnExitReportLoss.Text = "Exit";
            btnExitReportLoss.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 278);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 8;
            label2.Text = "Product Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 393);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 9;
            label3.Text = "Loss Category:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(74, 451);
            label4.Name = "label4";
            label4.Size = new Size(210, 25);
            label4.TabIndex = 10;
            label4.Text = "Loss Description / Notes:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 333);
            label5.Name = "label5";
            label5.Size = new Size(45, 25);
            label5.TabIndex = 11;
            label5.Text = "Site:";
            // 
            // cboLossSite
            // 
            cboLossSite.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLossSite.FormattingEnabled = true;
            cboLossSite.Location = new Point(225, 332);
            cboLossSite.Name = "cboLossSite";
            cboLossSite.Size = new Size(301, 33);
            cboLossSite.TabIndex = 12;
            // 
            // frmLoss
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 847);
            Controls.Add(cboLossSite);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnExitReportLoss);
            Controls.Add(btnConfirmLoss);
            Controls.Add(cboProductName);
            Controls.Add(textBox2);
            Controls.Add(cboLossCategory);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLoss";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Report Loss";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox cboLossCategory;
        private TextBox textBox2;
        private ComboBox cboProductName;
        private Button btnConfirmLoss;
        private Button btnExitReportLoss;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboLossSite;
    }
}