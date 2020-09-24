using System;
using System.Collections.Generic;

namespace _00._Outputting_data_from_db.Data
{
    public partial class Projects
    {
        public Projects()
        {
            EmployeesProjects = new HashSet<EmployeesProjects>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
    }
}
