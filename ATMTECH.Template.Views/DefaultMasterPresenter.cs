using System.Collections.Generic;
using ATMTECH.Common.Constant;
using ATMTECH.Template.Views.Base;
using ATMTECH.Template.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Template.Views
{
    public class DefaultMasterPresenter : BaseTemplatePresenter<IDefaultMasterPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
        }

        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }

        public void Redirect(string page, IList<QueryString> queryStrings)
        {
            NavigationService.Redirect(page, queryStrings);
        }

        public void CloseSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }

        public void SetLanguage()
        {
            LocalizationService.CurrentLanguage = LocalizationService.CurrentLanguage == LocalizationLanguage.ENGLISH ?
                LocalizationLanguage.FRENCH : LocalizationLanguage.ENGLISH;
            NavigationService.Refresh();
        }
    }
}
