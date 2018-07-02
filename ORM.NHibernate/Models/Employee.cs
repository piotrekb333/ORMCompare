using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.NHibernate.Models
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual int? EmployeeTitleId { get; set; }
    }
}
