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
            string source = Settings.Default.IP;
            string user = "";
            string security = "True";
            if (!string.IsNullOrEmpty(Settings.Default.Port))
            {
                source += "," + Settings.Default.Port;
            }
            if (!string.IsNullOrEmpty(Settings.Default.Login))
            {
                user = $"User Id={Settings.Default.Login};Password={Settings.Default.Password};";
                security = "False";
            }
            return $"Data Source={source};Initial Catalog={Settings.Default.DatabaseName};Integrated Security={security};{user}TrustServerCertificate=False;MultipleActiveResultSets=True;";
            
        }
    }
}
