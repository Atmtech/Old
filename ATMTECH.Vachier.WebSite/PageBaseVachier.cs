using System;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Vachier.Views.Base;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Vachier.WebSite
{
    public class PageBaseVachier<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseVachierPresenter<TView>
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
                Panel panel = (Panel)Master.FindControl("pnlSuccess");
                Label literal = (Label)Master.FindControl("lblSucces");
                literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                panel.Visible = true;
            }
            else
            {
                Panel panel = (Panel)Master.FindControl("pnlError");
                Label literal = (Label)Master.FindControl("lblError");
                literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                panel.Visible = true;
            }
        }

    }


}