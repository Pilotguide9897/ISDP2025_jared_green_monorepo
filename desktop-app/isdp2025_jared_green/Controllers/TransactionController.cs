using idsp2025_jared_green.Cron;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Services;
using IronBarCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green.Controllers
{

    public class TransactionController : ITransactionController
    {
        private readonly ITransaction _transactionService;
        private readonly ILocations _locationService;
        private readonly IInventory _inventoryService;

        public TransactionController(ITransaction transactionService, ILocations locations, IInventory inventoryService)
        {
            _transactionService = transactionService;
            _locationService = locations;
            _inventoryService = inventoryService;
        }

        public Task<BindingList<dtoOrderItem>> GetTxnItems(int txnID) 
        { 
            return _transactionService.GetTransactionItemsByTxnID(txnID);
        }

        public async Task<Txn> CreateBackorder(int employeeID, int siteIDFrom, string notes)
        {
            Txn newBackorder = new Txn();
            newBackorder.EmployeeId = employeeID;
            newBackorder.SiteIdfrom = siteIDFrom;
            newBackorder.SiteIdto = 2;

            Site location = await _locationService.GetLocationBySiteID(siteIDFrom);
            string deliveryDay = location.DayOfWeek;

            // Get the next day of that time
            DateOnly deliveryDate = DateTimeHelpers.CalculateNextBackorderDeliveryDate(deliveryDay);
            TimeOnly to = new();
            to.AddHours(12);

            newBackorder.ShipDate = deliveryDate.ToDateTime(to);

            newBackorder.TxnStatus = "NEW";
            newBackorder.TxnType = "Back Order";

            string barcodeData = Guid.NewGuid().ToString();
            newBackorder.BarCode = barcodeData;
            //var barcodeGen = BarcodeWriter.CreateBarcode(barcodeData, BarcodeWriterEncoding.Code93).SaveAsPng("barcode.png");
            // Convert the png from a png to bytes for storage.
            //byte[] barcodeAsBinary = barcodeGen.BinaryValue;
            //newBackorder.BarCode = Convert.ToBase64String(barcodeAsBinary);

            newBackorder.CreatedDate = DateTime.UtcNow;

            // Create the new delivery
            Delivery newDelivery = new Delivery();
            newDelivery.DeliveryDate = newBackorder.ShipDate;
            newDelivery.VehicleType = "Van";
            newDelivery.DistanceCost = 0.75m;
            newDelivery.Notes = "Placeholder";

            Delivery savedDelivery = await _transactionService.AddDelivery(newDelivery);

            newBackorder.DeliveryId = savedDelivery.DeliveryId;

            // newBackorder.DeliveryId = null;
            newBackorder.EmergencyDelivery = 0;
            newBackorder.Notes = notes;

            return await _transactionService.AddTransaction(newBackorder);
        }

        public async Task<Txn> CreateOrder(int employeeID, int siteIDFrom, int standardOrEmergency)
        {
            Txn newOrder = await _transactionService.CreateOrder(employeeID, siteIDFrom, standardOrEmergency);
            if (standardOrEmergency == 0)
            {
                return await AddDefaultItemsToOrder(employeeID, siteIDFrom, newOrder);
            } else
            {
                return newOrder;
            }
        }

        public async Task<Txn> AddDefaultItemsToOrder(int employeeID, int site, Txn newOrder)
        {
            if (newOrder != null)
            {

                BindingList<Inventory> requiredInventory = await _inventoryService.GetInventoryInNeedOfResupply(site);
                List<Txnitem> defaultItems = new List<Txnitem>();
                foreach (Inventory inventory in requiredInventory)
                {
                    Txnitem txnItem = new Txnitem();

                    int quantityToSupply = -1;
                    int delta = inventory.OptimumThreshold - inventory.Quantity;
                    int casesToOrder = delta / inventory.Item.CaseSize;
                    int remainder = delta % inventory.Item.CaseSize;
                    if (remainder > 0)
                    {
                        casesToOrder++;
                    }
                    txnItem.TxnId = newOrder.TxnId;
                    txnItem.ItemId = inventory.ItemId;
                    txnItem.Quantity = (casesToOrder * inventory.Item.CaseSize);

                    defaultItems.Add(txnItem);
                }
                newOrder.Txnitems = defaultItems;

                return await _transactionService.AddTransaction(newOrder);

            }
            return null;
        }

        public async Task<BindingList<Txn>> GetAllTransactions()
        {
            var result =  await _transactionService.GetAllTransactions();
            if (result is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<Txn>();
            } else
            {
                return result as BindingList<Txn>;
            }
        }

        public async Task<BindingList<dtoOrders>> GetAllStoreOrders()
        {
            return await _transactionService.GetAllOrders();

        }

        public async Task<Txn> GetOrder(int siteID, int standardOrEmergency)
        {
            return await _transactionService.CheckForOrder(siteID, standardOrEmergency);
        }

        public async Task<Txn> CheckForBackorder(int siteID)
        {
            return await _transactionService.CheckForBackorder(siteID);
        }

        public async Task<Txn> CheckForOrder(int siteID, int standardOrEmergency)
        {
            return await _transactionService.CheckForOrder(siteID, standardOrEmergency);
        }

        public async Task<Txn> CheckForEmergencyOrder(int siteID, int standardOrEmergency)
        {
            return await _transactionService.CheckForEmergencyOrder(siteID, standardOrEmergency);
        }

        public async Task<bool> CheckForOrderSubmission(int timeframe)
        {
            return await _transactionService.CheckForOrderSubmissions(timeframe);
        }

        public async Task<Txn> GetOrderByID(int orderID)
        {
            return await _transactionService.GetOrderByID(orderID);
        }

        public async Task<bool> UpdateTransactionStatus(int txnID, int employeeID, string updatedStatus)
        {
            Txn txn = await _transactionService.GetOrderByID(txnID);
            try
            {
                await _transactionService.UpdateOrderStatus(txn, employeeID, updatedStatus);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<BindingList<Txnitem>> GetTxnItemsFromOrder(int txnID)
        {
            return await _transactionService.GetTransactionItemsForOrder(txnID);
        }

        public async Task SaveChanges()
        {
            await _transactionService.UpdateTransaction();
        }

        public async Task SaveOrderItemChanges(int txnId, List<Txnitem> txnItems)
        {
            await _transactionService.UpdateOrderTransactionItems(txnId, txnItems);
        }

        public async Task<BindingList<dtoOrders>> GetAllStoreOrdersForDelivery(List<int> txnIDs)
        {
            return await _transactionService.GetAllOrdersForStoreForDelivery(txnIDs);
        }

        public async Task<BindingList<Delivery>> GetDeliveriesForDeliveryDate(List<int> txnIDs)
        {
            return await _transactionService.GetDeliveries(txnIDs);
        }

        public async Task UpdateBackorder(List<Txnitem> txnitems)
        {
            await _transactionService.UpdateBackorder(txnitems);
        }

        public async Task<bool> UpdateTransactionDetails(Txn transaction)
        {
            var trn = await _transactionService.SaveChangesToTransaction(transaction);
            if (trn is ErrorResult error) 
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else
            {
                return true;
            }
        }

        public async Task<List<Txnaudit>> GetTransactionAudit(int txnId)
        {
            var trn = await _transactionService.GetTransactionAudit(txnId);
            if (trn is ErrorResult error)
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Txnaudit>();
            }
            else
            {
                List<Txnaudit>? audit = trn as List<Txnaudit>;
                return audit;
            }
        }

        public async Task<BindingList<Txn>> GetOnlineOrdersForStores()
        {
            var trn = await _transactionService.GetOnlineOrders();
            if (trn is ErrorResult error)
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new BindingList<Txn>();
            }
            else
            {
                BindingList<Txn>? orders = trn as BindingList<Txn>;
                return orders;
            }
        }

        public async Task<Txn> RecordLoss(Txn loss)
        {
            var trn = await _transactionService.RecordLoss(loss);
            if (trn is ErrorResult error)
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Txn();
            }
            else
            {
                Txn orders = trn as Txn;
                return orders;
            }
        }

        public async Task<Txn> ProcessReturn(Txn rtrn)
        {
            var trn = await _transactionService.ProcessReturn(rtrn);
            if (trn is ErrorResult error)
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Txn();
            }
            else
            {
                Txn orders = trn as Txn;
                return orders;
            }
        }

        public async Task<Txn> CreateSupplierOrder()
        {
            //var trn = await _transactionService.ProcessReturn(rtrn);
            //if (trn is ErrorResult error)
            //{
            //    MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return new Txn();
            //}
            //else
            //{
            //    Txn orders = trn as Txn;
            //    return orders;
            //}
        }
    }
}
