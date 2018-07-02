using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using ORMSettings.Models;

namespace ORM.NHibernate.Repositories.Implementations
{
    public class NHibernateRepository : ORMSettings.Interfaces.IORMDatabaseMethods
    {
        private Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;
        public NHibernateRepository()
        {
            mySession = NHibernateConfig.OpenSession();


        }
        public bool InsertEmployee(Employee model)
        {
            using (mySession)
            {
                mySession.Save(model);
            }
            return true;
        }
    }
}
