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
            txtLossDescription = new TextBox();
            cboProductName = new ComboBox();
            btnConfirmLoss = new Button();
            btnExitReportLoss = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cboLossSite = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lstLossItems = new TabPage();
            dgvLossItems = new DataGridView();
            Product = new DataGridViewTextBoxColumn();
            Quantity = new CustomControls.DataGridViewNumericUpDownColumn();
            btnRemoveLossItem = new Button();
            btnAddLossItem = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            lstLossItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLossItems).BeginInit();
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
            cboLossCategory.Location = new Point(168, 124);
            cboLossCategory.Name = "cboLossCategory";
            cboLossCategory.Size = new Size(301, 33);
            cboLossCategory.TabIndex = 3;
            // 
            // txtLossDescription
            // 
            txtLossDescription.Location = new Point(17, 214);
            txtLossDescription.MaxLength = 255;
            txtLossDescription.Multiline = true;
            txtLossDescription.Name = "txtLossDescription";
            txtLossDescription.Size = new Size(454, 196);
            txtLossDescription.TabIndex = 4;
            // 
            // cboProductName
            // 
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.FormattingEnabled = true;
            cboProductName.Location = new Point(168, 10);
            cboProductName.MaxDropDownItems = 15;
            cboProductName.Name = "cboProductName";
            cboProductName.Size = new Size(301, 33);
            cboProductName.TabIndex = 5;
            // 
            // btnConfirmLoss
            // 
            btnConfirmLoss.Location = new Point(395, 735);
            btnConfirmLoss.Name = "btnConfirmLoss";
            btnConfirmLoss.Size = new Size(112, 34);
            btnConfirmLoss.TabIndex = 6;
            btnConfirmLoss.Text = "&Confirm";
            btnConfirmLoss.UseVisualStyleBackColor = true;
            btnConfirmLoss.Click += btnConfirmLoss_Click;
            // 
            // btnExitReportLoss
            // 
            btnExitReportLoss.Location = new Point(395, 790);
            btnExitReportLoss.Name = "btnExitReportLoss";
            btnExitReportLoss.Size = new Size(112, 34);
            btnExitReportLoss.TabIndex = 7;
            btnExitReportLoss.Text = "&Exit";
            btnExitReportLoss.UseVisualStyleBackColor = true;
            btnExitReportLoss.Click += btnExitReportLoss_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 13);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 8;
            label2.Text = "Product Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 128);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 9;
            label3.Text = "Loss Category:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 186);
            label4.Name = "label4";
            label4.Size = new Size(210, 25);
            label4.TabIndex = 10;
            label4.Text = "Loss Description / Notes:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 68);
            label5.Name = "label5";
            label5.Size = new Size(45, 25);
            label5.TabIndex = 11;
            label5.Text = "Site:";
            // 
            // cboLossSite
            // 
            cboLossSite.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLossSite.FormattingEnabled = true;
            cboLossSite.Location = new Point(168, 67);
            cboLossSite.Name = "cboLossSite";
            cboLossSite.Size = new Size(301, 33);
            cboLossSite.TabIndex = 12;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(lstLossItems);
            tabControl1.Location = new Point(44, 243);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(494, 473);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtLossDescription);
            tabPage1.Controls.Add(cboLossSite);
            tabPage1.Controls.Add(cboLossCategory);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(cboProductName);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(486, 435);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Loss Details";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstLossItems
            // 
            lstLossItems.Controls.Add(dgvLossItems);
            lstLossItems.Controls.Add(btnRemoveLossItem);
            lstLossItems.Controls.Add(btnAddLossItem);
            lstLossItems.Location = new Point(4, 34);
            lstLossItems.Name = "lstLossItems";
            lstLossItems.Padding = new Padding(3);
            lstLossItems.Size = new Size(486, 435);
            lstLossItems.TabIndex = 1;
            lstLossItems.Text = "Loss Items";
            lstLossItems.UseVisualStyleBackColor = true;
            // 
            // dgvLossItems
            // 
            dgvLossItems.AllowUserToAddRows = false;
            dgvLossItems.AllowUserToDeleteRows = false;
            dgvLossItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLossItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLossItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLossItems.Columns.AddRange(new DataGridViewColumn[] { Product, Quantity });
            dgvLossItems.Location = new Point(6, 6);
            dgvLossItems.MultiSelect = false;
            dgvLossItems.Name = "dgvLossItems";
            dgvLossItems.RowHeadersVisible = false;
            dgvLossItems.RowHeadersWidth = 62;
            dgvLossItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLossItems.Size = new Size(474, 337);
            dgvLossItems.TabIndex = 3;
            // 
            // Product
            // 
            Product.HeaderText = "Product Name";
            Product.MinimumWidth = 8;
            Product.Name = "Product";
            Product.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            // 
            // btnRemoveLossItem
            // 
            btnRemoveLossItem.Location = new Point(182, 364);
            btnRemoveLossItem.Name = "btnRemoveLossItem";
            btnRemoveLossItem.Size = new Size(166, 34);
            btnRemoveLossItem.TabIndex = 2;
            btnRemoveLossItem.Text = "Remove Loss Item";
            btnRemoveLossItem.UseVisualStyleBackColor = true;
            btnRemoveLossItem.Click += btnRemoveLossItem_Click;
            // 
            // btnAddLossItem
            // 
            btnAddLossItem.Location = new Point(24, 364);
            btnAddLossItem.Name = "btnAddLossItem";
            btnAddLossItem.Size = new Size(143, 34);
            btnAddLossItem.TabIndex = 1;
            btnAddLossItem.Text = "Add Loss Item";
            btnAddLossItem.UseVisualStyleBackColor = true;
            btnAddLossItem.Click += btnAddLossItem_Click;
            // 
            // frmLoss
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 847);
            Controls.Add(tabControl1);
            Controls.Add(btnExitReportLoss);
            Controls.Add(btnConfirmLoss);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLoss";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Report Loss";
            Load += frmLoss_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            lstLossItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLossItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox cboLossCategory;
        private TextBox txtLossDescription;
        private ComboBox cboProductName;
        private Button btnConfirmLoss;
        private Button btnExitReportLoss;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboLossSite;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage lstLossItems;
        private Button btnRemoveLossItem;
        private Button btnAddLossItem;
        private DataGridView dgvLossItems;
        private DataGridViewTextBoxColumn Product;
        private CustomControls.DataGridViewNumericUpDownColumn Quantity;
    }
}