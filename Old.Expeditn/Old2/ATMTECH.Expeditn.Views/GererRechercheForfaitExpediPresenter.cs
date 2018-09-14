using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class GererRechercheForfaitExpediPresenter : BaseExpeditnPresenter<IGererRechercheForfaitExpediPresenter>
    {
        public IExpediaService ExpediaService { get; set; }


        public GererRechercheForfaitExpediPresenter(IGererRechercheForfaitExpediPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();

            if (string.IsNullOrEmpty(View.Date))
            {
                View.Date = DateTime.Now.ToShortDateString();
            }

        }


        public void Enregistrer()
        {
            RechercheForfaitExpedia rechercheForfaitExpedia = new RechercheForfaitExpedia
            {
                Nom = View.Nom,
                Url = View.Url,
                DateDepart = Convert.ToDateTime(View.Date),
                NombreJour = 7,
                Utilisateur = AuthenticationService.AuthenticateUser
            };
            ExpediaService.EnregistrerRechercheForfaitExpedia(rechercheForfaitExpedia);
            NavigationService.Redirect(Pages.TABLEAU_BORD);
        }
    }
}