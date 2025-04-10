namespace idsp2025_jared_green.Forms
{
    partial class frmAddSupplierProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSupplierProduct));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnAddSupplierProduct = new Button();
            btnExitProductAdd = new Button();
            txtNotes = new TextBox();
            txtProductName = new TextBox();
            txtDescription = new TextBox();
            txtCategory = new TextBox();
            btnAddImage = new Button();
            nudRetailPrice = new NumericUpDown();
            nudCaseSize = new NumericUpDown();
            nudWeight = new NumericUpDown();
            nudCostPrice = new NumericUpDown();
            cboSuppliers = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ofdAddImage = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRetailPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCaseSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCostPrice).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(33, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(220, 72);
            label1.Name = "label1";
            label1.Size = new Size(481, 65);
            label1.TabIndex = 1;
            label1.Text = "Add Supplier Product";
            // 
            // btnAddSupplierProduct
            // 
            btnAddSupplierProduct.Location = new Point(605, 808);
            btnAddSupplierProduct.Name = "btnAddSupplierProduct";
            btnAddSupplierProduct.Size = new Size(112, 34);
            btnAddSupplierProduct.TabIndex = 2;
            btnAddSupplierProduct.Text = "&Add";
            btnAddSupplierProduct.UseVisualStyleBackColor = true;
            btnAddSupplierProduct.Click += btnAddSupplierProduct_Click;
            // 
            // btnExitProductAdd
            // 
            btnExitProductAdd.Location = new Point(605, 868);
            btnExitProductAdd.Name = "btnExitProductAdd";
            btnExitProductAdd.Size = new Size(112, 34);
            btnExitProductAdd.TabIndex = 3;
            btnExitProductAdd.Text = "&Exit";
            btnExitProductAdd.UseVisualStyleBackColor = true;
            btnExitProductAdd.Click += btnExitProductAdd_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(104, 808);
            txtNotes.MaxLength = 255;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(453, 94);
            txtNotes.TabIndex = 4;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(366, 305);
            txtProductName.MaxLength = 100;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(284, 31);
            txtProductName.TabIndex = 5;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(104, 481);
            txtDescription.MaxLength = 255;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(546, 110);
            txtDescription.TabIndex = 6;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(366, 390);
            txtCategory.MaxLength = 32;
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(284, 31);
            txtCategory.TabIndex = 7;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(537, 165);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(112, 34);
            btnAddImage.TabIndex = 8;
            btnAddImage.Text = "Add Image";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // nudRetailPrice
            // 
            nudRetailPrice.DecimalPlaces = 2;
            nudRetailPrice.Location = new Point(537, 734);
            nudRetailPrice.Maximum = new decimal(new int[] { 1410065407, 2, 0, 131072 });
            nudRetailPrice.Name = "nudRetailPrice";
            nudRetailPrice.Size = new Size(180, 31);
            nudRetailPrice.TabIndex = 9;
            nudRetailPrice.Value = new decimal(new int[] { 2000, 0, 0, 131072 });
            // 
            // nudCaseSize
            // 
            nudCaseSize.Location = new Point(537, 650);
            nudCaseSize.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCaseSize.Name = "nudCaseSize";
            nudCaseSize.Size = new Size(180, 31);
            nudCaseSize.TabIndex = 10;
            nudCaseSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudWeight
            // 
            nudWeight.DecimalPlaces = 2;
            nudWeight.Location = new Point(204, 650);
            nudWeight.Maximum = new decimal(new int[] { 1410065407, 2, 0, 131072 });
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new Size(165, 31);
            nudWeight.TabIndex = 11;
            nudWeight.Value = new decimal(new int[] { 100, 0, 0, 131072 });
            // 
            // nudCostPrice
            // 
            nudCostPrice.DecimalPlaces = 2;
            nudCostPrice.Location = new Point(204, 734);
            nudCostPrice.Maximum = new decimal(new int[] { 1410065407, 2, 0, 131072 });
            nudCostPrice.Name = "nudCostPrice";
            nudCostPrice.Size = new Size(165, 31);
            nudCostPrice.TabIndex = 12;
            nudCostPrice.Value = new decimal(new int[] { 1000, 0, 0, 131072 });
            // 
            // cboSuppliers
            // 
            cboSuppliers.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSuppliers.FormattingEnabled = true;
            cboSuppliers.Location = new Point(366, 236);
            cboSuppliers.Name = "cboSuppliers";
            cboSuppliers.Size = new Size(284, 33);
            cboSuppliers.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 239);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 14;
            label2.Text = "Supplier:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 308);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 15;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(104, 396);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 16;
            label4.Text = "Category:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 453);
            label5.Name = "label5";
            label5.Size = new Size(106, 25);
            label5.TabIndex = 17;
            label5.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(104, 780);
            label6.Name = "label6";
            label6.Size = new Size(63, 25);
            label6.TabIndex = 18;
            label6.Text = "Notes:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(104, 656);
            label7.Name = "label7";
            label7.Size = new Size(72, 25);
            label7.TabIndex = 19;
            label7.Text = "Weight:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(104, 734);
            label8.Name = "label8";
            label8.Size = new Size(94, 25);
            label8.TabIndex = 20;
            label8.Text = "Cost Price:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(399, 652);
            label9.Name = "label9";
            label9.Size = new Size(89, 25);
            label9.TabIndex = 21;
            label9.Text = "Case Size:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(399, 734);
            label10.Name = "label10";
            label10.Size = new Size(100, 25);
            label10.TabIndex = 22;
            label10.Text = "Retail Price:";
            // 
            // ofdAddImage
            // 
            ofdAddImage.FileName = "openFileDialog1";
            // 
            // frmAddSupplierProduct
            // 
            AcceptButton = btnAddSupplierProduct;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitProductAdd;
            ClientSize = new Size(768, 939);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboSuppliers);
            Controls.Add(nudCostPrice);
            Controls.Add(nudWeight);
            Controls.Add(nudCaseSize);
            Controls.Add(nudRetailPrice);
            Controls.Add(btnAddImage);
            Controls.Add(txtCategory);
            Controls.Add(txtDescription);
            Controls.Add(txtProductName);
            Controls.Add(txtNotes);
            Controls.Add(btnExitProductAdd);
            Controls.Add(btnAddSupplierProduct);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAddSupplierProduct";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Add Supplier Product";
            Load += frmAddSupplierProduct_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRetailPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCaseSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCostPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button btnAddSupplierProduct;
        private Button btnExitProductAdd;
        private TextBox txtNotes;
        private TextBox txtProductName;
        private TextBox txtDescription;
        private TextBox txtCategory;
        private Button btnAddImage;
        private NumericUpDown nudRetailPrice;
        private NumericUpDown nudCaseSize;
        private NumericUpDown nudWeight;
        private NumericUpDown nudCostPrice;
        private ComboBox cboSuppliers;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private OpenFileDialog ofdAddImage;
    }
}