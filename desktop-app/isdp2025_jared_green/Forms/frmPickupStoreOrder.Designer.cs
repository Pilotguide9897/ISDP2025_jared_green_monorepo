namespace idsp2025_jared_green.Forms
{
    partial class frmPickupStoreOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPickupStoreOrder));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pnlDriverSignature = new Panel();
            btnAcceptOrderPickup = new Button();
            btnExitStoreOrderPickup = new Button();
            dgvOrderItems = new DataGridView();
            btnResetDriverSignature = new Button();
            label3 = new Label();
            lblStoreOrderId = new Label();
            bsPickupOrder = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsPickupOrder).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bullseye;
            pictureBox1.Location = new Point(45, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(159, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(228, 67);
            label1.Name = "label1";
            label1.Size = new Size(427, 65);
            label1.TabIndex = 1;
            label1.Text = "Pickup Store Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1570, 93);
            label2.Name = "label2";
            label2.Size = new Size(110, 32);
            label2.TabIndex = 2;
            label2.Text = "Order ID:";
            // 
            // pnlDriverSignature
            // 
            pnlDriverSignature.BackColor = SystemColors.Window;
            pnlDriverSignature.Location = new Point(333, 812);
            pnlDriverSignature.Name = "pnlDriverSignature";
            pnlDriverSignature.Size = new Size(1321, 165);
            pnlDriverSignature.TabIndex = 3;
            pnlDriverSignature.MouseDown += pnlDriverSignature_MouseDown;
            pnlDriverSignature.MouseMove += pnlDriverSignature_MouseMove;
            pnlDriverSignature.MouseUp += pnlDriverSignature_MouseUp;
            // 
            // btnAcceptOrderPickup
            // 
            btnAcceptOrderPickup.Location = new Point(1695, 847);
            btnAcceptOrderPickup.Name = "btnAcceptOrderPickup";
            btnAcceptOrderPickup.Size = new Size(112, 34);
            btnAcceptOrderPickup.TabIndex = 0;
            btnAcceptOrderPickup.Text = "Accept";
            btnAcceptOrderPickup.UseVisualStyleBackColor = true;
            btnAcceptOrderPickup.Click += btnAcceptOrderPickup_Click;
            // 
            // btnExitStoreOrderPickup
            // 
            btnExitStoreOrderPickup.Location = new Point(1695, 905);
            btnExitStoreOrderPickup.Name = "btnExitStoreOrderPickup";
            btnExitStoreOrderPickup.Size = new Size(112, 34);
            btnExitStoreOrderPickup.TabIndex = 4;
            btnExitStoreOrderPickup.Text = "Exit";
            btnExitStoreOrderPickup.UseVisualStyleBackColor = true;
            btnExitStoreOrderPickup.Click += btnExitStoreOrderPickup_Click;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(45, 203);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowHeadersWidth = 62;
            dgvOrderItems.Size = new Size(1800, 583);
            dgvOrderItems.TabIndex = 5;
            dgvOrderItems.CellContentClick += dgvOrderItems_CellContentClick;
            // 
            // btnResetDriverSignature
            // 
            btnResetDriverSignature.Location = new Point(190, 892);
            btnResetDriverSignature.Name = "btnResetDriverSignature";
            btnResetDriverSignature.Size = new Size(112, 34);
            btnResetDriverSignature.TabIndex = 0;
            btnResetDriverSignature.Text = "Reset";
            btnResetDriverSignature.UseVisualStyleBackColor = true;
            btnResetDriverSignature.Click += btnResetDriverSignature_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(159, 812);
            label3.Name = "label3";
            label3.Size = new Size(143, 25);
            label3.TabIndex = 6;
            label3.Text = "Driver Signature:";
            // 
            // lblStoreOrderId
            // 
            lblStoreOrderId.AutoSize = true;
            lblStoreOrderId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStoreOrderId.Location = new Point(1695, 93);
            lblStoreOrderId.Name = "lblStoreOrderId";
            lblStoreOrderId.Size = new Size(78, 32);
            lblStoreOrderId.TabIndex = 7;
            lblStoreOrderId.Text = "label4";
            lblStoreOrderId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmPickupStoreOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(lblStoreOrderId);
            Controls.Add(label3);
            Controls.Add(btnResetDriverSignature);
            Controls.Add(dgvOrderItems);
            Controls.Add(btnExitStoreOrderPickup);
            Controls.Add(btnAcceptOrderPickup);
            Controls.Add(pnlDriverSignature);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPickupStoreOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPickupStoreOrder";
            Load += frmPickupStoreOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsPickupOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Panel pnlDriverSignature;
        private Button btnAcceptOrderPickup;
        private Button btnExitStoreOrderPickup;
        private DataGridView dgvOrderItems;
        private Button btnResetDriverSignature;
        private Label label3;
        private Label lblStoreOrderId;
        private BindingSource bsPickupOrder;
    }
}