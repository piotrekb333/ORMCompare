using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class DataGridResultModel
    {
        public Guid GuidId { get; set; }
        public double ADO { get; set; }
        public double EntityFramework { get; set; }
        public double Drapper { get; set; }
        public double PetaPoco { get; set; }
        
        public DataGridResultModel()
        {
            this.GuidId = Guid.NewGuid();
        }
    }
}
