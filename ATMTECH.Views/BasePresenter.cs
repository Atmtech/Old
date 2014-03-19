using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Common.Constant;
using ATMTECH.Common.Context;
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

        }

        public virtual void OnViewLoaded()
        {
        }

        public void Log()
        {
            LogService.LogVisit();
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



    }
}
