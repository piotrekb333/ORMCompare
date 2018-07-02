using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class TimeChartModel
    {
        public List<TimeModel> ChartData { get; set; }
        public string Label { get; set; }
    }
}
