using System;
using System.Configuration;
using ATMTECH.BDD.Object.Base;

namespace ATMTECH.BDD.Object
{
    public sealed class ImageButton : Element
    {

        public ImageButton(string value)
        {
            string recherche = string.Format("$('input[type=\"submit\"][value=\"{0}\"]')", value.Replace("'", @"\'"));
            TrouverElement(recherche, EnumTypeCritereRecherche.Jquery);
        }

        public void Click()
        {
            WebElement.Click();
        }

    }
}
