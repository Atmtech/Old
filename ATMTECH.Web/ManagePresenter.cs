using System;
using ATMTECH.Common;
using ATMTECH.Common.Context;

namespace ATMTECH.Web
{
    public class ManagePresenter<TPresenter> where TPresenter : new()
    {
        public static TPresenter SetPresenter()
        {
            Type presenterName = typeof(TPresenter);

            if (ContextSessionManager.Context != null)
            {

                if (ContextSessionManager.Context.Session["Presenter" + presenterName.Name] == null)
                {
                    ContextSessionManager.Context.Session["Presenter" + presenterName.Name] = new TPresenter();
                    return (TPresenter)ContextSessionManager.Context.Session["Presenter" + presenterName.Name];
                }
                else
                {
                    return (TPresenter)ContextSessionManager.Context.Session["Presenter" + presenterName.Name];
                }
            }
            else
            {
                var presenter = new TPresenter();
                return presenter;
            }
        }
    }
}
