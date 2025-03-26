using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ISDP2025_jared_green_web.Server.Models.dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ISDP2025_jared_green_web.Server.Services
{
    public class DeliveriesService : IDeliveries
    {
        private readonly BullseyeContext _bullseyeContext;
        private readonly ILogger<DeliveriesService> _logger;
        private readonly IMapper _mapper;

        public DeliveriesService(BullseyeContext bullseyeContext, ILogger<DeliveriesService> logger, IMapper mapper)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        // Data Access Methods
        public async Task<Object> GetDeliveries()
        {
            try
            {
                string[] orderTypes = new[] { "Back Order", "Store Order", "Emergency Order" };

                var dto = await _bullseyeContext.Txns
                    .Where(txn => orderTypes.Contains(txn.TxnType))
                    .ProjectTo<dtoDelivery>(_mapper.ConfigurationProvider).ToListAsync();

                if (dto != null)
                {
                    return dto;
                }

                _logger.LogWarning($"No upcoming order data available.");
                return "No delivery data available."; ;

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
