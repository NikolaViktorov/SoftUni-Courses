﻿using System;
using System.Collections.Generic;

namespace _00._Outputting_data_from_db.Data
{
    public partial class EmployeesProjects
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Projects Project { get; set; }
    }
}
