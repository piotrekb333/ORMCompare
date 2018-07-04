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
    public class DepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        public IQueryable<DepartmentEmployee> Table => throw new NotImplementedException();
        private IRepository<DepartmentEmployee> departmentEmployeeRepository;

        public DepartmentEmployeeRepository()
        {
            var context = new ORMContext();
            departmentEmployeeRepository = new Repository<DepartmentEmployee>(context);
        }
        public void Delete(DepartmentEmployee entity)
        {
            departmentEmployeeRepository.Delete(entity);
        }

        public DepartmentEmployee GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DepartmentEmployee entity)
        {
            departmentEmployeeRepository.Insert(entity);
        }

        public void Update(DepartmentEmployee entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteLast()
        {
            departmentEmployeeRepository.DeleteLast();
        }

        public long NumberOfRecords()
        {
            return departmentEmployeeRepository.NumberOfRecords();
        }
        public void DeleteAll(string procedureName)
        {
             departmentEmployeeRepository.DeleteAll(procedureName);
        }

        public void InsertRandom(string procedureName, int number)
        {
            departmentEmployeeRepository.InsertRandom(procedureName, number);
        }

        public void DeleteRange(string procedureName, int number)
        {
            departmentEmployeeRepository.DeleteRange(procedureName, number);
        }
    }
}
