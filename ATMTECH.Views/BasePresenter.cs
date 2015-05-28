using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;
using WebFormsMvp;

namespace ATMTECH.Views
{
    public class BasePresenter<TView> : Presenter<TView>
        where TView : class, IViewBase
    {

        public INavigationService NavigationService { get; set; }
        public IMessageService MessageService { get; set; }
        public ILogService LogService { get; set; }
        public ILocalizationService LocalizationService { get; set; }

        public IList<Control> Controls { get; set; }

        public BasePresenter(TView view)
            : base(view)
        {
        }

        protected BasePresenter()
            : base(null)
        {

        }

        public virtual void OnViewInitialized()
        {
            LogService.LogVisit();
        }

        public virtual void OnViewLoaded()
        {
        }

        public string ObtenirTitrePage()
        {
            return NavigationService.ObtenirTitrePage(Common.Utils.Web.Pages.GetCurrentAbsoluteUri(), LocalizationService.CurrentLanguage);
        }

        public void AjouterPageFilAriane()
        {
            NavigationService.AjouterPageFilArianne(Common.Utils.Web.Pages.GetCurrentAbsoluteUri(), LocalizationService.CurrentLanguage);
        }
        public void Localize()
        {
            LocalizationService.Localize(Controls, LocalizationService.CurrentLanguage);
        }

        public string Localize(string control)
        {
            return LocalizationService.Localize(control, LocalizationService.CurrentLanguage);
        }

        public string ShowMessage(Message message)
        {
            return message.Description + "(" + message.Id.ToString() + ")";
        }

        public void SaveLocalization(IList<Localization> localizations)
        {
            LocalizationService.SaveLocalization(localizations);
        }



    }
}
