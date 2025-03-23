using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idsp2025_jared_green.Forms
{
    public partial class frmRemainLoggedIn : Form
    {

        // A windows class style flag that disables the close button.
        private const int CP_DISABLE_CLOSE_BUTTON = 0x200;

        public frmRemainLoggedIn()
        {
            InitializeComponent();
        }

        // Override the CreateParams method in Form class to disable the close button.
        // This override only applies to this form.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Add the disabling of the close button to the class style.
                cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
                return cp;
            }
        }


        private void frmRemainLoggedIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.DialogResult == DialogResult.OK)
            //{
                
            //}
        }

        private void btnRemainSignedIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmRemainLoggedIn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "Your inactivity timer has expired. Are you still there? Please confirm whether or not you would like to remain logged in.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
