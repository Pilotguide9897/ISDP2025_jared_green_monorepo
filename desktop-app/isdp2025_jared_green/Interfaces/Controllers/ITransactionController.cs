using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface ITransactionController
    {

        public Task<BindingList<Txn>> GetAllTransactions();

        public Task<BindingList<dtoOrders>> GetAllStoreOrders();

        public Task<BindingList<dtoOrders>> GetAllStoreOrdersForDelivery(List<int> txnIDs);

        public Task<Txn> GetOrder(int siteID, int standardOrEmergency);

        public Task<Txn> GetOrderByID(int orderID);

        public Task<BindingList<dtoOrderItem>> GetTxnItems(int txnID);

        public Task<BindingList<Txnitem>> GetTxnItemsFromOrder(int txnID);

        public Task<Txn> CheckForOrder(int siteID, int standardOrEmergency);

        public Task<Txn> CheckForEmergencyOrder(int siteID, int standardOrEmergency);

        public Task<Txn> CheckForBackorder(int siteID);

        public Task<Txn> CreateOrder(int employeeID, int siteIDFrom, int standardOrEmergency);

        public Task<Txn> CreateBackorder(int employeeID, int siteIDTo, string notes);

        public Task<bool> CheckForOrderSubmission(int timeframe);

        public Task<bool> UpdateTransactionStatus(int txnID, int employeeID, string updatedStatus);

        public Task SaveChanges();

        public Task UpdateBackorder(List<Txnitem> txnItems);

        public Task SaveOrderItemChanges(int txnId, List<Txnitem> txnItems);

        public Task<BindingList<Delivery>> GetDeliveriesForDeliveryDate(List<int> txnIDs);

        public Task<bool> UpdateTransactionDetails(Txn transaction);

        public Task<List<Txnaudit>> GetTransactionAudit(int txnId);

        public Task<BindingList<Txn>> GetOnlineOrdersForStores();
        public Task<Txn> RecordLoss(Txn loss);
        public Task<Txn> ProcessReturn(Txn rtrn);

        public Task<Txn> CreateSupplierOrder();
    }
}
