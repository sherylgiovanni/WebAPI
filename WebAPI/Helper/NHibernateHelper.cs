using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Automapping;
using WebAPI.Models;
using NHibernate.Tool.hbm2ddl;

namespace WebAPI.Helper
{
    public class NHibernateHelper
    {
        private NHibernate.ISessionFactory _sessionFactory;

        public NHibernateHelper()
        {
            CreateSessionFactory();
        }

        private void CreateSessionFactory()
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=university;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();
        }

        public NHibernate.ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
