﻿using ORMSettings.Inftrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMSettings.Models
{
    public class Department:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
