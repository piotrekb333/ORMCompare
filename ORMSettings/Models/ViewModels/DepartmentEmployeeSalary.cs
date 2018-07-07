using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSettings.Models.ViewModels
{
    public class DepartmentEmployeeSalary
    {
        public decimal SalarySum { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
