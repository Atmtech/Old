using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Default1 : PageBase<AccueilPresenter, IAccueilPresenter>, IAccueilPresenter
    {
        public string idUtilisateur
        {
            get { return QueryString.GetQueryStringValue(PagesId.UTILISATEUR); }
        }

        public IList<Expedition> Expeditions
        {
            set { ListeExpedition.Expeditions = value; }
        }

        public IList<Categorie> Categories
        {
            set
            {
                FillDropDown(ddlCategorie, value, "NomFr");
            }
        }

    }
}