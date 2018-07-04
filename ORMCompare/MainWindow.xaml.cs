using ORMCompare.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ORM.EntityFramework;
using ORM.EntityFramework.Repositories.Implementations;
using ORMCompare.Services;
using ORMCompare.Views;
using ORMCompare.ApplicationModels;
using ORMCompare.Services.Interfaces;
using ORMCompare.Services.Repositories;
using ORMCompare.Services.ManageDatabase;

namespace ORMCompare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            TestTimeMethods s = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco);
            var dd = s.EntityFrameworkInsertEmployee();
            TimeChartModel mod = new TimeChartModel();
            mod.ChartData = new List<TimeModel>();
            mod.ChartData.Add(new TimeModel { Name = "Entity", Time = dd });
            TimeChart ch = new TimeChart(mod);
            ch.ShowDialog();
            
            IEmployeeRepository dd = new EmployeeRepository();
            dd.Insert(new ORMSettings.Models.Employee
            {
                Birthday = DateTime.Now,
                FirstName = "df",
                LastName = "df"
            });

            ManageDatabaseService d = new ManageDatabaseService();
            d.DeleteAllEmployeeTitles();
            */
            //d.InsertRandomEmployeeTitle(100000);
            InitTablesInfo();
        }

        private void BtnInsertRecords_Click(object sender, RoutedEventArgs e)
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            int employees = 0;
            int titles = 0;
            int departments = 0;
            int managers = 0;
            int depemployees = 0;
            int.TryParse(txtInsertEmployees.Text, out employees);
            int.TryParse(txtInsertEmployeeTitles.Text, out titles);
            int.TryParse(txtInsertDepartments.Text, out departments);
            int.TryParse(txtInsertDepartmentManagers.Text, out managers);
            int.TryParse(txtInsertDepartmentEmployees.Text, out depemployees);
            if (employees > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomEmployees(employees);
                }, null);
            }
            if (titles > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomEmployeeTitle(titles);
                }, null);
            }
            if (departments > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomDepartment(departments);
                }, null);
            }
            if (managers > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomDepartmentManagers(managers);
                }, null);
            }
            if (depemployees > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomDepartmentEmployees(depemployees);
                }, null);
            }
        }


        private void InitTablesInfo()
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            var stats=manager.GetTablesStatistics();
            if (stats == null)
                return;
            lbNumberDepartmentEmployees.Content = stats.DepartmentEmployees.ToString();
            lbNumberDepartments.Content = stats.Departments.ToString();
            lbNumberDepartmentsManagers.Content = stats.DepartmentManagers.ToString();
            lbNumberEmployees.Content = stats.Employees.ToString();
            lbNumberEmployeeTitles.Content = stats.EmployeeTitles;
        }
    }
}
