using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Entities.dto
{
    public class dtoSupplierOrderItem
    {
        public int itemID {  get; set; }
        public string productName { get; set; }
        public int quantityRequested { get; set; }
        public string supplierName { get; set; } = null!;
    }
}
