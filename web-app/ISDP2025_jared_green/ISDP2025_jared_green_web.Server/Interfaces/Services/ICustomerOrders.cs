using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Models.dto;

namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface ICustomerOrders
    {
        public Task CreateOrder(dtoOrder orderDetails);

        public Task<object> GetOrderByOrderID(int orderID);

        public Task<object> GetOrderByCustomerEmail(string email);

        public Task<object> CreateOrder(Txn order);
    }
}
