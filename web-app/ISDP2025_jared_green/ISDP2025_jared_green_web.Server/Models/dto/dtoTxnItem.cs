namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoTxnItem
    {
        public int TxnId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
        public dtoItem Item { get; set; } = new();
    }
}
