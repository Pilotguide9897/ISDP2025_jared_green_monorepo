namespace idsp2025_jared_green.Forms
{
    partial class frmSupplierOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierOrder));
            pictureBox1 = new PictureBox();
            dgvSupplierOrderCart = new DataGridView();
            productName = new DataGridViewTextBoxColumn();
            supplier = new DataGridViewTextBoxColumn();
            quantityRequested = new CustomControls.DataGridViewNumericUpDownColumn();
            dgvSupplierInventory = new DataGridView();
            btnCloseSupplierOrder = new Button();
            btnCreateSupplierOrder = new Button();
            btnAddToSupplierOrder = new Button();
            label5 = new Label();
            label6 = new Label();
            txtSearchSupplierInventory = new TextBox();
            cboSuppliers = new ComboBox();
            label7 = new Label();
            bsSupplierOrderCart = new BindingSource(components);
            bsSupplierInventory = new BindingSource(components);
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierOrderCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsSupplierOrderCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsSupplierInventory).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(53, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 239);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dgvSupplierOrderCart
            // 
            dgvSupplierOrderCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplierOrderCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplierOrderCart.Columns.AddRange(new DataGridViewColumn[] { productName, supplier, quantityRequested });
            dgvSupplierOrderCart.Location = new Point(53, 329);
            dgvSupplierOrderCart.MultiSelect = false;
            dgvSupplierOrderCart.Name = "dgvSupplierOrderCart";
            dgvSupplierOrderCart.RowHeadersVisible = false;
            dgvSupplierOrderCart.RowHeadersWidth = 62;
            dgvSupplierOrderCart.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSupplierOrderCart.Size = new Size(756, 505);
            dgvSupplierOrderCart.TabIndex = 1;
            dgvSupplierOrderCart.CellValueChanged += dgvSupplierOrderCart_CellValueChanged;
            // 
            // productName
            // 
            productName.HeaderText = "Product Name";
            productName.MinimumWidth = 8;
            productName.Name = "productName";
            productName.ReadOnly = true;
            // 
            // supplier
            // 
            supplier.HeaderText = "Supplier";
            supplier.MinimumWidth = 8;
            supplier.Name = "supplier";
            supplier.ReadOnly = true;
            // 
            // quantityRequested
            // 
            quantityRequested.HeaderText = "Quantity Requested";
            quantityRequested.MinimumWidth = 8;
            quantityRequested.Name = "quantityRequested";
            quantityRequested.ReadOnly = true;
            // 
            // dgvSupplierInventory
            // 
            dgvSupplierInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplierInventory.Location = new Point(896, 272);
            dgvSupplierInventory.MultiSelect = false;
            dgvSupplierInventory.Name = "dgvSupplierInventory";
            dgvSupplierInventory.RowHeadersWidth = 62;
            dgvSupplierInventory.Size = new Size(962, 652);
            dgvSupplierInventory.TabIndex = 2;
            dgvSupplierInventory.CellDoubleClick += dgvSupplierInventory_CellDoubleClick;
            // 
            // btnCloseSupplierOrder
            // 
            btnCloseSupplierOrder.Location = new Point(1605, 955);
            btnCloseSupplierOrder.Name = "btnCloseSupplierOrder";
            btnCloseSupplierOrder.Size = new Size(112, 34);
            btnCloseSupplierOrder.TabIndex = 3;
            btnCloseSupplierOrder.Text = "&Exit";
            btnCloseSupplierOrder.UseVisualStyleBackColor = true;
            btnCloseSupplierOrder.Click += btnCloseSupplierOrder_Click;
            // 
            // btnCreateSupplierOrder
            // 
            btnCreateSupplierOrder.Location = new Point(1746, 955);
            btnCreateSupplierOrder.Name = "btnCreateSupplierOrder";
            btnCreateSupplierOrder.Size = new Size(112, 34);
            btnCreateSupplierOrder.TabIndex = 4;
            btnCreateSupplierOrder.Text = "&Submit";
            btnCreateSupplierOrder.UseVisualStyleBackColor = true;
            btnCreateSupplierOrder.Click += btnCreateSupplierOrder_Click;
            // 
            // btnAddToSupplierOrder
            // 
            btnAddToSupplierOrder.BackgroundImage = Properties.Resources.vector_left_arrow_icon;
            btnAddToSupplierOrder.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddToSupplierOrder.Location = new Point(820, 556);
            btnAddToSupplierOrder.Name = "btnAddToSupplierOrder";
            btnAddToSupplierOrder.Size = new Size(70, 45);
            btnAddToSupplierOrder.TabIndex = 9;
            btnAddToSupplierOrder.UseVisualStyleBackColor = true;
            btnAddToSupplierOrder.Click += btnAddToSupplierOrder_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(323, 112);
            label5.Name = "label5";
            label5.Size = new Size(350, 65);
            label5.TabIndex = 10;
            label5.Text = "Supplier Order";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(1229, 224);
            label6.Name = "label6";
            label6.Size = new Size(105, 32);
            label6.TabIndex = 11;
            label6.Text = "Product:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearchSupplierInventory
            // 
            txtSearchSupplierInventory.Location = new Point(1340, 226);
            txtSearchSupplierInventory.Name = "txtSearchSupplierInventory";
            txtSearchSupplierInventory.Size = new Size(518, 31);
            txtSearchSupplierInventory.TabIndex = 12;
            txtSearchSupplierInventory.TextChanged += txtSearchSupplierInventory_TextChanged;
            // 
            // cboSuppliers
            // 
            cboSuppliers.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSuppliers.FormattingEnabled = true;
            cboSuppliers.Location = new Point(1012, 224);
            cboSuppliers.Name = "cboSuppliers";
            cboSuppliers.Size = new Size(211, 33);
            cboSuppliers.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(896, 222);
            label7.Name = "label7";
            label7.Size = new Size(110, 32);
            label7.TabIndex = 14;
            label7.Text = "Supplier:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(53, 272);
            label8.Name = "label8";
            label8.Size = new Size(90, 45);
            label8.TabIndex = 15;
            label8.Text = "Cart:\r\n";
            // 
            // frmSupplierOrder
            // 
            AcceptButton = btnCreateSupplierOrder;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCloseSupplierOrder;
            ClientSize = new Size(1898, 1024);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cboSuppliers);
            Controls.Add(txtSearchSupplierInventory);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnAddToSupplierOrder);
            Controls.Add(btnCreateSupplierOrder);
            Controls.Add(btnCloseSupplierOrder);
            Controls.Add(dgvSupplierInventory);
            Controls.Add(dgvSupplierOrderCart);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSupplierOrder";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Supplier Order";
            Load += frmSupplierOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierOrderCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsSupplierOrderCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsSupplierInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvSupplierOrderCart;
        private DataGridView dgvSupplierInventory;
        private Button btnCloseSupplierOrder;
        private Button btnCreateSupplierOrder;
        private Button btnAddToSupplierOrder;
        private Label label5;
        private Label label6;
        private TextBox txtSearchSupplierInventory;
        private ComboBox cboSuppliers;
        private Label label7;
        private BindingSource bsSupplierOrderCart;
        private BindingSource bsSupplierInventory;
        private Label label8;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn supplier;
        private CustomControls.DataGridViewNumericUpDownColumn quantityRequested;
    }
}