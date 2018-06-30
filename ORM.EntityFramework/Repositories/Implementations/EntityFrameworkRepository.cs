using AutoMapper;
using ORM.EntityFramework.Database;
using ORMSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.EntityFramework.Repositories.Implementations
{
    public class EntityFrameworkRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        private readonly ORMEntities context;
        public EntityFrameworkRepository()
        {
            context = new ORMEntities(@"metadata=res://*/Database.ORMDatabase.csdl|res://*/Database.ORMDatabase.ssdl|res://*/Database.ORMDatabase.msl;provider=System.Data.SqlClient;provider connection string="";data source=DESKTOP-2F2DTR9\SQLEXPRESS;initial catalog=ORM;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"";");
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return context.Employees.ToList();
        }

        public bool InsertEmployee(ORMSettings.Models.Employee model)
        {
            try
            {
                var mapConf = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ORMSettings.Models.Employee, ORM.EntityFramework.Database.Employees>();
                });
                IMapper mapper = mapConf.CreateMapper();
                var output = mapper.Map<ORMSettings.Models.Employee, ORM.EntityFramework.Database.Employees>(model);
                context.Employees.Add(output);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
