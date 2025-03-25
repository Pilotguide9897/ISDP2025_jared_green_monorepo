using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models.dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.ComponentModel;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ISDP2025_jared_green_web.Server.Services
{
    public class CustomerOrdersService : ICustomerOrders
    {
        private readonly BullseyeContext _bullseyeContext;
        private readonly ILogger<CustomerOrdersService> _logger;
        private readonly IMapper _mapper;

        public CustomerOrdersService(BullseyeContext bullseyeContext, ILogger<CustomerOrdersService> logger, IMapper mapper)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        // Data Access Methods
        public async Task<dtoOrder> CreateOrder(dtoOrderCreation orderDetails)
        {
            try
            {
                Txn order = new Txn
                {
                    TxnStatus = "NEW",
                    EmployeeId = 10000,
                    SiteIdfrom = 10000,
                    TxnType = "Online",
                    ShipDate = orderDetails.ShipTime,
                    SiteIdto = orderDetails.OrderSite,
                    CreatedDate = DateTime.Now,
                    BarCode = Guid.NewGuid().ToString(),
                    CustFirstName = orderDetails.CustFirstName,
                    CustLastName = orderDetails.CustLastName,
                    CustEmail = orderDetails.CustEmail,
                    CustPhone = orderDetails.CustPhone,
                    Txnitems = _mapper.Map<List<Txnitem>>(orderDetails.txnitems)
                };

                // Add the new order
                await _bullseyeContext.AddAsync(order);
                await _bullseyeContext.SaveChangesAsync();

                // EF will not set the nav properties until order is loaded or query. Load to return site info. Do the same for items too.
                // .Reference is used for loading a single navigation property.
                await _bullseyeContext.Entry(order).Reference(o => o.SiteIdtoNavigation).LoadAsync();
                // .Collection is used for loading a collection navigation property.
                await _bullseyeContext.Entry(order).Collection(m => m.Txnitems).Query().Include(j => j.Item).LoadAsync();
                // Cannot load both at the same time. Do in two statements.

                return _mapper.Map<dtoOrder>(order);
            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
                throw;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
                throw;
            }
        }

        //public async Task<object> GetOrderByOrderID(int txnID)
        //{
        //    try
        //    {
        //        var order = await _bullseyeContext.Txns
        //            .Where(txn => txn.TxnId == txnID)
        //            .Include(s => s.SiteIdtoNavigation)
        //            .Include(e => e.Txnitems)
        //            .ThenInclude(f => f.Item)
        //            .Select(g => new dtoOrder
        //            {
        //                txnID = g.TxnId,
        //                orderSite = g.SiteIdto,
        //                firstName = g.CustFirstName,
        //                lastName = g.CustLastName,
        //                email = g.CustEmail,
        //                phone = g.CustPhone,
        //                txnitems = g.Txnitems
        //            })
        //            .FirstOrDefaultAsync();

        //        if (order != null)
        //        {
        //            return order;
        //        }

        //        _logger.LogWarning($"No order found for TxnID: {txnID}");
        //        return $"No order found for TxnID: {txnID}";

        //    }
        //    catch (MySqlException msqlEx)
        //    {
        //        _logger.LogError($":{msqlEx.Message}");
        //        return null;
        //    }
        //    catch (TimeoutException toEx)
        //    {
        //        _logger.LogError($":{toEx.Message}");
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($":{ex.Message}");
        //        return null;
        //    }
        //}

        public async Task<object> GetOrderByOrderID(int txnID)
        {
            try
            {
                //var order = await _bullseyeContext.Txns
                //    .Where(txn => txn.TxnId == txnID)
                //    .Include(s => s.SiteIdtoNavigation)
                //    .Include(e => e.Txnitems)
                //    .ThenInclude(f => f.Item)
                //    .FirstOrDefaultAsync();

                //if (order != null)
                //{
                //    var dto = _mapper.Map<dtoOrder>(order);
                //    return dto;
                //}

                var dto = await _bullseyeContext.Txns
                    .Where(txn => txn.TxnId == txnID && txn.ShipDate > DateTime.Now)
                    .ProjectTo<dtoOrder>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                if (dto != null)
                {
                    return dto;
                }

                _logger.LogWarning($"No order found for TxnID: {txnID}");
                return $"No order found for TxnID: {txnID}";

            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
                throw;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
                throw;
            }
        }

        public async Task<object> GetOrderByCustomerEmail(string email)
        {
            try
            {


                //var order = await _bullseyeContext.Txns
                //    .Where(txn => txn.CustEmail == email && txn.ShipDate > DateTime.Now)
                //    .Include(s => s.SiteIdtoNavigation)
                //    .Include(e => e.Txnitems)
                //    .ThenInclude(f => f.Item)
                //    .FirstOrDefaultAsync();

                //if (order != null)
                //{
                //    var dto = _mapper.Map<dtoOrder>(order);
                //    return dto;
                //}

                var dto = await _bullseyeContext.Txns
                    .Where(txn => txn.CustEmail == email && txn.ShipDate > DateTime.Now)
                    .ProjectTo<dtoOrder>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                if (dto != null)
                {
                    return dto;
                }

                _logger.LogWarning($"No order found for email: {email}");
                return $"No order found for email: {email}";

            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError($":{msqlEx.Message}");
                throw;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError($":{toEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($":{ex.Message}");
                throw;
            }
        }

        //public async Task<object> CreateOrder(Txn order)
        //{
        //    try
        //    {
        //        await _bullseyeContext.AddAsync(order);
        //        return true;
        //    }
        //    catch (MySqlException msqlEx)
        //    {
        //        _logger.LogError($":{msqlEx.Message}");
        //        throw;
        //    }
        //    catch (TimeoutException toEx)
        //    {
        //        _logger.LogError($":{toEx.Message}");
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($":{ex.Message}");
        //        throw;
        //    }
        //}

        //public async Task<object> GetOrderByCustomerEmail(string email)
        //{
        //    try
        //    {
        //        var order = await _bullseyeContext.Txns
        //            .Where(txn => txn.CustEmail == email)
        //            .Include(e => e.Txnitems)
        //            .ThenInclude(f => f.Item)
        //            .Select(g => new dtoOrder
        //            {
        //                txnID = g.TxnId,
        //                orderSite = g.SiteIdto,
        //                firstName = g.CustFirstName,
        //                lastName = g.CustLastName,
        //                email = g.CustEmail,
        //                phone = g.CustPhone,
        //                txnitems = g.Txnitems
        //            })
        //            .FirstOrDefaultAsync();

        //        if (order != null)
        //        {
        //            return order;
        //        }

        //        _logger.LogWarning($"No order found for customer email: {email}");
        //        return $"No order found for customer email: {email}";

        //    }
        //    catch (MySqlException msqlEx)
        //    {
        //        _logger.LogError($":{msqlEx.Message}");
        //        return null;
        //    }
        //    catch (TimeoutException toEx)
        //    {
        //        _logger.LogError($":{toEx.Message}");
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($":{ex.Message}");
        //        return null;
        //    }
        //}
    }
}
