using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings.Models;

namespace ADOSqlClient.Repositories.Implementations
{
    public class ADOSqlClientRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        public bool InsertEmployee(Employee model)
        {
            try
            {
                string connectionString = "Insert into Employees (FirstName,LastName,Birthday,EmployeeTitleId) values (@0,@1,@2,@3)";
                string queryString = "";
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

