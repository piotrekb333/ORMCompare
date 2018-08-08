using AutoMapper;
using ORM.EntityFramework.Database;
using ORMSettings;
using ORMSettings.Models;
using ORMSettings.Models.ViewModels;
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
            try
            {
                decimal? res = context.Employees?.Average(m => m.Salary);
                return res ?? 0;
            }
            catch(System.InvalidOperationException ex)
            {
                return 0;
            }
        }

        public bool DeleteFirstDepartmentEmployee()
        {
            var first=context.DepartmentEmployees.FirstOrDefault();
            if (first != null)
            {
                context.DepartmentEmployees.Remove(first);
                context.SaveChanges();
            }
            return true;
        }

        public bool ExistsSalary(decimal salary)
        {
            return context.Employees.Any(m => m.Salary == salary);
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

        public IEnumerable<DepartmentEmployeeSalary> GetDepartmentEmployeeSalary()
        {
            List<DepartmentEmployeeSalary> res = context.DepartmentEmployees.GroupBy(m => new { m.Departments.Id, m.Departments.Name }).Select(m =>
            new DepartmentEmployeeSalary {
                DepartmentId=m.FirstOrDefault().Departments.Id,
                DepartmentName=m.FirstOrDefault().Departments.Name,
                SalarySum=m.Sum(mc=>mc.Employees.Salary)
            }).ToList();
            return res;
        }

        public Employee GetEmployeeById(int id)
        {
            var res= context.Employees.FirstOrDefault(m => m.Id == id);
            /*
            var mapConf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ORM.EntityFramework.Database.Employees, ORMSettings.Models.Employee>();
            });
            IMapper mapper = mapConf.CreateMapper();
            var output = mapper.Map<ORM.EntityFramework.Database.Employees, ORMSettings.Models.Employee>(res);
            */
            Employee output = new Employee
            {
                Birthday = res.Birthday,
                Id = res.Id,
                FirstName = res.FirstName,
                LastName = res.LastName,
                Salary = res.Salary,
                EmployeeTitleId=res.EmployeeTitleId
            };
            return output;
        }

        public IEnumerable<EmployeeTitleViewModel> GetEmployeesWithTitle()
        {
            List<EmployeeTitleViewModel> output = new List<EmployeeTitleViewModel>();
            var query = context.Employees // your starting point - table in the "from" statement
                .Join(context.EmployeeTitles, // the source table of the inner join
                    post => post
                        .EmployeeTitleId, // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                    meta => meta.Id, // Select the foreign key (the second part of the "on" clause)
                    (post, meta) => new {Post = post, Meta = meta}).ToList();
            query.ForEach(m =>
            {
                output.Add(new EmployeeTitleViewModel{FirstName = m.Post.FirstName,LastName = m.Post.LastName,Title = m.Meta.Title});
            });

            return output;
        }

        public InfoDatabaseModel GetInfoDatabase()
        {
            var mod = new InfoDatabaseModel();
            mod.TitlesCount= context.EmployeeTitles.Count();
            mod.DepartmentsCount = context.Departments.Count();
            mod.EmployeesCount = context.Employees.Count();

            return mod;
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

        public IEnumerable<Employee> UnionEmployees()
        {
            List<Employee> lastOutput = new List<Employee>();
            var result = context.Employees.Where(m=>m.Salary<3000).Union(context.Employees.Where(z=>z.Salary>6000)).ToList();
            foreach (var item in result)
            {
                lastOutput.Add(new Employee { FirstName = item.FirstName, LastName = item.LastName, Birthday = item.Birthday, EmployeeTitleId = item.EmployeeTitleId, Id = item.Id });
            }
            return lastOutput;
        }

        public bool UpdateEmployee(int id, Employee model)
        {
            var emp=context.Employees.FirstOrDefault(m => m.Id == id);
            if (emp == null)
                return false;
            emp.FirstName = model.FirstName;
            emp.LastName = model.LastName;
            emp.EmployeeTitleId = model.EmployeeTitleId;
            emp.Birthday = model.Birthday;
            emp.Salary = model.Salary;
            context.SaveChanges();
            return true;
        }
    }
}
