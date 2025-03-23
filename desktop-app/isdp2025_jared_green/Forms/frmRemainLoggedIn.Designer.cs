namespace idsp2025_jared_green.Forms
{
    partial class frmRemainLoggedIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemainLoggedIn));
            label1 = new Label();
            label2 = new Label();
            btnRemainSignedIn = new Button();
            btnExitApp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 34);
            label1.Name = "label1";
            label1.Size = new Size(491, 74);
            label1.TabIndex = 0;
            label1.Text = "Are you still there?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 152);
            label2.Name = "label2";
            label2.Size = new Size(633, 25);
            label2.TabIndex = 1;
            label2.Text = "Your session has expired due to inactivity. Would you like to remain logged in?";
            // 
            // btnRemainSignedIn
            // 
            btnRemainSignedIn.Location = new Point(393, 230);
            btnRemainSignedIn.Name = "btnRemainSignedIn";
            btnRemainSignedIn.Size = new Size(179, 34);
            btnRemainSignedIn.TabIndex = 1;
            btnRemainSignedIn.Text = "&Remain Logged In";
            btnRemainSignedIn.UseVisualStyleBackColor = true;
            btnRemainSignedIn.Click += btnRemainSignedIn_Click;
            // 
            // btnExitApp
            // 
            btnExitApp.Location = new Point(176, 230);
            btnExitApp.Name = "btnExitApp";
            btnExitApp.Size = new Size(112, 34);
            btnExitApp.TabIndex = 0;
            btnExitApp.Text = "&Exit";
            btnExitApp.UseVisualStyleBackColor = true;
            btnExitApp.Click += btnExitApp_Click;
            // 
            // frmRemainLoggedIn
            // 
            AcceptButton = btnRemainSignedIn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExitApp;
            ClientSize = new Size(732, 311);
            Controls.Add(btnExitApp);
            Controls.Add(btnRemainSignedIn);
            Controls.Add(label2);
            Controls.Add(label1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRemainLoggedIn";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bullseye Sporting Goods - Inventory Management System";
            FormClosing += frmRemainLoggedIn_FormClosing;
            HelpRequested += frmRemainLoggedIn_HelpRequested;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnRemainSignedIn;
        private Button btnExitApp;
    }
}