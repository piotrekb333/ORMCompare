using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings;
using ORMSettings.Models;
using ORMSettings.Models.ViewModels;
using PetaPoco;
namespace ORM.PetaPoco.Repositories.Implementations
{
    public class PetaPocoRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        private IDatabase db;
        private IDbConnection dbConnection;
        private string connectionString = "";
        public PetaPocoRepository()
        {
            connectionString = HelperDatabaseSettings.GetConnectionString();
            //string connectionString = "Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=true;TrustServerCertificate=False;MultipleActiveResultSets=True;";

            dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            db = new Database(dbConnection);
        }

        public decimal AverageEmployeesSalary()
        {
            using (dbConnection)
            {
                string query = "Select avg(salary) from employees";
                var res= db.ExecuteScalar<decimal?>(query);
                return res ?? 0;
            }
        }

        public bool DeleteFirstDepartmentEmployee()
        {
            using (dbConnection)
            {
                string query = "Delete top (1) from DepartmentEmployees";
                db.Execute(query);
                return true;
            }
        }

        public bool ExistsSalary(decimal salary)
        {
            using (dbConnection)
            {
                string query = @"select  case WHEN count(Id) <=0 THEN 0
    WHEN count(Id) >0 THEN 1 end
	from Employees
	where    exists ( select salary from Employees e where Salary=@Salary )";

                var parameters = new
                {
                    Salary = salary
                };

                return db.ExecuteScalar<bool>(query,parameters);
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            using (dbConnection)
            {
                string query = "select * from Employees";
                var res = db.Query<Employee>(query).ToList();
                return res;
            }
        }

        public IEnumerable<DepartmentEmployeeSalary> GetDepartmentEmployeeSalary()
        {
            using (dbConnection)
            {
                string query = @"select d.id as DepartmentId,d.Name as DepartmentName, sum(e.Salary) as SalarySum from DepartmentEmployees de inner join Employees e on de.EmployeeId=e.Id inner join Departments d on de.DepartmentId=d.Id
group by d.Id,d.Name";
                var result = db.Query<DepartmentEmployeeSalary>(query).ToList();
                return result;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (dbConnection)
            {
                return db.SingleOrDefault<Employee>("select * from Employees where id=@EmployeeId", new
                {
                    EmployeeId = id,
                });
            }
        }

        public bool InsertEmployee(Employee model)
        {
            using (dbConnection)
            {
                db.Save("Employees", "Id", new
                {
                    Id = DBNull.Value,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    EmployeeTitleId = model.EmployeeTitleId

                });
            }
            return true;
        }

        public IEnumerable<Employee> UnionEmployees()
        {
            using (dbConnection)
            {
                string query = @"select * from Employees where Salary < 3000
union 
select * from Employees where Salary > 6000";
                var res= db.Query<Employee>(query).ToList();            
                return res;
            }
        }

        public bool UpdateEmployee(int id, Employee model)
        {
            using (dbConnection)
            {
                var parameters = new
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    EmployeeTitleId = model.EmployeeTitleId,
                    Salary = model.Salary,
                    Id = model.Id
                };
                db.Update("Employees", "Id", parameters);
                return true;
            }
        }
    }
}
