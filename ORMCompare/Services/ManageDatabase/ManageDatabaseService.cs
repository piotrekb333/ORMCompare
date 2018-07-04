using ORMCompare.Models;
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
            employeeTitleRepository.InsertRandom(Helpers.SPInsertEmployeeTitle, count);
            return true;
        }

        public bool InsertRandomDepartment(int count)
        {
            departmentRepository.InsertRandom(Helpers.SPInsertDepartments, count);
            return true;
        }
        public bool InsertRandomEmployees(int count)
        {
            employeeRepository.InsertRandom(Helpers.SPInsertEmployees, count);
            return true;
        }

        public bool InsertRandomDepartmentManagers(int count)
        {
            departmentManagerRepository.InsertRandom(Helpers.SPInsertDepartmentManagers, count);
            return true;
        }

        public bool InsertRandomDepartmentEmployees(int count)
        {
            departmentEmployeeRepository.InsertRandom(Helpers.SPInsertDepartmentEmployees, count);
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
