using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.PubJL
{
    public class PageBaseShoppingCart<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseShoppingCartPresenter<TView>
    {
        public TPresenter Presenter { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                List<Control> allControls = new List<Control>();
                GetControlList(Page.Controls, allControls);
                Presenter.Controls = allControls;
                Presenter.Localize();
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

            ResetErrorMessage();
        }

        private void ResetErrorMessage()
        {
            Panel panel = (Panel)Master.FindControl("pnlError");
            panel.Visible = false;
        }

        private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection) where T : Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);

                if (control.HasControls())
                    GetControlList(control.Controls, resultCollection);
            }
        }

        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {
                Panel panel = (Panel)Master.FindControl("pnlSuccess");
                Label literal = (Label)Master.FindControl("lblSuccess");
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