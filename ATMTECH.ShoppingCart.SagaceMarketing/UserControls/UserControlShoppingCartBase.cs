using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Controls.Affichage;
using WebFormsMvp.Web;

namespace ATMTECH.ShoppingCart.SagaceMarketing.UserControls
{
    public class UserControlShoppingCartBase<TPresenter, TView> : MvpUserControl
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
                GetControlList(Controls, allControls);
                Presenter.Controls = allControls;
                Presenter.Localize();
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

            ResetErrorMessage();
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

        private void ResetErrorMessage()
        {
            Panel panel = (Panel)FindControl("pnlError");
            panel.Visible = false;
        }

        public void ShowMessage(Message message)
        {
            Panel panel = (Panel)FindControl("pnlError");
            Literal literal = (Literal)FindControl("lblError");
            literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
            panel.Visible = true;
        }
    }
}