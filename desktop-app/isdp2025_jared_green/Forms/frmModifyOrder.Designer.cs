namespace idsp2025_jared_green.Forms
{
    partial class frmModifyOrder
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyOrder));
            pictureBox1 = new PictureBox();
            btnExitModifyOrder = new Label();
            dgvOrderItems = new DataGridView();
            txtInventorySearch = new TextBox();
            btnSubmitOrder = new Button();
            btnExitWithoutSaving = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddToOrder = new Button();
            lblOrderType = new Label();
            bsOrderItems = new BindingSource(components);
            bsBullseyeInventory = new BindingSource(components);
            btnClearSearchBar = new Button();
            btnSaveAndExit = new Button();
            label4 = new Label();
            lblOrderID = new Label();
            dtpBackorderDate = new DateTimePicker();
            dgvBullseyeInventory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsBullseyeInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBullseyeInventory).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(79, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 170);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnExitModifyOrder
            // 
            btnExitModifyOrder.AutoSize = true;
            btnExitModifyOrder.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExitModifyOrder.Location = new Point(263, 86);
            btnExitModifyOrder.Name = "btnExitModifyOrder";
            btnExitModifyOrder.Size = new Size(458, 65);
            btnExitModifyOrder.TabIndex = 1;
            btnExitModifyOrder.Text = "Manage Store Order";
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.AllowUserToDeleteRows = false;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOrderItems.DefaultCellStyle = dataGridViewCellStyle1;
            dgvOrderItems.Location = new Point(79, 265);
            dgvOrderItems.MultiSelect = false;
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.RowHeadersWidth = 62;
            dgvOrderItems.Size = new Size(689, 666);
            dgvOrderItems.TabIndex = 2;
            dgvOrderItems.CellMouseEnter += dgvOrderItems_CellMouseEnter;
            // 
            // txtInventorySearch
            // 
            txtInventorySearch.Location = new Point(1019, 214);
            txtInventorySearch.Name = "txtInventorySearch";
            txtInventorySearch.Size = new Size(699, 31);
            txtInventorySearch.TabIndex = 4;
            txtInventorySearch.TextChanged += txtInventorySearch_TextChanged;
            // 
            // btnSubmitOrder
            // 
            btnSubmitOrder.Location = new Point(1715, 962);
            btnSubmitOrder.Name = "btnSubmitOrder";
            btnSubmitOrder.Size = new Size(112, 34);
            btnSubmitOrder.TabIndex = 5;
            btnSubmitOrder.Text = "Submit Order";
            btnSubmitOrder.UseVisualStyleBackColor = true;
            btnSubmitOrder.Click += btnSubmitOrder_Click;
            // 
            // btnExitWithoutSaving
            // 
            btnExitWithoutSaving.Location = new Point(1376, 962);
            btnExitWithoutSaving.Name = "btnExitWithoutSaving";
            btnExitWithoutSaving.Size = new Size(174, 34);
            btnExitWithoutSaving.TabIndex = 6;
            btnExitWithoutSaving.Text = "Exit Without Saving";
            btnExitWithoutSaving.UseVisualStyleBackColor = true;
            btnExitWithoutSaving.Click += btnExitWithoutSaving_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1614, 52);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 7;
            label1.Text = "Order Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 224);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 8;
            label2.Text = "Order Items";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(904, 220);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 9;
            label3.Text = "Item Search:";
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.BackgroundImage = Properties.Resources.vector_left_arrow_icon;
            btnAddToOrder.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddToOrder.Location = new Point(795, 565);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(75, 41);
            btnAddToOrder.TabIndex = 10;
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // lblOrderType
            // 
            lblOrderType.AutoSize = true;
            lblOrderType.Location = new Point(1724, 52);
            lblOrderType.Name = "lblOrderType";
            lblOrderType.Size = new Size(103, 25);
            lblOrderType.TabIndex = 11;
            lblOrderType.Text = "Placeholder";
            lblOrderType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClearSearchBar
            // 
            btnClearSearchBar.Location = new Point(1728, 215);
            btnClearSearchBar.Name = "btnClearSearchBar";
            btnClearSearchBar.Size = new Size(112, 34);
            btnClearSearchBar.TabIndex = 12;
            btnClearSearchBar.Text = "Clear";
            btnClearSearchBar.UseVisualStyleBackColor = true;
            btnClearSearchBar.Click += btnClearSearchBar_Click;
            // 
            // btnSaveAndExit
            // 
            btnSaveAndExit.Location = new Point(1565, 962);
            btnSaveAndExit.Name = "btnSaveAndExit";
            btnSaveAndExit.Size = new Size(135, 34);
            btnSaveAndExit.TabIndex = 13;
            btnSaveAndExit.Text = "Save and Exit";
            btnSaveAndExit.UseVisualStyleBackColor = true;
            btnSaveAndExit.Click += btnSaveAndExit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1614, 98);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 14;
            label4.Text = "Order ID:";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(1724, 98);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(103, 25);
            lblOrderID.TabIndex = 15;
            lblOrderID.Text = "Placeholder";
            lblOrderID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpBackorderDate
            // 
            dtpBackorderDate.Location = new Point(468, 219);
            dtpBackorderDate.Name = "dtpBackorderDate";
            dtpBackorderDate.Size = new Size(300, 31);
            dtpBackorderDate.TabIndex = 16;
            dtpBackorderDate.Visible = false;
            // 
            // dgvBullseyeInventory
            // 
            dgvBullseyeInventory.AllowUserToAddRows = false;
            dgvBullseyeInventory.AllowUserToDeleteRows = false;
            dgvBullseyeInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBullseyeInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvBullseyeInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBullseyeInventory.Location = new Point(908, 251);
            dgvBullseyeInventory.MultiSelect = false;
            dgvBullseyeInventory.Name = "dgvBullseyeInventory";
            dgvBullseyeInventory.ReadOnly = true;
            dgvBullseyeInventory.RowHeadersVisible = false;
            dgvBullseyeInventory.RowHeadersWidth = 62;
            dgvBullseyeInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBullseyeInventory.ShowEditingIcon = false;
            dgvBullseyeInventory.Size = new Size(936, 705);
            dgvBullseyeInventory.TabIndex = 3;
            // 
            // frmModifyOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.White_Background;
            ClientSize = new Size(1898, 1024);
            Controls.Add(dtpBackorderDate);
            Controls.Add(lblOrderID);
            Controls.Add(label4);
            Controls.Add(btnSaveAndExit);
            Controls.Add(btnClearSearchBar);
            Controls.Add(lblOrderType);
            Controls.Add(btnAddToOrder);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnExitWithoutSaving);
            Controls.Add(btnSubmitOrder);
            Controls.Add(txtInventorySearch);
            Controls.Add(dgvBullseyeInventory);
            Controls.Add(dgvOrderItems);
            Controls.Add(btnExitModifyOrder);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmModifyOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Order Form";
            Load += frmModifyOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsBullseyeInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBullseyeInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label btnExitModifyOrder;
        private DataGridView dgvOrderItems;
        private TextBox txtInventorySearch;
        private Button btnSubmitOrder;
        private Button btnExitWithoutSaving;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAddToOrder;
        private Label lblOrderType;
        private BindingSource bsOrderItems;
        private BindingSource bsBullseyeInventory;
        private Button btnClearSearchBar;
        private Button btnSaveAndExit;
        private Label label4;
        private Label lblOrderID;
        private DateTimePicker dtpBackorderDate;
        private DataGridView dgvBullseyeInventory;
    }
}