using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Txntype
{
    public string TxnType1 { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Txnaudit> Txnaudits { get; set; } = new List<Txnaudit>();

    public virtual ICollection<Txn> Txns { get; set; } = new List<Txn>();
}
