using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class TimeChartManyModel
    {
        public List<long> Employees { get; set; }
        public List<long> Departments { get; set; }
        public List<long> DepartmentEmployees { get; set; }
        public List<long> EmployeeTitles { get; set; }
        public List<long> DepartmentManagers { get; set; }
        public string[] Labels { get; set; }
    }
}
