using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;

namespace ATMTECH.BDD.Object.Base
{
    public abstract class Element
    {
        public static IWebDriver Driver { get; set; }
        public IWebElement WebElement { get; set; }

        public static int TimeoutImplicite { get { return 20; } }


        protected enum EnumTypeCritereRecherche { Id, XPath, Css, Jquery };
        protected virtual void TrouverElement(string critereRecherche, EnumTypeCritereRecherche enumTypeCritereRecherche)
        {
            switch (enumTypeCritereRecherche)
            {
                case EnumTypeCritereRecherche.Id:
                    RafraichirElementParId(critereRecherche);
                    break;
                case EnumTypeCritereRecherche.Css:
                    WebElement = TrouverElementParCss(critereRecherche);
                    break;
                case EnumTypeCritereRecherche.Jquery:
                    WebElement = TrouverElementParJQuery(critereRecherche);
                    break;
            }
        }

        protected void RafraichirElementParId(string critereRecherche)
        {
            WebElement = TrouverElementParId(critereRecherche);
        }

        protected bool EstElementPresentParJQuery(string jquery)
        {
            string script = string.Format("return {0}[0]", jquery);
            IWebElement element = ((IJavaScriptExecutor)Driver).ExecuteScript(script) as IWebElement;
            return element != null;
        }
        protected IWebElement TrouverElementParJQuery(string selecteurJQuery)
        {
            string script = string.Format("return {0}[0]", selecteurJQuery);
            IWebElement element = RechercheAvecTimeoutImplicite(() => ((IJavaScriptExecutor)Driver).ExecuteScript(script) as IWebElement);
            if (element != null)
                return element;
            else
                throw new NoSuchElementException("Aucun élément retrouvé avec ce cette recherche: " + selecteurJQuery);

        }
        protected IWebElement TrouverElementParJQuery(IWebElement elementParent, string selecteurJQuery)
        {

            IWebElement element =
            RechercheAvecTimeoutImplicite(() => ((IJavaScriptExecutor)Driver).ExecuteScript("return $(arguments[0]).find(\"" + selecteurJQuery + "\")[0]", elementParent) as IWebElement);

            if (element != null)
                return element;
            else
                throw new NoSuchElementException("Aucun élément retrouvé avec ce cette recherche: " + selecteurJQuery);


        }

        public IWebElement TrouverElementParId(string id)
        {
            return Driver.FindElement(By.Id(id));
        }
        public IWebElement TrouverSousElementParId(IWebElement elementParent, string id)
        {
            return elementParent.FindElement(By.Id(id));
        }

        protected IWebElement TrouverElementParCss(string selecteurCss)
        {
            return Driver.FindElement(By.CssSelector(selecteurCss));
        }
        protected IWebElement TrouverElementParCss(IWebElement elementParent, string selecteurCss)
        {
            return elementParent.FindElement(By.CssSelector(selecteurCss));
        }
        protected ReadOnlyCollection<IWebElement> TrouverGroupeSousElementParSelecteurCss(IWebElement elementParent, string selecteurCss)
        {
            return elementParent.FindElements(By.CssSelector(selecteurCss));
        }

        protected IWebElement RechercheAvecTimeoutImplicite(Func<IWebElement> actionTrouver)
        {
            IWebElement element = null;

            DateTime debut = DateTime.Now;
            while (element == null && ((DateTime.Now - debut).TotalSeconds < TimeoutImplicite))
            {
                try
                {
                    element = actionTrouver();
                }
                catch (Exception)
                {
                }

                if (element == null) Thread.Sleep(300);
            }

            return element;
        }

    }

}
