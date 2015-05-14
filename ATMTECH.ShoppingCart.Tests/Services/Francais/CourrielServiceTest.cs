using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.Services.Francais
{
    [TestClass]
    public class CourrielServiceTest : BaseTest<CourrielService>
    {
        [TestMethod]
        public void RemplacerAvecNomChamp_DevraitRetournerLaBonneValeurDansLaChaineSiUnNiveau()
        {
            User utilisateur = AutoFixture.Create<User>();
            string remplacerAvecNomChamp = InstanceTest.RemplacerAvecNomChamp("Je suis une crevette [ATMTECH.Entities.User.Id]", utilisateur);
            remplacerAvecNomChamp.Should().Be("Je suis une crevette " + utilisateur.Id);
        }

        [TestMethod]
        public void RemplacerAvecNomChamp_DevraitRetournerLaBonneValeurDansLaChaineSiDeuxNiveau()
        {
            Customer client = AutoFixture.Create<Customer>();
            string remplacerAvecNomChamp = InstanceTest.RemplacerAvecNomChamp("Je suis une crevette [ATMTECH.Entities.User.FirstName]", client);
            remplacerAvecNomChamp.Should().Be("Je suis une crevette " + client.User.FirstName);
        }

        [TestMethod]
        public void RemplacerAvecNomChamp_DevraitRetournerLaBonneValeurDansLaChaineSiDeuxNiveauSurPremier()
        {
            Customer client = AutoFixture.Create<Customer>();
            string remplacerAvecNomChamp = InstanceTest.RemplacerAvecNomChamp("Je suis une crevette [ATMTECH.ShoppingCart.Entities.Customer.CustomerNumber]", client);
            remplacerAvecNomChamp.Should().Be("Je suis une crevette " + client.CustomerNumber);
        }

    }
}
