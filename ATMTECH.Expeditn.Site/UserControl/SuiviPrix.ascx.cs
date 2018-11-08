using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
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
            IList<HistoriqueSuiviPrix> historiqueScans = new SuiviPrixService().Obtenir(new UtilisateurService().Obtenir().FirstOrDefault()).OrderBy(x => x.SuiviPrix.Nom).ThenBy(x => x.Prix).ToList();

            string html = string.Empty;
            html += "<div class='row'>";
            html += "<div class='col-sm-6'>";
            html += "{0}";
            html += "</div>";
            html += "<div class='col-sm-6'>";

            html += "<div class='progress' style='margin-bottom: 4px;'> ";
            html += "<div class='progress-bar ' style ='width: {1}%'>{2}</div>";
            html += "</div>";
            html += "</div>";
            html += "</div>";

            IList<HistoriqueDejaAjoute> historiqueDejaAjoutes = new List<HistoriqueDejaAjoute>();
            foreach (HistoriqueSuiviPrix historiqueScan in historiqueScans)
            {
                if (!historiqueDejaAjoutes.Any(x => x.Id == historiqueScan.SuiviPrix.Id.ToString() && x.Prix == historiqueScan.Prix.ToString()))
                {
                    decimal valeurMaximum = historiqueScans.Where(x => x.Hotel == historiqueScan.Hotel).Max(x => x.Prix);
                    decimal valeurPourcentage = (100 * historiqueScan.Prix) / valeurMaximum;
                    string pourcentage = Math.Truncate(valeurPourcentage).ToString();
                    string nom = historiqueScan.Hotel;
                    string prix = string.Format("{0:C}", historiqueScan.Prix);
                    string date = historiqueScan.DateSuiviPrix.ToShortDateString();
                    string transporteur = historiqueScan.OperateurEnChargeDuVoyage;
                    string depart = historiqueScan.VilleDepart + " à " + historiqueScan.DateDepart;
                    string arrive = historiqueScan.VilleArrive + " à " + historiqueScan.DateRetour;
                    string note = historiqueScan.CoteTotalAppreciation + " pour " + historiqueScan.NombreTotalAppreciation + " appréciation";
                    string etoile = string.Empty;

                    string estMeilleurAchat = string.Empty;
                    if (historiqueScan.Prix == historiqueScans.Where(x => x.Hotel == historiqueScan.Hotel).Min(x => x.Prix))
                    {
                        estMeilleurAchat = "<img src='Images/green-cute-icon.png' style='width:45px;'><b style='color:green'> Meilleur prix !</b>";
                    }

                    switch (historiqueScan.NombreEtoile)
                    {
                        case "1":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'>";
                            break;
                        case "1,5":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon-demi.png' style='width:15px;'>";
                            break;
                        case "2":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'>";
                            break;
                        case "2,5":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon-demi.png' style='width:15px;'>";
                            break;
                        case "3":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'>";
                            break;
                        case "3,5":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon-demi.png' style='width:15px;'>";
                            break;
                        case "4":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'>";
                            break;
                        case "4,5":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon-demi.png' style='width:15px;'>";
                            break;
                        case "5":
                            etoile += "<img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'><img src='Images/star-icon.png' style='width:15px;'>";
                            break;
                        default:
                            etoile = "Inconnu";
                            break;
                    }


                    string descriptionTotal = string.Format("<b>{0} (Date du suivi: {1}) {6}</b>{7}<table style='width:90%'><td>Transporteur</td><td>{2}</td></tr><td>Départ</td><td>{3}</td></tr><td>Arrivée</td><td>{4}</td></tr><tr><td>Note: </td><td>{5}</td></tr>  </table>", nom, date, transporteur, depart, arrive, note, etoile, estMeilleurAchat);

                    LiteralControl literalControl = new LiteralControl
                    {
                        Text = string.Format(html, descriptionTotal, pourcentage, prix)
                    };
                    historiqueDejaAjoutes.Add(new HistoriqueDejaAjoute { Id = historiqueScan.SuiviPrix.Id.ToString(), Prix = historiqueScan.Prix.ToString() });
                    placeholderHistorique.Controls.Add(literalControl);

                }
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
    }

    public class HistoriqueDejaAjoute
    {
        public string Id { get; set; }
        public string Prix { get; set; }
    }
}