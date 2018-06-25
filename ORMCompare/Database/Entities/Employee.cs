using System;
using System.Collections.Generic;
using System.Text;

namespace ORMCompare.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int EmployeeTitleId { get; set; }

        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }

        public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
        public virtual EmployeeTitle EmployeeTitle { get; set; }
    }
}
