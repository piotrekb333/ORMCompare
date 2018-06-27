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
            string source = ORMCompare.Properties.Settings.Default.IP;
            string user = "";
            string security = "True";
            if (!string.IsNullOrEmpty(ORMCompare.Properties.Settings.Default.Port))
            {
                source += "," + ORMCompare.Properties.Settings.Default.Port;
            }
            if (!string.IsNullOrEmpty(ORMCompare.Properties.Settings.Default.Login))
            {
                user = $"User Id={ORMCompare.Properties.Settings.Default.Login};Password={ORMCompare.Properties.Settings.Default.Password};";
                security = "False";
            }
            return $"Data Source={source};Initial Catalog={ORMCompare.Properties.Settings.Default.DatabaseName};Integrated Security={security};{user}TrustServerCertificate=False;MultipleActiveResultSets=True;";
            
        }
    }
}
