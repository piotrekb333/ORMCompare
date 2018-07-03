using System;
using System.Collections.Generic;
using System.Text;
using ORMSettings.Inftrastructure;


namespace ORMSettings.Models
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int? EmployeeTitleId { get; set; }

        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }

        public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
        public virtual EmployeeTitle EmployeeTitle { get; set; }
    }
}
