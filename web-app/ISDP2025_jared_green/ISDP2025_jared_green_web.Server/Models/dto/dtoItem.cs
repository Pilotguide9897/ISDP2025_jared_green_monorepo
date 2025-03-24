namespace ISDP2025_jared_green_web.Server.Models.dto
{
    public class dtoItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public string? Description { get; set; }
        public string Category { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal RetailPrice { get; set; }
        public string? ImageLocation { get; set; }
    }
}
