using AutoMapper;
using ORM.EntityFramework.Database;
using ORMSettings;
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
        private readonly Entities context;
        private string connectionString = "";
        public EntityFrameworkRepository()
        {
            connectionString = HelperDatabaseSettings.GetConnectionString();
            //context = new Entities(@"metadata=res://*/Database.ORMEntities.csdl|res://*/Database.ORMEntities.ssdl|res://*/Database.ORMEntities.msl;provider=System.Data.SqlClient;provider connection string="";data source=DESKTOP-2F2DTR9\SQLEXPRESS;initial catalog=ORM;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"";");
            context = new Entities($@"metadata=res://*/Database.ORMEntities.csdl|res://*/Database.ORMEntities.ssdl|res://*/Database.ORMEntities.msl;provider=System.Data.SqlClient;provider connection string="";{connectionString}"";");

        }

        public decimal AverageEmployeesSalary()
        {
            return context.Employees.Average(m => m.Salary);
        }

        public bool DeleteFirstDepartmentEmployee()
        {
            var first=context.DepartmentEmployees.FirstOrDefault();
            if (first != null)
                context.DepartmentEmployees.Remove(first);
            return true;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lastOutput = new List<Employee>();
            var result= context.Employees.ToList();
            /*
            var mapConf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ORM.EntityFramework.Database.Employees, ORMSettings.Models.Employee>();
            });
            IMapper mapper = mapConf.CreateMapper();
            var output = mapper.Map<List<ORM.EntityFramework.Database.Employees>, List<ORMSettings.Models.Employee>>(result);
            */
            foreach(var item in result)
            {
                lastOutput.Add(new Employee { FirstName = item.FirstName, LastName = item.LastName, Birthday = item.Birthday, EmployeeTitleId = item.EmployeeTitleId, Id = item.Id });
            }
            return lastOutput;
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
