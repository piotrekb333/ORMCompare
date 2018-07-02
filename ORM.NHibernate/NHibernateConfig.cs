using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using ORM.NHibernate.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.NHibernate
{
    public class NHibernateConfig
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {


            _sessionFactory = Fluently.Configure()
       .Database(MsSqlConfiguration.MsSql2012
       .ConnectionString(@"Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=false;TrustServerCertificate=False;MultipleActiveResultSets=True;"))
       .Mappings(m => m
       .FluentMappings.AddFromAssemblyOf<Employee>())
       .BuildSessionFactory();
            /*
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(
                  @"Data Source=DESKTOP-2F2DTR9\\SQLEXPRESS;Initial Catalog=ORM;Integrated Security=false;TrustServerCertificate=False;MultipleActiveResultSets=True;") // Modify your ConnectionString
                              .ShowSql()
                )
                .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Employee>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(true, true))
                .BuildSessionFactory();
                */
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
