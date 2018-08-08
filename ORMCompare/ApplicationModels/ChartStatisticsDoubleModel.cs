using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class ChartStatisticsDoubleModel
    {
        public List<double> ADO { get; set; }
        public List<double> EntityFramework { get; set; }
        public List<double> Drapper { get; set; }
        public List<double> PetaPoco { get; set; }
    }
}
