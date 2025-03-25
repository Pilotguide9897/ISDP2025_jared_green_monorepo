namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoInventory
    {
        public int ItemId { get; set; }

        public int SiteId { get; set; }

        public string ItemLocation { get; set; } = null!;

        public int Quantity { get; set; }

        public int ReorderThreshold { get; set; }

        public int OptimumThreshold { get; set; }

        public string? Notes { get; set; }

        public dtoItem Item { get; set; }
    }
}
