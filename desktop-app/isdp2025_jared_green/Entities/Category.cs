using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
