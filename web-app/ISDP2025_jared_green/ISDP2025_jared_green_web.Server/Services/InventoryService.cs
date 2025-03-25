using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Models.dto;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Site = ISDP2025_jared_green_web.Server.Models.Site;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ISDP2025_jared_green_web.Server.Services
{
    public class InventoryService : IInventory
    {
        private readonly BullseyeContext _bullseyeContext;
        private readonly ILogger<InventoryService> _logger;
        private readonly IMapper _mapper;
        public InventoryService(BullseyeContext bullseyeContext, ILogger<InventoryService> logger, IMapper mapper)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<dtoInventory>> GetInventoryByLocation(int siteId)
        {
            try
            {

                var inventoryDto = await _bullseyeContext.Inventories
                    .Where(e => e.SiteId == siteId)
                    .ProjectTo<dtoInventory>(_mapper.ConfigurationProvider).ToListAsync();

                return inventoryDto;
            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError(msqlEx, "MySQL database error while fetching the inventory data.");
                throw;
            }
            catch (TimeoutException toEx)
            {

                _logger.LogError(toEx, "Timeout error while fetching the inventory data.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching the inventory data.");
                throw;
            }
        }
    }
}
