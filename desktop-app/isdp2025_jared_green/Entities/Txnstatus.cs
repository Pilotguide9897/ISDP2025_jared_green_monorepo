using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Txnstatus
{
    public string StatusName { get; set; } = null!;

    public string StatusDescription { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Txn> Txns { get; set; } = new List<Txn>();
}
