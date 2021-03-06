﻿using ORMCompare.Context;
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
using ORMCompare.Services.TestService;
using System.Collections.ObjectModel;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace ORMCompare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DataGridResultModel> dataGridList;
        TestService testService;
        IManageDatabaseRepository databaseManagment;
        public MainWindow()
        {
            InitializeComponent();
            LoadDatabaseSettings();
            databaseManagment = new ManageDatabaseRepository(new ORMContext());
            if (!databaseManagment.CheckIfExistsDatabase())
            {
                MessageBox.Show("Database doesn't exists! Please type database settings in Tab 'Database and click CREATE'");
            }
            else
            {
                InitAll();
            }
            //CheckDatabase();            
            /*
            TestTimeMethods s = new TestTimeMethods(EnumsClass.ORMTool.PetaPoco);
            TestTimeMethods s1 = new TestTimeMethods(EnumsClass.ORMTool.ADOSqlClient);
            TestTimeMethods s2 = new TestTimeMethods(EnumsClass.ORMTool.Drapper);
            TestTimeMethods s3 = new TestTimeMethods(EnumsClass.ORMTool.EntityFramework);
            var res3 = s2.ExistsSalaryTest();
            var res4 = s3.ExistsSalaryTest();
            var res1 = s.ExistsSalaryTest();
            var res2 = s1.ExistsSalaryTest();

            

            TimeChartModel mod = new TimeChartModel();
            mod.ChartData = new List<TimeModel>();
            mod.ChartData.Add(new TimeModel { Name = "PetaPoco", Time = res1 });
            mod.ChartData.Add(new TimeModel { Name = "ADOSql", Time = res2 });
            mod.ChartData.Add(new TimeModel { Name = "Drapper", Time = res3 });
            mod.ChartData.Add(new TimeModel { Name = "EntityFramework", Time = res4 });
            */
           // TimeChart ch = new TimeChart(mod);
           // ch.ShowDialog();
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
        }

        private void InitAll()
        {
            FillCbMethods();
            InitTablesInfo();
            dataGridList = new ObservableCollection<DataGridResultModel>();
            testService = new TestService();
        }

        private void CheckDatabase()
        {
            if (databaseManagment.CheckDatabase())
            {
                InitAll();
            }
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

        private void FillCbMethods()
        {
            cbMethod.Items.Add("Insert Employee");
            cbMethod.Items.Add("Delete first Departament Employee");
            cbMethod.Items.Add("Get All Employee");
            cbMethod.Items.Add("Average Employees Salary");
            cbMethod.Items.Add("Get Department Employee Salary");
            cbMethod.Items.Add("Update Employee");
            cbMethod.Items.Add("Get Employee By Id");
            cbMethod.Items.Add("Exists Salary");
            cbMethod.Items.Add("Union Employees");
            cbMethod.Items.Add("Database info");
            cbMethod.Items.Add("Employees with title");
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

        private void ConvertTable()
        {
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter("GridData.csv");
            // First we will write the headers.
            var ds= Helpers.ToDataSet(dataGridList.ToList());
            DataTable dt = ds.Tables[0];

            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void CheckExistsDatabase()
        {

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
            model.Port = txtPort.Text;
            model.Login = txtLogin.Text;
            model.Password = txtPassword.Text;
            SaveDatabaseSettings(model);
            MessageBox.Show("Changes was saved!");
        }

        private void BtnGenerateResult_Click(object sender, RoutedEventArgs e)
        {
            if (cbMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Choose test!");
                return;               
            }
            var res=testService.GetTestResult(cbMethod.SelectedValue?.ToString());
            dataGridList.Add(res);
            DGTestResult.ItemsSource = dataGridList;
        }

        private void BtnChart_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridList.Count > 1)
            {
                ChartStatistics model = new ChartStatistics();
                List<long> ado = new List<long>();
                List<long> entity = new List<long>();
                List<long> petapoco = new List<long>();
                List<long> drapper = new List<long>();

                foreach (var item in dataGridList)
                {
                    ado.Add((long)item.ADO);
                    entity.Add((long)item.EntityFramework);
                    petapoco.Add((long)item.PetaPoco);
                    drapper.Add((long)item.Drapper);
                }
                model.ADO = ado;
                model.EntityFramework = entity;
                model.PetaPoco = petapoco;
                model.Drapper = drapper;
                TimeChart chart = new TimeChart(model);
                chart.ShowDialog();
            }
            ///
            else if(dataGridList.Count==1)
            {
                TimeChartModel mod = new TimeChartModel();
                mod.ChartData = new List<TimeModel>();
                mod.ChartData.Add(new TimeModel { Name = ".NET ADO", Time = (long)dataGridList[0].ADO });
                mod.ChartData.Add(new TimeModel { Name = "Entity Framework", Time = (long)dataGridList[0].EntityFramework });
                mod.ChartData.Add(new TimeModel { Name = "PetaPoco", Time = (long)dataGridList[0].PetaPoco });
                mod.ChartData.Add(new TimeModel { Name = "Drapper", Time = (long)dataGridList[0].Drapper });
                TimeChart ch = new TimeChart(mod);
                ch.ShowDialog();
            }



        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            dataGridList.Clear();
        }

        private void BtnConvertTable_Click(object sender, RoutedEventArgs e)
        {
            ConvertTable();
        }

        private void BtnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            var res=DGTestResult.SelectedItems;
            List<Guid> toDelete = new List<Guid>();
            foreach(var item in res)
            {
                DataGridResultModel resItem = item as DataGridResultModel;
                if (resItem == null)
                    continue;
                toDelete.Add(resItem.GuidId);
            }
            dataGridList.Where(m => toDelete.Contains(m.GuidId)).ToList().ForEach(m =>
            {
                dataGridList.Remove(m);
            });

        }

        private void DGTestResult_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "GuidId")
            {
                e.Cancel = true;
            }
        }

        private void BtnGenerateDatabase_Click(object sender, RoutedEventArgs e)
        {
            databaseManagment.CheckDatabase();
            //CheckDatabase();
        }

        private void BtnTestConnection_Click(object sender, RoutedEventArgs e)
        {
            if (databaseManagment.CheckDatabase())
                MessageBox.Show("OK");
            else
            {
                MessageBox.Show("Fail!");
            }
        }

        private void BtnChartDouble_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridList.Count > 1)
            {
                ChartStatisticsDoubleModel model = new ChartStatisticsDoubleModel();
                List<double> ado = new List<double>();
                List<double> entity = new List<double>();
                List<double> petapoco = new List<double>();
                List<double> drapper = new List<double>();

                foreach (var item in dataGridList)
                {
                    ado.Add(item.ADO);
                    entity.Add(item.EntityFramework);
                    petapoco.Add(item.PetaPoco);
                    drapper.Add(item.Drapper);
                }
                model.ADO = ado;
                model.EntityFramework = entity;
                model.PetaPoco = petapoco;
                model.Drapper = drapper;
                TimeChart chart = new TimeChart(model);
                chart.ShowDialog();
            }
        }
    }
}
