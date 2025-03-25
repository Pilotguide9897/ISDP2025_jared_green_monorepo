namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoOrderItemCreation
    {
        public int TxnId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }
}
