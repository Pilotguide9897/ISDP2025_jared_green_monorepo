﻿using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Forms.CustomControls;
using idsp2025_jared_green.Interfaces.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idsp2025_jared_green.Forms
{
    public partial class frmAssignInventory : Form
    {

        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private int _orderID;
        private int _employeeID;

        public frmAssignInventory(ITransactionController transactionController, IInventoryController inventoryController, int orderID, int employeeID)
        {
            _transactionController = transactionController;
            _inventoryController = inventoryController;
            _orderID = orderID;
            _employeeID = employeeID;
            InitializeComponent();
        }

        private async void frmAssignInventory_Load(object sender, EventArgs e)
        {
            Txn order = await _transactionController.GetOrderByID(_orderID);
            await _transactionController.UpdateTransactionStatus(_orderID, _employeeID, "ASSEMBLING");
            lblOrderID.Text = order.TxnId.ToString();
            setOrderRequest(order.Txnitems);
            setOrderAllocation(order.Txnitems);

            //dgvAllocatedInventory.Rows.Add(5);
            //MessageBox.Show(dgvAllocatedInventory.Rows[0].Cells[0].GetType().ToString());
            //for (int i = 0; i < 5; i++)
            //{
            //    {
            //        DataGridViewNumericUpDownCell cell = dgvAllocatedInventory.Rows[i].Cells[0] as DataGridViewNumericUpDownCell;
            //        cell.Increment = i + 1;
            //        cell.Value = i;

            //    }
            //}

            // Display the Original Order in the DGV to the Right
            //bsRequestedInventory.DataSource = await _transactionController.GetOrderByID(_orderID);
            //dgvRequestedInventory.DataSource = bsRequestedInventory;
        }

        private void setOrderRequest<T>(IEnumerable<T> dataSource)
        {
            bsRequestedInventory.DataSource = dataSource;
            dgvRequestedInventory.DataSource = bsRequestedInventory;
            dgvRequestedInventory.Columns["Txn"].Visible = false;
        }

        private async void setOrderAllocation<T>(IEnumerable<T> dataSource)
        {
            bsAssignedInventory.DataSource = dataSource;
            dgvAllocatedInventory.DataSource = bsAssignedInventory;

            // Add NumericUpDown Column
            if (!dgvAllocatedInventory.Columns.Contains("Allocated"))
            {
                DataGridViewNumericUpDownColumn numericColumn = new DataGridViewNumericUpDownColumn
                {
                    HeaderText = "Allocated",
                    Name = "Allocated",
                    Width = 150
                };
                dgvAllocatedInventory.Columns.Add(numericColumn);
            }

            dgvAllocatedInventory.Columns["Txn"].Visible = false;
            dgvAllocatedInventory.Columns["Quantity"].Visible = false;
            dgvAllocatedInventory.Columns["Notes"].Visible = false;

            // Ensure each row gets a properly configured NumericUpDown cell
            for (int i = 0; i < dgvAllocatedInventory.Rows.Count; i++)
            {
                if (dgvAllocatedInventory.Rows[i].Cells["Allocated"] is DataGridViewNumericUpDownCell numericCell)
                {
                    var txnItem = dataSource.ElementAt(i) as Txnitem;
                    if (txnItem != null)
                    {
                        int caseSize = txnItem.Item.CaseSize;
                        numericCell.Minimum = caseSize > 0 ? caseSize : 1;
                        numericCell.Increment = caseSize > 0 ? caseSize : 1;
                        numericCell.Value = txnItem.Quantity;
                        numericCell.Maximum = await _inventoryController.GetInventoryForLocationByItem(2, txnItem.ItemId, "0");
                    }
                }
            }
        }


        private async void btnConfirmOrderReceived_Click(object sender, EventArgs e)
        {
            await UpdateAllocatedQuantities();
            await UpdateOrderDeliveryDetails();
            await _transactionController.UpdateTransactionStatus(_orderID, _employeeID, "ASSEMBLING");
            this.Close();
        }

        private async Task UpdateAllocatedQuantities()
        {
            // Retrieve existing txn items for this order
            BindingList<Txnitem> itemList = await _transactionController.GetTxnItemsFromOrder(_orderID);

            foreach (DataGridViewRow row in dgvAllocatedInventory.Rows)
            {
                if (row.Cells["ItemId"].Value == null) continue; 

                int itemId = Convert.ToInt32(row.Cells[0].Value); 
                int allocatedQuantity = Convert.ToInt32(row.Cells[2].Value); 

                // Find the matching TxnItem object
                var existingItem = itemList.FirstOrDefault(item => item.ItemId == itemId);

                if (existingItem != null)
                {
                    // Update the quantity if it has changed
                    if (existingItem.Quantity != allocatedQuantity)
                    {
                        existingItem.Quantity = allocatedQuantity;
                    }
                }
                else
                {
                    // If it's a new allocation (item not previously assigned), add it
                    itemList.Add(new Txnitem
                    {
                        ItemId = itemId,
                        Quantity = allocatedQuantity,
                        TxnId = _orderID
                    });
                }
            }

            // Save updates to database
            await _transactionController.SaveChanges();
        }

        private async Task UpdateOrderDeliveryDetails()
        {
            BindingList<Txn> transactions = await _transactionController.GetAllTransactions();
            Txn? currentTransaction = (from tx in transactions where tx.TxnId == _orderID select tx).FirstOrDefault();
            if (currentTransaction != null) {
                List<Txn> locationTransactions = (from trans in transactions where trans.SiteIdfrom == currentTransaction.SiteIdfrom && trans.ShipDate == currentTransaction.ShipDate select trans).ToList();
                List<int> locationIds = new List<int>();
                List<int> deliveryIds = new List<int>();
                foreach (Txn locationTransaction in locationTransactions) 
                {
                    locationIds.Add(locationTransaction.TxnId);
                    deliveryIds.Add((int)locationTransaction.DeliveryId);
                }
                BindingList<dtoOrders> orders = await _transactionController.GetAllStoreOrdersForDelivery(locationIds);
                int orderWeight = (from ow in orders select ow).Sum(o => o.totalWeight);
                string vehicleType = "";

                if (orderWeight <= 1000) 
                {
                    vehicleType = "Van";
                } else if (orderWeight <= 5000)
                {
                    vehicleType = "Small";
                } else if (orderWeight <= 10000)
                {
                    vehicleType = "Medium";
                } else if (orderWeight <= 25000)
                {
                    vehicleType = "Heavy";
                } else
                {
                    throw new Exception("Order is too large. Please contact your manager.");
                }
                BindingList<Delivery> deliveries = await _transactionController.GetDeliveriesForDeliveryDate(deliveryIds);
                foreach (Delivery delivery in deliveries) 
                { 
                    delivery.VehicleType = vehicleType;
                }

                await _transactionController.SaveChanges();
            }
        }


        private async void btnCancelAllocation_Click(object sender, EventArgs e)
        {
            await _transactionController.UpdateTransactionStatus(_orderID, _employeeID, "RECEIVED");
            this.Close();
        }

        private void dgvAllocatedInventory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvAllocatedInventory.Columns.Count - 1)
            {
                dgvAllocatedInventory.CurrentCell = dgvAllocatedInventory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvAllocatedInventory.BeginEdit(true);
            }

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            _transactionController.UpdateTransactionStatus(_orderID, _employeeID, "CANCELLED");
        }
    }
}

