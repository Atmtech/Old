using System;
using System.Configuration;
using ATMTECH.BDD.Object.Base;

namespace ATMTECH.BDD.Object
{
    public sealed class Text : Element
    {

        public Text(string value)
        {
            value = value.Replace("'", @"\'");
            if (EstElementPresentParJQuery(ObtenirSelecteurJQueryEdition(value)))
            {
                WebElement = TrouverElementParJQuery(ObtenirSelecteurJQueryEdition(value));
            }
            else if (EstElementPresentParJQuery(ObtenirSelecteurJQueryLectureSeule(value)))
            {
                WebElement = TrouverElementParJQuery(ObtenirSelecteurJQueryLectureSeule(value));
            }
            else if (EstElementPresentParJQuery(ObtenirSelecteurJQueryAvecInputName(value)))
            {
                WebElement = TrouverElementParJQuery(ObtenirSelecteurJQueryAvecInputName(value));
            }
        }

        private string ObtenirSelecteurJQueryAvecInputName(string champ)
        {
            return string.Format("$('input[name*=\"{0}\"]')", champ);
        }

        private string ObtenirSelecteurJQueryEdition(string champ)
        {
            return string.Format("$('.titreLabelAvance:contains(\"{0}\")').next().find('input:text')", champ);
        }

        private string ObtenirSelecteurJQueryLectureSeule(string champ)
        {
            return string.Format("$('.titreLabelAvance:contains(\"{0}\")').next().find(\".controleLectureSeule\")", champ);
        }
        public void SaisirValeur(string valeurChamp)
        {
            Effacer();
            WebElement.SendKeys(valeurChamp);
        }

        public void Effacer()
        {
            WebElement.Click();
            WebElement.Clear();
        }

    }
}
