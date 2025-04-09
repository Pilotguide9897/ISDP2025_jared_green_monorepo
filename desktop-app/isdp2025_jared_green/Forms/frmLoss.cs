using idsp2025_jared_green.Controllers;
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
    public partial class frmLoss : Form
    {
        private readonly IInventoryController _inventoryController;
        private readonly IItemController _itemController;

        public frmLoss(IItemController itemController, IInventoryController inventoryController)
        {
            _inventoryController = inventoryController;
            _itemController = itemController;

            InitializeComponent();
        }

        private void frmLoss_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmLoss_Click(object sender, EventArgs e)
        {

        }

        private void btnExitReportLoss_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
