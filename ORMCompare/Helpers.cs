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
        public static string SPDeleteAllEmployeeTitle = "SP_DeleteAllEmployeeTitles";
        public static string SPDeleteAllDepartmentEmployees = "SP_DeleteAllDepartmentEmployees";
        public static string SPDeleteAllDepartmentManagers = "SP_DeleteAllDepartmentManagers";
        public static string SPDeleteAllDepartments = "SP_DeleteAllDepartments";
        public static string SPDeleteAllEmployees = "SP_DeleteAllEmployees";

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
