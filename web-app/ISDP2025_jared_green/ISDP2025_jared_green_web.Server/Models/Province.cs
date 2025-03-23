using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Province
{
    public string ProvinceId { get; set; } = null!;

    public string ProvinceName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Deliverymethod> Deliverymethods { get; set; } = new List<Deliverymethod>();

    public virtual ICollection<Site> Sites { get; set; } = new List<Site>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
