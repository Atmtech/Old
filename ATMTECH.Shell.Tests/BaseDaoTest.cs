using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Shell.Tests
{
    public class BaseDaoTest
    {
//        using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Data.SQLite;
//using System.Globalization;
//using System.IO;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using SIQ.PESA.Commun.Utils;
//using log4net.Config;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NHibernate;
//using NHibernate.Dialect;
//using NHibernate.Driver;
//using NHibernate.Tool.hbm2ddl;
//using SIQ.PESA.Entite;
//using SIQ.PESA.Persistence.Persistence;
//using Environment = NHibernate.Cfg.Environment;

//namespace SIQ.PESA.Commun.Tests.Base
//{
//    /// <summary>
//    /// Classe de base pour tous les tests unitaires
//    /// de DAO.
//    /// 
//    /// La classe initialise une BD en mémoire (SQLite)
//    /// et pour chaque test, réinitialise toutes les
//    /// tables qui sont générées à partir des mappings
//    /// NHibernate.
//    /// 
//    /// Chaque test doit initialiser le contenu des
//    /// tables pertinentes en implémentant la
//    /// méthode abstraite InitialiserEntites.
//    /// </summary>
//    [TestClass]
//    public abstract class DAOTest
//    {
//        private static NHibernate.Cfg.Configuration _configuration;

//        /// <summary>
//        /// La session NHibernate en cours
//        /// </summary>
//        public ISession Session
//        {
//            get { return StaticGestionnaireSession.Session; }
//        }

//        /// <summary>
//        /// Si vrai, les logs de debug de Hibernate
//        /// vont être affichés dans la console de
//        /// sortie du debugger.
//        /// </summary>
//        public virtual bool EstTraceHibernateActivee { get; set; }

//        protected NHibernate.Cfg.Configuration Configuration
//        {
//            get { return _configuration; }
//        }

//        /// <summary>
//        /// Méthode abstraite à implémenter.
//        /// Permet au test unitaire d'initialiser
//        /// le contenu des tables de la BD en
//        /// mémoire.
//        /// </summary>
//        public abstract void InitialiserEntites();

//        /// <summary>
//        /// Utilitaire pour persister une entité.
//        /// </summary>
//        public void PersisterEntite<T>(T entite) where T : IEntite
//        {
//            Session.Save(entite);
//            Session.Flush();
//            Session.Clear();
//        }

//        /// <summary>
//        /// Utilitaire pour persister une entité qui aurait déjà été persistée.
//        /// </summary>
//        /// <remarks>
//        /// Cette méthode diffère de <see cref="PersisterEntite{T}"/> par le fait qu'elle appellle le SaveOrUpdate de nHibernate
//        /// au lieu de seulement appeller Save, qui force nHibernate à faire un INSERT.
//        /// </remarks>
//        public void EnregistrerEntite<T>(T entite) where T : IEntite
//        {
//            Session.SaveOrUpdate(entite);
//            Session.Flush();
//            Session.Clear();
//        }

//        /// <summary>
//        /// Utilitaire pour persister une liste d'entités
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="entites"></param>
//        public void PersisterEntites<T>(IList<T> entites) where T : IEntite
//        {
//            foreach (T e in entites)
//            {
//                PersisterEntite(e);
//            }
//        }

//        /// <summary>
//        /// Utilitaire pour persister une liste d'entités
//        /// </summary>
//        public void PersisterEntites<T>(ICollection<T> entites) where T : IEntite
//        {
//            foreach (T e in entites)
//            {
//                PersisterEntite(e);
//            }
//        }

//        /// <summary>
//        /// Permet de spécifier une liste d'objets "inline" dans l'appel.
//        /// </summary>
//        public void PersisterPlusieursEntites<T>(params T[] entites) where T: IEntite
//        {
//            PersisterEntites(entites);
//        }

//        /// <summary>
//        /// Initialise la configuration NHibernate
//        /// a partir de la DLL SIQ.PESA.Entite.
//        /// </summary>
//        private static void InitNHibernateSessionFactory()
//        {

//            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
//            // hack car sinon la dll SQLLite n'est pas copiee et donc les TUs ne roulent pas.
//            SQLiteException exp = new SQLiteException();
//            exp.ToString();
//            // ReSharper restore ReturnValueOfPureMethodIsNotUsed

//            if (_configuration == null)
//            {
//                _configuration = new NHibernate.Cfg.Configuration()
//                    .SetProperty(Environment.ShowSql, "true")
//                    .SetProperty(Environment.ReleaseConnections, "on_close")
//                    .SetProperty(Environment.Dialect, typeof (SQLiteDialect).AssemblyQualifiedName)
//                    .SetProperty(Environment.ConnectionDriver,
//                                 typeof (SQLite20Driver).AssemblyQualifiedName)
//                    .SetProperty(Environment.ConnectionString, "Data Source=:memory:");

//                ConfigurerAssembliesEntites();

//                StaticGestionnaireSession.Configuration = _configuration;
//                StaticGestionnaireSession.SessionFactory = _configuration.BuildSessionFactory();
//            }
//        }

//        private static void ConfigurerAssembliesEntites()
//        {
//            ISet<string> assembliesEntites = new SortedSet<string>();
//            assembliesEntites.Add(typeof(DAOTest).Assembly.GetName().Name);

//            foreach (Assembly assemblyTUs in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name.EndsWith("Tests")))
//            {
//                string assemblyTesteNom = assemblyTUs.GetName().Name.Replace(".Tests", "");
//                Assembly assemblyTeste = Assembly.Load(assemblyTesteNom);

//                foreach (
//                    AssemblyName assemblyEntiteName in
//                        assemblyTeste.GetReferencedAssemblies().Where(b => b.Name.EndsWith("Entite")))
//                {
//                    assembliesEntites.Add(assemblyEntiteName.Name);

//                    Assembly assemblyEntite = Assembly.Load(assemblyEntiteName.Name);
//                    foreach (
//                        AssemblyName assemblyEntiteDepName in
//                            assemblyEntite.GetReferencedAssemblies().Where(b => b.Name.EndsWith("Entite")))
//                    {
//                        assembliesEntites.Add(assemblyEntiteDepName.Name);
//                    }
//                }
//            }

//            foreach (string nomAssembly in assembliesEntites)
//            {
//                _configuration.AddAssembly(nomAssembly);
//            }
//        }
      
//        /// <summary>
//        /// Remet à zéro les tables
//        /// </summary>
//        [TestInitialize]
//        public void DAOTestTestInitialize()
//        {
//            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
//            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");

//            DateUtil.ReinitialiserDateSysteme();

//            InitNHibernateSessionFactory();
//            InitTraceHibernate();
//            InitBDMemoire();
//            InitialiserEntites();
//        }

//        /// <summary>
//        /// Ferme la session
//        /// </summary>
//        [TestCleanup]
//        public void DAOTestTestCleanup()
//        {
//            if (Session != null)
//            {
//                Session.Dispose();
//                StaticGestionnaireSession.Session = null;
//            }
//        }

//        private void InitBDMemoire()
//        {
//            StaticGestionnaireSession.Session = StaticGestionnaireSession.SessionFactory.OpenSession();

//            SchemaExport se = new SchemaExport(_configuration);
//            se.Execute(false, true, false, Session.Connection, null);
//        }

//        /// <summary>
//        /// Configure log4net pour afficher
//        /// les traces Debug de NHibernate.
//        /// </summary>
//        private void InitTraceHibernate()
//        {
//            if (EstTraceHibernateActivee)
//            {
//                const string log4Netconfig =
//                    @"
//                <log4net>
//                    <appender name=""trace"" type=""log4net.Appender.TraceAppender"">
//                        <layout type=""log4net.Layout.PatternLayout"">
//                            <conversionPattern value=""%d{ABSOLUTE} %-5p %c{1}:%L - %m%n"" />
//                        </layout>
//                    </appender>
//
//                    <logger name=""NHibernate.SQL"" additivity=""false"">
//                        <level value=""DEBUG""/>
//                        <appender-ref ref=""trace"" />
//                    </logger>
//
//                    <logger name=""NHibernate"">
//                        <level value=""DEBUG"" />
//                        <appender-ref ref=""trace"" />
//                    </logger>
//                </log4net>";

//                XmlConfigurator.Configure(new MemoryStream(Encoding.Default.GetBytes(log4Netconfig)));
//            }
//        }

//        /// <summary>
//        /// Sert à attraper le throw d'une méthode sans try catch et sans tag Expected exception
//        /// </summary>
//        /// <typeparam name="TException"></typeparam>
//        /// <param name="methode"></param>
//        /// <param name="message"></param>
//        public static void AttraperThrows<TException>(Action methode, string message) where TException : Exception
//        {
//            try
//            {
//                methode.Invoke();
//                Assert.Fail("Mauvais throw: Aucune exception");
//            }
//            catch (TException ex)
//            {
//                Assert.AreEqual(message, ex.Message);
//            }
//        }

//    }

//    [TestClass]
//    public abstract class DAOTest<TTypeInstance> : DAOTest where TTypeInstance : class, new()
//    {
//        private TTypeInstance _instanceTest;

//        public TTypeInstance InstanceTest 
//        {
//            get { return _instanceTest; }
//        }

//        [TestInitialize]
//        public void InitialiserInstanceTest()
//        {
//            _instanceTest = new TTypeInstance();
//        }

//        public abstract override void InitialiserEntites();
//    }
//}

        //[TestClass]
        //public abstract class DAOTest<TTypeInstance> : DAOTest where TTypeInstance : class, new()
        //{
        //    private TTypeInstance _instanceTest;

        //    public TTypeInstance InstanceTest
        //    {
        //        get { return _instanceTest; }
        //    }

        //    [TestInitialize]
        //    public void InitialiserInstanceTest()
        //    {
        //        _instanceTest = new TTypeInstance();
        //    }

        //    public abstract override void InitialiserEntites();
        //}

    }
}
