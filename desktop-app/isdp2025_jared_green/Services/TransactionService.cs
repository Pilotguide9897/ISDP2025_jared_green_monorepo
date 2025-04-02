using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using NodaTime;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Loggers;
using System.Security.Policy;
using Site = idsp2025_jared_green.Entities.Site;
using idsp2025_jared_green.Error;

namespace idsp2025_jared_green.Services
{
    internal class TransactionService : ITransaction
    {
        public readonly BullseyeContext _bullseyeContext;
        private static readonly NLog.Logger _transactionLogger = NLog.LogManager.GetCurrentClassLogger();

        public TransactionService(BullseyeContext bullseyeContext) 
        { 
            _bullseyeContext = bullseyeContext;
        }

        public async Task<BindingList<dtoOrders>> GetAllOrders()
        {
            try
            {
                // Use a left join to prevent leaving out orders that do not have any txn items assigned to them yet...
                var orders = await (from txn in _bullseyeContext.Txns
                                    join ste in _bullseyeContext.Sites on txn.SiteIdfrom equals ste.SiteId
                                    join txnItm in _bullseyeContext.Txnitems on txn.TxnId equals txnItm.TxnId into txnItemsGroup
                                    from txnItm in txnItemsGroup.DefaultIfEmpty()
                                    join itm in _bullseyeContext.Items on txnItm.ItemId equals itm.ItemId into itemsGroup
                                    from itm in itemsGroup.DefaultIfEmpty()
                                    join dlv in _bullseyeContext.Deliveries on txn.DeliveryId equals dlv.DeliveryId into deliveriesGroup
                                    from dlv in deliveriesGroup.DefaultIfEmpty()
                                    group new { txnItm, itm } by new
                                    {
                                        txn.TxnId,
                                        ste.SiteName,
                                        txn.TxnStatus,
                                        ste.DayOfWeek,
                                        txn.TxnType,
                                        txn.Delivery.DeliveryDate
                                    } into g
                                    where g.Key.TxnType == "Store Order" || g.Key.TxnType == "Back Order" || g.Key.TxnType == "Emergency Order"
                                    select new
                                    {
                                        ID = g.Key.TxnId,
                                        Type = g.Key.TxnType,
                                        Location = g.Key.SiteName,
                                        Status = g.Key.TxnStatus,
                                        ItemCount = g.Sum(x => x.txnItm != null ? x.txnItm.Quantity : 0),
                                        TotalWeight = Math.Ceiling(g.Sum(x => x.txnItm != null && x.itm != null ? x.txnItm.Quantity * x.itm.Weight : 0)),
                                        DeliveryDate = g.Key.DeliveryDate != null ? DateOnly.FromDateTime(g.Key.DeliveryDate) : (DateOnly?)null
                                    }).ToListAsync();


                BindingList<dtoOrders> ordDetails = new BindingList<dtoOrders>();

                foreach (var order in orders)
                {
                    dtoOrders o = new dtoOrders();
                    o.txnID = order.ID;
                    o.siteName = order.Location;
                    o.txnType = order.Type;
                    o.txnStatus = order.Status;
                    o.deliveryDate = order.DeliveryDate;
                    o.itemCount = order.ItemCount;
                    o.totalWeight = (int) order.TotalWeight;

                    ordDetails.Add(o);
                }

                BindingList<dtoOrders> result = new BindingList<dtoOrders>(ordDetails);
                
                return result;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the orders. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while fetching the orders. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the orders. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<object> GetAllTransactions()
        {
            try
            {
                var transactions = await(from tx in _bullseyeContext.Txns
                                   select tx).Include(x => x.Txnitems).ToListAsync();

                if (transactions.Count > 0)
                {
                    var bindingList = new BindingList<Txn>(transactions);

                    return bindingList;
                }

                return new ErrorResult("NO_DATA", "The database contains no supplier data to return");

            }
            catch (MySqlException msqlEx)
            {
                _transactionLogger.Error(msqlEx, "Database error occurred when requesting a supplier.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _transactionLogger.Error(toEx, "Operation timed out when requesting a supplier.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _transactionLogger.Error(ex, "An unexpected error occurred when requesting a supplier.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }


        public async Task<Txn> AddTransaction(Txn transaction)
        {
            // TransactionLogger.LogTransaction();
            try
            {
                // await _bullseyeContext.Txns.AddAsync(transaction);
                _bullseyeContext.Update(transaction);
                await _bullseyeContext.SaveChangesAsync();
                return transaction;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while creating the new order. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while creating the new order. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while creating the new order. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> UpdateTransaction(Txn updatedTransaction)
        {
            try
            {
                _bullseyeContext.Txns.Attach(updatedTransaction);
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while updating the order's details. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while updating the order's details. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating the order's details. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                foreach (Txnitem txnitem in updatedTransaction.Txnitems)
                {
                    Txnitem? existingItem = await (from item in _bullseyeContext.Txnitems
                                                   where item.TxnId == txnitem.TxnId && item.ItemId == txnitem.ItemId
                                                   select item).FirstOrDefaultAsync();
                    if (existingItem != null)
                    {
                        _bullseyeContext.Entry(txnitem).State = EntityState.Modified;
                    }
                    else
                    {
                        _bullseyeContext.Entry(txnitem).State = EntityState.Added;
                    }
                }
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while updating the order's items. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while updating order's items. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating the order's items. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // TransactionLogger.LogTransactionUpdate();
            await _bullseyeContext.SaveChangesAsync(); 
            return true;
        }

        public async Task<BindingList<dtoOrderItem>> GetTransactionItemsByTxnID(int txnID)
        {
            try
            {
                var txnItemsWithDetails = await (from t  in _bullseyeContext.Txns
                                                 join ti in _bullseyeContext.Txnitems on t.TxnId equals ti.TxnId
                                                 join itm in _bullseyeContext.Items on ti.ItemId equals itm.ItemId
                                                 join inv in _bullseyeContext.Inventories on itm.ItemId equals inv.ItemId
                                                 where inv.SiteId == 2 && t.TxnId == txnID
                                                 select new
                                                 {
                                                     Item_ID = ti.ItemId,
                                                     Item_Name = itm.Name,
                                                     Requested_Quantity = ti.Quantity,
                                                     Quantity_Warehouse = inv.Quantity,
                                                 }).ToListAsync();

                BindingList<dtoOrderItem> txnItems = new BindingList<dtoOrderItem>();

                foreach (var item in txnItemsWithDetails)
                {
                    dtoOrderItem dto = new dtoOrderItem();
                    dto.itemID = item.Item_ID;
                    dto.productName = item.Item_Name;
                    dto.quantityRequested = item.Requested_Quantity;
                    dto.quantityAtWarehouse = item.Quantity_Warehouse;
                    txnItems.Add(dto);
                }

                return txnItems;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the transactions. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while fetching the transactions. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the transactions. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Txn> CheckForBackorder(int siteID)
        {
            try
            {
                Txn? backorder = await (from txn in _bullseyeContext.Txns
                                       where txn.SiteIdfrom == siteID && txn.TxnStatus == "NEW" && txn.TxnType == "Back Order"
                                       select txn).FirstOrDefaultAsync();
                return backorder;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while checking for any existing backorders. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while checking for any existing backorders. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while checking for any existing backorders. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Txn> CreateBackorder(Txn backorder)
        {
            try
            {
                await _bullseyeContext.AddAsync(backorder);
                return backorder;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while creating the backorder. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while creating the backorder. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while creating the backorder. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> UpdateBackorder(List<Txnitem> newTxnItems)
        {
            try
            {
                await _bullseyeContext.AddRangeAsync(newTxnItems);
                await _bullseyeContext.SaveChangesAsync();
                return true;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while saving the order changes.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while saving the order changes. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while saving the order changes. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public async Task<bool> CreateOrder(Txn order)
        {
            try
            {
                await _bullseyeContext.AddAsync(order);
                return true;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while creating the order. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while creating the order. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while creating the order. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<Txn> CheckForOrder(int siteID, int standardOrEmergency)
        {
            try
            {
                Txn? order = await (from txn in _bullseyeContext.Txns
                                        where txn.SiteIdfrom == siteID && txn.TxnStatus == "NEW" && txn.TxnType == "Store Order" && txn.EmergencyDelivery == standardOrEmergency
                                        select txn).Include(t => t.Txnitems).FirstOrDefaultAsync();
                return order;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while checking for any orders in progress. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while checking for any orders in progress. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while checking for any orders in progress. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Txn> CheckForEmergencyOrder(int siteID, int standardOrEmergency)
        {
            try
            {
                Txn? order = await (from txn in _bullseyeContext.Txns
                                    where txn.SiteIdfrom == siteID && txn.TxnStatus == "NEW" && txn.TxnType == "Emergency Order" && txn.EmergencyDelivery == standardOrEmergency
                                    select txn).Include(t => t.Txnitems).FirstOrDefaultAsync();
                return order;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while checking for any orders in progress. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while checking for any orders in progress. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while checking for any orders in progress. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> UpdateTransaction()
        {
            try
            {
                await _bullseyeContext.SaveChangesAsync();
                return true;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while saving the order changes.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while saving the order changes. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while saving the order changes. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public async Task<bool> UpdateOrderTransactionItems(int transactionId, List<Txnitem> newItems)
        {
            try
            {
                // Load the transaction and include existing items
                Txn? order = await _bullseyeContext.Txns
                    .Include(txn => txn.Txnitems)  
                    .FirstOrDefaultAsync(txn => txn.TxnId == transactionId);

                if (order == null)
                    return false;

                // Initialize Txnitems if it is null
                if (order.Txnitems == null)
                    order.Txnitems = new List<Txnitem>();

                // **Add new items to the order**
                foreach (var item in newItems)
                {
                    bool itemExists = order.Txnitems.Any(ti => ti.ItemId == item.ItemId && ti.TxnId == order.TxnId);
                    if (!itemExists)
                    {
                        order.Txnitems.Add(item);
                        _bullseyeContext.Txnitems.Add(item); 
                    }
                }

                // Save changes
                await _bullseyeContext.SaveChangesAsync();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("A database error occurred while saving the order changes.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException)
            {
                MessageBox.Show("The operation timed out while saving the order changes. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred while saving the order changes. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public async Task<Txn> CreateOrder(int employeeID, int siteID, int standardOrEmergency)
        {
            Txn newTxn = new Txn();
            newTxn.EmployeeId = employeeID;
            newTxn.SiteIdfrom = siteID;
            newTxn.SiteIdto = 2;
            newTxn.TxnStatus = "NEW";
            if (standardOrEmergency == 1)
            {
                newTxn.ShipDate = DateTime.Today.AddDays(1);
            }
            else
            {

                Site? site = await (from st in _bullseyeContext.Sites where st.SiteId == siteID select st).FirstOrDefaultAsync();
                if (site == null)
                {
                    // Log the error
                    return null;
                }

                newTxn.ShipDate = DateTimeHelpers.CalculateNextStandardDeliveryDate(site.DayOfWeek).ToDateTime(new TimeOnly(12,0,0));
            }

            if (standardOrEmergency == 1)
            {
                newTxn.TxnType = "Emergency Order";
            } else
            {
                newTxn.TxnType = "Store Order";
            }

            newTxn.CreatedDate = DateTime.Now;

            Delivery scheduledDelivery = await (from del in _bullseyeContext.Deliveries where del.DeliveryDate == newTxn.ShipDate select del).FirstOrDefaultAsync();

            if (scheduledDelivery == null) {
                Delivery newDelivery = new Delivery();
                newDelivery.DeliveryDate = newTxn.ShipDate;
                newDelivery.VehicleType = "Van";


                if (newTxn.TxnType == "Emergency Order")
                {
                    newDelivery.DistanceCost = 0;
                }
                else
                {
                    newDelivery.DistanceCost = 0.75m;
                }
                newDelivery.Notes = "Placeholder";

                Delivery savedDelivery = await AddDelivery(newDelivery);

                newTxn.DeliveryId = savedDelivery.DeliveryId;
            } else
            {
                newTxn.DeliveryId = scheduledDelivery.DeliveryId;
            }

            if (standardOrEmergency == 1)
            {
                newTxn.EmergencyDelivery = 1;
            }
            else
            {
                newTxn.EmergencyDelivery = 0;
            }
            newTxn.Notes = "";
            //newTxn.BarCode = "0";
            newTxn.BarCode = Guid.NewGuid().ToString();

            await _bullseyeContext.AddAsync(newTxn);
            await _bullseyeContext.SaveChangesAsync();
            return newTxn;
        }

        public async Task<Delivery> AddDelivery(Delivery delivery)
        {
            try
            {
                await _bullseyeContext.AddAsync(delivery);
                await _bullseyeContext.SaveChangesAsync();

                return delivery;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while scheduling the delivery for the order. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while scheduling the delivery for the order. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while scheduling the delivery for the order. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> CheckForOrderSubmissions(int timeframeInMs)
        {
            try
            {
                int orders = await (from txn in _bullseyeContext.Txns
                                   where (txn.TxnType == "Store Order" || txn.TxnType == "Emergency Order") && txn.CreatedDate > (DateTime.Now - TimeSpan.FromMilliseconds(timeframeInMs)) && txn.TxnStatus == "SUBMITTED"
                                   select txn).CountAsync();

                return orders > 0;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while checking for new store orders. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while checking for new store orders. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while checking for new store orders. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task UpdateOrderStatus(Txn order, int employeeID, string newStatus)
        {
            order.TxnStatus = newStatus;
            order.EmployeeId = employeeID;
            await _bullseyeContext.SaveChangesAsync();
        }

        public async Task<Txn> GetOrderByID(int orderID)
        {
            try
            {

                Txn? order = await (from txn in _bullseyeContext.Txns
                                    where txn.TxnId == orderID
                                    select txn).Include(d => d.Delivery).Include(t => t.Txnitems).ThenInclude(ti => ti.Item).FirstOrDefaultAsync();

                return order;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show($"A database error occurred while fetching the order details for order {orderID}. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show($"The operation timed out while fetching the order details for order {orderID}. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while fetching the order details for order {orderID}. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<BindingList<Txnitem>> GetTransactionItemsForOrder(int txnID)
        {
            try
            {
                var orders = await(from txn in _bullseyeContext.Txnitems
                                   where txn.TxnId == txnID
                                   select txn).ToListAsync();


                BindingList<Txnitem> ordDetails = new BindingList<Txnitem>(orders);

                return ordDetails;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the orders. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while fetching the orders. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the orders. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<BindingList<dtoOrders>> GetAllOrdersForStoreForDelivery(List<int> txnIDs)
        {
            try { 
                var orders = await (from txn in _bullseyeContext.Txns
                            join ste in _bullseyeContext.Sites on txn.SiteIdfrom equals ste.SiteId
                            join txnItm in _bullseyeContext.Txnitems on txn.TxnId equals txnItm.TxnId into txnItemsGroup
                            from txnItm in txnItemsGroup.DefaultIfEmpty()
                            join itm in _bullseyeContext.Items on txnItm.ItemId equals itm.ItemId into itemsGroup
                            from itm in itemsGroup.DefaultIfEmpty()
                            join dlv in _bullseyeContext.Deliveries on txn.DeliveryId equals dlv.DeliveryId into deliveriesGroup
                            from dlv in deliveriesGroup.DefaultIfEmpty()
                            where txnIDs.Contains(txn.TxnId)
                            group new { txnItm, itm } by new
                            {
                                txn.TxnId,
                                ste.SiteName,
                                txn.TxnStatus,
                                ste.DayOfWeek,
                                txn.TxnType,
                                txn.Delivery.DeliveryDate
                            } into g
                            where g.Key.TxnType == "Store Order" || g.Key.TxnType == "Back Order" || g.Key.TxnType == "Emergency Order" 
                            select new
                            {
                                ID = g.Key.TxnId,
                                Type = g.Key.TxnType,
                                Location = g.Key.SiteName,
                                Status = g.Key.TxnStatus,
                                ItemCount = g.Sum(x => x.txnItm != null ? x.txnItm.Quantity : 0),
                                TotalWeight = Math.Ceiling(g.Sum(x => x.txnItm != null && x.itm != null ? x.txnItm.Quantity * x.itm.Weight : 0)),
                                DeliveryDate = g.Key.DeliveryDate != null ? DateOnly.FromDateTime(g.Key.DeliveryDate) : (DateOnly?)null
                            }).ToListAsync();


                BindingList<dtoOrders> ordDetails = new BindingList<dtoOrders>();

                foreach (var order in orders)
                {
                    // MessageBox.Show($"{order.Location}, {order.Status}, {order.ItemCount}, {order.TotalWeight}, {order.DeliveryDate}");
                    dtoOrders o = new dtoOrders();
                    o.txnID = order.ID;
                    o.siteName = order.Location;
                    o.txnType = order.Type;
                    o.txnStatus = order.Status;
                    o.deliveryDate = order.DeliveryDate;
                    o.itemCount = order.ItemCount;
                    o.totalWeight = (int)order.TotalWeight;

                    ordDetails.Add(o);
                }

                BindingList<dtoOrders> result = new BindingList<dtoOrders>(ordDetails);

                return result;

            } catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the orders. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while fetching the orders. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the orders. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<BindingList<Delivery>> GetDeliveries(List<int> txnIDs)
        {
            try
            {
                var deliveries = await (from del in _bullseyeContext.Deliveries where txnIDs.Contains(del.DeliveryId) select del).ToListAsync();


                BindingList<Delivery> result = new BindingList<Delivery>(deliveries);

                return result;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the orders. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out while fetching the orders. Please check your network connection and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the orders. Please contact support if the problem persists.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<object> SaveChangesToTransaction(Txn transaction)
        {
            try {

                var tracked = _bullseyeContext.Txns.Local.FirstOrDefault(e => e.TxnId == transaction.TxnId);
                if (tracked != null)
                {
                    _bullseyeContext.Entry(tracked).State = EntityState.Detached;
                }
                _bullseyeContext.Update(transaction);
                int result = await _bullseyeContext.SaveChangesAsync();
                if (result > 0)
                {
                    return transaction;
                } else
                {
                    _transactionLogger.Error("No changes made", $"An unexpected error occurred when when attempting to update transaction {transaction.TxnId}");
                    return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.");
                }
            }
            catch (ArgumentException argEx)
            {
                _transactionLogger.Error(argEx, "Invalid argument provided when attempting to update transaction.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _transactionLogger.Error(msqlEx, "Database error occurred when when attempting to update transaction.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _transactionLogger.Error(toEx, "Operation timed out when when attempting to update transaction.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _transactionLogger.Error(ex, $"An unexpected error occurred when when attempting to update transaction {transaction.TxnId}");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> GetTransactionAudit(int txnId)
        {
            try
            {

                object txnAudit = await(from txnAud in _bullseyeContext.Txnaudits where txnAud.TxnId == txnId select txnAud).ToListAsync();

                if (txnAudit != null)
                {
                    return txnAudit;
                }
                else
                {
                    _transactionLogger.Error("Unable to get transaction log", $"An unexpected error occurred when when attempting to get transaction log for transaction {txnId}");
                    return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.");
                }
            }
            catch (ArgumentException argEx)
            {
                _transactionLogger.Error(argEx, "Invalid argument provided when attempting to to get transaction log.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _transactionLogger.Error(msqlEx, "Database error occurred when when attempting to get transaction log.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _transactionLogger.Error(toEx, "Operation timed out when when attempting to get transaction log.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _transactionLogger.Error(ex, $"An unexpected error occurred when when attempting get transaction log");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> GetOnlineOrders()
        {
            try
            {

                List<Txn> onOrds = await (from onlineOrder in _bullseyeContext.Txns where onlineOrder.TxnType == "Online" select onlineOrder).ToListAsync();

                if (onOrds != null)
                {
                    BindingList<Txn> result = new BindingList<Txn>(onOrds);
                    return result;
                }
                else
                {
                    _transactionLogger.Error("Unable to get online orders", $"An unexpected error occurred when when attempting to a record of online orders");
                    return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.");
                }
            }
            catch (ArgumentException argEx)
            {
                _transactionLogger.Error(argEx, "Invalid argument provided when attempting to to get online orders.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _transactionLogger.Error(msqlEx, "Database error occurred when when attempting to get online orders.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _transactionLogger.Error(toEx, "Operation timed out when when attempting to get online orders.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _transactionLogger.Error(ex, $"An unexpected error occurred when when attempting get online orders");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public Task<object> RecordLoss()
        {
            throw new NotImplementedException();
        }

        public Task<object> ProcessReturn()
        {
            throw new NotImplementedException();
        }

        public Task<object> CreateSupplierOrder(Txn transaction, List<Txnitem> txnitems)
        {
            throw new NotImplementedException();
        }
    }
}
