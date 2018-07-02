using ADOSqlClient.Repositories.Implementations;
using ORM.EntityFramework.Repositories.Implementations;
using ORMCompare.EnumsClass;
using ORMSettings.Interfaces;
using System;
namespace ORMCompare.Services
{
    public class TestTimeMethods
    {
        IORMDatabaseMethods repo;
        public TestTimeMethods(ORMTool tool)
        {
            switch (tool)
            {
                case ORMTool.EntityFramework:
                    repo = new EntityFrameworkRepository();
                    break;
                case ORMTool.ADOSqlClient:
                    repo = new ADOSqlClientRepository();
                    break;
            }
                 
        }    
        public long EntityFrameworkInsertEmployee()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            repo.InsertEmployee(new ORMSettings.Models.Employee
            {
                Birthday = DateTime.Now,
                FirstName = "test",
                LastName = "test"
            });
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }
    }
}
