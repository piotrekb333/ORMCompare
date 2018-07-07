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
    public class DepartmentRepository : IDepartmentRepository
    {
        public IQueryable<Department> Table => throw new NotImplementedException();
        private IRepository<Department> departmentRepository;


        public DepartmentRepository()
        {
            var context = new ORMContext();
            departmentRepository = new Repository<Department>(context);
        }

        public void Delete(Department entity)
        {
            departmentRepository.Delete(entity);
        }

        public Department GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Department entity)
        {
            departmentRepository.Insert(entity);
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
        public void DeleteLast()
        {
            departmentRepository.DeleteLast();
        }

        public long NumberOfRecords()
        {
            return departmentRepository.NumberOfRecords();
        }
        public void DeleteAll(string procedureName)
        {
            departmentRepository.DeleteAll(procedureName);
        }
        public void InsertRandom(string procedureName, int number)
        {
            departmentRepository.InsertRandom(procedureName, number);
        }
        public void DeleteRange(string procedureName, int number)
        {
            departmentRepository.DeleteRange(procedureName, number);
        }
        public Department GetFirst()
        {
            return departmentRepository.GetFirst();
        }
    }
}
