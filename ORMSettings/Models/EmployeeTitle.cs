using System;
using System.Collections.Generic;
using System.Text;
using ORMSettings.Inftrastructure;

namespace ORMSettings.Models
{
    public class EmployeeTitle : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
}
