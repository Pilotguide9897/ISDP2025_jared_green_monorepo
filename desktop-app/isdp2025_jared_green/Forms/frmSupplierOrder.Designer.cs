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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierOrder));
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            btnCloseSupplierOrder = new Button();
            btnCreateSupplierOrder = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAddToSupplierOrder = new Button();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(53, 329);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(756, 505);
            dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(896, 266);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(962, 652);
            dataGridView2.TabIndex = 2;
            // 
            // btnCloseSupplierOrder
            // 
            btnCloseSupplierOrder.Location = new Point(1605, 955);
            btnCloseSupplierOrder.Name = "btnCloseSupplierOrder";
            btnCloseSupplierOrder.Size = new Size(112, 34);
            btnCloseSupplierOrder.TabIndex = 3;
            btnCloseSupplierOrder.Text = "Exit";
            btnCloseSupplierOrder.UseVisualStyleBackColor = true;
            btnCloseSupplierOrder.Click += btnCloseSupplierOrder_Click;
            // 
            // btnCreateSupplierOrder
            // 
            btnCreateSupplierOrder.Location = new Point(1746, 955);
            btnCreateSupplierOrder.Name = "btnCreateSupplierOrder";
            btnCreateSupplierOrder.Size = new Size(112, 34);
            btnCreateSupplierOrder.TabIndex = 4;
            btnCreateSupplierOrder.Text = "Submit";
            btnCreateSupplierOrder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1625, 76);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1625, 152);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1746, 76);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 7;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1746, 152);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 8;
            label4.Text = "label4";
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
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(323, 112);
            label5.Name = "label5";
            label5.Size = new Size(339, 65);
            label5.TabIndex = 10;
            label5.Text = "Supplier Order";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1229, 227);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 11;
            label6.Text = "Product:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1313, 226);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(545, 31);
            textBox1.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(983, 224);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(218, 33);
            comboBox1.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(896, 227);
            label7.Name = "label7";
            label7.Size = new Size(81, 25);
            label7.TabIndex = 14;
            label7.Text = "Supplier:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(53, 286);
            label8.Name = "label8";
            label8.Size = new Size(44, 25);
            label8.TabIndex = 15;
            label8.Text = "Cart";
            // 
            // frmSupplierOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnAddToSupplierOrder);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCreateSupplierOrder);
            Controls.Add(btnCloseSupplierOrder);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSupplierOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Supplier Order";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button btnCloseSupplierOrder;
        private Button btnCreateSupplierOrder;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAddToSupplierOrder;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label7;
        private Label label8;
    }
}