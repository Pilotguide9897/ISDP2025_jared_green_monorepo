namespace idsp2025_jared_green.Forms
{
    partial class frmAcceptStoreOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcceptStoreOrder));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            dgvOrderItems = new DataGridView();
            label3 = new Label();
            btnAcceptDelivery = new Button();
            btnExitAcceptDelivery = new Button();
            pnlManagerSignature = new Panel();
            btnResetSignature = new Button();
            lblOrderID = new Label();
            bsOrderArrival = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderArrival).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(94, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 171);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(303, 58);
            label1.Name = "label1";
            label1.Size = new Size(356, 65);
            label1.TabIndex = 1;
            label1.Text = "Accept Delivery";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(313, 143);
            label2.Name = "label2";
            label2.Size = new Size(114, 32);
            label2.TabIndex = 2;
            label2.Text = "Order ID:";
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.AllowUserToDeleteRows = false;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(94, 223);
            dgvOrderItems.MultiSelect = false;
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.RowHeadersWidth = 62;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.Size = new Size(1729, 621);
            dgvOrderItems.TabIndex = 3;
            dgvOrderItems.CellContentClick += dgvOrderItems_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(94, 872);
            label3.Name = "label3";
            label3.Size = new Size(203, 30);
            label3.TabIndex = 4;
            label3.Text = "Manager Signature:";
            // 
            // btnAcceptDelivery
            // 
            btnAcceptDelivery.Location = new Point(1694, 908);
            btnAcceptDelivery.Name = "btnAcceptDelivery";
            btnAcceptDelivery.Size = new Size(112, 34);
            btnAcceptDelivery.TabIndex = 5;
            btnAcceptDelivery.Text = "Accept";
            btnAcceptDelivery.UseVisualStyleBackColor = true;
            btnAcceptDelivery.Click += btnAcceptDelivery_Click;
            // 
            // btnExitAcceptDelivery
            // 
            btnExitAcceptDelivery.Location = new Point(1694, 972);
            btnExitAcceptDelivery.Name = "btnExitAcceptDelivery";
            btnExitAcceptDelivery.Size = new Size(112, 34);
            btnExitAcceptDelivery.TabIndex = 6;
            btnExitAcceptDelivery.Text = "Exit";
            btnExitAcceptDelivery.UseVisualStyleBackColor = true;
            btnExitAcceptDelivery.Click += btnExitAcceptDelivery_Click;
            // 
            // pnlManagerSignature
            // 
            pnlManagerSignature.Location = new Point(303, 872);
            pnlManagerSignature.Name = "pnlManagerSignature";
            pnlManagerSignature.Size = new Size(1366, 175);
            pnlManagerSignature.TabIndex = 8;
            pnlManagerSignature.MouseDown += pnlManagerSignature_MouseDown;
            pnlManagerSignature.MouseMove += pnlManagerSignature_MouseMove;
            pnlManagerSignature.MouseUp += pnlManagerSignature_MouseUp;
            // 
            // btnResetSignature
            // 
            btnResetSignature.Location = new Point(173, 923);
            btnResetSignature.Name = "btnResetSignature";
            btnResetSignature.Size = new Size(112, 34);
            btnResetSignature.TabIndex = 9;
            btnResetSignature.Text = "Reset";
            btnResetSignature.UseVisualStyleBackColor = true;
            btnResetSignature.Click += btnResetSignature_Click;
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderID.Location = new Point(433, 140);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(91, 38);
            lblOrderID.TabIndex = 10;
            lblOrderID.Text = "label4";
            // 
            // frmAcceptStoreOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1075);
            Controls.Add(lblOrderID);
            Controls.Add(btnResetSignature);
            Controls.Add(pnlManagerSignature);
            Controls.Add(btnExitAcceptDelivery);
            Controls.Add(btnAcceptDelivery);
            Controls.Add(label3);
            Controls.Add(dgvOrderItems);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAcceptStoreOrder";
            Text = "Bullseye Inventory Management System - Accept Store Order";
            Load += frmAcceptStoreOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderArrival).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private DataGridView dgvOrderItems;
        private Label label3;
        private Button btnAcceptDelivery;
        private Button btnExitAcceptDelivery;
        private Panel pnlManagerSignature;
        private Button btnResetSignature;
        private Label lblOrderID;
        private BindingSource bsOrderArrival;
    }
}