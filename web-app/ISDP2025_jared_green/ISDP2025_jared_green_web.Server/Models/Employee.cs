using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int PositionId { get; set; }

    public int SiteId { get; set; }

    public string Username { get; set; } = null!;

    public string? Notes { get; set; }

    public sbyte? Locked { get; set; }

    public sbyte Active { get; set; }

    public virtual ICollection<Employeerole> Employeeroles { get; set; } = new List<Employeerole>();

    public virtual Posn Position { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;

    public virtual ICollection<Txnaudit> Txnaudits { get; set; } = new List<Txnaudit>();

    public virtual ICollection<Txn> Txns { get; set; } = new List<Txn>();
}
