using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface ILocations
    {
        public Task<BindingList<Site>> GetAllLocations();

        public Task<Site> GetLocationByEmployee(string username);

        public Task<Site> GetLocationBySiteID(int siteID);

        public Task<List<int>> GetRetailLocations();

        public Task<Site> UpdateSite(Site site);

        public Task<Site> AddSite(Site site);
    }
}
