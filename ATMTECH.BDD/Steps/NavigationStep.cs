using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.BDD.Object;
using TechTalk.SpecFlow;

namespace ATMTECH.BDD.Steps
{
    [Binding]
    public class NavigationStep
    {
        [Given(@"que je suis sur la page: *(.*)"),
      Given(@"je suis sur la page: *(.*)"),
      When(@"je suis sur la page: *(.*)")]
        public void EtantDonneQueJeSuisSurLaPageX(string url)
        {
            new Navigation().Navigate(url);
        }
    }
}
