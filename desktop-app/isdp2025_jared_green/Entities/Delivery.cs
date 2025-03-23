using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public DateTime DeliveryDate { get; set; }

    public decimal DistanceCost { get; set; }

    public string VehicleType { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<Txnaudit> Txnaudits { get; set; } = new List<Txnaudit>();

    public virtual ICollection<Txn> Txns { get; set; } = new List<Txn>();

    public virtual Vehicle VehicleTypeNavigation { get; set; } = null!;
}
