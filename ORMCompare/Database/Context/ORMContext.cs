
using ORMCompare.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ORMCompare.Context
{
    public class ORMContext : DbContext
    {
        public ORMContext() : base(Helpers.GetConnectionString())
        {
        }

        #region DBSets
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
        public DbSet<DepartmentManager> DepartmentManagers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        #endregion
    }
}
