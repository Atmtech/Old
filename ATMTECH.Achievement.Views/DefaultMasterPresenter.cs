using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Common.Constant;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class DefaultMasterPresenter : BaseAccomplissementPresenter<IDefaultMasterPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IFileService FileService { get; set; }
        public IAccomplissementService AccomplissementService { get; set; }

        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            if (AuthenticationService.AuthenticateUser != null)
            {
                View.IsAuthenticated = true;
                View.NomUtilisateur = AuthenticationService.AuthenticateUser.FirstNameLastName;
                File file = FileService.GetFile(AuthenticationService.AuthenticateUser.Image.Id);
                View.ImageUtilisateur = file != null ? file.FileName : "/images/badge/contacts-48.png";
                GenererListeBadge();
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }

        public void Redirect(string page, IList<QueryString> queryStrings)
        {
            NavigationService.Redirect(page, queryStrings);
        }

        public void SetLanguage()
        {
            LocalizationService.CurrentLanguage = LocalizationService.CurrentLanguage == LocalizationLanguage.ENGLISH ?
                LocalizationLanguage.FRENCH : LocalizationLanguage.ENGLISH;
            NavigationService.Refresh();
        }

        public void GenererListeBadge()
        {
            IList<AccomplissementUtilisateur> accomplissementUtilisateurs =
                AccomplissementService.ObtenirListeAccomplissementUtilisateur(AuthenticationService.AuthenticateUser.Id);
            View.AccomplissementUtilisateur = accomplissementUtilisateurs;
        }

        public void SignOut()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
    }
}
