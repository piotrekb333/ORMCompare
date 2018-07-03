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
            */
            IEmployeeRepository dd = new EmployeeRepository();
            dd.Insert(new ORMSettings.Models.Employee
            {
                Birthday = DateTime.Now,
                FirstName = "df",
                LastName = "df"
            });
        }

        private void BtnInsertRecords_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
