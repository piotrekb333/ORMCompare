﻿using ORMCompare.Context;
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
    }
}
