using LiveCharts;
using LiveCharts.Wpf;
using ORMCompare.ApplicationModels;
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
using System.Windows.Shapes;

namespace ORMCompare.Views
{
    /// <summary>
    /// Interaction logic for TimeChart.xaml
    /// </summary>
    public partial class TimeChart : Window
    {
        SeriesCollection CharSeries;
        TimeChartModel chartModel;
        public TimeChart(TimeChartModel model)
        {
            InitializeComponent();

            var colSeries = new ColumnSeries();
            Axis axis = new Axis();
            axis.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Axis axisy = new Axis();
            axisy.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            axisy.FontSize = 15;
            axis.Labels = new List<string>();
            axis.MinRange = 0;
           
            axis.FontSize = 15;
            chartModel = model;
            CharSeries = new SeriesCollection();
            colSeries.Values = new ChartValues<long>();
            colSeries.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            foreach (var item in model.ChartData)
            {
                colSeries.Values.Add(item.Time);
                axis.Labels.Add(item.Name);
            }
            CharSeries.Add(colSeries);
            this.lvTimeChart.Series = CharSeries;
            this.lvTimeChart.AxisX = new AxesCollection { axis };
            this.lvTimeChart.AxisY = new AxesCollection { axisy };
        }

        public TimeChart(ChartStatistics model)
        {
            InitializeComponent();
            var SeriesCollection = new SeriesCollection();
            var numTest=model.EntityFramework.Count;
            string[] tests= new string[numTest];
            for(int i = 0; i < numTest; i++)
            {
                tests[i] = "Test " + i.ToString();
            }

            ChartValues<long> entityVal = new ChartValues<long>();
            ChartValues<long> adoVal = new ChartValues<long>();
            ChartValues<long> petapocoVal = new ChartValues<long>();
            ChartValues<long> drapperVal = new ChartValues<long>();
            model.EntityFramework.ForEach(m =>
            {
                entityVal.Add(m);
            });

            model.ADO.ForEach(m =>
            {
                adoVal.Add(m);
            });
            model.PetaPoco.ForEach(m =>
            {
                petapocoVal.Add(m);
            });
            model.Drapper.ForEach(m =>
            {
                drapperVal.Add(m);
            });

            SeriesCollection.Add(new LineSeries
            {
                Title="ADO",
                Values = adoVal,
                PointGeometry = null
            });

            SeriesCollection.Add(new LineSeries
            {
                Title = "Entity Framework",
                Values = entityVal,
                PointGeometry = null
            });

            SeriesCollection.Add(new LineSeries
            {
                Title = "PetaPoco",
                Values = petapocoVal,
                PointGeometry = null
            });

            SeriesCollection.Add(new LineSeries
            {
                Title = "Drapper",
                Values = drapperVal,
                PointGeometry = null
            });

            this.lvTimeChart.Series = SeriesCollection;
            Axis axis = new Axis();
            axis.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            axis.Labels = tests.ToList();
            axis.MinRange = 0;
            axis.FontSize = 15;

            Axis axisy = new Axis();
            axisy.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            axisy.FontSize = 15;
            axisy.MinRange = 0;
            axisy.MinValue = 0;
            this.lvTimeChart.LoadLegend();
            this.lvTimeChart.AxisX = new AxesCollection { axis };
            this.lvTimeChart.AxisY = new AxesCollection { axisy };
            /*
            var SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },

            };
            */
        }


    }
}

