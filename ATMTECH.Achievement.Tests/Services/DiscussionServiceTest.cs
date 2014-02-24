using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services;
using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Achievement.Tests.Services
{
    [TestClass]
    public class DiscussionServiceTest : BaseTest<DiscussionService>
    {
        public Mock<IDAODiscussion> MockDAODiscussion { get { return ObtenirMock<IDAODiscussion>(); } }
        public Mock<IDAODiscussionReponse> MockDAODiscussionReponse { get { return ObtenirMock<IDAODiscussionReponse>(); } }

        [TestMethod]
        public void Creer_SiDescriptionVideErreur()
        {
            InstanceTest.Creer(string.Empty);

            MockMessageService.Verify(test => test.ThrowMessage(Achievement.Services.ErrorCode.ErrorCode.ACH_MESSAGE_OBLIGATOIRE));
        }

        [TestMethod]
        public void Creer_DoitCreerAvecBonParametre()
        {
            User user = AutoFixture.Create<User>();
            MockAuthenticationService.Setup(x => x.AuthenticateUser).Returns(user);

            InstanceTest.Creer("Test");

            MockDAODiscussion.Verify(test => test.Creer(It.Is<Discussion>(it => it.Utilisateur.FirstNameLastName == user.FirstNameLastName)), Times.Once());
            MockDAODiscussion.Verify(test => test.Creer(It.Is<Discussion>(it => it.Description == "Test")), Times.Once());

        }

        [TestMethod]
        public void AjouterCommentaire_SiDescriptionVideErreur()
        {
            InstanceTest.AjouterCommentaire(0, string.Empty);

            MockMessageService.Verify(test => test.ThrowMessage(Achievement.Services.ErrorCode.ErrorCode.ACH_COMMENTAIRE_OBLIGATOIRE));
        }

        [TestMethod]
        public void AjouterCommentaire_DoitAjouterAvecBonParametre()
        {
            User user = AutoFixture.Create<User>();
            Discussion discussion = AutoFixture.Create<Discussion>();

            MockAuthenticationService.Setup(x => x.AuthenticateUser).Returns(user);
            MockDAODiscussion.Setup(test => test.ObtenirDiscussion(It.IsAny<int>())).Returns(discussion);
            InstanceTest.AjouterCommentaire(discussion.Id, "Test");

            MockDAODiscussionReponse.Verify(test => test.Enregistrer(It.Is<DiscussionReponse>(it => it.Utilisateur.FirstNameLastName == user.FirstNameLastName)), Times.Once());
            MockDAODiscussionReponse.Verify(test => test.Enregistrer(It.Is<DiscussionReponse>(it => it.Description == "Test")), Times.Once());
            MockDAODiscussionReponse.Verify(test => test.Enregistrer(It.Is<DiscussionReponse>(it => it.Discussion.Id == discussion.Id)), Times.Once());

        }
    }
}
