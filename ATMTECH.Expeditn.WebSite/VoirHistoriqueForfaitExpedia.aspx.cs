using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class VoirHistoriqueForfaitExpedia : PageBase<VoirHistoriqueForfaitExpediaPresenter, IVoirHistoriqueForfaitExpediaPresenter>, IVoirHistoriqueForfaitExpediaPresenter
    {
        public IList<string> ListeHotel
        {
             set
        {
            
            ddlListeHotel.DataSource = value;
            ddlListeHotel.DataBind();
        }
        }

        public int IdRechercheForfaitExpedia
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue("ID")); }
        }

        public string FiltreHotel { get { return QueryString.GetQueryStringValue("Filtre"); } }



        public IList<HistoriqueForfaitExpedia> HistoriqueForfaitExpedia
        {
            set
            {
                btnVoirRechercheSurExpedia.NavigateUrl = value.First().RechercheForfaitExpedia.Url;
                lblNom.Text = value.First().RechercheForfaitExpedia.Nom;
                lblDateDepart.Text = value.First().DateDepart.ToString();
                lblNombreJour.Text = value.First().NombreJour.ToString();

                HistoriqueForfaitExpedia maximum = value.FirstOrDefault(x => x.Prix == value.Max(z => z.Prix));
                HistoriqueForfaitExpedia minimum = value.FirstOrDefault(x => x.Prix == value.Min(z => z.Prix));

                lblForfaitMoinsCher.Text = minimum.Prix.ToString("C");
                lblForfaitMoinsCherNomHotel.Text = minimum.NomHotel;
                lblForfaitMoinsCherCompagnie.Text = minimum.CompagnieOrganisatrice;
                lblForfaitMoinsCherDate.Text = minimum.DateCreated.ToString();

                lblForfaitPlusCher.Text = maximum.Prix.ToString("C");
                lblForfaitPlusCherNomHotel.Text = maximum.NomHotel;
                lblForfaitPlusCherCompagnie.Text = maximum.CompagnieOrganisatrice;
                lblForfaitPlusCherDate.Text = maximum.DateCreated.ToString();

               
                listeHistoriqueForfaitExpedia.DataSource = value;
                listeHistoriqueForfaitExpedia.DataBind();
            }
        }


      

        protected void ddlListeHotelChanged(object sender, EventArgs e)
        {
            Presenter.Filtrer(ddlListeHotel.SelectedValue);
        }

        protected void btnVoirTousClick(object sender, EventArgs e)
        {
            Presenter.Filtrer("");
        }
    }


}