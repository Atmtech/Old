using System;
using System.Configuration;
using ATMTECH.BDD.Object.Base;

namespace ATMTECH.BDD.Object
{
    public sealed class Combobox : Element
    {

        public Combobox(string value)
        {
            string recherche = string.Format("$('TD:contains(\"{0}\")').next().find('select')",
                                             value.Replace("'", @"\'"));
            TrouverElement(recherche, EnumTypeCritereRecherche.Jquery);
        }

        public void SaisirValeur(string valeurASaisir)
        {
            WebElement.SendKeys(valeurASaisir);
        }


    }
}
