using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Models.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface IInventory
    {
        public Task<List<Inventory>> GetInventoryByLocation(int siteId);
    }
}
