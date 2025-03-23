using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
