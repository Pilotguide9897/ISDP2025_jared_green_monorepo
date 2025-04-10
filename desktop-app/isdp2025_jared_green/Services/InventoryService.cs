using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Loggers;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green.Services
{
    public class InventoryService : IInventory
    {
        private static readonly NLog.Logger _inventoryLogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly BullseyeContext _bullseyeContext;
        public InventoryService(BullseyeContext bullseyeContext) 
        {
            _bullseyeContext = bullseyeContext;
        }

        public async Task<BindingList<Inventory>> GetAllInventory()
        {
            try
            {
                var inventory = await (from inv in _bullseyeContext.Inventories
                                       select inv).Include(e => e.Item).ToListAsync();

                if (inventory.Count == 0)
                {
                    MessageBox.Show("No inventory found.", "No Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                var bindingList = new BindingList<Inventory>(inventory);

                return bindingList;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while retrieving the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
                return new BindingList<Inventory>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to retrieve the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
                return new BindingList<Inventory>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
                return new BindingList<Inventory>();
            }
        }


        public async Task<BindingList<Inventory>> GetInventoryByLocation(Site site)
        {
            try
            {
                var inventory = await (from inv in _bullseyeContext.Inventories
                                       where inv.Site == site
                                       select inv).Include(e => e.Item).ToListAsync();

                if (inventory.Count == 0)
                {
                    MessageBox.Show("No inventory found for the selected location.", "No Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                var bindingList = new BindingList<Inventory>(inventory);

                return bindingList;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while retrieving the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
                return new BindingList<Inventory>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to retrieve the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
                return new BindingList<Inventory>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while fetching the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
                return new BindingList<Inventory>();
            }
        }

        public async Task<bool> UpdateInventory(Inventory inv)
        {
            try
            {

                //var existingEntity = _context.Inventories.Local
                //.FirstOrDefault(i => i.ItemId == inventory.ItemId && i.SiteId == inventory.SiteId && i.ItemLocation == inventory.ItemLocation);
                Inventory existingEntry = await _bullseyeContext.Inventories.FirstOrDefaultAsync(i => i.ItemId == inv.ItemId && i.SiteId == inv.SiteId && i.ItemLocation == inv.ItemLocation);
                if (existingEntry != null) { 
                    _bullseyeContext.Entry(existingEntry).CurrentValues.SetValues(inv);
                } else
                {
                    _bullseyeContext.Update(inv);
                }

                await _bullseyeContext.SaveChangesAsync();
                return true;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while updating the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to update the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
                return false;
            }
        }

        // For checking the restock threshold.
        public async Task<int> CheckInventoryLevel(int locationID, int productID)
        {
            try
            {
                int inventory = await (from inv in _bullseyeContext.Inventories
                                       where inv.ItemId == productID && inv.SiteId == locationID
                                       select inv.Quantity).SumAsync();
                    
                return inventory;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while accessing the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
                return -1;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to access the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while accessing the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
                return -1;
            }
        }

        // For checking whether a product is available at a location before moving.
        public async Task<int> CheckInventoryLevelForLocation(int locationID, int productID, string itemLocation)
        {
            try
            {
                int inventory = await (from inv in _bullseyeContext.Inventories
                                       where inv.ItemId == productID && inv.SiteId == locationID && inv.ItemLocation == itemLocation
                                       select inv.Quantity).SumAsync();

                return inventory;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while accessing the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
                return -1;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to access the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while accessing the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
                return -1;
            }
        }

        public async Task MoveInventoryRecords(int site, int quantity, int itemID)
        {
            try
            {
               Inventory? inventory = await (from inv in _bullseyeContext.Inventories
                                           where inv.SiteId == site && inv.ItemId == itemID
                                           select inv).FirstOrDefaultAsync();
               if (inventory == null)
                {
                    MessageBox.Show("No inventory to update");
                } else
                {
                    inventory.Quantity += quantity;
                }

               await _bullseyeContext.SaveChangesAsync();
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while updating the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to update the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
    
            }
        }

        public async Task MoveInventoryRecords(int siteA, int siteB, int quantity, int itemID, string itemLocationFrom, string itemLocationTo)
        {
            try
            {
                Inventory? inventoryA = await (from inv in _bullseyeContext.Inventories
                                               where inv.SiteId == siteA && inv.ItemId == itemID && inv.ItemLocation == itemLocationFrom
                                               select inv).FirstOrDefaultAsync();

                Console.WriteLine($"Searching for ItemId={itemID} at SiteId={siteA} in Location='{itemLocationFrom}'");

                Inventory? inventoryB = await (from inv in _bullseyeContext.Inventories
                                               where inv.SiteId == siteB && inv.ItemId == itemID && inv.ItemLocation == itemLocationTo
                                               select inv).FirstOrDefaultAsync();

                if (inventoryA != null && (inventoryA.Quantity - quantity >= 0))
                {
                    inventoryA.Quantity -= quantity;

                    if (inventoryB != null)
                    {
                        // Entity already exists — update its quantity
                        inventoryB.Quantity += quantity;
                    }
                    else
                    {
                        Inventory newInventoryRecord = new Inventory
                        {
                            SiteId = siteB,
                            ItemId = itemID,
                            ItemLocation = itemLocationTo,
                            Quantity = quantity,
                            ReorderThreshold = (siteB == 3 || siteB == 9999) ? 0 : quantity,
                            OptimumThreshold = (siteB == 3 || siteB == 9999) ? 0 : quantity * 2
                        };

                        await _bullseyeContext.AddAsync(newInventoryRecord);
                    }

                    await _bullseyeContext.SaveChangesAsync();
                }
                else
                {
                    MessageBox.Show("Unable to move the inventory due to insufficient quantities.", "Inventory Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while updating the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to update the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
            }
        }

        public async Task<BindingList<Inventory>> GetInventoryInNeedOfResupply(int siteID)
        {
            try
            {
                List<Inventory> inventoryToResupply = await (from inv in _bullseyeContext.Inventories
                                                       where inv.Quantity < inv.ReorderThreshold && inv.SiteId == siteID
                                                       select inv).Include(e => e.Item).ToListAsync();

                BindingList<Inventory> inventoryResupply = new BindingList<Inventory>(inventoryToResupply);

                return inventoryResupply;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred while accessing the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(msqlEx, "");
                return null;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The request to access the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ItemLogger.Error(toEx, "");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while accessing the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ItemLogger.Error(ex, "");
                return null;
            }
        }

        public async Task<object> GetInventoryNames()
        {
            try
            {
                List<string> itemNames = await (from itm in _bullseyeContext.Items select itm.Name).ToListAsync();
                if (itemNames == null)
                {
                    _inventoryLogger.Error($"No item information found");
                    return new ErrorResult("NO_MATCHES", "No item information found.");
                }
                return itemNames!;

            }
            catch (MySqlException msqlEx)
            {
                _inventoryLogger.Error(msqlEx, "Database error occurred when querying item names.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _inventoryLogger.Error(toEx, "Operation timed out when querying item names.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _inventoryLogger.Error(ex, "An unexpected error occurred when querying item names.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> GetCategoryNames()
        {
            try
            {
                List<string> itemNames = await (from itm in _bullseyeContext.Items select itm.Category).ToListAsync();
                if (itemNames == null)
                {
                    _inventoryLogger.Error($"No item category information found");
                    return new ErrorResult("NO_MATCHES", "No item information found.");
                }
                return itemNames!;

            }
            catch (MySqlException msqlEx)
            {
                _inventoryLogger.Error(msqlEx, "Database error occurred when querying item categories.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _inventoryLogger.Error(toEx, "Operation timed out when querying item categories.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _inventoryLogger.Error(ex, "An unexpected error occurred when querying item categories.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> ModifyItem(int siteID, int itemID, int quantity)
        {
            try
            {
                Inventory? inv = await (from inventory in _bullseyeContext.Inventories where siteID == inventory.SiteId && inventory.ItemId == itemID select inventory).FirstOrDefaultAsync();
                if (inv == null)
                {
                    _inventoryLogger.Error($"No item information found for matching inventory");
                    return new ErrorResult("NO_MATCHES", "No inventory information found.");
                }
                else
                {
                    if (quantity > 0)
                    {
                        inv.Quantity += quantity;
                    }

                    if (quantity < 0 && Math.Abs(quantity) > inv.Quantity)
                    {
                        _inventoryLogger.Error($"Unable to modify quantities of an item that are greater than is present at location");
                        return new ErrorResult("QUANTITY_IN_EXCESS", "Unable to remove that much inventory");
                    }
                    else
                    {
                        inv.Quantity += quantity;
                    }

                    int res = await _bullseyeContext.SaveChangesAsync();

                    if (res > 0)
                    {
                        return inv;
                    }
                    else
                    {
                        _inventoryLogger.Error($"No change has been made to the inventory's quantity.");
                        return new ErrorResult("NO_CHANGES", "No updates to quantity were made.");
                    }
                }
            }
            catch (ArgumentException argEx)
            {
                _inventoryLogger.Error(argEx, "Invalid argument provided when attempting to create a record of the return.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _inventoryLogger.Error(msqlEx, "Database error occurred when querying item names.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _inventoryLogger.Error(toEx, "Operation timed out when querying item names.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _inventoryLogger.Error(ex, "An unexpected error occurred when querying item names.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }
    }
}
