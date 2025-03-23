using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    internal class LocationController : ILocationController
    {
        private readonly ILocations _locationService;
        public LocationController(ILocations locationService)
        {
            _locationService = locationService;
        }

        public async Task<BindingList<Site>> GetBullseyeLocations()
        {
           return await _locationService.GetAllLocations();
        }

        public async Task<Site> GetEmployeeLocation(string username)
        {
            return await _locationService.GetLocationByEmployee(username);
        }

        public async Task<Site> AddLocation(Site site)
        {
            return await _locationService.AddSite(site);
        }

        public async Task<Site> UpdateLocation(Site site)
        {
            return await _locationService.UpdateSite(site); 
        }
    }
}
