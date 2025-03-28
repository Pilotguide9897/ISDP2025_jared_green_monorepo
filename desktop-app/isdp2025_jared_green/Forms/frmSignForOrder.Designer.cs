namespace idsp2025_jared_green.Forms
{
    partial class frmSignForOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignForOrder));
            btnCancelSigning = new Button();
            btnConfirmSigning = new Button();
            pnlCustomerSignature = new Panel();
            label1 = new Label();
            btnResetSignature = new Button();
            SuspendLayout();
            // 
            // btnCancelSigning
            // 
            btnCancelSigning.Location = new Point(744, 388);
            btnCancelSigning.Name = "btnCancelSigning";
            btnCancelSigning.Size = new Size(112, 34);
            btnCancelSigning.TabIndex = 0;
            btnCancelSigning.Text = "Cancel";
            btnCancelSigning.UseVisualStyleBackColor = true;
            btnCancelSigning.Click += btnCancelSigning_Click;
            // 
            // btnConfirmSigning
            // 
            btnConfirmSigning.Location = new Point(887, 388);
            btnConfirmSigning.Name = "btnConfirmSigning";
            btnConfirmSigning.Size = new Size(112, 34);
            btnConfirmSigning.TabIndex = 1;
            btnConfirmSigning.Text = "Submit";
            btnConfirmSigning.UseVisualStyleBackColor = true;
            btnConfirmSigning.Click += btnConfirmSigning_Click;
            // 
            // pnlCustomerSignature
            // 
            pnlCustomerSignature.Location = new Point(159, 23);
            pnlCustomerSignature.Name = "pnlCustomerSignature";
            pnlCustomerSignature.Size = new Size(840, 340);
            pnlCustomerSignature.TabIndex = 2;
            pnlCustomerSignature.MouseDown += pnlCustomerSignature_MouseDown;
            pnlCustomerSignature.MouseMove += pnlCustomerSignature_MouseMove;
            pnlCustomerSignature.MouseUp += pnlCustomerSignature_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 76);
            label1.TabIndex = 0;
            label1.Text = "Customer \r\nSignature:";
            // 
            // btnResetSignature
            // 
            btnResetSignature.Location = new Point(23, 329);
            btnResetSignature.Name = "btnResetSignature";
            btnResetSignature.Size = new Size(112, 34);
            btnResetSignature.TabIndex = 3;
            btnResetSignature.Text = "Reset";
            btnResetSignature.UseVisualStyleBackColor = true;
            btnResetSignature.Click += btnResetSignature_Click;
            // 
            // frmSignForOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 450);
            Controls.Add(btnResetSignature);
            Controls.Add(label1);
            Controls.Add(pnlCustomerSignature);
            Controls.Add(btnConfirmSigning);
            Controls.Add(btnCancelSigning);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSignForOrder";
            Text = "Customer Signature";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelSigning;
        private Button btnConfirmSigning;
        private Panel pnlCustomerSignature;
        private Label label1;
        private Button btnResetSignature;
    }
}