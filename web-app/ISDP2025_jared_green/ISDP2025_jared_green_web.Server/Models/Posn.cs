using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Posn
{
    public int PositionId { get; set; }

    public string PermissionLevel { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Employeerole> Employeeroles { get; set; } = new List<Employeerole>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public override string ToString()
    {
        return $"{PermissionLevel}";
    }
}
