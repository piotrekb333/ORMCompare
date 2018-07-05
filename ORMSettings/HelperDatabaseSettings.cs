using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ORMSettings
{
    public static class HelperDatabaseSettings
    {
        public static string GetConnectionString()
        {
            string source = Properties.Settings.Default.Ip;
            string user = "";
            string security = "True";
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Port))
            {
                source += "," + Properties.Settings.Default.Port;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Login))
            {
                user = $"User Id={Properties.Settings.Default.Login};Password={Properties.Settings.Default.Password};";
                security = "False";
            }
            return $"Data Source={source};Initial Catalog={Properties.Settings.Default.Database};Integrated Security={security};{user}TrustServerCertificate=False;MultipleActiveResultSets=True;";

        }
        public static string GetIp()
        {
            return Properties.Settings.Default.Ip;
        }

        public static string GetDatabase()
        {
            return Properties.Settings.Default.Database;
        }
        public static string GetPort()
        {
            return Properties.Settings.Default.Port;
        }
        public static string GetLogin()
        {
            return Properties.Settings.Default.Login;
        }
        public static string GetPassword()
        {
            return Properties.Settings.Default.Password;
        }
        //save

        public static void SaveIp(string value)
        {
            Properties.Settings.Default.Ip = value;
            Properties.Settings.Default.Save();
        }

        public static void SaveDatabase(string value)
        {
            Properties.Settings.Default.Database = value;
            Properties.Settings.Default.Save();
        }
        public static void SavePort(string value)
        {
            Properties.Settings.Default.Port = value;
            Properties.Settings.Default.Save();
        }
        public static void SaveLogin(string value)
        {
            Properties.Settings.Default.Login = value;
            Properties.Settings.Default.Save();
        }
        public static void SavePassword(string value)
        {
            Properties.Settings.Default.Password = value;
            Properties.Settings.Default.Save();
        }
    }
}
