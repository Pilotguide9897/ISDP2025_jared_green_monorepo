using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Entities.dto
{
    public class dtoOrders
    {
        public int txnID {  get; set; }
        public string? siteName { get; set; }

        public string txnType { get; set; } = null!;

        public string? txnStatus { get; set; }

        public int itemCount { get; set; }

        public int totalWeight { get; set; }

        public DateOnly? deliveryDate { get; set; }
        public string deliveryDateDisplay => deliveryDate?.ToString("yyyy-MM-dd") ?? "No Delivery Scheduled";
    }
}
