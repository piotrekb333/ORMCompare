using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.ApplicationModels
{
    public class DatabaseSettingsModel
    {
        public string Ip { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
