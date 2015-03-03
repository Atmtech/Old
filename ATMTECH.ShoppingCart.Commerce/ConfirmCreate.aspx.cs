using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ConfirmCreate : PageBase<ConfirmationCreationUtilisateurPresenter, IConfirmationCreationUtilisateurPresenter>, IConfirmationCreationUtilisateurPresenter
    {
        public int IdConfirmationUtilisateur { get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.CONFIRM_CREATE)); } }
        public bool EstConfirme { set { lblCreationCompteConfirme.Visible = value; } }
    }
}