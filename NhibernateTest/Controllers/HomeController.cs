using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NhibernateTest.Data;
using NhibernateTest.Models;
using NHibernate;
using NHibernate.Linq;

namespace NhibernateTest.Controllers
{
    public class HomeController : Controller
    {

        public void DbInit()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var cliff = new Author() {FirstName = "Cliff", LastName = "Mayson"};
                var book1 = new Book() {Author = cliff, Title = "Using Nhibernate", Type = "Non Fiction"};
                var book2 = new Book() {Author = cliff, Title = "Some Boring Piece of Tripe", Type = "Fiction"};

                cliff.Books = new List<Book>() {book1, book2};

                session.SaveOrUpdate(cliff);
                transaction.Commit();
            }
        }  
    

        public List<Author> GetAuthorsDb()
        {
            var sessionFactory = CreateSessionFactory();
            List<Author> authors;

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                authors = session.Query<Author>().ToList(); 
                transaction.Commit();
            }
            return authors;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var model = new HomeModel() {Authors = GetAuthorsDb()};

            return View(model);
        }

        [Route("Initialise-database")]
        public ActionResult InitialiseDb()
        {
            DbInit();
            return View();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnection")))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HomeController>())
              .BuildSessionFactory();
        }
    }
}
