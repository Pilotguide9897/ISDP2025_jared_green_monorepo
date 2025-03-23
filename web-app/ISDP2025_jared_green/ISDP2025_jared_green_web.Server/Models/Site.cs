using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Site
{
    public int SiteId { get; set; }

    public string SiteName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string ProvinceId { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? DayOfWeek { get; set; }

    public int DistanceFromWh { get; set; }

    public string? Notes { get; set; }

    public sbyte Active { get; set; }

    public string locationType { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Txn> TxnSiteIdfromNavigations { get; set; } = new List<Txn>();

    public virtual ICollection<Txn> TxnSiteIdtoNavigations { get; set; } = new List<Txn>();

    public virtual ICollection<Txnaudit> Txnaudits { get; set; } = new List<Txnaudit>();

    public override string ToString()
    {
        return SiteName;
    }
}
