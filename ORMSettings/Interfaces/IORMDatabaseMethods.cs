using ORMSettings.Models;
using ORMSettings.Models.ViewModels;
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
        IEnumerable<DepartmentEmployeeSalary> GetDepartmentEmployeeSalary();
        bool UpdateEmployee(int id, Employee model);
        Employee GetEmployeeById(int id);
        bool ExistsSalary(decimal salary);
        IEnumerable<Employee> UnionEmployees();
    }
}
