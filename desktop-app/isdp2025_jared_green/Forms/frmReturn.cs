using idsp2025_jared_green.Interfaces.Controllers;
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
    public partial class frmReturn : Form
    {
        private readonly IInventoryController _inventoryController;

        public frmReturn(IInventoryController inventoryController)
        {
            _inventoryController = inventoryController;
            InitializeComponent();
        }

        private void txtReasonForReturn_TextChanged(object sender, EventArgs e)
        {

        }

        private async void frmReturn_Load(object sender, EventArgs e)
        {
            try
            {
                await InitializeFormAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}");
            }
        }

        private async Task InitializeFormAsync()
        {
            List<string> items = await _inventoryController.GetInventoryNames();
            cboProductName.DataSource = items.Order();
            cboProductName.SelectedIndex = 0;

        }
    }
}
