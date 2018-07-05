using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings.Models;

using System.Data;

using Dapper;
using ORMSettings;

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
                const string query = "Select avg(salary) from employees";
                return connection.ExecuteScalar<decimal>(query);
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            using (connection)
            {
                const string query = "select * from Employees";
                return  connection.Query<Employee>(query);
            }
        }

        public bool InsertEmployee(Employee model)
        {
            using (connection)
            {
                const string query = "Insert into Employees (FirstName,LastName,Birthday,EmployeeTitleId) values (@Name,@Last,@Birth,@TitleId)";
                var parameters = new
                {
                    Name = model.FirstName,
                    Last = model.LastName,
                    Birth = model.Birthday,
                    TitleId = model.EmployeeTitleId
                };
                var exec=connection.Execute(query, parameters);
                if (exec > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
