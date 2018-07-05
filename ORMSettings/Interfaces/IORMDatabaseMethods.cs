using ORMSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSettings.Interfaces
{
    public interface IORMDatabaseMethods
    {
        bool InsertEmployee(Employee model);
        bool DeleteFirstDepartmentEmployee();
        IEnumerable<Employee> GetAllEmployee();
        decimal AverageEmployeesSalary();
    }
}
