using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface IInventory
    {
        //public Task<BindingList<Inventory>> GetAllInventory();
        public Task<BindingList<Inventory>> GetAllInventory();

        public Task<object> GetInventoryNames();

        public Task<BindingList<Inventory>> GetInventoryByLocation(Site site);

        public Task<bool> UpdateInventory(Inventory inventory);

        // Moves inventory between locations in one site.
        public Task MoveInventoryRecords(int siteIdA, int siteIdB, int quantity, int itemID, string locationIdA, string locationIdB);

        public Task<int> CheckInventoryLevel(int siteID, int productID);

        public Task<BindingList<Inventory>> GetInventoryInNeedOfResupply(int siteID);
    }
}
