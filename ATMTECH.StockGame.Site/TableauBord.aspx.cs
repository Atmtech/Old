using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;
using ATMTECH.StockGame.Entites;
using ATMTECH.StockGame.Services;

namespace ATMTECH.StockGame.Site
{
    public partial class TableauBord : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();
            if (!Page.IsPostBack)
            {
                Rafraichir();
            }
        }

        private void Rafraichir()
        {
            PageMaitre.UtilisateurAuthentifie =
                UtilisateurService.Obtenir(PageMaitre.UtilisateurAuthentifie.Id.ToString());

            TitreService.RafraichirValeurActuelle(PageMaitre.UtilisateurAuthentifie);

            IList<Titre> titreAchete = TitreService.Obtenir(PageMaitre.UtilisateurAuthentifie).Where(x => x.ValeurVendu == 0).ToList();

            repeaterMesTitres.DataSource = titreAchete;
            repeaterMesTitres.DataBind();

            repeaterTitreVendu.DataSource = TitreService.Obtenir(PageMaitre.UtilisateurAuthentifie).Where(x => x.ValeurVendu != 0).ToList();
            repeaterTitreVendu.DataBind();

            lblSolde.Text = PageMaitre.UtilisateurAuthentifie.Solde.ToString("C");
            lblNombreTotalTitrePossession.Text = titreAchete.Count().ToString();
            lblCommission.Text = TitreService.ObtenirCommission().ToString("C");
            lblRang.Text = TitreService.ObtenirRang(PageMaitre.UtilisateurAuthentifie);

            repeaterOrdre.DataSource = titreAchete;
            repeaterOrdre.DataBind();

        }

        protected void btnRechercherTitre_OnClick(object sender, EventArgs e)
        {
            string codeTitre = Request.Form[txtSymbole.UniqueID];
            if (string.IsNullOrEmpty(codeTitre))
                codeTitre = txtRecherche.Text;

            Titre titre = TitreService.RechercherTitreSurInternet(codeTitre);

            if (titre.Nom != null)
            {
                pnlResultatRecheche.Visible = true;
                lblDateDerniereTransactionRecherche.Text = titre.DateDerniereTransaction;
                lblNomBourseRecherche.Text = titre.Bourse;
                lblNomRecherche.Text = titre.Nom;
                lblSymboleRecherche.Text = titre.Code;
                lblPourcentageVariationOuvertureRecherche.Text = titre.PourcentageVariationEntreFermetureEtActuel.ToString("P");
                lblValeurOuvertureRecherche.Text = titre.ValeurOuverture.ToString("C");
                lblValeurActuelleRecherche.Text = titre.ValeurActuelle.ToString("C");
                imgLogo.ImageUrl = titre.Logo;
                txtRecherche.Text = "";
            }
            else
            {
                PageMaitre.AfficherMessage("Ce titre n'existe pas sur la plateforme d'échange", TypeMessage.Erreur);
            }
        }

        protected void btnAcheterTitre_OnClick(object sender, EventArgs e)
        {
            if (IsNumeric(txtNombre.Text))
                try
                {
                    TitreService.AcheterTitre(lblSymboleRecherche.Text, PageMaitre.UtilisateurAuthentifie.Id.ToString(), Convert.ToInt32(txtNombre.Text));
                    NavigationService.RafraichirPage();
                }
                catch (Exception exception)
                {
                    PageMaitre.AfficherMessage(exception.Message, TypeMessage.Erreur);
                }

            else
            {
                PageMaitre.AfficherMessage("Vous devez saisir un chiffre entier", TypeMessage.Erreur);
            }
        }

        public static bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        protected void repeaterMesTitres_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "vendre")
            {
                TitreService.VendreTitre(e.CommandArgument.ToString(), PageMaitre.UtilisateurAuthentifie.Id.ToString());
            }
            if (e.CommandName == "enleverOrdre")
            {
                TitreService.EnleverOrdre(e.CommandArgument.ToString());
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Rafraichir();
        }

        [WebMethod]
        public static string[] ObtenirSymbole(string prefix)
        {

            IList<Symbole> enumerable = new TitreService().ObtenirSymboles().Where(x => x.Symbol.IndexOf(prefix.ToUpper(), StringComparison.Ordinal) >= 0).ToList();
            IList<string> test = new List<string>();
            foreach (Symbole obtenirSymbole in enumerable)
            {
                if (obtenirSymbole.Name.Length >= 50)
                    test.Add(obtenirSymbole.Name.Substring(0, 50) + "-" + obtenirSymbole.Symbol);
                else
                {
                    test.Add(obtenirSymbole.Name + "-" + obtenirSymbole.Symbol);
                }

            }
            return test.ToArray();

        }

        protected void repeaterOrdre_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Ordre")
            {
                int rowid = (e.Item.ItemIndex);
                TextBox txtValeurOrdre = (TextBox)repeaterOrdre.Items[rowid].FindControl("txtValeurOrdre");
                if (IsNumeric(txtValeurOrdre.Text))
                {
                    TitreService.AjouterOrdre(e.CommandArgument.ToString(), Convert.ToDecimal(txtValeurOrdre.Text));
                }
                Rafraichir();
            }
        }
    }
}