using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace ISDP2025_jared_green_web.Server.Services
{
    public class DeliveriesService : IDeliveries
    {
        private readonly BullseyeContext _bullseyeContext;
        private readonly ILogger<DeliveriesService> _logger;

        public DeliveriesService(BullseyeContext bullseyeContext, ILogger<DeliveriesService> logger)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Data Access Methods
        public async Task<List<Txn>> GetDeliveries()
        {
            try
            {
                string[] orderTypes = new[] { "Back Order", "Store Order", "Emergency Order" };

                var orders = await (from tx in _bullseyeContext.Txns where orderTypes.Contains(tx.TxnType) && tx.ShipDate > DateTime.Today select tx)
                    .Include(t => t.SiteIdtoNavigation)
                    .Include(e => e.Txnitems)
                    .ThenInclude(f => f.Item).ToListAsync();

                if (orders != null)
                {
                    return orders;
                }

                _logger.LogWarning($"No upcoming order data available.");
                return new List<Txn>();

            } catch (MySqlException msqlEx)
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
    }
}
