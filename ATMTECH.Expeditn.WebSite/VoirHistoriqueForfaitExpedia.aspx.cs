using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;
using Microsoft.Reporting.WebForms;

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

                if (!string.IsNullOrEmpty(FiltreHotel))
                {
                    ddlListeHotel.SelectedValue = FiltreHotel;
                }

            }
        }

        public int IdRechercheForfaitExpedia
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue("ID")); }
        }

        public string FiltreHotel { get { return QueryString.GetQueryStringValue("Filtre"); } }

        public RechercheForfaitExpedia RechercheForfaitExpedia
        {
            set
            {
                lblNom.Text = value.Nom;
                lblDateDepart.Text = value.DateDepart.ToString();
                lblNombreJour.Text = value.NombreJour.ToString();
                btnVoirRechercheSurExpedia.NavigateUrl = value.Url;
            }
        }

        public IList<AffichageHistoriqueForfaitExpedia> AffichageGraphique
        {
            set
            {
                IList<AffichageHistoriqueForfaitExpedia> historiqueForfaitExpedias = value;
                if (!string.IsNullOrEmpty(FiltreHotel))
                    historiqueForfaitExpedias = historiqueForfaitExpedias.Where(x => x.NomHotel == FiltreHotel).ToList();
                List<AffichageHistoriqueForfaitExpedia> affichageHistoriqueForfaitExpedias = historiqueForfaitExpedias.OrderBy(x => x.NomHotel).ThenBy(x => x.Prix).ToList();

                string html = String.Empty;
                string titre = String.Empty;
                decimal maximumForfait = 0;
                decimal minimumForfait = 0;
                foreach (AffichageHistoriqueForfaitExpedia affichageHistoriqueForfaitExpedia in affichageHistoriqueForfaitExpedias)
                {


                    if (titre != affichageHistoriqueForfaitExpedia.NomHotel)
                    {
                        titre = affichageHistoriqueForfaitExpedia.NomHotel;

                        maximumForfait = affichageHistoriqueForfaitExpedias.Where(x => x.NomHotel == titre).Max(x => x.Prix);
                        minimumForfait = affichageHistoriqueForfaitExpedias.Where(x => x.NomHotel == titre).Min(x => x.Prix);

                        html += string.Format(@"<h3 class='header3'><table style='width:700px'><tr style='border-bottom: solid 2px gray'><td>{0}</td><td style='text-align:right;font-weight:bold;'>{1}<img src='/images/etoile.png' style='width:20px;height:20px;'></td></tr></table> </h3>", titre, affichageHistoriqueForfaitExpedia.NombreEtoile);
                        html += string.Format(@"(Plus bas prix <b>{0}</b> :: Plus haut prix <b>{1}</b>)  ", minimumForfait.ToString("C"), maximumForfait.ToString("C"));
                    }

                    string style = "padding-right:4px;padding-left:4px;padding-bottom:4px;padding-top:4px;margin-top:4px;margin-bottom:4px;font-size:12px; border:solid 1px gray;";
                    if (affichageHistoriqueForfaitExpedia.Prix == maximumForfait)
                    {
                        html += string.Format("<div style='{0}width:700px;background-color:rgb(212, 72, 72);'><table style='width:100%'><tr><td>{1}</td><td style='text-align:right;font-weight:bold;'>{2}</td></tr></table> </div>", style, affichageHistoriqueForfaitExpedia.Date, affichageHistoriqueForfaitExpedia.Prix.ToString("C"));
                    }
                    else if (affichageHistoriqueForfaitExpedia.Prix == minimumForfait)
                    {
                        html += string.Format("<div style='{0}width:200px;background-color:rgb(54, 180, 54);'><table style='width:100%'><tr><td>{1}</td><td style='text-align:right;font-weight:bold;'>{2}</td></tr></table></div>", style, affichageHistoriqueForfaitExpedia.Date, affichageHistoriqueForfaitExpedia.Prix.ToString("C"));
                    }
                    else
                    {
                        decimal @decimal = affichageHistoriqueForfaitExpedia.Prix - minimumForfait + 200;
                        if (@decimal > 700) @decimal = 650;
                        string width = @decimal + "px;";
                        html += string.Format("<div style='{0}width:{3};background-color:#dedede;'><table style='width:100%'><tr><td>{1}</td><td style='text-align:right;font-weight:bold;'>{2}</td></tr></table></div>", style, affichageHistoriqueForfaitExpedia.Date, affichageHistoriqueForfaitExpedia.Prix.ToString("C"), width);
                    }


                }
                placeHolderGraphique.Controls.Add(new Literal { Text = html });

            }
        }


        public IList<HistoriqueForfaitExpedia> HistoriqueForfaitExpedia
        {
            set
            {
                if (value.Count > 0)
                {

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

                }
                else
                {

                    lblForfaitMoinsCher.Text = "";
                    lblForfaitMoinsCherNomHotel.Text = "";
                    lblForfaitMoinsCherCompagnie.Text = "";
                    lblForfaitMoinsCherDate.Text = "";

                    lblForfaitPlusCher.Text = "";
                    lblForfaitPlusCherNomHotel.Text = "";
                    lblForfaitPlusCherCompagnie.Text = "";
                    lblForfaitPlusCherDate.Text = "";
                }
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