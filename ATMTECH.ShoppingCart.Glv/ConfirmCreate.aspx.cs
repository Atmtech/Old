using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Glv
{
    public partial class ConfirmCreate : PageBaseShoppingCart<ConfirmCreatePresenter, IConfirmCreatePresenter>, IConfirmCreatePresenter
    {
        public int IdConfirm
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.CONFIRM_CREATE)); }
        }

        public bool IsConfirmed
        {
            set
            {
                if (value)
                {
                    pnlConfirmed.Visible = true;
                    pnlNotConfirmed.Visible = false;
                }
                else
                {
                    pnlConfirmed.Visible = false;
                    pnlNotConfirmed.Visible = true;
                }
            }
        }

    }
}