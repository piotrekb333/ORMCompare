using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings;
using ORMSettings.Models;
using ORMSettings.Models.ViewModels;

namespace ADOSqlClient.Repositories.Implementations
{
    public class ADOSqlClientRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        string connectionString = "";//"Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=true;TrustServerCertificate=False;MultipleActiveResultSets=True;";
        public ADOSqlClientRepository()
        {
            connectionString = HelperDatabaseSettings.GetConnectionString();
        }

        public decimal AverageEmployeesSalary()
        {
            decimal val = 0;
            string queryString = "Select avg(salary) from employees";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var res = command.ExecuteScalar();
                connection.Close();
                if(!(res is DBNull))
                {
                    val = Convert.ToDecimal(res);

                }
            }
            return val;
        }

        public bool DeleteFirstDepartmentEmployee()
        {
            string queryString = "Delete top (1) from DepartmentEmployees";
            using (SqlConnection connection =
    new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var res = command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }

        public bool ExistsSalary(decimal salary)
        {
            bool val;
            string queryString = @"select  case WHEN count(Id) <=0 THEN 0
    WHEN count(Id) >0 THEN 1 end
	from Employees
	where    exists ( select salary from Employees e where Salary=@0 )";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@0", salary);

                connection.Open();
                var res = command.ExecuteScalar();
                connection.Close();
                val = Convert.ToBoolean(res);
            }
            return val;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            string queryString = "select * from Employees";
            List<Employee> emp = new List<Employee>();
            using (SqlConnection connection =
    new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var res = command.ExecuteReader();
                while (res.Read())
                {
                    int id = int.Parse(res["Id"].ToString());
                    string firstName = res["FirstName"].ToString();
                    string lastName = res["LastName"].ToString();
                    DateTime dateBirthday = Convert.ToDateTime(res["BirthDay"]);
                    int? titleId=null;
                    int help;
                    if(int.TryParse(res["EmployeeTitleId"]?.ToString(), out help))
                    {
                        titleId = help;
                    }
                    emp.Add(new Employee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Birthday = dateBirthday,
                        EmployeeTitleId = titleId,
                        Id = id

                    });
                }
                connection.Close();

            }
            return emp;
        }

        public IEnumerable<DepartmentEmployeeSalary> GetDepartmentEmployeeSalary()
        {
            string queryString = @"select d.id as DepartmentId,d.Name as DepartmentName, sum(e.Salary) as SalarySum from DepartmentEmployees de inner join Employees e on de.EmployeeId=e.Id inner join Departments d on de.DepartmentId=d.Id
group by d.Id,d.Name";
            List<DepartmentEmployeeSalary> emp = new List<DepartmentEmployeeSalary>();
            using (SqlConnection connection =
    new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var res = command.ExecuteReader();
                while (res.Read())
                {
                    int id = int.Parse(res["DepartmentId"].ToString());
                    string depName = res["DepartmentName"].ToString();
                    decimal salary = Convert.ToDecimal(res["SalarySum"].ToString());
                    emp.Add(new DepartmentEmployeeSalary
                    {
                        DepartmentId=id,
                        DepartmentName=depName,
                        SalarySum=salary

                    });
                }
                connection.Close();

            }
            return emp;
        }

        public Employee GetEmployeeById(int id)
        {
            string queryString = "select * from Employees where id=@0";
            List<Employee> emp = new List<Employee>();
            using (SqlConnection connection =
    new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@0", id);

                connection.Open();
                var res = command.ExecuteReader();
                while (res.Read())
                {
                    int helpid = int.Parse(res["Id"].ToString());
                    string firstName = res["FirstName"].ToString();
                    string lastName = res["LastName"].ToString();
                    DateTime dateBirthday = Convert.ToDateTime(res["BirthDay"]);
                    int? titleId = null;
                    int help;
                    if (int.TryParse(res["EmployeeTitleId"]?.ToString(), out help))
                    {
                        titleId = help;
                    }
                    emp.Add(new Employee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Birthday = dateBirthday,
                        EmployeeTitleId = titleId,
                        Id = helpid

                    });
                }
                connection.Close();

            }
            return emp.FirstOrDefault();
        }

        public bool InsertEmployee(Employee model)
        {
            try
            {
                string queryString = "Insert into Employees (FirstName,LastName,Birthday,EmployeeTitleId) values (@0,@1,@2,@3)";

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@0", model.FirstName);
                    command.Parameters.AddWithValue("@1", model.LastName);
                    command.Parameters.AddWithValue("@2", model.Birthday);
                    command.Parameters.AddWithValue("@3", model.EmployeeTitleId);
                    connection.Open();
                    var res = command.ExecuteNonQuery();
                    connection.Close();

                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Employee> UnionEmployees()
        {
            string queryString = @"select * from Employees where Salary < 3000
union 
select * from Employees where Salary > 6000";
            List<Employee> emp = new List<Employee>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var res = command.ExecuteReader();
                while (res.Read())
                {
                    int id = int.Parse(res["Id"].ToString());
                    string firstName = res["FirstName"].ToString();
                    string lastName = res["LastName"].ToString();
                    DateTime dateBirthday = Convert.ToDateTime(res["BirthDay"]);
                    int? titleId = null;
                    int help;
                    if (int.TryParse(res["EmployeeTitleId"]?.ToString(), out help))
                    {
                        titleId = help;
                    }
                    emp.Add(new Employee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Birthday = dateBirthday,
                        EmployeeTitleId = titleId,
                        Id = id

                    });
                }
                connection.Close();

            }
            return emp;
        }

        public bool UpdateEmployee(int id, Employee model)
        {
            try
            {
                string queryString = "Update Employees set FirstName=@0,LastName=@1,Birthday=@2,TitleId=@3,Salay=@4 where Id=@5";

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@0", model.FirstName);
                    command.Parameters.AddWithValue("@1", model.LastName);
                    command.Parameters.AddWithValue("@2", model.Birthday);
                    command.Parameters.AddWithValue("@3", model.EmployeeTitleId);
                    command.Parameters.AddWithValue("@4", model.Salary);
                    command.Parameters.AddWithValue("@5", id);

                    connection.Open();
                    var res = command.ExecuteNonQuery();
                    connection.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

