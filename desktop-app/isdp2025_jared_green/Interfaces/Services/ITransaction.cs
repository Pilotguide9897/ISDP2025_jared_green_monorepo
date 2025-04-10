using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface ITransaction
    {
        public Task<object> GetAllTransactions();

        public Task<BindingList<dtoOrders>> GetAllOrders();

        public Task<BindingList<dtoOrders>> GetAllOrdersForStoreForDelivery(List<int> txnIDs);

        public Task<bool> UpdateTransaction();

        public Task<bool> UpdateOrderTransactionItems(int txnId, List<Txnitem> newItems);

        public Task<Txn> AddTransaction(Txn transaction);

        public Task<BindingList<dtoOrderItem>> GetTransactionItemsByTxnID(int txnID);

        public Task<BindingList<Txnitem>> GetTransactionItemsForOrder(int txnID);

        public Task<Txn> CheckForBackorder(int siteID);

        public Task<Txn> CreateBackorder(Txn txn);

        public Task<bool> UpdateBackorder(List<Txnitem> newTxnItems);

        public Task<Txn> CreateOrder(int employeeID, int siteID, int standardOrEmergency);

        public Task<Txn> CheckForOrder(int siteID, int standardOrEmergency);

        public Task<Txn> CheckForEmergencyOrder(int siteID, int standardOrEmergency);

        public Task<bool> CheckForOrderSubmissions(int timeframeInMs);

        public Task UpdateOrderStatus(Txn order, int employeeID, string newStatus);

        public Task<Txn> GetOrderByID(int orderID);

        public Task<Delivery> AddDelivery(Delivery delivery);

        public Task<BindingList<Delivery>> GetDeliveries(List<int> txnIDs);

        public Task<object> SaveChangesToTransaction(Txn transaction);

        public Task<object>GetTransactionAudit(int txnId);

        public Task<object> GetOnlineOrders();

        public Task<object> RecordLoss(Txn txn);

        public Task<object> ProcessReturn(Txn txn);

        public Task<object> CreateSupplierOrder(Txn transaction, List<Txnitem> txnitems);
    }
}
