using System;
using System.Collections.Generic;

namespace idsp2025_jared_green.Entities;

public partial class Deliverymethod
{
    public int DeliveryMethodId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string ProvinceId { get; set; } = null!;

    public string? Postalcode { get; set; }

    public string? Phone { get; set; }

    public string? Contact { get; set; }

    public string? Notes { get; set; }

    public sbyte Active { get; set; }

    public virtual Province Province { get; set; } = null!;
}
