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
            axis.Foreground= new SolidColorBrush(Color.FromRgb(0,0,0));
            axis.Labels = new List<string>();
            chartModel = model;
            CharSeries = new SeriesCollection();
            colSeries.Values = new ChartValues<long>();
            colSeries.Foreground= new SolidColorBrush(Color.FromRgb(0, 0, 0));
            foreach (var item in model.ChartData)
            {
                colSeries.Values.Add(item.Time);
                axis.Labels.Add(item.Name);
            }
            CharSeries.Add(colSeries);
            this.lvTimeChart.Series = CharSeries;
            this.lvTimeChart.AxisX = new AxesCollection { axis };




        }
    }
}
