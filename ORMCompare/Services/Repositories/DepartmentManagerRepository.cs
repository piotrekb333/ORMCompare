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
    public class DepartmentManagerRepository : IDepartmentManagerRepository
    {
        public IQueryable<DepartmentManager> Table => throw new NotImplementedException();
        private IRepository<DepartmentManager> departmentManagerRepository;


        public DepartmentManagerRepository()
        {
            var context = new ORMContext();
            departmentManagerRepository = new Repository<DepartmentManager>(context);
        }

        public void Delete(DepartmentManager entity)
        {
            departmentManagerRepository.Delete(entity);
        }

        public DepartmentManager GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DepartmentManager entity)
        {
            departmentManagerRepository.Insert(entity);
        }

        public void Update(DepartmentManager entity)
        {
            throw new NotImplementedException();
        }
        public void DeleteLast()
        {
            departmentManagerRepository.DeleteLast();
        }

        public long NumberOfRecords()
        {
            return departmentManagerRepository.NumberOfRecords();
        }
    }
}
