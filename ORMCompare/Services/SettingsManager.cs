using ORMCompare.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.Services
{
    public class SettingsManager
    {
        public DatabaseSettingsModel GetDatabaseSettings()
        {
            DatabaseSettingsModel model = new DatabaseSettingsModel();
            model.Ip=ORMSettings.HelperDatabaseSettings.GetIp();
            model.Database = ORMSettings.HelperDatabaseSettings.GetDatabase();
            model.Port = ORMSettings.HelperDatabaseSettings.GetPort();
            model.Login = ORMSettings.HelperDatabaseSettings.GetLogin();
            model.Password = ORMSettings.HelperDatabaseSettings.GetPassword();
            return model;
        }

        public void SaveDatabaseSettings(DatabaseSettingsModel model)
        {
            ORMSettings.HelperDatabaseSettings.SaveIp(model.Ip);
            ORMSettings.HelperDatabaseSettings.SaveDatabase(model.Database);
            ORMSettings.HelperDatabaseSettings.SaveLogin(model.Login);
            ORMSettings.HelperDatabaseSettings.SavePassword(model.Password);
            ORMSettings.HelperDatabaseSettings.SavePort(model.Port);

        }
    }
}
