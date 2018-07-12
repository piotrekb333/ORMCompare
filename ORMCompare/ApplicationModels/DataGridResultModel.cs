﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class DataGridResultModel
    {
        public Guid GuidId { get; set; }
        public long ADO { get; set; }
        public long EntityFramework { get; set; }
        public long Drapper { get; set; }
        public long PetaPoco { get; set; }
        
        public DataGridResultModel()
        {
            this.GuidId = Guid.NewGuid();
        }
    }
}