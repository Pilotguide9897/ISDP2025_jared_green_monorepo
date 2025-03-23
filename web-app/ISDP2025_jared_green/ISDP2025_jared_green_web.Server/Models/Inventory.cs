using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Inventory
{
    public int ItemId { get; set; }

    public int SiteId { get; set; }

    public string ItemLocation { get; set; } = null!;

    public int Quantity { get; set; }

    public int ReorderThreshold { get; set; }

    public int OptimumThreshold { get; set; }

    public string? Notes { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;
}
