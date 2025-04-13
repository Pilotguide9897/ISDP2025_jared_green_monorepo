using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Postalcode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Contact { get; set; }

    public string? Notes { get; set; }

    public sbyte Active { get; set; }

    //public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    //public virtual Province ProvinceNavigation { get; set; } = null!;

    public ICollection<Item> Items { get; set; } = new List<Item>();

    public Province ProvinceNavigation { get; set; } = null!;

    public override string ToString()
    {
        return Name;
    }
}
