using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Item
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public decimal Weight { get; set; }

    public int CaseSize { get; set; }

    public decimal CostPrice { get; set; }

    public decimal RetailPrice { get; set; }

    public int SupplierId { get; set; }

    public string? Notes { get; set; }

    public sbyte Active { get; set; }

    public bool IsSelected { get; set; }

    public string? ImageLocation { get; set; } = null;

    public virtual Category CategoryNavigation { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Txnitem> Txnitems { get; set; } = new List<Txnitem>();

    public virtual ICollection<ImagePath> ImagePaths { get; set; } = new List<ImagePath>();

    public override string ToString()
    {
        return this.Name;
    }
}
