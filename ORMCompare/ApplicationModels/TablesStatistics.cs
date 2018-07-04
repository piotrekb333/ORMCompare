using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class TablesStatistics
    {
        public long Employees { get; set; }
        public long Departments { get; set; }
        public long DepartmentEmployees { get; set; }
        public long EmployeeTitles { get; set; }
        public long DepartmentManagers { get; set; }
    }
}
