namespace idsp2025_jared_green.Forms
{
    partial class frmItemInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemInfo));
            label1 = new Label();
            picProductImage = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnClose = new Button();
            lblSupplier = new Label();
            lblProductName = new Label();
            panel1 = new Panel();
            txtDescription = new TextBox();
            txtPrice = new Label();
            txtCaseSize = new Label();
            txtWeight = new Label();
            lblCategory = new Label();
            lblSku = new Label();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(374, 65);
            label1.TabIndex = 1;
            label1.Text = "Product Details:";
            // 
            // picProductImage
            // 
            picProductImage.BackColor = Color.Gainsboro;
            picProductImage.Location = new Point(40, 88);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(433, 452);
            picProductImage.TabIndex = 2;
            picProductImage.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 14);
            label2.Name = "label2";
            label2.Size = new Size(110, 32);
            label2.TabIndex = 3;
            label2.Text = "Supplier:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 64);
            label3.Name = "label3";
            label3.Size = new Size(85, 32);
            label3.TabIndex = 4;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(546, 71);
            label4.Name = "label4";
            label4.Size = new Size(65, 32);
            label4.TabIndex = 5;
            label4.Text = "SKU:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 171);
            label5.Name = "label5";
            label5.Size = new Size(143, 32);
            label5.TabIndex = 6;
            label5.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 119);
            label6.Name = "label6";
            label6.Size = new Size(120, 32);
            label6.TabIndex = 7;
            label6.Text = "Category:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(14, 299);
            label7.Name = "label7";
            label7.Size = new Size(98, 32);
            label7.TabIndex = 8;
            label7.Text = "Weight:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 356);
            label8.Name = "label8";
            label8.Size = new Size(121, 32);
            label8.TabIndex = 9;
            label8.Text = "Case Size:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(14, 413);
            label9.Name = "label9";
            label9.Size = new Size(126, 32);
            label9.TabIndex = 10;
            label9.Text = "Unit Price:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1098, 561);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 11;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(167, 21);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(69, 25);
            lblSupplier.TabIndex = 12;
            lblSupplier.Text = "label10";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(167, 70);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(69, 25);
            lblProductName.TabIndex = 13;
            lblProductName.Text = "label11";
            lblProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(txtCaseSize);
            panel1.Controls.Add(txtWeight);
            panel1.Controls.Add(lblCategory);
            panel1.Controls.Add(lblSku);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblProductName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblSupplier);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(497, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(713, 452);
            panel1.TabIndex = 14;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Enabled = false;
            txtDescription.Location = new Point(173, 174);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(513, 106);
            txtDescription.TabIndex = 20;
            // 
            // txtPrice
            // 
            txtPrice.AutoSize = true;
            txtPrice.Location = new Point(167, 416);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(69, 25);
            txtPrice.TabIndex = 19;
            txtPrice.Text = "label17";
            txtPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCaseSize
            // 
            txtCaseSize.AutoSize = true;
            txtCaseSize.Location = new Point(167, 361);
            txtCaseSize.Name = "txtCaseSize";
            txtCaseSize.Size = new Size(69, 25);
            txtCaseSize.TabIndex = 18;
            txtCaseSize.Text = "label16";
            txtCaseSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtWeight
            // 
            txtWeight.AutoSize = true;
            txtWeight.Location = new Point(167, 303);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(69, 25);
            txtWeight.TabIndex = 17;
            txtWeight.Text = "label15";
            txtWeight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(167, 125);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(69, 25);
            lblCategory.TabIndex = 16;
            lblCategory.Text = "label14";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSku
            // 
            lblSku.AutoSize = true;
            lblSku.Location = new Point(617, 74);
            lblSku.Name = "lblSku";
            lblSku.Size = new Size(69, 25);
            lblSku.TabIndex = 14;
            lblSku.Text = "label12";
            lblSku.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmItemInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 619);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(picProductImage);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmItemInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Product Information";
            Load += frmItemInfo_Load;
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox picProductImage;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnClose;
        private Label lblSupplier;
        private Label lblProductName;
        private Panel panel1;
        private Label txtPrice;
        private Label txtCaseSize;
        private Label txtWeight;
        private Label lblCategory;
        private Label lblSku;
        private TextBox txtDescription;
    }
}