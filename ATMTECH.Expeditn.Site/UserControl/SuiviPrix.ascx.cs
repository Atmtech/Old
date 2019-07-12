using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Services;
using MongoDB.Bson;

namespace ATMTECH.Expeditn.Site.UserControl
{
    public partial class SuiviPrix : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Affichage();
            }
        }

        private void Affichage()
        {
            AffichageGraphique();

            if (!string.IsNullOrEmpty(IdSuiviPrix))
            {
                Entites.SuiviPrix obtenirsuiviPrix = SuiviPrixService.ObtenirsuiviPrix(IdSuiviPrix);
                txtNom.Text = obtenirsuiviPrix.Nom;
                txtDebut.Text = obtenirsuiviPrix.Debut.ToShortDateString();
                txtUrlSuiviPrix.Text = obtenirsuiviPrix.UrlSuiviPrix;
            }
            else
            {
                btnSupprimer.Visible = false;

            }

        }

        public void AffichageGraphique()
        {
            placeholderHistorique.Controls.Clear();
            IList<HistoriqueSuiviPrix> historiqueSuiviPrixes = new SuiviPrixService().Obtenir(new UtilisateurService().Obtenir().FirstOrDefault());
            List<ListeHotel> listeHotels = (from test in historiqueSuiviPrixes
                                            group test by new { test.Hotel, test.DateDepart }
                                            into chatte
                                            select new ListeHotel() { Hotel = chatte.First().Hotel, DateDepart = chatte.First().DateDepart }).ToList();


            string entete = "<div class='row' style='font-size: 16px; font-weight: bold;'>{0}&nbsp;&nbsp;{1}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}</div>";
            entete += "<div class='row' style='font-size: 14px;margin-bottom: 10px;'>";
            entete += "Départ de {4} à {5}";
            entete += "&nbsp;Arrivée à {6} à {7}&nbsp;&nbsp;&nbsp;&nbsp;{3}";
            entete += "</div>";

            string appreciation = "{0} / {1} appréciations";



            string meilleurPrix = "<img src = 'Images/green-cute-icon.png' style='width:25px;height: 25px;'><b style = 'color:green' > Meilleur prix !</b>";
            foreach (ListeHotel listeHotel in listeHotels)
            {


                HistoriqueSuiviPrix hotel = historiqueSuiviPrixes.FirstOrDefault(x => x.Hotel == listeHotel.Hotel);
                string etoile = TrouverNombreEtoile(hotel);

                string detailHotel = string.Format(entete,
                hotel.Hotel,
                etoile,
                    !string.IsNullOrEmpty(hotel.NombreTotalAppreciation) ? string.Format(appreciation, hotel.CoteTotalAppreciation.Substring(0, 4), hotel.NombreTotalAppreciation) : "",

                    ImageCompagnieAerienne(hotel.CompagnieAviation),
                hotel.VilleDepart,
                hotel.DateDepart,
                hotel.VilleArrive,
                hotel.DateDepart);

                IList<HistoriqueSuiviPrix> listePrix = historiqueSuiviPrixes.Where(x => x.Hotel == listeHotel.Hotel).OrderBy(x => x.Prix).ToList();
                decimal valeurMaximum = listePrix.Where(x => x.Hotel == listeHotel.Hotel).Max(x => x.Prix);
                string progressBar = string.Empty;
                IList<ListeHotel> listeInHotelsInserer = new List<ListeHotel>();
                int i = 0;
                foreach (var historiqueSuiviPrix in listePrix)
                {
                    if (listeInHotelsInserer.Count(x => x.Prix == historiqueSuiviPrix.Prix) == 0)
                    {
                        decimal valeurPourcentage = (100 * historiqueSuiviPrix.Prix) / valeurMaximum;
                        string pourcentage = Math.Truncate(valeurPourcentage).ToString();
                        if (i == 0)
                        {
                            progressBar += string.Format("<div style = 'font-size: 12px;'>{0}{3}</div><div class='progress' style='margin-bottom:5px;'><div class='progress-bar' style='width: {1}%'>{2}</div></div>",
                                historiqueSuiviPrix.DateSuiviPrix, pourcentage, string.Format("{0:C}", historiqueSuiviPrix.Prix), meilleurPrix);
                        }
                        else
                        {
                            progressBar += string.Format("<div style = 'font-size: 12px;'>{0}</div><div class='progress' style='margin-bottom:5px;'><div class='progress-bar' style='width: {1}%'>{2}</div></div>",
                                historiqueSuiviPrix.DateSuiviPrix, pourcentage, string.Format("{0:C}", historiqueSuiviPrix.Prix));
                        }
                        i++;
                        listeInHotelsInserer.Add(new ListeHotel { Prix = historiqueSuiviPrix.Prix });
                    }
                }

                Literal lit = new Literal
                {
                    Text = "<div style='margin-bottom:25px;'>" + detailHotel + progressBar + "</div>"
                };
                placeholderHistorique.Controls.Add(lit);
            }
        }

        protected void btnEnregistrer_OnClick(object sender, EventArgs e)
        {
            Entites.SuiviPrix suiviPrix = new Entites.SuiviPrix();
            if (!string.IsNullOrEmpty(IdSuiviPrix))
            {
                suiviPrix = new SuiviPrixService().ObtenirsuiviPrix(IdSuiviPrix);
            };

            suiviPrix.Nom = txtNom.Text;
            suiviPrix.Utilisateur = (PageMaitre.UtilisateurAuthentifie);
            suiviPrix.TypeSuiviPrix = ddlTypeSuiviPrix.Text;
            suiviPrix.UrlSuiviPrix = txtUrlSuiviPrix.Text;
            suiviPrix.Debut = Convert.ToDateTime(txtDebut.Text);

            if (suiviPrix.UrlSuiviPrix.ToLower().IndexOf(suiviPrix.TypeSuiviPrix.ToLower(), StringComparison.Ordinal) >= 0)
            {
                ObjectId objectId = new SuiviPrixService().Enregistrer(suiviPrix);
                Response.Redirect("ModifierSuiviPrix.aspx?IdSuiviPrix=" + objectId);
            }
            else
            {
                PageMaitre.AfficherMessage("Le url que vous essayez d'enregistrer n'est pas valide.", TypeMessage.Erreur);
            }
        }

        protected void btnSupprimer_OnClick(object sender, EventArgs e)
        {
            SuiviPrixService.Supprimer(new SuiviPrixService().ObtenirsuiviPrix(IdSuiviPrix));
            Response.Redirect("Tableaubord.aspx");
        }


        private string ImageCompagnieAerienne(string compagnie)
        {
            string taille = "";
            string image = "<img src='images/{0}' style='width:60px;height:30px;' >";

            if (compagnie == "Air Transat") return string.Format(image, "logo-airtransat-header-desktop.svg");
            if (compagnie == "WestJet") return string.Format(image, "ws.gif");
            if (compagnie == "Sunwing Airlines") return string.Format(image, "wg.gif");
            if (compagnie.ToLower().IndexOf("canada") >= 0) return string.Format(image, "ac.gif");
            return compagnie;
        }

        private string TrouverNombreEtoile(HistoriqueSuiviPrix historique)
        {
            string etoilePleine = "<img src='Images/star-icon.png' style='width:15px;height:15px;'>";
            string etoileDemi = "<img src='Images/star-icon-demi.png' style='width:15px;height:15px;'>";

            switch (historique.NombreEtoile)
            {
                case "1":
                    return etoilePleine;
                case "1,5":
                    return etoilePleine + etoileDemi;
                case "2":
                    return etoilePleine + etoilePleine;
                case "2,5":
                    return etoilePleine + etoilePleine + etoileDemi;
                case "3":
                    return etoilePleine + etoilePleine + etoilePleine;
                case "3,5":
                    return etoilePleine + etoilePleine + etoilePleine + etoileDemi;
                case "4":
                    return etoilePleine + etoilePleine + etoilePleine + etoilePleine;
                case "4,5":
                    return etoilePleine + etoilePleine + etoilePleine + etoilePleine + etoileDemi;
                case "5":
                    return etoilePleine + etoilePleine + etoilePleine + etoilePleine + etoilePleine;
                default:
                    return "Inconnu";
            }
        }

    }

    //public class HistoriqueDejaAjoute
    //{
    //    public string Id { get; set; }
    //    public string Prix { get; set; }
    //}

    public class ListeHotel
    {
        public string Hotel { get; set; }
        public DateTime DateDepart { get; set; }
        public decimal Prix { get; set; }
        public DateTime DateSuivi { get; set; }
    }

}