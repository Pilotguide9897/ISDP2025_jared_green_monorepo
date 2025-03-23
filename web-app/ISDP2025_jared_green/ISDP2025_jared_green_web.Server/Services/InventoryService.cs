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

namespace ISDP2025_jared_green_web.Server.Services
{
    public class InventoryService : IInventory
    {
        private readonly BullseyeContext _bullseyeContext;
        private readonly ILogger<InventoryService> _logger;
        public InventoryService(BullseyeContext bullseyeContext, ILogger<InventoryService> logger)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger;
        }

        public async Task<List<Inventory>> GetInventoryByLocation(int siteId)
        {
            try
            {
                var inventory = await (from inv in _bullseyeContext.Inventories
                                       where inv.SiteId == siteId
                                       select inv).Include(e => e.Item).ToListAsync();

                return inventory;
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
