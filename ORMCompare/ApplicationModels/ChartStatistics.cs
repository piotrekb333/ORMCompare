using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class ChartStatistics
    {
        public List<long> ADO { get; set; }
        public List<long> EntityFramework { get; set; }
        public List<long> Drapper { get; set; }
        public List<long> PetaPoco { get; set; }
        public List<string> NumRecord { get; set; }
    }
}
