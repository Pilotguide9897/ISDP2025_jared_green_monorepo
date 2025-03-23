using idsp2025_jared_green.Entities;
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
    public partial class frmConfirmUserDelete : Form
    {
        public frmConfirmUserDelete()
        {
            InitializeComponent();
        }

        private void btnConfirmUserDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelUserDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ApplyPermissions(List<Posn> employeePositions)
        {
            foreach (Posn position in employeePositions)
            {
                switch (position)
                {
                    //case :

                    //case :

                    //case :

                    default:
                        MessageBox.Show("Error: No permissions detected for deleting employee. Closing form");
                        this.Close();
                        break;
                }
            }
        }

        private void frmConfirmUserDelete_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "You can set an employee as incative, meaning that they are no longer an active employee of Bullseye. Click the 'confirm' button if you wish to proceed. Otherwise, click the exit button to exit without making any changes.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
