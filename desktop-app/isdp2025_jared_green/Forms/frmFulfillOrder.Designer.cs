namespace idsp2025_jared_green.Forms
{
    partial class frmFulfillOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFulfillOrder));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnMarkOrderFulfilled = new Button();
            btnExitFulfillment = new Button();
            pgbOrderFulfillment = new ProgressBar();
            dgvTransactionItems = new DataGridView();
            label2 = new Label();
            lblOrderID = new Label();
            label4 = new Label();
            bsOrderFulfillment = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderFulfillment).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 52);
            label1.Margin = new Padding(8, 0, 8, 0);
            label1.Name = "label1";
            label1.Size = new Size(285, 65);
            label1.TabIndex = 0;
            label1.Text = "FulFill Order";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(54, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 143);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnMarkOrderFulfilled
            // 
            btnMarkOrderFulfilled.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMarkOrderFulfilled.Location = new Point(1714, 946);
            btnMarkOrderFulfilled.Name = "btnMarkOrderFulfilled";
            btnMarkOrderFulfilled.Size = new Size(138, 34);
            btnMarkOrderFulfilled.TabIndex = 2;
            btnMarkOrderFulfilled.Text = "Mark Fulfilled";
            btnMarkOrderFulfilled.UseVisualStyleBackColor = true;
            btnMarkOrderFulfilled.Click += btnMarkOrderFulfilled_Click;
            // 
            // btnExitFulfillment
            // 
            btnExitFulfillment.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExitFulfillment.Location = new Point(1561, 946);
            btnExitFulfillment.Name = "btnExitFulfillment";
            btnExitFulfillment.Size = new Size(111, 34);
            btnExitFulfillment.TabIndex = 3;
            btnExitFulfillment.Text = "Exit";
            btnExitFulfillment.UseVisualStyleBackColor = true;
            btnExitFulfillment.Click += btnExitFulfillment_Click;
            // 
            // pgbOrderFulfillment
            // 
            pgbOrderFulfillment.Location = new Point(289, 946);
            pgbOrderFulfillment.Name = "pgbOrderFulfillment";
            pgbOrderFulfillment.Size = new Size(1207, 34);
            pgbOrderFulfillment.Style = ProgressBarStyle.Continuous;
            pgbOrderFulfillment.TabIndex = 4;
            // 
            // dgvTransactionItems
            // 
            dgvTransactionItems.AllowUserToAddRows = false;
            dgvTransactionItems.AllowUserToDeleteRows = false;
            dgvTransactionItems.AllowUserToResizeColumns = false;
            dgvTransactionItems.AllowUserToResizeRows = false;
            dgvTransactionItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactionItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactionItems.Location = new Point(54, 174);
            dgvTransactionItems.MultiSelect = false;
            dgvTransactionItems.Name = "dgvTransactionItems";
            dgvTransactionItems.ReadOnly = true;
            dgvTransactionItems.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactionItems.RowHeadersVisible = false;
            dgvTransactionItems.RowHeadersWidth = 62;
            dgvTransactionItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactionItems.Size = new Size(1798, 749);
            dgvTransactionItems.TabIndex = 5;
            dgvTransactionItems.CellContentClick += dgvTransactionItems_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1593, 78);
            label2.Name = "label2";
            label2.Size = new Size(110, 32);
            label2.TabIndex = 6;
            label2.Text = "Order ID:";
            // 
            // lblOrderID
            // 
            lblOrderID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderID.Location = new Point(1709, 75);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(143, 39);
            lblOrderID.TabIndex = 7;
            lblOrderID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(54, 946);
            label4.Name = "label4";
            label4.Size = new Size(230, 32);
            label4.TabIndex = 8;
            label4.Text = "Fulfillment Progress:";
            // 
            // frmFulfillOrder
            // 
            AutoScaleDimensions = new SizeF(27F, 65F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(label4);
            Controls.Add(lblOrderID);
            Controls.Add(label2);
            Controls.Add(dgvTransactionItems);
            Controls.Add(pgbOrderFulfillment);
            Controls.Add(btnExitFulfillment);
            Controls.Add(btnMarkOrderFulfilled);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(8);
            Name = "frmFulfillOrder";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Fulfill Order";
            Load += frmFulfillOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderFulfillment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button btnMarkOrderFulfilled;
        private Button btnExitFulfillment;
        private ProgressBar pgbOrderFulfillment;
        private DataGridView dgvTransactionItems;
        private Label label2;
        private Label lblOrderID;
        private Label label4;
        private BindingSource bsOrderFulfillment;
    }
}