using ORMCompare.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.Services.TestService
{
    public class TestService
    {

        public TestService()
        {

        }

        public DataGridResultModel GetTestResult(string testName)
        {
            DataGridResultModel toReturn = new DataGridResultModel();
            switch (testName)
            {
                case "Insert Employee":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).InsertEmployeeTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).InsertEmployeeTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).InsertEmployeeTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).InsertEmployeeTest();
                    break;
                case "Delete first Departament Employee":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).DeleteFirstDepartmentEmployeeTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).DeleteFirstDepartmentEmployeeTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).DeleteFirstDepartmentEmployeeTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).DeleteFirstDepartmentEmployeeTest();
                    break;
                case "Get All Employee":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).GetAllEmployeesTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).GetAllEmployeesTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).GetAllEmployeesTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).GetAllEmployeesTest();
                    break;
                case "Average Employees Salary":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).AverageEmployeesSalaryTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).AverageEmployeesSalaryTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).AverageEmployeesSalaryTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).AverageEmployeesSalaryTest();
                    break;
                case "Get Department Employee Salary":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).GetDepartmentEmployeeSalaryTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).GetDepartmentEmployeeSalaryTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).GetDepartmentEmployeeSalaryTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).GetDepartmentEmployeeSalaryTest();
                    break;
                case "Update Employee":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).UpdateEmployeeTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).UpdateEmployeeTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).UpdateEmployeeTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).UpdateEmployeeTest();
                    break;

                case "Get Employee By Id":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).GetEmployeeByIdTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).GetEmployeeByIdTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).GetEmployeeByIdTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).GetEmployeeByIdTest();
                    break;

                case "Exists Salary":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).ExistsSalaryTest();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).ExistsSalaryTest();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).ExistsSalaryTest();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).ExistsSalaryTest();
                    break;
                case "Union Employees":
                    toReturn.ADO = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient).UnionEmployees();
                    toReturn.EntityFramework = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework).UnionEmployees();
                    toReturn.Drapper = new TestTimeMethods(EnumsClass.ORMTool.Drapper).UnionEmployees();
                    toReturn.PetaPoco = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco).UnionEmployees();
                    break;
            }
            return toReturn;
        }
    }
}
