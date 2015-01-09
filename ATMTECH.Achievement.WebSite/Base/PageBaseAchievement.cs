using System;
using System.Web.UI.WebControls;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Achievement.WebSite.Base
{
    public class PageBaseAchievement<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseAccomplissementPresenter<TView>
    {
        public TPresenter Presenter { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        }

        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {
                if (Master != null)
                {
                    Panel panel = (Panel)Master.FindControl("pnlSuccess");
                    Label literal = (Label)Master.FindControl("lblSuccess");
                    literal.Text = message.Description;
                    panel.Visible = true;
                }
            }
            else
            {
                if (Master != null)
                {
                    Panel panel = (Panel)Master.FindControl("pnlError");
                    Label literal = (Label)Master.FindControl("lblError");
                    literal.Text = message.Description;
                    panel.Visible = true;
                }
            }
        }

    }


}