using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings.Models;

using System.Data;

using Dapper;
using ORMSettings;
using ORMSettings.Models.ViewModels;

namespace ORM.Drapper.Repositories.Implementations
{
    public class DrapperRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        IDbConnection connection;
        string connectionString = "";
        public DrapperRepository()
        {
            connectionString = HelperDatabaseSettings.GetConnectionString();
            //Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=true;TrustServerCertificate=False;MultipleActiveResultSets=True;
            connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
        }

        public decimal AverageEmployeesSalary()
        {
            using (connection)
            {
                string query = "Select avg(salary) from employees";
                return connection.ExecuteScalar<decimal>(query);
            }
        }

        public bool DeleteFirstDepartmentEmployee()
        {
            using (connection)
            {
                string query = "Delete top (1) from DepartmentEmployees";
                connection.Execute(query);
                return true;
            }
        }

        public bool ExistsSalary(decimal salary)
        {
            using (connection)
            {
                var parameters = new
                {
                    Salary = salary,
                };
                string query = @"select  case WHEN count(Id) <=0 THEN 0
    WHEN count(Id) >0 THEN 1 end
	from Employees
	where    exists ( select salary from Employees e where Salary=@Salary )";
                return connection.ExecuteScalar<bool>(query, parameters);
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            using (connection)
            {
                string query = "select * from Employees";
                return  connection.Query<Employee>(query);
            }
        }

        public IEnumerable<DepartmentEmployeeSalary> GetDepartmentEmployeeSalary()
        {
            using (connection)
            {
                string query = @"select d.id as DepartmentId,d.Name as DepartmentName, sum(e.Salary) as SalarySum from DepartmentEmployees de inner join Employees e on de.EmployeeId=e.Id inner join Departments d on de.DepartmentId=d.Id
group by d.Id,d.Name";
                return connection.Query<DepartmentEmployeeSalary>(query);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (connection)
            {
                var parameters = new
                {
                    Id = id,
                };
                string query = "select * from Employees where Id=@Id";
                return connection.QueryFirst<Employee>(query, parameters);
            }
        }

        public bool InsertEmployee(Employee model)
        {
            using (connection)
            {
                string query = "Insert into Employees (FirstName,LastName,Birthday,EmployeeTitleId,Salary) values (@Name,@Last,@Birth,@TitleId,@Salary)";
                var parameters = new
                {
                    Name = model.FirstName,
                    Last = model.LastName,
                    Birth = model.Birthday,
                    TitleId = model.EmployeeTitleId,
                    Salary = model.Salary
                };
                var exec=connection.Execute(query, parameters);
                if (exec > 0)
                    return true;
                else
                    return false;
            }
        }

        public IEnumerable<Employee> UnionEmployees()
        {
            using (connection)
            {
                string query = @"select * from Employees where Salary < 3000
union 
select * from Employees where Salary > 6000";
                return connection.Query<Employee>(query);
            }
        }

        public bool UpdateEmployee(int id, Employee model)
        {
            using (connection)
            {
                string query = "Update Employees set FirstName=@Name,LastName=@Last,Birthday=@Birth,EmployeeTitleId=@TitleId,Salary=@Salary where Id=@Id";
                var parameters = new
                {
                    Name = model.FirstName,
                    Last = model.LastName,
                    Birth = model.Birthday,
                    TitleId = model.EmployeeTitleId,
                    Salary=model.Salary,
                    Id=model.Id
                };
                var exec = connection.Execute(query, parameters);
                if (exec > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
