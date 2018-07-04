﻿using ORMCompare.Models;
using ORMCompare.Services.Interfaces;
using ORMCompare.Services.Repositories;
using ORMSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ORMCompare.Services.ManageDatabase
{
    public class ManageDatabaseService
    {
        IEmployeeRepository employeeRepository;
        IEmployeeTitleRepository employeeTitleRepository;
        IDepartmentRepository departmentRepository;
        IDepartmentManagerRepository departmentManagerRepository;
        IDepartmentEmployeeRepository departmentEmployeeRepository;
        public ManageDatabaseService()
        {
            employeeRepository = new EmployeeRepository();
            employeeTitleRepository = new EmployeeTitleRepository();
            departmentRepository=new DepartmentRepository();
            departmentManagerRepository = new DepartmentManagerRepository();
            departmentEmployeeRepository = new DepartmentEmployeeRepository();
        }


        public bool InsertRandomEmployeeTitle(int count)
        {
            for (int i = 0; i < count; i++)
            {
                EmployeeTitle model = new EmployeeTitle();
                model.Title = "test"+i.ToString();
                Thread t1 = new Thread(() => new EmployeeTitleRepository().Insert(model));
                t1.Start();
                //employeeTitleRepository.Insert(model);
            }
            return true;
        }

        public bool InsertRandomDepartment(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Department model = new Department();
                model.Name = "testDeparment" + i.ToString();
                departmentRepository.Insert(model);
            }
            return true;
        }
        public bool InsertRandomEmployees(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Employee model = new Employee();
                model.Birthday = DateTime.Now;
                model.FirstName = "test";
                model.LastName = "test";
            }
            return true;
        }

        public bool DeleteAllEmployeeTitles()
        {
            employeeTitleRepository.DeleteAll(Helpers.SPDeleteAllEmployeeTitle);
            return true;
        }

        public TablesStatistics GetTablesStatistics()
        {
            TablesStatistics returnModel = new TablesStatistics();
            returnModel.DepartmentEmployees = departmentEmployeeRepository.NumberOfRecords();
            returnModel.DepartmentManagers = departmentManagerRepository.NumberOfRecords();
            returnModel.Departments = departmentRepository.NumberOfRecords();
            returnModel.Employees = employeeRepository.NumberOfRecords();
            returnModel.EmployeeTitles = employeeTitleRepository.NumberOfRecords();
            return returnModel;
        }
    }
}