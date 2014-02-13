using System;
using ATMTECH.BDD.Object;
using ATMTECH.BDD.Object.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

using TechTalk.SpecFlow;

namespace ATMTECH.BDD.Steps
{
    [Binding]
    public class WrapperSpecFlow
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
          //  BaseDonneesHandler.CreerBasesDonnees();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //BaseDonneesHandler.OuvrirTransaction();
            OuvrirNavigateur();
            new Page("http://localhost:52990");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //BaseDonneesHandler.FermerTransaction();
            FermerNavigateur();
            //ChampsUtilisateur.Effacer();
        }

        private static void OuvrirNavigateur()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();

            IWebDriver driver = new InternetExplorerDriver(options);
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, Element.TimeoutImplicite));
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, Element.TimeoutImplicite));
            Element.Driver = driver;
        }

        private static void FermerNavigateur()
        {
            if (Element.Driver != null)
            {
                Element.Driver.Quit();
                Element.Driver = null;
            }
        }
    }
}
