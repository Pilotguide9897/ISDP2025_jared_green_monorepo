﻿namespace idsp2025_jared_green.Forms
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
            button1 = new Button();
            btnExitProductAdd = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            btnAddImage = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
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
            // button1
            // 
            button1.Location = new Point(605, 808);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnExitProductAdd
            // 
            btnExitProductAdd.Location = new Point(605, 868);
            btnExitProductAdd.Name = "btnExitProductAdd";
            btnExitProductAdd.Size = new Size(112, 34);
            btnExitProductAdd.TabIndex = 3;
            btnExitProductAdd.Text = "Exit";
            btnExitProductAdd.UseVisualStyleBackColor = true;
            btnExitProductAdd.Click += btnExitProductAdd_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(104, 808);
            textBox1.MaxLength = 255;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(453, 94);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(366, 305);
            textBox2.MaxLength = 100;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(284, 31);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(104, 481);
            textBox3.MaxLength = 255;
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(546, 110);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(366, 390);
            textBox4.MaxLength = 32;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(284, 31);
            textBox4.TabIndex = 7;
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
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(537, 734);
            numericUpDown1.Maximum = new decimal(new int[] { 1410065407, 2, 0, 131072 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 31);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 2000, 0, 0, 131072 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(537, 650);
            numericUpDown2.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(180, 31);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Location = new Point(204, 650);
            numericUpDown3.Maximum = new decimal(new int[] { 1410065407, 2, 0, 131072 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(165, 31);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.Value = new decimal(new int[] { 100, 0, 0, 131072 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown4.Location = new Point(204, 734);
            numericUpDown4.Maximum = new decimal(new int[] { 1410065407, 2, 0, 131072 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(165, 31);
            numericUpDown4.TabIndex = 12;
            numericUpDown4.Value = new decimal(new int[] { 1000, 0, 0, 131072 });
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
            label6.Size = new Size(59, 25);
            label6.TabIndex = 18;
            label6.Text = "Notes";
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
            // frmAddSupplierProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(btnAddImage);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnExitProductAdd);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAddSupplierProduct";
            Text = "Bullseye Inventory Management System - Add Supplier Product";
            Load += frmAddSupplierProduct_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private Button btnExitProductAdd;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button btnAddImage;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
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
    }
}