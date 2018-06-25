using ORMCompare.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare
{
    public class Helpers
    {
        public static string GetConnectionString()
        {
            return $"Data Source={Settings.Default.IP},{Settings.Default.Port};Initial Catalog={Settings.Default.DatabaseName};Integrated Security=False;User Id={Settings.Default.Login};Password={Settings.Default.Password};Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True";
            
        }
    }
}
