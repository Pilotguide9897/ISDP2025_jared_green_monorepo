using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Vehicle
{
    public string VehicleType { get; set; } = null!;

    public decimal MaxWeight { get; set; }

    public decimal HourlyTruckCost { get; set; }

    public decimal CostPerKm { get; set; }

    public string Notes { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
