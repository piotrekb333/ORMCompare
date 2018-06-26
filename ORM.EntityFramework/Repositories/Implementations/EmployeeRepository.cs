using ORM.EntityFramework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EntityFramework.Repositories.Implementations
{
    public class EmployeeRepository
    {
        private readonly ORMEntities context;
        public EmployeeRepository()
        {
            context = new ORMEntities(@"metadata=res://*/Database.ORMDatabase.csdl|res://*/Database.ORMDatabase.ssdl|res://*/Database.ORMDatabase.msl;provider=System.Data.SqlClient;provider connection string="";data source=DESKTOP-2F2DTR9\SQLEXPRESS;initial catalog=ORM;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"";");
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
    }
}
