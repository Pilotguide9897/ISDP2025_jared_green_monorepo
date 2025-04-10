namespace idsp2025_jared_green.Forms
{
    partial class frmSelectItem
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectItem));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtSearchItem = new TextBox();
            dgvItemSelect = new DataGridView();
            btnConfirm = new Button();
            btnCancel = new Button();
            bsProductSearch = new BindingSource(components);
            ProductName = new DataGridViewTextBoxColumn();
            sku = new DataGridViewTextBoxColumn();
            supplier = new DataGridViewTextBoxColumn();
            category = new DataGridViewTextBoxColumn();
            Select = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItemSelect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsProductSearch).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(46, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(114, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(202, 41);
            label1.Name = "label1";
            label1.Size = new Size(394, 65);
            label1.TabIndex = 1;
            label1.Text = "Seach Product(s)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 144);
            label2.Name = "label2";
            label2.Size = new Size(150, 32);
            label2.TabIndex = 2;
            label2.Text = "Search Item:";
            // 
            // txtSearchItem
            // 
            txtSearchItem.Location = new Point(202, 144);
            txtSearchItem.Name = "txtSearchItem";
            txtSearchItem.Size = new Size(1015, 31);
            txtSearchItem.TabIndex = 3;
            txtSearchItem.TextChanged += txtSearchItem_TextChanged;
            // 
            // dgvItemSelect
            // 
            dgvItemSelect.AllowUserToAddRows = false;
            dgvItemSelect.AllowUserToDeleteRows = false;
            dgvItemSelect.AllowUserToResizeColumns = false;
            dgvItemSelect.AllowUserToResizeRows = false;
            dgvItemSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItemSelect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItemSelect.Columns.AddRange(new DataGridViewColumn[] { ProductName, sku, supplier, category, Select });
            dgvItemSelect.Location = new Point(46, 199);
            dgvItemSelect.MultiSelect = false;
            dgvItemSelect.Name = "dgvItemSelect";
            dgvItemSelect.RowHeadersVisible = false;
            dgvItemSelect.RowHeadersWidth = 62;
            dgvItemSelect.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvItemSelect.Size = new Size(1171, 404);
            dgvItemSelect.TabIndex = 4;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(1105, 618);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(112, 34);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(975, 618);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "\"Name\"";
            ProductName.HeaderText = "Product Name";
            ProductName.MinimumWidth = 8;
            ProductName.Name = "ProductName";
            // 
            // sku
            // 
            sku.DataPropertyName = "\"Sku\"";
            sku.HeaderText = "SKU";
            sku.MinimumWidth = 8;
            sku.Name = "sku";
            sku.ReadOnly = true;
            // 
            // supplier
            // 
            supplier.DataPropertyName = "\"Supplier.Name\"";
            supplier.HeaderText = "Supplier";
            supplier.MinimumWidth = 8;
            supplier.Name = "supplier";
            supplier.ReadOnly = true;
            // 
            // category
            // 
            category.DataPropertyName = "\"Category\"";
            category.HeaderText = "Category";
            category.MinimumWidth = 8;
            category.Name = "category";
            category.ReadOnly = true;
            // 
            // Select
            // 
            Select.DataPropertyName = "\"IsSelected\"";
            Select.HeaderText = "Select";
            Select.MinimumWidth = 8;
            Select.Name = "Select";
            // 
            // frmSelectItem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(dgvItemSelect);
            Controls.Add(txtSearchItem);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSelectItem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Select Item(s)";
            Load += frmSelectItem_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItemSelect).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsProductSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox txtSearchItem;
        private DataGridView dgvItemSelect;
        private Button btnConfirm;
        private Button btnCancel;
        private BindingSource bsProductSearch;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn sku;
        private DataGridViewTextBoxColumn supplier;
        private DataGridViewTextBoxColumn category;
        private DataGridViewCheckBoxColumn Select;
    }
}