using System;
using System.Text;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;

using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Grille;
using ATMTECH.Web.Controls.Validation;
using WebFormsMvp.Web;


namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Classe de base à utiliser pour toutes les pages ASPX
    /// </summary>
    public class PageBase : MvpPage
    {
        ///// <summary>
        ///// Gère le mode d'affichage.
        ///// </summary>
        ///// <value>Le mode d'affichage.</value>  
        //public ModeAffichage ModeAffichage
        //{
        //    get
        //    {
        //        string vsId = this.ID + "_ModeAffichage";
        //        if (ViewState[vsId] == null)
        //        {
        //            ViewState[vsId] = ModeAffichage.Modification;
        //        }
        //        return (ModeAffichage)ViewState[vsId];
        //    }
        //    set
        //    {
        //        string vsId = this.ID + "_ModeAffichage";
        //        ViewState[vsId] = value;
        //    }
        //}


        //public PageBase()
        //{
        //    AutoDataBind = false;
        //}
        ///// <summary>
        ///// Configure le lien d'aide de la page
        ///// </summary>
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    ScriptManager sm = ScriptManager.GetCurrent(this);
        //    if (sm == null || !sm.IsInAsyncPostBack)
        //    {
        //        // On charge toujours l'ensemble du code CSS nécessaire aux contrôles.
        //        // C'est beaucoup plus simple de gérer ainsi les UpdatePanel.
        //        ChargerCssEtJsControles();
        //    }


        //}



        ///// <summary>
        ///// Méthode qui permet d'obtenir une valeur dans le querystring de la page courant.
        ///// </summary>
        ///// <param name="cle">La clé du paramètre</param>
        ///// <returns>La valeur du paramètre</returns>
        //public string ObtenirParametreQueryString(string cle)
        //{
        //    string valeur = string.Empty;

        //    if (!string.IsNullOrEmpty(Request.QueryString[cle]))
        //    {
        //        valeur = Request.QueryString[cle];
        //    }

        //    return valeur;
        //}


        ///// <summary>
        ///// Permet de réinitialiser la position des barres de défilements 
        ///// horizontale et vertical à zéro.
        ///// </summary>
        //public void ReinitialiserPositionBarreDefilement()
        //{
        //    ReinitialiserPositionBarreDefilement(0, 0);
        //}

        ///// <summary>
        ///// Permet de réinitialiser la position des barres de défilements 
        ///// horizontale et vertical à des positions données.
        ///// </summary>
        ///// <param name="positionX">Position de la barre horizontale</param>
        ///// <param name="positionY">Position de la barre verticale</param>
        //public void ReinitialiserPositionBarreDefilement(int positionX, int positionY)
        //{
        //    var script = new StringBuilder();
        //    //Création du javascript qui réinitialise la page
        //    script.AppendLine(@"function CreerReInitBarreDefilement(){");
        //    script.AppendLine(@"var positionX = document.getElementById('__SCROLLPOSITIONX');");
        //    script.AppendLine(@"var positionY = document.getElementById('__SCROLLPOSITIONY');");
        //    script.AppendLine(@"if (positionX && positionY){");
        //    script.AppendFormat("  positionX.value = {0};", positionX);
        //    script.AppendLine("");
        //    script.AppendFormat("  positionY.value = {0};", positionY);
        //    script.AppendLine("");
        //    script.AppendLine(@"}");
        //    script.AppendLine(@"}");
        //    //Injection de la méthode
        //    ClientScript.RegisterClientScriptBlock(GetType(), "CreerReInitBarreDefilement", script.ToString(), true);

        //    //Injection de l'appel de la méthode
        //    ClientScript.RegisterStartupScript(GetType(), "AppelCreerReInitBarreDefilement",
        //                                       "CreerReInitBarreDefilement();", true);
        //}

        ///// <summary>
        ///// Mettre le focus sur un contrôle contenu dans un Updatepanel.
        ///// Devrait aussi fonctionner sans UpdatePanel.
        ///// </summary>
        /////<param name="control"></param>
        //public void FocusSurControl(Control control)
        //{
        //    ScriptManager manager = ScriptManager.GetCurrent(this);
        //    if (manager != null)
        //    {
        //        manager.SetFocus(control);
        //    }
        //}

        ///// <summary>
        ///// Permet d'enregistrer un contrôle pour la mise à jour partielle.
        ///// Voir ScriptManager.RegisterAsyncPostBackControl
        ///// </summary>
        ///// <param name="control"></param>
        //public void RegisterAsyncPostBackTrigger(Control control)
        //{
        //    ScriptManager manager = ScriptManager.GetCurrent(this);
        //    if (manager != null)
        //    {
        //        manager.RegisterAsyncPostBackControl(control);
        //    }
        //}



        //private void ChargerCssEtJsControles()
        //{
        //    string[] enTete = new[]
        //                          {
        //                              "<link href=\"%%Base.Controles.css%%\" type=\"text/css\" rel=\"stylesheet\" />",
        //                              "<style type=\"text/css\">",
        //                              "/*<![CDATA[*/",
        //                              GroupeBoite.ObtenirBlocCss(),
        //                              GrilleAvance.ObtenirBlocCss(),
        //                              ValidationSummaryAvance.ObtenirBlocCss(),
        //                              Edition.Wizard.ObtenirBlocCss(),
        //          "/*]]>*/",
        //          "</style>"
        //      };
        //    AjouterEntete(string.Join("\n", enTete));

        //    this.InclureRessourceJavascript("Base.Controles.js");
        //    // Tâche 4641
        //    ASPxWebControl.RegisterBaseScript(this);
        //}

        ///// <summary>
        ///// Ajoute le code HTML spécifié dans l'en-tête de page (balises "head").
        ///// Les ressources peuvent être spécifiées sous la forme:
        ///// @@SubNamespace.Resource.png@@
        ///// ou
        ///// %%SubNamespace.Resource.png%% si on veut encoder l'URL pour un attribut HTML.
        ///// Le SubNamespace sera systématiquement "ATMTECH.Web.Controls", et la chaîne sera
        ///// remplacée par le résultat de l'appel à GetWebResourceUrl.
        ///// Utiliser cette fonction pour les balises Meta et Link, pour les blocs de
        ///// styles, etc. Tout ce qui doit être placé entre les balises &lt;head&gt;.
        ///// </summary>
        ///// <param name="html">Bloc HTML</param>
        //private void AjouterEntete(string html)
        //{
        //    if (this.Header == null) return;

        //    //Créer le contrôle en ajoutant les ressources.
        //    string htmlAvecRessources = this.RemplacerRessources(html);
        //    LiteralControl htmlControl = new LiteralControl("\n" + htmlAvecRessources.Trim() + "\n");
        //    this.Header.Controls.Add(htmlControl);
        //}




        ///*
        //// SVP conserver cette méthode car j'ai l'impresion qu'elle sera utile
        //// plus tard. Pour l'instant on ne conserve que la version privée.
        //public void AjouterEntete(string cle, string html)
        //{
        //    if (!this.Context.Items.Contains(cle))
        //    {
        //        AjouterEntete(html);
        //        this.Context.Items[cle] = true;
        //    }
        //}
        //*/

        ///// <summary>
        ///// Permet d'afficher un rapport à partir d'un URL construit par RapportUtils.
        ///// </summary>
        ///// <param name="url">L'URL du rapport.</param>
        //public void AfficherRapport(string url)
        //{
        //    AfficherRapport(this, url);
        //}

        ///// <summary>
        ///// Permet d'afficher un rapport à partir d'un URL construit par RapportUtils.
        ///// </summary>
        ///// <param name="page">La page courante.</param>
        ///// <param name="url">L'URL du rapport.</param>
        //internal static void AfficherRapport(System.Web.UI.Page page, string url)
        //{
        //    string js = String.Format("$.ATMTECH.afficherRapport('{0}');", url);
        //    string key = Guid.NewGuid().ToString();
        //    page.IncorporerJavascript(key, js);
        //}
    }
}