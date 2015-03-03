﻿using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ConfirmationCreationUtilisateurPresenter : BaseShoppingCartPresenter<IConfirmationCreationUtilisateurPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public ConfirmationCreationUtilisateurPresenter(IConfirmationCreationUtilisateurPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.EstConfirme = CustomerService.ConfirmCreate(View.IdConfirmationUtilisateur);
        }
    }
}