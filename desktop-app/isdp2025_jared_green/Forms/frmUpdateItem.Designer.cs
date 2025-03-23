namespace idsp2025_jared_green
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
            ((System.ComponentModel.ISupportInitialize)picItemImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picUpdateItemFrmLogo).BeginInit();
            SuspendLayout();
            // 
            // lblItemNameAndID
            // 
            lblItemNameAndID.AutoSize = true;
            lblItemNameAndID.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblItemNameAndID.Location = new Point(161, 18);
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
            picItemImage.Location = new Point(56, 173);
            picItemImage.Name = "picItemImage";
            picItemImage.Size = new Size(259, 207);
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom;
            picItemImage.TabIndex = 3;
            picItemImage.TabStop = false;
            // 
            // chkItemActive
            // 
            chkItemActive.AutoSize = true;
            chkItemActive.Location = new Point(428, 207);
            chkItemActive.Name = "chkItemActive";
            chkItemActive.Size = new Size(86, 29);
            chkItemActive.TabIndex = 0;
            chkItemActive.Text = "Active";
            chkItemActive.UseVisualStyleBackColor = true;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(365, 258);
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
            label2.Location = new Point(56, 403);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 6;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 554);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 7;
            label3.Text = "Notes:";
            // 
            // txtUpdateItemDescription
            // 
            txtUpdateItemDescription.Location = new Point(56, 431);
            txtUpdateItemDescription.MaxLength = 255;
            txtUpdateItemDescription.Multiline = true;
            txtUpdateItemDescription.Name = "txtUpdateItemDescription";
            txtUpdateItemDescription.Size = new Size(458, 109);
            txtUpdateItemDescription.TabIndex = 3;
            // 
            // txtUpdateItemNotes
            // 
            txtUpdateItemNotes.Location = new Point(56, 582);
            txtUpdateItemNotes.MaxLength = 255;
            txtUpdateItemNotes.Multiline = true;
            txtUpdateItemNotes.Name = "txtUpdateItemNotes";
            txtUpdateItemNotes.Size = new Size(458, 107);
            txtUpdateItemNotes.TabIndex = 4;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.Location = new Point(402, 720);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(112, 34);
            btnUpdateItem.TabIndex = 5;
            btnUpdateItem.Text = "&Update";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnCancelItemUpdate
            // 
            btnCancelItemUpdate.Location = new Point(402, 777);
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
            cboImageSelect.Location = new Point(365, 315);
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
            picUpdateItemFrmLogo.Size = new Size(84, 75);
            picUpdateItemFrmLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picUpdateItemFrmLogo.TabIndex = 13;
            picUpdateItemFrmLogo.TabStop = false;
            // 
            // frmUpdateItem
            // 
            AcceptButton = btnUpdateItem;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCancelItemUpdate;
            ClientSize = new Size(567, 842);
            Controls.Add(picUpdateItemFrmLogo);
            Controls.Add(cboImageSelect);
            Controls.Add(btnCancelItemUpdate);
            Controls.Add(btnUpdateItem);
            Controls.Add(txtUpdateItemNotes);
            Controls.Add(txtUpdateItemDescription);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnAddImage);
            Controls.Add(chkItemActive);
            Controls.Add(picItemImage);
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
    }
}