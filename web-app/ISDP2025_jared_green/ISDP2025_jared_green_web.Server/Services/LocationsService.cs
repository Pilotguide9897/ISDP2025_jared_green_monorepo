using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models;
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
    public class LocationsService : ILocations
    {
        private readonly BullseyeContext _context;
        private readonly ILogger<LocationsService> _logger;

        public LocationsService(BullseyeContext context, ILogger<LocationsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Site>> GetAllLocations()
        {
            try
            {
                return await _context.Sites.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch all locations.");
                throw;
            }
        }

        //public async Task<Site?> GetLocationByEmployee(string username)
        //{
        //    try
        //    {
        //        return await _context.Employees
        //            .Where(emp => emp.Username == username)
        //            .Select(emp => emp.Site)
        //            .FirstOrDefaultAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Failed to fetch location for employee '{Username}'", username);
        //        throw;
        //    }
        //}

        public async Task<Site?> GetLocationBySiteID(int siteID)
        {
            try
            {
                return await _context.Sites
                    .FirstOrDefaultAsync(site => site.SiteId == siteID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch location with site ID {SiteId}", siteID);
                throw;
            }
        }

        public async Task<List<Site>> GetRetailLocations()
        {
            try
            {
                return await _context.Sites
                    .Where(site => site.locationType == "Store")
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch retail locations.");
                throw;
            }
        }
    }
}
