using ORM.EntityFramework.Repositories.Implementations;
using ORMSettings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.Services
{
    public class TestTimeMethods
    {

        public long EntityFrameworkInsertEmployee()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            IORMDatabaseMethods repo = new EntityFrameworkRepository();
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
