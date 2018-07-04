using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMSettings.Models;
using PetaPoco;
namespace ORM.PetaPoco.Repositories.Implementations
{
    public class PetaPocoRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        private IDatabase db;
        private IDbConnection dbConnection;
        public PetaPocoRepository()
        {
            string connectionString = "Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=true;TrustServerCertificate=False;MultipleActiveResultSets=True;";
            dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            db = new Database(dbConnection);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            using (dbConnection)
            {
                const string query = "select * from Employees";
                var res = db.Query<Employee>(query).ToList();
                return res;
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
    }
}
