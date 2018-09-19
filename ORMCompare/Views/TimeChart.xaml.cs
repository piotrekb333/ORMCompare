using LiveCharts;
using LiveCharts.Wpf;
using ORMCompare.ApplicationModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

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
            axisy.Title = "Czas [ms]";
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
            if (model.NumRecord == null || model.NumRecord.Count == 0)
            {
                for (int i = 0; i < numTest; i++)
                {
                    int v = i + 1;
                    tests[i] = "Test " + v.ToString();
                }
            }
            else
                tests = model.NumRecord.ToArray();

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
                Title=".NET ADO",
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
            axisy.Title = "Czas [ms]";
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

        public TimeChart(ChartStatisticsDoubleModel model)
        {
            InitializeComponent();
            var SeriesCollection = new SeriesCollection();
            var numTest = model.EntityFramework.Count;
            string[] tests = new string[numTest];
            if (model.NumRecord == null || model.NumRecord.Count == 0)
            {
                for (int i = 0; i < numTest; i++)
                {
                    int v = i + 1;
                    tests[i] = "Test " + v.ToString();
                }
            }
            else
                tests = model.NumRecord.ToArray();

            ChartValues<double> entityVal = new ChartValues<double>();
            ChartValues<double> adoVal = new ChartValues<double>();
            ChartValues<double> petapocoVal = new ChartValues<double>();
            ChartValues<double> drapperVal = new ChartValues<double>();
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
                Title = ".NET ADO",
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
            axis.Title = "Liczba rekordów";
            Axis axisy = new Axis();
            axisy.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            axisy.FontSize = 15;
            axisy.MinRange = 0;
            axisy.MinValue = 0;
            axisy.Title = "Czas [ms]";
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

