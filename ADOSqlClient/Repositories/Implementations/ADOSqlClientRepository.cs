using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings;
using ORMSettings.Models;

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
                val = Convert.ToDecimal(res);
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
                while (res.NextResult())
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
    }
}

