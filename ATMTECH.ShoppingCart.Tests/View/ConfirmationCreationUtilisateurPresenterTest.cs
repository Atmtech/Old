using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.ShoppingCart.Tests.View
{
    [TestClass]
    public class ConfirmationCreationUtilisateurPresenterTest : BaseTest<ConfirmationCreationUtilisateurPresenter>
    {
        public Mock<IConfirmationCreationUtilisateurPresenter> ViewMock
        {
            get { return ObtenirMock<IConfirmationCreationUtilisateurPresenter>(); }
        }

        [TestMethod]
        public void OnViewInitialized_DevraitConfirmerLaCreationUtilisateur()
        {
            ViewMock.Setup(x => x.IdConfirmationUtilisateur).Returns(10217271);

            InstanceTest.OnViewInitialized();

            ObtenirMock<ICustomerService>().Verify(x => x.ConfirmCreate(10217271), Times.Once());
        }


    }
}
