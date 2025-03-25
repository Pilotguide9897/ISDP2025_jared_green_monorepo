using System.ComponentModel;

namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoOrderCreation
    {
        public int TxnId { get; set; }

        public int OrderSite { get; set; }

        public DateTime ShipTime { get; set; }

        public string CustFirstName { get; set; }

        public string CustLastName { get; set; }

        public string CustEmail { get; set; }

        public string CustPhone { get; set; }

        public List<dtoOrderItemCreation> txnitems { get; set; } = new();
    }
}
