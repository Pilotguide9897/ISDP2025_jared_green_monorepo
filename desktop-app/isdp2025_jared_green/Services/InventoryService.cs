using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
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
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green.Services
{
    public class InventoryService : IInventory
    {
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


        //public async Task<BindingList<InventoryDTO>> GetAllInventory()
        //{
        //    try
        //    {
        //        var inventory = await (from inv in _bullseyeContext.Inventories
        //                               select new InventoryDTO
        //                               {
        //                                   Id = inv.ItemId,
        //                                   Name = inv.Item.Name,
        //                                   ItemName = inv.Item.Name
        //                               }).ToListAsync();

        //        if (inventory.Count == 0)
        //        {
        //            MessageBox.Show("No inventory found.", "No Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        var bindingList = new BindingList<InventoryDTO>(inventory);

        //        return bindingList;

        //    }
        //    catch (MySqlException msqlEx)
        //    {
        //        MessageBox.Show("A database error occurred while retrieving the inventory. Please check your connection and try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return new BindingList<InventoryDTO>();
        //    }
        //    catch (TimeoutException toEx)
        //    {
        //        MessageBox.Show("The request to retrieve the inventory timed out. Please check your network and try again.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return new BindingList<InventoryDTO>();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An unexpected error occurred while fetching the inventory. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return new BindingList<InventoryDTO>();
        //    }
        //}



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

                Inventory? inventoryB = await (from inv in _bullseyeContext.Inventories
                                              where inv.SiteId == siteB && inv.ItemId == itemID && inv.ItemLocation == itemLocationTo
                                              select inv).FirstOrDefaultAsync();

                if (inventoryB == null && quantity >= 0) {
                    if (inventoryA != null && (inventoryA.Quantity - quantity > 0))
                    {
                        inventoryA!.Quantity -= quantity;

                        Inventory newInventoryRecord = new Inventory();
                        newInventoryRecord.SiteId = siteB;
                        newInventoryRecord.ItemId = itemID;
                        newInventoryRecord.ItemLocation = itemLocationTo;

                        if (siteB == 3)
                        {
                            newInventoryRecord.ReorderThreshold = 0;
                            newInventoryRecord.OptimumThreshold = 0;
                        } else
                        {
                            newInventoryRecord.ReorderThreshold = quantity;
                            newInventoryRecord.OptimumThreshold = quantity * 2;
                        }


                        newInventoryRecord.Quantity = quantity;
                        await _bullseyeContext.AddAsync(newInventoryRecord);
                    } else
                    {
                        MessageBox.Show("Unable to move the inventory due to an inventory processing error", "Insufficient Quantities");
                        return;
                    }
                }
                else
                {
                    if (inventoryA != null && (inventoryA.Quantity - quantity > 0))
                    {                    
                        inventoryA!.Quantity -= quantity;
                        inventoryB!.Quantity += quantity;
                    }
                    else
                    {
                        MessageBox.Show("Unable to move the inventory due to an inventory processing error", "Insufficient Quantities");
                        return;
                    }
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

        public async Task TransferInventoryRecords()
        {
            throw new NotImplementedException();
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
    }
}
