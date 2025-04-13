using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green.Controllers
{
    internal class InventoryController : IInventoryController
    {
        private readonly IInventory _inventoryService;
        private readonly IItems _itemService;
        public InventoryController(IInventory inventoryService, IItems itemService) 
        {
            _inventoryService = inventoryService;
            _itemService = itemService;
        }

        public async Task<BindingList<Inventory>> GetAllInventory()
        {
            return await _inventoryService.GetAllInventory();
        }

        public async Task<BindingList<Inventory>> GetInventoryByLocation(Site site)
        {
            return await _inventoryService.GetInventoryByLocation(site);
        }

        public async Task<bool> UpdateInventory(Inventory existingItem, Inventory updateItem)
        {
            existingItem.ReorderThreshold = updateItem.ReorderThreshold;
            existingItem.OptimumThreshold = updateItem.OptimumThreshold;
            existingItem.Notes = updateItem.Notes;

            return await _inventoryService.UpdateInventory(existingItem);
        }

        public async Task MoveInventory(int siteIdFrom, int siteIdTo, int quantity, int itemID, string locationIDFrom, string locationIDTo) {
            // Check if there are sufficient quantities at both locations to transfer
            int amountPresent = await _inventoryService.CheckInventoryLevel(siteIdFrom, itemID);
            if (quantity <= amountPresent)
            {
                // If there are sufficient amounts, transfer the quantities
                await _inventoryService.MoveInventoryRecords(siteIdFrom, siteIdTo, quantity, itemID, locationIDFrom, locationIDTo);
            }
            else
            {
                MessageBox.Show("Insufficient stock to complete the requested transfer", "Insufficient stock");
            }
        }

        public async Task<int> GetInventoryForLocationByItem(int siteID, int itemID, string locationID)
        {
            int availableInventory = await _inventoryService.CheckInventoryLevel(siteID, itemID);
            return availableInventory;
        }

        public async Task<List<string>> GetInventoryNames()
        {
            object itemNames = await _inventoryService.GetInventoryNames();


            // Handle the state of the object!
            if (itemNames is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
            else
            {
                return itemNames as List<string>;
            }
        }

        public async Task<List<string>> GetCategoryNames()
        {
            object categoryNames = await _inventoryService.GetCategoryNames();


            // Handle the state of the object!
            if (categoryNames is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
            else
            {
                return categoryNames as List<string>;
            }
        }

        public async Task<object> ModifyItemsInCirculation(int siteID, int itemID, int quantity)
        {
            object modifiedInventory = await _inventoryService.ModifyItem(siteID, itemID, quantity);


            // Handle the state of the object!
            if (modifiedInventory is ErrorResult er)
            {
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Inventory();
            }
            else
            {
                return modifiedInventory as Inventory;
            }
        }

        public async Task<object> GetWarehouseResupply()
        {
            object itemsForResupply = await _inventoryService.GetInventoryInNeedOfResupply(2);
            BindingList<Inventory> ifrs = itemsForResupply as BindingList<Inventory>;

            HashSet<int> ids = new HashSet<int>(ifrs.Select(i => i.ItemId));
            List<dtoSupplierOrderItem> items = new List<dtoSupplierOrderItem>();
            BindingList<Item> it = await _itemService.GetAllItems();

            foreach (Item item in it) {
                if (ids.Contains(item.ItemId)) {
                    dtoSupplierOrderItem orderSupplierItem = new dtoSupplierOrderItem()
                    {
                        itemID = item.ItemId,
                        productName = item.Name,
                        quantityRequested = ifrs.Where(k => ids.Contains(k.ItemId)).Select(i => i.Quantity).FirstOrDefault(),
                        supplierName = item.Supplier.Name
                    };
                    items.Add(orderSupplierItem);
                }
            }
            // Handle the state of the object!
            if (items is null)
            {
                ErrorResult er = new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.");
                MessageBox.Show(er.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Inventory>();
            }
            else
            {
                return items;
            }
        }
    }
}
