using ISDP2025_jared_green_web.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface ILocations
    {
        public Task<List<Site>> GetAllLocations();

        //public Task<Site> GetLocationByEmployee(string username);

        public Task<Site> GetLocationBySiteID(int siteID);

        public Task<List<Site>> GetRetailLocations();
    }
}
