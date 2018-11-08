using System;
using System.Collections.Generic;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Services;
using MongoDB.Bson;

namespace ATMTECH.Expeditn.Site.UserControl
{
    public partial class InformationGeneralesExpedition : UserControlBase
    {

        public bool EstEnAjout { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Affichage();
            }
            else
            {
                string path = Server.MapPath("~/Images/Expedition/");
                bool estOkFichier = false;
                string fichierASauvegarder = Guid.NewGuid() + "." +
                                             System.IO.Path.GetExtension(fichierImage.FileName).ToLower();
                if (fichierImage.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(fichierImage.FileName).ToLower();
                    string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            estOkFichier = true;
                            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
                            expedition.Image = fichierASauvegarder;
                            ExpeditionService.Enregistrer(expedition);
                        }
                    }

                    if (estOkFichier)
                    {
                        try
                        {
                            fichierImage.PostedFile.SaveAs(path + fichierASauvegarder);
                        }
                        catch (Exception ex)
                        {
                            PageMaitre.AfficherMessage("Erreur sur le fichier (" + ex.Message + ")",
                                TypeMessage.Erreur);
                        }
                    }
                    else
                    {
                        PageMaitre.AfficherMessage("Extension de fichier non permis.", TypeMessage.Erreur);
                    }
                }
            }
        }

        public void Affichage()
        {
            if (EstEnAjout)
            {
                pnlAjouterImageExpedition.Visible = false;
                btnSupprimer.Visible = false;
            }

            if (!string.IsNullOrEmpty(IdExpedition))
            {
                Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
                txtDescription.Text = expedition.Description;
                txtTitre.Text = expedition.Titre;
                txtDebut.Text = expedition.Debut.ToShortDateString();
                txtFin.Text = expedition.Fin.ToShortDateString();

                imagePrincipale.ImageUrl = !string.IsNullOrEmpty(expedition.Image)
                    ? @"/images/Expedition/" + expedition.Image
                    : @"/images/Expedition/Missing.png";
            }
        }

        protected void btnEnregistrer_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = new Expedition();
            if (!string.IsNullOrEmpty(IdExpedition))
            {
                expedition = ExpeditionService.Obtenir(IdExpedition);
            }

            expedition.Description = txtDescription.Text;
            expedition.Titre = txtTitre.Text;
            expedition.Debut = Convert.ToDateTime(txtDebut.Text);
            expedition.Fin = Convert.ToDateTime(txtFin.Text);

            if (expedition.ListeUtilisateur == null)
            {
                expedition.ListeUtilisateur = new List<Utilisateur> { PageMaitre.UtilisateurAuthentifie };
            }
            if (expedition.Administrateur == null)
            {
                expedition.Administrateur = PageMaitre.UtilisateurAuthentifie;
            }

            ObjectId objectId = new ExpeditionService().Enregistrer(expedition);
            Response.Redirect("ModifierExpedition.aspx?IdExpedition=" + objectId);
        }

        protected void btnSupprimer_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            ExpeditionService.Supprimer(expedition);
            Response.Redirect("TableauBord.aspx");
        }
    }

}