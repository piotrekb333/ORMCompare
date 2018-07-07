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
using System.Windows.Threading;

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
            
            TestTimeMethods s = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco);
            TestTimeMethods s1 = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient);
            TestTimeMethods s2 = new TestTimeMethods(EnumsClass.ORMTool.Drapper);
            TestTimeMethods s3 = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework);
            var res3 = s2.UpdateEmployeeTest();
            var res4 = s3.UpdateEmployeeTest();
            var res1 = s.UpdateEmployeeTest();
            var res2 = s1.UpdateEmployeeTest();

            

            TimeChartModel mod = new TimeChartModel();
            mod.ChartData = new List<TimeModel>();
            mod.ChartData.Add(new TimeModel { Name = "PetaPoco", Time = res1 });
            mod.ChartData.Add(new TimeModel { Name = "ADOSql", Time = res2 });
            mod.ChartData.Add(new TimeModel { Name = "Drapper", Time = res3 });
            mod.ChartData.Add(new TimeModel { Name = "EntityFramework", Time = res4 });
            TimeChart ch = new TimeChart(mod);
            ch.ShowDialog();
            /*
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
            LoadDatabaseSettings();
            InitTablesInfo();
        }


        private void InitTablesInfo()
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            var stats = manager.GetTablesStatistics();
            if (stats == null)
                return;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                lbNumberDepartmentEmployees.Content = stats.DepartmentEmployees.ToString();
                lbNumberDepartments.Content = stats.Departments.ToString();
                lbNumberDepartmentsManagers.Content = stats.DepartmentManagers.ToString();
                lbNumberEmployees.Content = stats.Employees.ToString();
                lbNumberEmployeeTitles.Content = stats.EmployeeTitles;
            }), DispatcherPriority.Background);
            /*
            lbNumberDepartmentEmployees.Content = stats.DepartmentEmployees.ToString();
            lbNumberDepartments.Content = stats.Departments.ToString();
            lbNumberDepartmentsManagers.Content = stats.DepartmentManagers.ToString();
            lbNumberEmployees.Content = stats.Employees.ToString();
            lbNumberEmployeeTitles.Content = stats.EmployeeTitles;
            */
        }
        private void InsertRecords()
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
                    InitTablesInfo();
                }, null);
            }
            if (titles > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomEmployeeTitle(titles);
                    InitTablesInfo();
                }, null);
            }
            if (departments > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomDepartment(departments);
                    InitTablesInfo();
                }, null);
            }
            if (managers > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomDepartmentManagers(managers);
                    InitTablesInfo();
                }, null);
            }
            if (depemployees > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.InsertRandomDepartmentEmployees(depemployees);
                    InitTablesInfo();
                }, null);
            }
        }

        private void DeleteRecords()
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
                    manager.DeleteRangeEmployees(employees);
                    InitTablesInfo();
                }, null);
            }
            if (titles > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.DeleteRangeEmployeeTitles(titles);
                    InitTablesInfo();
                }, null);
            }
            if (departments > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.DeleteRangeDepartments(departments);
                    InitTablesInfo();
                }, null);
            }
            if (managers > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.DeleteRangeDepartmentManagers(managers);
                    InitTablesInfo();
                }, null);
            }
            if (depemployees > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate {
                    manager.DeleteRangeDepartmentEmployee(depemployees);
                    InitTablesInfo();
                }, null);
            }
        }

        private void LoadDatabaseSettings()
        {
            SettingsManager manager = new SettingsManager();
            var opt=manager.GetDatabaseSettings();
            txtDatabase.Text = opt.Database;
            txtIp.Text = opt.Ip;
            txtPassword.Text = opt.Password;
            txtLogin.Text = opt.Login;
            txtPort.Text = opt.Port;
        }

        private void SaveDatabaseSettings(DatabaseSettingsModel model)
        {
            SettingsManager manager = new SettingsManager();
            manager.SaveDatabaseSettings(model);

        }

        //EVENTS
        private void BtnInsertRecords_Click(object sender, RoutedEventArgs e)
        {
            InsertRecords();
        }
        private void BtnDeleteRecords_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecords();
        }

        private void btnDeleteAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            manager.DeleteAllEmployees();
            InitTablesInfo();
        }

        private void btnDeleteAllDepartments_Click(object sender, RoutedEventArgs e)
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            manager.DeleteAllDepartments();
            InitTablesInfo();
        }

        private void btnDeleteAllEmployeeTitles_Click(object sender, RoutedEventArgs e)
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            manager.DeleteAllEmployeeTitles();
            InitTablesInfo();
        }

        private void btnDeleteAllDepartmentEmployees_Click(object sender, RoutedEventArgs e)
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            manager.DeleteAllDepartmentEmployee();
            InitTablesInfo();
        }

        private void btnDeleteAllDepartmentsManagers_Click(object sender, RoutedEventArgs e)
        {
            ManageDatabaseService manager = new ManageDatabaseService();
            manager.DeleteAllDepartmentManagers();
            InitTablesInfo();
        }

        private void BtnSaveDatabaseSettings_Click(object sender, RoutedEventArgs e)
        {
            DatabaseSettingsModel model = new DatabaseSettingsModel();
            model.Database = txtDatabase.Text;
            model.Ip = txtIp.Text;
            model.Port = txtPassword.Text;
            model.Login = txtLogin.Text;
            model.Password = txtPassword.Text;
            SaveDatabaseSettings(model);
        }
    }
}
