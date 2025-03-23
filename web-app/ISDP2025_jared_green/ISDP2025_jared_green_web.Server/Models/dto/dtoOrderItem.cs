using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoOrderItem
    {
        public int itemID {  get; set; }
        public string productName { get; set; }
        public int quantityRequested { get; set; }
        public int quantityAtWarehouse { get; set; }
    }
}
