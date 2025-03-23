using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green.Services
{
    public class LocationsService : ILocations
    {

        private readonly BullseyeContext _bullseyeContext;
        public LocationsService(BullseyeContext bullseyeContext) 
        {
            _bullseyeContext = bullseyeContext;    
        }

        public async Task<BindingList<Site>> GetAllLocations()
        {
            try
            {
                var locations = await (from loc in _bullseyeContext.Sites
                                   select loc).ToListAsync();

                var bindingList = new BindingList<Site>(locations);

                return bindingList;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //LocationLogger.Error(msqlEx, "");
                return new BindingList<Site>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //LocationLogger.Error(msqlEx, "");
                return new BindingList<Site>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the location data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //LocationLogger.Error(msqlEx, "");
                return new BindingList<Site>();
            }
        }

        public async Task<Site> GetLocationByEmployee(string username)
        {
            try
            {
                var location = await (from emp in _bullseyeContext.Employees
                                      where emp.Username == username
                                      select emp.Site).FirstOrDefaultAsync();

                if (location == null)
                {
                    MessageBox.Show("No site data found for the specified user.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null; 
                }

                return location;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the employee's site data.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(msqlEx, "Database query failed.");
                return null; // Or a new Site() if necessary
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request timed out while fetching the site data. Please try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // LocationLogger.Error(toEx, "Database query timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the employee's site data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(ex, "Unexpected error fetching site data.");
                return null;
            }
        }

        public async Task<Site> GetLocationBySiteID(int siteID)
        {
            try
            {
                var location = await (from site in _bullseyeContext.Sites
                                      where site.SiteId == siteID
                                      select site).FirstOrDefaultAsync();

                if (location == null)
                {
                    MessageBox.Show("No site data found for the specified site ID.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                return location;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the site data.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(msqlEx, "Database query failed.");
                return null; // Or a new Site() if necessary
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request timed out while fetching the site data. Please try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // LocationLogger.Error(toEx, "Database query timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the site data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(ex, "Unexpected error fetching site data.");
                return null;
            }
        }

        public async Task<List<int>> GetRetailLocations()
        {
            try
            {
                var locations = await (from site in _bullseyeContext.Sites
                                      where site.locationType == "Store"
                                      select site.SiteId).ToListAsync();

                if (locations == null)
                {
                    MessageBox.Show("No site data found corresponding to retail locations.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                return locations;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while fetching the retail sites data.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(msqlEx, "Database query failed.");
                return null; // Or a new Site() if necessary
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request timed out while fetching the retail sites data. Please try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // LocationLogger.Error(toEx, "Database query timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the retail sites data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(ex, "Unexpected error fetching site data.");
                return null;
            }
        }

        public async Task<Site> AddSite(Site site)
        {
            try
            {
                await _bullseyeContext.AddAsync(site);
                await _bullseyeContext.SaveChangesAsync();
                return site;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while registering the new location.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(msqlEx, "Database query failed.");
                return null; // Or a new Site() if necessary
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request timed out while while registering the new location. Please try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // LocationLogger.Error(toEx, "Database query timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while registering the new location.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(ex, "Unexpected error fetching site data.");
                return null;
            }
        }

        public async Task<Site> UpdateSite(Site site)
        {
            try
            {
                _bullseyeContext.Update(site);
                await _bullseyeContext.SaveChangesAsync();
                return site;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while updating the location's data.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(msqlEx, "Database query failed.");
                return null; // Or a new Site() if necessary
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request timed out while updating the location's data.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // LocationLogger.Error(toEx, "Database query timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred updating the location's data.", " Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // LocationLogger.Error(ex, "Unexpected error fetching site data.");
                return null;
            }
        }
    }
}
