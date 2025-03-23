using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface ILocationController
    {
        public Task<BindingList<Site>> GetBullseyeLocations();

        public Task<Site> GetEmployeeLocation(string username);

        public Task<Site> UpdateLocation(Site site);

        public Task<Site> AddLocation(Site site);
    }
}
