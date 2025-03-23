using System;
using System.Collections.Generic;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Employeerole
{
    public int EmployeeRoleId { get; set; }

    public int EmployeeId { get; set; }

    public int PositionId { get; set; }

    //public bool Active { get; set; }
    public sbyte Active { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Posn Position { get; set; } = null!;

    public override string ToString()
    {
        return Position.PermissionLevel;
    }
}
