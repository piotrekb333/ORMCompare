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
    public class EmployeeTitleRepository : IEmployeeTitleRepository
    {
        public IQueryable<EmployeeTitle> Table => throw new NotImplementedException();
        private IRepository<EmployeeTitle> employeeTitleRepository;

        public EmployeeTitleRepository()
        {
            var context = new ORMContext();
            employeeTitleRepository = new Repository<EmployeeTitle>(context);
        }

        public void Delete(EmployeeTitle entity)
        {
            employeeTitleRepository.Delete(entity);
        }

        public EmployeeTitle GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(EmployeeTitle entity)
        {
            employeeTitleRepository.Insert(entity);
        }

        public void Update(EmployeeTitle entity)
        {
            throw new NotImplementedException();
        }
        public void DeleteLast()
        {
            employeeTitleRepository.DeleteLast();
        }

        public long NumberOfRecords()
        {
            return employeeTitleRepository.NumberOfRecords();
        }
        public void DeleteAll(string procedureName)
        {
            employeeTitleRepository.DeleteAll(procedureName);
        }
    }
}
