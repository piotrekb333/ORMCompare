using ADOSqlClient.Repositories.Implementations;
using ORM.Drapper.Repositories.Implementations;
using ORM.EntityFramework.Repositories.Implementations;
using ORM.PetaPoco.Repositories.Implementations;
using ORMCompare.EnumsClass;
using ORMCompare.Services.Interfaces;
using ORMCompare.Services.Repositories;
using ORMSettings.Interfaces;
using System;
namespace ORMCompare.Services
{
    public class TestTimeMethods
    {
        IORMDatabaseMethods repo;
        public TestTimeMethods(ORMTool tool)
        {
            switch (tool)
            {
                case ORMTool.EntityFramework:
                    repo = new EntityFrameworkRepository();
                    break;
                case ORMTool.ADOSqlClient:
                    repo = new ADOSqlClientRepository();
                    break;
                case ORMTool.Drapper:
                    repo = new DrapperRepository();
                    break;
                case ORMTool.PetaPoco:
                    repo = new PetaPocoRepository();
                    break;
            }
                 
        }    
        public long InsertEmployeeTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.InsertEmployee(new ORMSettings.Models.Employee
            {
                Birthday = DateTime.Now,
                FirstName = "test",
                LastName = "test"
            });
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long GetAllEmployeesTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.GetAllEmployee();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long AverageEmployeesSalaryTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.AverageEmployeesSalary();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long DeleteFirstDepartmentEmployeeTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.DeleteFirstDepartmentEmployee();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long GetDepartmentEmployeeSalaryTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.GetDepartmentEmployeeSalary();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long UpdateEmployeeTest()
        {
            IEmployeeRepository repoEmp = new EmployeeRepository();
            var first= repoEmp.GetFirst();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (first != null)
            {
                repo.UpdateEmployee(first.Id, new ORMSettings.Models.Employee
                {
                    FirstName = "update",
                    Birthday = first.Birthday,
                    EmployeeTitleId = first.EmployeeTitleId,
                    LastName = first.LastName,
                    Salary = first.Salary
                });
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long GetEmployeeByIdTest()
        {
            IEmployeeRepository repoEmp = new EmployeeRepository();
            var first = repoEmp.GetFirst();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if(first!=null)
               repo.GetEmployeeById(first.Id);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long ExistsSalaryTest()
        {
            IEmployeeRepository repoEmp = new EmployeeRepository();
            var first = repoEmp.GetFirst();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.ExistsSalary(100);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        public long UnionEmployees()
        {
            IEmployeeRepository repoEmp = new EmployeeRepository();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.UnionEmployees();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }
    }
}
