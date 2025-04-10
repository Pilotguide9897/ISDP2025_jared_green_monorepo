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
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    internal class InventoryController : IInventoryController
    {
        private readonly IInventory _inventoryService;
        public InventoryController(IInventory inventoryService) 
        {
            _inventoryService = inventoryService;
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
    }
}
