using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface IInventoryController
    {
        //public Task<BindingList<Inventory>> GetAllInventory();
        public Task<BindingList<Inventory>> GetAllInventory();

        public Task<List<String>> GetInventoryNames();

        public Task<List<String>> GetCategoryNames();

        public Task<BindingList<Inventory>> GetInventoryByLocation(Site site);

        public Task<bool> UpdateInventory(Inventory oldItem, Inventory updates);

        // Moves inventory between locations or within a site
        public Task MoveInventory(int siteIDFrom, int siteIDTo, int quantity, int itemID, string itemLocationFrom, string itemLocationTo);

        public Task<int> GetInventoryForLocationByItem(int siteID, int itemID, string locationID);
    }
}
