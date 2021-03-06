﻿using ORMCompare.Services.Repositories;
using ORMSettings.Inftrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.Services.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        T GetFirst();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        void DeleteLast();
        long NumberOfRecords();
        void DeleteAll(string procedureName);
        void DeleteRange(string procedureName,int number);
        void InsertRandom(string procedureName,int number);
    }
}
