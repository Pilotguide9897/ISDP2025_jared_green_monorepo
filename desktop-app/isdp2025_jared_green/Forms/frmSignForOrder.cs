using idsp2025_jared_green.Entities.dto;
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

namespace idsp2025_jared_green.Forms
{
    public partial class frmSignForOrder : Form
    {

        private bool _isDrawing = false;
        private Point _lastPoint;
        private Bitmap _signatureBitmap;
        private dtoOrders _orderDetails;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private readonly ILocationController _locationController;
        private readonly Employee _employee;

        public frmSignForOrder(ITransactionController transactionController, IInventoryController inventoryController, ILocationController locationController, Employee employee)
        {
            _transactionController = transactionController;
            _inventoryController = inventoryController;
            _locationController = locationController;
            _employee = employee;
            InitializeComponent();

            // Initialize Bitmap for drawing
            _signatureBitmap = new Bitmap(pnlCustomerSignature.Width, pnlCustomerSignature.Height);
            pnlCustomerSignature.BackgroundImage = _signatureBitmap;
        }

        private void btnCancelSigning_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnConfirmSigning_Click(object sender, EventArgs e)
        {
            try
            {
                BindingList<Site> bullseyeLocations = await _locationController.GetBullseyeLocations();
                Site site = (from loc in bullseyeLocations where loc.SiteId == _employee.SiteId select loc).FirstOrDefault();

                BindingList<dtoOrderItem> items = await _transactionController.GetTxnItems(_orderDetails.txnID);

                foreach (dtoOrderItem item in items)
                {

                    await _inventoryController.MoveInventory(site.SiteId, 10000, item.quantityRequested, item.itemID, "0", "Received by Customer");
                }

                await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "CLOSED");
                this.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnResetSignature_Click(object sender, EventArgs e)
        {
            using (Graphics graphics = Graphics.FromImage(_signatureBitmap))
            {
                graphics.Clear(Color.White);
                _isDrawing = false;
                _lastPoint = Point.Empty;
                pnlCustomerSignature.Invalidate();
            }
        }

        private void pnlCustomerSignature_MouseDown(object sender, MouseEventArgs e)
        {
            _isDrawing = true;
            _lastPoint = e.Location;
        }

        private void pnlCustomerSignature_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(_signatureBitmap))
                {
                    g.DrawLine(Pens.Black, _lastPoint, e.Location);
                }

                _lastPoint = e.Location;
                pnlCustomerSignature.Invalidate();
            }
        }

        private void pnlCustomerSignature_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
        }
    }
}



