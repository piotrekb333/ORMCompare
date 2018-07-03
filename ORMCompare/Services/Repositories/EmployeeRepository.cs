
using ORMCompare.Context;
using ORMCompare.Services.Interfaces;
using ORMSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.Services.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IQueryable<Employee> Table => throw new NotImplementedException();
        private IRepository<Employee> employeeRepository;

        public EmployeeRepository()
        {
            var context = new ORMContext();
            employeeRepository = new Repository<Employee>(context);
        }

        public void Delete(Employee entity)
        {
            employeeRepository.Delete(entity);
        }

        public Employee GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee entity)
        {
            employeeRepository.Insert(entity);
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
