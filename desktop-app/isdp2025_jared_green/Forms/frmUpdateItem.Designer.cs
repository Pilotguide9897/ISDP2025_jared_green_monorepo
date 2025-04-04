﻿namespace idsp2025_jared_green
{
    partial class frmUpdateItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateItem));
            lblItemNameAndID = new Label();
            label1 = new Label();
            lblItemSKU = new Label();
            picItemImage = new PictureBox();
            chkItemActive = new CheckBox();
            btnAddImage = new Button();
            label2 = new Label();
            label3 = new Label();
            txtUpdateItemDescription = new TextBox();
            txtUpdateItemNotes = new TextBox();
            btnUpdateItem = new Button();
            btnCancelItemUpdate = new Button();
            ofdAddImage = new OpenFileDialog();
            cboImageSelect = new ComboBox();
            picUpdateItemFrmLogo = new PictureBox();
            tabItemDetails = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)picItemImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picUpdateItemFrmLogo).BeginInit();
            tabItemDetails.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // lblItemNameAndID
            // 
            lblItemNameAndID.AutoSize = true;
            lblItemNameAndID.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblItemNameAndID.Location = new Point(169, 29);
            lblItemNameAndID.Name = "lblItemNameAndID";
            lblItemNameAndID.Size = new Size(290, 65);
            lblItemNameAndID.TabIndex = 0;
            lblItemNameAndID.Text = "Update Item";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 115);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 1;
            label1.Text = "SKU:";
            // 
            // lblItemSKU
            // 
            lblItemSKU.Location = new Point(110, 108);
            lblItemSKU.Name = "lblItemSKU";
            lblItemSKU.Size = new Size(88, 38);
            lblItemSKU.TabIndex = 2;
            lblItemSKU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picItemImage
            // 
            picItemImage.BackColor = Color.Gainsboro;
            picItemImage.Location = new Point(3, 6);
            picItemImage.Name = "picItemImage";
            picItemImage.Size = new Size(288, 217);
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom;
            picItemImage.TabIndex = 3;
            picItemImage.TabStop = false;
            // 
            // chkItemActive
            // 
            chkItemActive.AutoSize = true;
            chkItemActive.Location = new Point(375, 40);
            chkItemActive.Name = "chkItemActive";
            chkItemActive.Size = new Size(86, 29);
            chkItemActive.TabIndex = 0;
            chkItemActive.Text = "Active";
            chkItemActive.UseVisualStyleBackColor = true;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(312, 91);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(149, 34);
            btnAddImage.TabIndex = 1;
            btnAddImage.Text = "&Add Image";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 236);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 6;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 387);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 7;
            label3.Text = "Notes:";
            // 
            // txtUpdateItemDescription
            // 
            txtUpdateItemDescription.Location = new Point(3, 264);
            txtUpdateItemDescription.MaxLength = 255;
            txtUpdateItemDescription.Multiline = true;
            txtUpdateItemDescription.Name = "txtUpdateItemDescription";
            txtUpdateItemDescription.Size = new Size(458, 109);
            txtUpdateItemDescription.TabIndex = 3;
            // 
            // txtUpdateItemNotes
            // 
            txtUpdateItemNotes.Location = new Point(3, 415);
            txtUpdateItemNotes.MaxLength = 255;
            txtUpdateItemNotes.Multiline = true;
            txtUpdateItemNotes.Name = "txtUpdateItemNotes";
            txtUpdateItemNotes.Size = new Size(458, 119);
            txtUpdateItemNotes.TabIndex = 4;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.Location = new Point(400, 739);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(112, 34);
            btnUpdateItem.TabIndex = 5;
            btnUpdateItem.Text = "&Update";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnCancelItemUpdate
            // 
            btnCancelItemUpdate.Location = new Point(400, 796);
            btnCancelItemUpdate.Name = "btnCancelItemUpdate";
            btnCancelItemUpdate.Size = new Size(112, 34);
            btnCancelItemUpdate.TabIndex = 6;
            btnCancelItemUpdate.Text = "&Cancel";
            btnCancelItemUpdate.UseVisualStyleBackColor = true;
            btnCancelItemUpdate.Click += btnCancelItemUpdate_Click;
            // 
            // ofdAddImage
            // 
            ofdAddImage.DefaultExt = "png";
            ofdAddImage.FileName = "PictureTitle";
            ofdAddImage.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            ofdAddImage.Title = "Select an Image";
            // 
            // cboImageSelect
            // 
            cboImageSelect.FormattingEnabled = true;
            cboImageSelect.Location = new Point(312, 148);
            cboImageSelect.Name = "cboImageSelect";
            cboImageSelect.Size = new Size(149, 33);
            cboImageSelect.TabIndex = 2;
            cboImageSelect.Visible = false;
            cboImageSelect.SelectedIndexChanged += cboImageSelect_SelectedIndexChanged;
            // 
            // picUpdateItemFrmLogo
            // 
            picUpdateItemFrmLogo.Image = Properties.Resources.bullseye;
            picUpdateItemFrmLogo.Location = new Point(56, 15);
            picUpdateItemFrmLogo.Name = "picUpdateItemFrmLogo";
            picUpdateItemFrmLogo.Size = new Size(107, 90);
            picUpdateItemFrmLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picUpdateItemFrmLogo.TabIndex = 13;
            picUpdateItemFrmLogo.TabStop = false;
            // 
            // tabItemDetails
            // 
            tabItemDetails.Controls.Add(tabPage1);
            tabItemDetails.Controls.Add(tabPage2);
            tabItemDetails.Location = new Point(56, 149);
            tabItemDetails.Name = "tabItemDetails";
            tabItemDetails.SelectedIndex = 0;
            tabItemDetails.Size = new Size(472, 572);
            tabItemDetails.TabIndex = 14;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(picItemImage);
            tabPage1.Controls.Add(chkItemActive);
            tabPage1.Controls.Add(cboImageSelect);
            tabPage1.Controls.Add(btnAddImage);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtUpdateItemNotes);
            tabPage1.Controls.Add(txtUpdateItemDescription);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(464, 534);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Item Overview";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(numericUpDown2);
            tabPage2.Controls.Add(numericUpDown1);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(464, 534);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Item Particulars";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 31);
            textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(158, 148);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(254, 31);
            textBox2.TabIndex = 16;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(157, 247);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(254, 33);
            comboBox1.TabIndex = 17;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(158, 348);
            numericUpDown1.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(252, 31);
            numericUpDown1.TabIndex = 18;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Location = new Point(158, 447);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(252, 31);
            numericUpDown2.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 55);
            label4.Name = "label4";
            label4.Size = new Size(63, 25);
            label4.TabIndex = 20;
            label4.Text = "Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 148);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 21;
            label5.Text = "Category:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 250);
            label6.Name = "label6";
            label6.Size = new Size(81, 25);
            label6.TabIndex = 22;
            label6.Text = "Supplier:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 350);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 23;
            label7.Text = "Case Size:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(45, 453);
            label8.Name = "label8";
            label8.Size = new Size(72, 25);
            label8.TabIndex = 24;
            label8.Text = "Weight:";
            // 
            // frmUpdateItem
            // 
            AcceptButton = btnUpdateItem;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCancelItemUpdate;
            ClientSize = new Size(596, 842);
            Controls.Add(tabItemDetails);
            Controls.Add(picUpdateItemFrmLogo);
            Controls.Add(btnCancelItemUpdate);
            Controls.Add(btnUpdateItem);
            Controls.Add(lblItemSKU);
            Controls.Add(label1);
            Controls.Add(lblItemNameAndID);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUpdateItem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management - Update Item";
            Load += frmUpdateItem_Load;
            HelpRequested += frmUpdateItem_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)picItemImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)picUpdateItemFrmLogo).EndInit();
            tabItemDetails.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblItemNameAndID;
        private Label label1;
        private Label lblItemSKU;
        private PictureBox picItemImage;
        private CheckBox chkItemActive;
        private Button btnAddImage;
        private Label label2;
        private Label label3;
        private TextBox txtUpdateItemDescription;
        private TextBox txtUpdateItemNotes;
        private Button btnUpdateItem;
        private Button btnCancelItemUpdate;
        private OpenFileDialog ofdAddImage;
        private ComboBox cboImageSelect;
        private PictureBox picUpdateItemFrmLogo;
        private TabControl tabItemDetails;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}