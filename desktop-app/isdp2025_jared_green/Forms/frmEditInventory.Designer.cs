namespace idsp2025_jared_green.Controllers
{
    partial class frmEditInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditInventory));
            picLogoEditInventory = new PictureBox();
            label1 = new Label();
            nudMinimumThreshold = new NumericUpDown();
            nudOptimumThreshold = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            txtInventoryNotes = new TextBox();
            label4 = new Label();
            btnSaveInvUpdate = new Button();
            btnCancelInvUpdate = new Button();
            lblItemName = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogoEditInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinimumThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOptimumThreshold).BeginInit();
            SuspendLayout();
            // 
            // picLogoEditInventory
            // 
            picLogoEditInventory.Image = Properties.Resources.bullseye;
            picLogoEditInventory.Location = new Point(71, 28);
            picLogoEditInventory.Name = "picLogoEditInventory";
            picLogoEditInventory.Size = new Size(137, 129);
            picLogoEditInventory.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoEditInventory.TabIndex = 0;
            picLogoEditInventory.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(214, 28);
            label1.Name = "label1";
            label1.Size = new Size(320, 65);
            label1.TabIndex = 1;
            label1.Text = "Edit Inventory";
            // 
            // nudMinimumThreshold
            // 
            nudMinimumThreshold.Location = new Point(333, 240);
            nudMinimumThreshold.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMinimumThreshold.Name = "nudMinimumThreshold";
            nudMinimumThreshold.Size = new Size(180, 31);
            nudMinimumThreshold.TabIndex = 0;
            nudMinimumThreshold.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudMinimumThreshold.ValueChanged += nudThreshold_ValueChanged;
            // 
            // nudOptimumThreshold
            // 
            nudOptimumThreshold.Location = new Point(333, 309);
            nudOptimumThreshold.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudOptimumThreshold.Name = "nudOptimumThreshold";
            nudOptimumThreshold.Size = new Size(180, 31);
            nudOptimumThreshold.TabIndex = 1;
            nudOptimumThreshold.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 242);
            label2.Name = "label2";
            label2.Size = new Size(161, 25);
            label2.TabIndex = 4;
            label2.Text = "Reorder Threshold:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 311);
            label3.Name = "label3";
            label3.Size = new Size(176, 25);
            label3.TabIndex = 5;
            label3.Text = "Optimum Threshold:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtInventoryNotes
            // 
            txtInventoryNotes.Location = new Point(96, 394);
            txtInventoryNotes.MaxLength = 255;
            txtInventoryNotes.Multiline = true;
            txtInventoryNotes.Name = "txtInventoryNotes";
            txtInventoryNotes.Size = new Size(462, 243);
            txtInventoryNotes.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 366);
            label4.Name = "label4";
            label4.Size = new Size(63, 25);
            label4.TabIndex = 7;
            label4.Text = "Notes:";
            // 
            // btnSaveInvUpdate
            // 
            btnSaveInvUpdate.Location = new Point(446, 669);
            btnSaveInvUpdate.Name = "btnSaveInvUpdate";
            btnSaveInvUpdate.Size = new Size(112, 34);
            btnSaveInvUpdate.TabIndex = 8;
            btnSaveInvUpdate.Text = "Update";
            btnSaveInvUpdate.UseVisualStyleBackColor = true;
            btnSaveInvUpdate.Click += btnSaveInvUpdate_Click;
            // 
            // btnCancelInvUpdate
            // 
            btnCancelInvUpdate.Location = new Point(446, 719);
            btnCancelInvUpdate.Name = "btnCancelInvUpdate";
            btnCancelInvUpdate.Size = new Size(112, 34);
            btnCancelInvUpdate.TabIndex = 9;
            btnCancelInvUpdate.Text = "Cancel";
            btnCancelInvUpdate.UseVisualStyleBackColor = true;
            btnCancelInvUpdate.Click += btnCancelInvUpdate_Click;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemName.Location = new Point(74, 184);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(79, 32);
            lblItemName.TabIndex = 10;
            lblItemName.Text = "label5";
            // 
            // frmEditInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 786);
            Controls.Add(lblItemName);
            Controls.Add(btnCancelInvUpdate);
            Controls.Add(btnSaveInvUpdate);
            Controls.Add(label4);
            Controls.Add(txtInventoryNotes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudOptimumThreshold);
            Controls.Add(nudMinimumThreshold);
            Controls.Add(label1);
            Controls.Add(picLogoEditInventory);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEditInventory";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Inventory Management System - Edit Inventory";
            Load += frmEditInventory_Load;
            ((System.ComponentModel.ISupportInitialize)picLogoEditInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinimumThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOptimumThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogoEditInventory;
        private Label label1;
        private NumericUpDown nudMinimumThreshold;
        private NumericUpDown nudOptimumThreshold;
        private Label label2;
        private Label label3;
        private TextBox txtInventoryNotes;
        private Label label4;
        private Button btnSaveInvUpdate;
        private Button btnCancelInvUpdate;
        private Label lblItemName;
    }
}