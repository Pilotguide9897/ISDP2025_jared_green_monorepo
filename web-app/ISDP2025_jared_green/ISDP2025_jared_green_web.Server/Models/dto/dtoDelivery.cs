namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoDelivery
    {
        public int TxnId { get; set; }

        public dtoSite OrderSite { get; set; }

        public DateTime ShipDate { get; set; }

        public string CustFirstName { get; set; }

        public string CustLastName { get; set; }

        public string CustEmail { get; set; }

        public string CustPhone { get; set; }

        public List<dtoTxnItem> Txnitems { get; set; } = new();
    }
}
