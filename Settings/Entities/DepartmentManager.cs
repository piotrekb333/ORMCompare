﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Settings.Entities
{
    public class DepartmentManager
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
    }
}
