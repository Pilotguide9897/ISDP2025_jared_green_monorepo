﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Entities
{
    public partial class Employeeloginattempt
    {
        public required int EmployeeID { get; set; }

        public int SubsequentFailedAttempt { get; set; }

        public DateTime LastFailedAttempt { get; set; }
    }
}
