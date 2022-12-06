using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;

namespace FluentHibernate_Example_3
{
    public class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = FluentConfigure();
        }
        public static ISession GetCurrentSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }



        public static void CreateSchema()
        {
            Fluently.Configure()
                //which database
                .Database(MySQLConfiguration.Standard
                .ConnectionString(cs => cs.FromConnectionStringWithKey("DBConnection")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                .Execute(false, true))
                .BuildSessionFactory();
        }

        public static ISessionFactory FluentConfigure()
        {
            return Fluently.Configure()
                //which database
                .Database(MySQLConfiguration.Standard
                .ConnectionString(cs => cs.FromConnectionStringWithKey("DBConnection")))

                //.Database(
                //    MsSqlConfiguration.MsSql2012
                //        .ConnectionString(
                //            cs => cs.FromConnectionStringWithKey
                //                  ("DBConnection")) //connection string from app.config
                //                                    //.ShowSql()
                //        )


                //2nd level cache
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                //find/set the mappings
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public static ISessionFactory BuildSessionFactory(string connectionString)
        {
            ISessionFactory sessionFactory = Fluently
                .Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL81
                    .ConnectionString(c => c.Is(connectionString))
                    .ShowSql())

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entities.Employee>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();

            return (ISessionFactory)sessionFactory.OpenSession();
        }
    }
}
