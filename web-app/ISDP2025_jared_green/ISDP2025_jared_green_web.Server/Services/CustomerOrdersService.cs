using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models.dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.ComponentModel;

namespace ISDP2025_jared_green_web.Server.Services
{
    public class CustomerOrdersService : ICustomerOrders
    {
        private readonly BullseyeContext _bullseyeContext;
        private readonly ILogger<CustomerOrdersService> _logger;

        public CustomerOrdersService(BullseyeContext bullseyeContext, ILogger<CustomerOrdersService> logger)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Data Access Methods
        public async Task CreateOrder(dtoOrder orderDetails)
        {
            try
            {
                Txn order = new Txn
                {
                    TxnStatus = "NEW",
                    EmployeeId = -1,
                    SiteIdfrom = 10000,
                    SiteIdto = orderDetails.orderSite,
                    CreatedDate = DateTime.Now,
                    BarCode = Guid.NewGuid().ToString(),
                    CustFirstName = orderDetails.firstName,
                    CustLastName = orderDetails.lastName,
                    CustEmail = orderDetails.email,
                    CustPhone = orderDetails.phone,
                    Txnitems = orderDetails.txnitems
                };

                // Add the new order
                await _bullseyeContext.AddAsync(order);
                await _bullseyeContext.SaveChangesAsync();
            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
            }
        }

        public async Task<object> GetOrderByOrderID(int txnID)
        {
            try
            {
                var order = await _bullseyeContext.Txns
                    .Where(txn => txn.TxnId == txnID)
                    .Include(e => e.Txnitems)
                    .ThenInclude(f => f.Item)
                    .Select(g => new dtoOrder
                    {
                        txnID = g.TxnId,
                        orderSite = g.SiteIdto,
                        firstName = g.CustFirstName,
                        lastName = g.CustLastName,
                        email = g.CustEmail,
                        phone = g.CustPhone,
                        txnitems = g.Txnitems
                    })
                    .FirstOrDefaultAsync();

                if (order != null)
                {
                    return order;
                }

                _logger.LogWarning($"No order found for TxnID: {txnID}");
                return $"No order found for TxnID: {txnID}";

            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
                return null;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
                return null;
            }
        }

        public async Task<object> CreateOrder(Txn order)
        {
            try
            {
                await _bullseyeContext.AddAsync(order);
                return true;
            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
                return null;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
                return null;
            }
        }

        public async Task<object> GetOrderByCustomerEmail(string email)
        {
            try
            {
                var order = await _bullseyeContext.Txns
                    .Where(txn => txn.CustEmail == email)
                    .Include(e => e.Txnitems)
                    .ThenInclude(f => f.Item)
                    .Select(g => new dtoOrder
                    {
                        txnID = g.TxnId,
                        orderSite = g.SiteIdto,
                        firstName = g.CustFirstName,
                        lastName = g.CustLastName,
                        email = g.CustEmail,
                        phone = g.CustPhone,
                        txnitems = g.Txnitems
                    })
                    .FirstOrDefaultAsync();

                if (order != null)
                {
                    return order;
                }

                _logger.LogWarning($"No order found for customer email: {email}");
                return $"No order found for customer email: {email}";

            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
                return null;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
                return null;
            }
        }
    }
}
