using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Services;


namespace ATMTECH.Expeditn.Site.UserControl
{
    public partial class SelectionnerUtilisateur : System.Web.UI.UserControl
    {
        //public IList<Utilisateur> ListeUtilisateurDejaPresent { get; set; }

        //public event EventHandler PreRecherche;
        //public event EventHandler Ajouter;

        //public IList<Utilisateur> ListeUtilisateurSelectionne
        //{
        //    get
        //    {
        //        if (Session["UtilisateurSelectionne"] == null)
        //            Session["UtilisateurSelectionne"] = new List<Utilisateur>();

        //        return (IList<Utilisateur>)Session["UtilisateurSelectionne"];
        //    }
        //    set => Session["UtilisateurSelectionne"] = value;
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        //private void Rechercher()
        //{
        //    PreRecherche?.Invoke(this, EventArgs.Empty);

        //    IList<Utilisateur> obtenirUtilisateur = new UtilisateurService().Obtenir();
        //    IList<Utilisateur> retrouve = new List<Utilisateur>();
        //    if (ListeUtilisateurDejaPresent == null) ListeUtilisateurDejaPresent = new List<Utilisateur>();

        //    foreach (Utilisateur utilisateur in obtenirUtilisateur)
        //    {
        //        foreach (string s in txtRechercherUtilisateur.Text.ToLower().Split(' '))
        //        {
        //            if (utilisateur.Recherche.Contains(s))
        //            {
        //                if (!retrouve.Contains(utilisateur))
        //                    if (ListeUtilisateurDejaPresent.FirstOrDefault(x => x.Id == utilisateur.Id) == null)
        //                        if (ListeUtilisateurSelectionne.FirstOrDefault(x => x.Id == utilisateur.Id) == null)
        //                            retrouve.Add(utilisateur);
        //            }
        //        }
        //    }

        //    repeaterListeUtilisateur.DataSource = retrouve;
        //    repeaterListeUtilisateur.DataBind();
        //}

        //protected void btnRechercherClick(object sender, EventArgs e)
        //{
        //    Rechercher();
        //}

        //protected void repeaterListeUtilisateurItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Ajouter")
        //    {
        //        Utilisateur utilisateur = new UtilisateurService().Obtenir(e.CommandArgument.ToString());
        //        if (ListeUtilisateurSelectionne == null)
        //        {
        //            ListeUtilisateurSelectionne = new List<Utilisateur>();
        //        }
        //        ListeUtilisateurSelectionne.Add(utilisateur);
        //        Ajouter?.Invoke(this, EventArgs.Empty);
        //        Rechercher();
               
        //    }
        //}

    }
}