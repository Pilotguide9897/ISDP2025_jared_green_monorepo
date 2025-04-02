namespace idsp2025_jared_green.Forms
{
    partial class frmAssignInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignInventory));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            dgvAllocatedInventory = new DataGridView();
            dgvRequestedInventory = new DataGridView();
            btnConfirmOrderReceived = new Button();
            bsRequestedInventory = new BindingSource(components);
            btnCancelAllocation = new Button();
            bsAssignedInventory = new BindingSource(components);
            btnCancelOrder = new Button();
            label4 = new Label();
            lblOrderID = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllocatedInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRequestedInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsRequestedInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsAssignedInventory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(266, 78);
            label1.Name = "label1";
            label1.Size = new Size(571, 65);
            label1.TabIndex = 0;
            label1.Text = "Assign Inventory to Order";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(66, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 165);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 218);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 2;
            label2.Text = "Allocated Inventory:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1089, 218);
            label3.Name = "label3";
            label3.Size = new Size(179, 25);
            label3.TabIndex = 3;
            label3.Text = "Requested Inventory:";
            // 
            // dgvAllocatedInventory
            // 
            dgvAllocatedInventory.AllowUserToAddRows = false;
            dgvAllocatedInventory.AllowUserToDeleteRows = false;
            dgvAllocatedInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllocatedInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAllocatedInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllocatedInventory.Location = new Point(66, 258);
            dgvAllocatedInventory.MultiSelect = false;
            dgvAllocatedInventory.Name = "dgvAllocatedInventory";
            dgvAllocatedInventory.RowHeadersVisible = false;
            dgvAllocatedInventory.RowHeadersWidth = 62;
            dgvAllocatedInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllocatedInventory.Size = new Size(966, 658);
            dgvAllocatedInventory.TabIndex = 4;
            dgvAllocatedInventory.CellMouseEnter += dgvAllocatedInventory_CellMouseEnter;
            // 
            // dgvRequestedInventory
            // 
            dgvRequestedInventory.AllowUserToAddRows = false;
            dgvRequestedInventory.AllowUserToDeleteRows = false;
            dgvRequestedInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequestedInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRequestedInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRequestedInventory.DefaultCellStyle = dataGridViewCellStyle1;
            dgvRequestedInventory.Location = new Point(1089, 258);
            dgvRequestedInventory.Name = "dgvRequestedInventory";
            dgvRequestedInventory.ReadOnly = true;
            dgvRequestedInventory.RowHeadersVisible = false;
            dgvRequestedInventory.RowHeadersWidth = 62;
            dgvRequestedInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequestedInventory.Size = new Size(763, 658);
            dgvRequestedInventory.TabIndex = 5;
            // 
            // btnConfirmOrderReceived
            // 
            btnConfirmOrderReceived.Location = new Point(1687, 943);
            btnConfirmOrderReceived.Name = "btnConfirmOrderReceived";
            btnConfirmOrderReceived.Size = new Size(165, 34);
            btnConfirmOrderReceived.TabIndex = 7;
            btnConfirmOrderReceived.Text = "Allocate Inventory";
            btnConfirmOrderReceived.UseVisualStyleBackColor = true;
            btnConfirmOrderReceived.Click += btnConfirmOrderReceived_Click;
            // 
            // btnCancelAllocation
            // 
            btnCancelAllocation.Location = new Point(1548, 943);
            btnCancelAllocation.Name = "btnCancelAllocation";
            btnCancelAllocation.Size = new Size(112, 34);
            btnCancelAllocation.TabIndex = 8;
            btnCancelAllocation.Text = "Exit";
            btnCancelAllocation.UseVisualStyleBackColor = true;
            btnCancelAllocation.Click += btnCancelAllocation_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Location = new Point(66, 943);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(122, 34);
            btnCancelOrder.TabIndex = 9;
            btnCancelOrder.Text = "Cancel Order";
            btnCancelOrder.UseVisualStyleBackColor = true;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1670, 110);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 10;
            label4.Text = "Order ID:";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(1793, 110);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(59, 25);
            lblOrderID.TabIndex = 11;
            lblOrderID.Text = "label5";
            // 
            // frmAssignInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1898, 1024);
            Controls.Add(lblOrderID);
            Controls.Add(label4);
            Controls.Add(btnCancelOrder);
            Controls.Add(btnCancelAllocation);
            Controls.Add(btnConfirmOrderReceived);
            Controls.Add(dgvRequestedInventory);
            Controls.Add(dgvAllocatedInventory);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAssignInventory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Assign Inventory";
            Load += frmAssignInventory_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllocatedInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRequestedInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsRequestedInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsAssignedInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private DataGridView dgvAllocatedInventory;
        private DataGridView dgvRequestedInventory;
        private Button btnConfirmOrderReceived;
        private BindingSource bsRequestedInventory;
        private Button btnCancelAllocation;
        private BindingSource bsAssignedInventory;
        private Button btnCancelOrder;
        private Label label4;
        private Label lblOrderID;
    }
}