using System.ComponentModel;

namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoOrder
    {
        public int txnID { get; set; }

        public int orderSite { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public ICollection<Txnitem> txnitems { get; set; }
    }
}
