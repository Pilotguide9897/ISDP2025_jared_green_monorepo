using idsp2025_jared_green.Entities;
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

namespace idsp2025_jared_green.Controllers
{
    public partial class frmEditInventory : Form
    {
        private readonly IInventoryController _inventoryController;
        private Inventory _inventory;
        public frmEditInventory(IInventoryController inventoryController, Inventory inventory)
        {
            _inventoryController = inventoryController;
            _inventory = inventory;

            InitializeComponent();

            nudMinimumThreshold.ValueChanged += new EventHandler(nudThreshold_ValueChanged);
            nudOptimumThreshold.ValueChanged += new EventHandler(nudThreshold_ValueChanged);
        }

        private async void btnSaveInvUpdate_Click(object sender, EventArgs e)
        {
            // Validate the inputs
            Inventory tempInv = new Inventory();
            tempInv.Notes = txtInventoryNotes.Text;
            tempInv.OptimumThreshold = (int)nudOptimumThreshold.Value;
            tempInv.ReorderThreshold = (int)nudMinimumThreshold.Value;
            await _inventoryController.UpdateInventory(_inventory, tempInv);
            this.Close();
        }

        private void btnCancelInvUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (nudOptimumThreshold.Value < nudMinimumThreshold.Value)
            {
                nudMinimumThreshold.Value = nudOptimumThreshold.Value;
            }
        }

        private void frmEditInventory_Load(object sender, EventArgs e)
        {
            lblItemName.Text = this.Tag.ToString();
            nudMinimumThreshold.Value = _inventory.ReorderThreshold;
            nudOptimumThreshold.Value = _inventory.OptimumThreshold;
            txtInventoryNotes.Text = _inventory.Notes;
        }
    }
}
