namespace idsp2025_jared_green.Forms
{
    partial class frmPrepareOnlineOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrepareOnlineOrder));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblOrderID = new Label();
            bsPrepareStoreOrder = new BindingSource(components);
            dgvPrepareOnlineOrder = new DataGridView();
            pgbOnlineOrderProgress = new ProgressBar();
            label3 = new Label();
            btnCancelPrepareOrder = new Button();
            btnMarkOrderPrepared = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsPrepareStoreOrder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrepareOnlineOrder).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(64, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 202);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(292, 72);
            label1.Name = "label1";
            label1.Size = new Size(555, 74);
            label1.TabIndex = 1;
            label1.Text = "Prepare Online Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1496, 108);
            label2.Name = "label2";
            label2.Size = new Size(130, 38);
            label2.TabIndex = 2;
            label2.Text = "Order ID:";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderID.Location = new Point(1632, 108);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(91, 38);
            lblOrderID.TabIndex = 3;
            lblOrderID.Text = "label3";
            // 
            // dgvPrepareOnlineOrder
            // 
            dgvPrepareOnlineOrder.AllowUserToAddRows = false;
            dgvPrepareOnlineOrder.AllowUserToDeleteRows = false;
            dgvPrepareOnlineOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrepareOnlineOrder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPrepareOnlineOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrepareOnlineOrder.Location = new Point(62, 251);
            dgvPrepareOnlineOrder.MultiSelect = false;
            dgvPrepareOnlineOrder.Name = "dgvPrepareOnlineOrder";
            dgvPrepareOnlineOrder.RowHeadersVisible = false;
            dgvPrepareOnlineOrder.RowHeadersWidth = 62;
            dgvPrepareOnlineOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrepareOnlineOrder.Size = new Size(1772, 673);
            dgvPrepareOnlineOrder.TabIndex = 4;
            dgvPrepareOnlineOrder.CellContentClick += dgvPrepareOnlineOrder_CellContentClick;
            // 
            // pgbOnlineOrderProgress
            // 
            pgbOnlineOrderProgress.Location = new Point(351, 949);
            pgbOnlineOrderProgress.Name = "pgbOnlineOrderProgress";
            pgbOnlineOrderProgress.Size = new Size(1146, 34);
            pgbOnlineOrderProgress.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(64, 945);
            label3.Name = "label3";
            label3.Size = new Size(281, 38);
            label3.TabIndex = 6;
            label3.Text = "Preparation Progress:";
            // 
            // btnCancelPrepareOrder
            // 
            btnCancelPrepareOrder.Location = new Point(1525, 949);
            btnCancelPrepareOrder.Name = "btnCancelPrepareOrder";
            btnCancelPrepareOrder.Size = new Size(143, 34);
            btnCancelPrepareOrder.TabIndex = 7;
            btnCancelPrepareOrder.Text = "Exit";
            btnCancelPrepareOrder.UseVisualStyleBackColor = true;
            btnCancelPrepareOrder.Click += btnCancelPrepareOrder_Click;
            // 
            // btnMarkOrderPrepared
            // 
            btnMarkOrderPrepared.Location = new Point(1691, 949);
            btnMarkOrderPrepared.Name = "btnMarkOrderPrepared";
            btnMarkOrderPrepared.Size = new Size(143, 34);
            btnMarkOrderPrepared.TabIndex = 8;
            btnMarkOrderPrepared.Text = "Mark Prepared";
            btnMarkOrderPrepared.UseVisualStyleBackColor = true;
            btnMarkOrderPrepared.Click += btnMarkOrderPrepared_Click;
            // 
            // frmPrepareOnlineOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnMarkOrderPrepared);
            Controls.Add(btnCancelPrepareOrder);
            Controls.Add(label3);
            Controls.Add(pgbOnlineOrderProgress);
            Controls.Add(dgvPrepareOnlineOrder);
            Controls.Add(lblOrderID);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPrepareOnlineOrder";
            Text = "Bullseye Inventory Management System - Prepare Online Order";
            Load += frmPrepareOnlineOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsPrepareStoreOrder).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrepareOnlineOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label lblOrderID;
        private BindingSource bsPrepareStoreOrder;
        private DataGridView dgvPrepareOnlineOrder;
        private ProgressBar pgbOnlineOrderProgress;
        private Label label3;
        private Button btnCancelPrepareOrder;
        private Button btnMarkOrderPrepared;
    }
}