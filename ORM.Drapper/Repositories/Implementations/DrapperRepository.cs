using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings.Models;

using System.Data;

using Dapper;
namespace ORM.Drapper.Repositories.Implementations
{
    public class DrapperRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        IDbConnection connection;
        public DrapperRepository()
        {
            connection = new System.Data.SqlClient.SqlConnection("Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=true;TrustServerCertificate=False;MultipleActiveResultSets=True;");
            connection.Open();
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
