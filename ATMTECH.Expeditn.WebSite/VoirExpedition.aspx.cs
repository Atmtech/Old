using System;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class VoirExpedition : PageBase<VoirExpeditionPresenter, IVoirExpeditionPresenter>, IVoirExpeditionPresenter
    {
        public Expedition Expedition
        {
            set
            {
                lblNom.Text = value.Nom;
                lblChefListe.Text = value.ChefDeGroupe.Utilisateur.FirstNameLastName;
                lblDateDebutListe.Text = value.Debut.ToString();
                lblDateFinListe.Text = value.Fin.ToString();
            }
        }
        public int IdExpedition
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue("ID")); }
        }
    }
}