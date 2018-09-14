using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Services;
using MongoDB.Bson;

namespace ATMTECH.Expeditn.Site
{
    public partial class TableauBordPage : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Rafraichir();
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    AfficherUneExpeditionEnModification(Request.QueryString["Id"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["Ajouter"]))
                {
                    ToutMasquer();
                    MettreBlancTextBox();
                    pnlExpedition.Visible = true;
                    lblId.Text = "0";
                    lblTitrePanneauExpedition.Text = "AJOUTER EXPEDITION";
                }
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
                            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
                            expedition.Image = fichierASauvegarder;
                            ExpeditionVue.Enregistrer(expedition);
                        }
                    }

                    if (estOkFichier)
                    {
                        try
                        {
                            fichierImage.PostedFile.SaveAs(path + fichierASauvegarder);
                            PageMaitre.AfficherMessage("Image téléversé avec succès", TypeMessage.Succes);
                        }
                        catch (Exception ex)
                        {
                            PageMaitre.AfficherMessage("Erreur sur le fichier (" + ex.Message + ")", TypeMessage.Erreur);

                        }
                    }
                    else
                    {
                        PageMaitre.AfficherMessage("Extension de fichier non permis.", TypeMessage.Erreur);

                    }
                }


            }


        }

        private void ToutMasquer()
        {
            pnlExpedition.Visible = false;
            pnlListeExpedition.Visible = false;
        }

        protected void btnEnregistrerOnclick(object sender, EventArgs e)
        {
            Expedition expedition = new Expedition
            {
                Titre = txtTitre.Text,
                Debut = Convert.ToDateTime(txtDebut.Text),
                Fin = Convert.ToDateTime(txtFin.Text),
                Description = txtDescription.Text,
                Image = fichierImage.FileName,
                ListeUtilisateur = new List<Utilisateur> { PageMaitre.UtilisateurAuthentifie },
                Administrateur = PageMaitre.UtilisateurAuthentifie
            };

            if (lblId.Text != "0")
            {
                expedition = ExpeditionVue.Obtenir(lblId.Text);
                expedition.Titre = txtTitre.Text;
                expedition.Debut = Convert.ToDateTime(txtDebut.Text);
                expedition.Fin = Convert.ToDateTime(txtFin.Text);
                expedition.Description = txtDescription.Text;
            }

            ExpeditionVue.Enregistrer(expedition);
            Rafraichir();
            ToutMasquer();
            pnlListeExpedition.Visible = true;
        }

        protected void btnAjouterExpeditionOnclick(object sender, EventArgs e)
        {
            Response.Redirect("TableauBord.aspx?Ajouter=1");

            //placeHolderDepense.Controls.Clear();
            //repeaterParticipant.Controls.Clear();
            //repeaterActivite.Controls.Clear();


        }

        public void Rafraichir()
        {
            MettreBlancTextBox();
            IList<Expedition> obtenirMesExpedition = ExpeditionVue.ObtenirMesExpedition(PageMaitre.UtilisateurAuthentifie);
            listeExpedition.DataSource = obtenirMesExpedition;
            listeExpedition.DataBind();
            pnlAucuneExpedition.Visible = obtenirMesExpedition.Count <= 0;
            repeaterRecherchePrix.DataSource = RecherchePrixVue.Obtenir(PageMaitre.UtilisateurAuthentifie);
            repeaterRecherchePrix.DataBind();
        }

        protected void listeExpeditionOnItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Modifier")
            {
                Response.Redirect("TableauBord.aspx?Id=" + e.CommandArgument);
            }
        }

        private void AfficherUneExpeditionEnModification(string argument)
        {
            ToutMasquer();

            Expedition expedition = ExpeditionVue.Obtenir(argument);
            txtDescription.Text = expedition.Description;
            txtDebut.Text = expedition.Debut.ToShortDateString();
            txtFin.Text = expedition.Fin.ToShortDateString();
            txtTitre.Text = expedition.Titre;
            if (!string.IsNullOrEmpty(expedition.Image))
            {
                imagePrincipale.ImageUrl = @"/images/Expedition/" + expedition.Image;
            }
            else
            {
                imagePrincipale.ImageUrl = @"/images/Expedition/Missing.png";
            }


            lblId.Text = expedition.Id.ToString();
            pnlExpedition.Visible = true;
            lblTitrePanneauExpedition.Text = "MODIFIER EXPEDITION";
            repeaterParticipant.DataSource = expedition.ListeUtilisateur;
            repeaterParticipant.DataBind();
            repeaterActivite.DataSource = expedition.ListeActivite;
            repeaterActivite.DataBind();

            ddlParticipantDepense.DataSource = expedition.ListeUtilisateur;
            ddlParticipantDepense.DataTextField = "Affichage";
            ddlParticipantDepense.DataValueField = "Id";
            ddlParticipantDepense.DataBind();

            ddlParticipantReset.DataSource = expedition.ListeUtilisateur;
            ddlParticipantReset.DataTextField = "Affichage";
            ddlParticipantReset.DataValueField = "Id";
            ddlParticipantReset.DataBind();

            if (expedition.ListeActivite != null)
            {
                ddlTypeActivite.DataSource = expedition.ListeActivite.GroupBy(x => x.TypeActivite).ToList().Select(activiteGroupe => activiteGroupe.Key).ToList();
                ddlTypeActivite.DataBind();
            }



            ddlDateActivite.DataSource = Enumerable.Range(0, 1 + expedition.Fin.Subtract(expedition.Debut).Days)
                .Select(offset => expedition.Debut.AddDays(offset).ToShortDateString())
                .ToArray();
            ddlDateActivite.DataBind();

            placeHolderDepense.Controls.Add(new Literal { Text = ExpeditionVue.GenererAffichageDepense(expedition) });

        }

        protected void btnToutMasquerClick(object sender, EventArgs e)
        {
            ToutMasquer();
            pnlListeExpedition.Visible = true;
        }

        protected void repeaterParticipantItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Enlever")
            {
                Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
                Utilisateur utilisateurAEnlever = ExpeditionVue.ObtenirUtilisateur(e.CommandArgument.ToString());
                foreach (Utilisateur utilisateur in expedition.ListeUtilisateur)
                {
                    if (utilisateur.Id == utilisateurAEnlever.Id)
                    {
                        expedition.ListeUtilisateur.Remove(utilisateur);
                        break;
                    }
                }

                ExpeditionVue.Enregistrer(expedition);
                repeaterParticipant.DataSource = expedition.ListeUtilisateur;
                repeaterParticipant.DataBind();
            }
        }

        protected void repeaterParticipantItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);

            if ((e.Item.DataItem as Utilisateur).Id == expedition.Administrateur.Id)
            {
                (e.Item.FindControl("btnEnlever") as Button).Visible = false;
                (e.Item.FindControl("lblEstAdministrateur") as Label).Visible = true;
            }
            else
            {
                (e.Item.FindControl("lblEstAdministrateur") as Label).Visible = false;
            }
        }

        protected void btnFermerModalClick(object sender, EventArgs e)
        {
            Response.Redirect("TableauBord.aspx?Id=" + lblId.Text);
        }

        protected void selectionnerUtilisateurParticipant_OnPreRecherche(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            selectionnerUtilisateurParticipant.ListeUtilisateurDejaPresent = expedition.ListeUtilisateur;
        }

        protected void selectionnerUtilisateurParticipant_OnAjouter(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            foreach (Utilisateur utilisateur in selectionnerUtilisateurParticipant.ListeUtilisateurSelectionne)
            {
                if (!expedition.ListeUtilisateur.Contains(utilisateur))
                {
                    expedition.ListeUtilisateur.Add(utilisateur);
                }
            }
            ExpeditionVue.Enregistrer(expedition);
        }

        protected void btnAjouterActiviteClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            if (expedition.ListeActivite == null) expedition.ListeActivite = new List<Activite>();

            Activite activite = new Activite
            {
                Nom = txtNomActivite.Text,
                Description = txtDescriptionActivite.Text,
                Date = Convert.ToDateTime(ddlDateActivite.Text),
                TypeActivite = txtTypeActivite.Text
            };
            ExpeditionVue.Enregistrer(activite);

            expedition.ListeActivite.Add(activite);
            ExpeditionVue.Enregistrer(expedition);
            Response.Redirect("TableauBord.aspx?Id=" + lblId.Text);
        }

        protected void repeaterActivite_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater repeater = e.Item.FindControl("repeaterListeParticipantActivite") as Repeater;
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            repeater.DataSource = expedition.ListeUtilisateur;
            repeater.DataBind();

        }

        protected void repeaterListeParticipantActivite_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            Utilisateur utilisateur = ExpeditionVue.ObtenirUtilisateur(e.CommandArgument.ToString());
            Label lblIdActivite = ((Label)e.Item.Parent.Parent.FindControl("lblIdActivite"));
            if (lblIdActivite != null)
            {
                Activite activite = expedition.ListeActivite.FirstOrDefault(x => x.Id == ObjectId.Parse(lblIdActivite.Text));
                if (activite != null)
                {
                    if (activite.ListeUtilisateur == null) activite.ListeUtilisateur = new List<Utilisateur>();

                    if (e.CommandName == "Absent")
                    {

                        activite.ListeUtilisateur.Remove(activite.ListeUtilisateur.SingleOrDefault(x => x.Id == utilisateur.Id));
                        ExpeditionVue.Enregistrer(activite);
                        ExpeditionVue.Enregistrer(expedition);

                        repeaterActivite.DataSource = expedition.ListeActivite;
                        repeaterActivite.DataBind();


                        // Response.Redirect("Expedition.aspx?Id=" + lblId.Text);

                    }
                    if (e.CommandName == "Present")
                    {
                        activite.ListeUtilisateur.Add(utilisateur);
                        ExpeditionVue.Enregistrer(activite);
                        ExpeditionVue.Enregistrer(expedition);
                        repeaterActivite.DataSource = expedition.ListeActivite;
                        repeaterActivite.DataBind();

                        //  Response.Redirect("Expedition.aspx?Id=" + lblId.Text);
                    }

                    placeHolderDepense.Controls.Clear();
                    placeHolderDepense.Controls.Add(new Literal { Text = ExpeditionVue.GenererAffichageDepense(expedition) });

                }
            }

        }

        protected void repeaterListeParticipantActivite_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Utilisateur utilisateur = e.Item.DataItem as Utilisateur;
            Activite activite = ((RepeaterItem)e.Item.Parent.Parent).DataItem as Activite;
            Control btnPresent = e.Item.FindControl("btnPresent");
            Control btnAbsent = e.Item.FindControl("btnAbsent");
            if (utilisateur != null)
            {
                if (activite.ListeUtilisateur != null)
                {
                    if (activite.ListeUtilisateur.Any(x => x.Id == utilisateur.Id))
                    {
                        btnAbsent.Visible = true;
                        btnPresent.Visible = false;
                    }
                    else
                    {
                        btnPresent.Visible = true;
                        btnAbsent.Visible = false;
                    }
                }
                else
                {
                    btnPresent.Visible = true;
                    btnAbsent.Visible = false;
                }
            }
        }

        protected void repeaterActivite_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            Activite activite = expedition.ListeActivite.FirstOrDefault(x => x.Id == ObjectId.Parse(e.CommandArgument.ToString()));

            if (e.CommandName == "delete")
            {
                expedition.ListeActivite.Remove(expedition.ListeActivite.SingleOrDefault(x => x.Id == activite.Id));
                ExpeditionVue.Enregistrer(expedition);
                ExpeditionVue.SupprimerActivite(activite.Id.ToString());

                repeaterActivite.DataSource = expedition.ListeActivite;
                repeaterActivite.DataBind();

            }
            if (e.CommandName == "edit")
            {
                (e.Item.FindControl("lblNom") as Label).Visible = false;
                (e.Item.FindControl("txtNom") as TextBox).Visible = true;

                (e.Item.FindControl("lblDescription") as Label).Visible = false;
                (e.Item.FindControl("txtDescription") as TextBox).Visible = true;

                (e.Item.FindControl("lblTypeActivite") as Label).Visible = false;
                (e.Item.FindControl("txtTypeActivite") as TextBox).Visible = true;

                (e.Item.FindControl("lblDate") as Label).Visible = false;
                (e.Item.FindControl("txtDate") as TextBox).Visible = true;

                (e.Item.FindControl("btnEnregistrer") as Button).Visible = true;
            }

            if (e.CommandName == "enregistrer")
            {
                (e.Item.FindControl("lblNom") as Label).Visible = true;
                (e.Item.FindControl("txtNom") as TextBox).Visible = false;

                (e.Item.FindControl("lblDescription") as Label).Visible = true;
                (e.Item.FindControl("txtDescription") as TextBox).Visible = false;

                (e.Item.FindControl("lblTypeActivite") as Label).Visible = true;
                (e.Item.FindControl("txtTypeActivite") as TextBox).Visible = false;

                (e.Item.FindControl("lblDate") as Label).Visible = true;
                (e.Item.FindControl("txtDate") as TextBox).Visible = false;
                (e.Item.FindControl("btnEnregistrer") as Button).Visible = false;

                activite.Nom = (e.Item.FindControl("txtNom") as TextBox).Text;
                activite.Description = (e.Item.FindControl("txtDescription") as TextBox).Text;
                activite.TypeActivite = (e.Item.FindControl("txtTypeActivite") as TextBox).Text;
                activite.Date = Convert.ToDateTime((e.Item.FindControl("txtDate") as TextBox).Text);
                ExpeditionVue.Enregistrer(activite);

                ExpeditionVue.Enregistrer(expedition);

                repeaterActivite.DataSource = expedition.ListeActivite;
                repeaterActivite.DataBind();

                placeHolderDepense.Controls.Clear();
                placeHolderDepense.Controls.Add(new Literal { Text = ExpeditionVue.GenererAffichageDepense(expedition) });
            }

        }

        protected void btnAjouterDepense_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            Utilisateur utilisateur = ExpeditionVue.ObtenirUtilisateur(ddlParticipantDepense.SelectedValue);
            if (expedition.ListeDepense == null) expedition.ListeDepense = new List<Depense>();

            Depense depense = new Depense
            {
                Utilisateur = utilisateur,
                Montant = txtMontant.Text,
                TypeActivite = ddlTypeActivite.Text
            };
            ExpeditionVue.Enregistrer(depense);
            expedition.ListeDepense.Add(depense);
            ExpeditionVue.Enregistrer(expedition);
            Response.Redirect("TableauBord.aspx?Id=" + lblId.Text);
        }

        protected void btnInitialiserRepartition_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionVue.Obtenir(lblId.Text);
            IList<Depense> depenses = new List<Depense>();
            foreach (Depense depense in expedition.ListeDepense)
            {
                if (depense.Utilisateur.Id != ObjectId.Parse(ddlParticipantReset.SelectedValue))
                {
                    depenses.Add(depense);
                }
                else
                {
                    ExpeditionVue.SupprimerDepense(depense.Id.ToString());
                }
            }
            expedition.ListeDepense = depenses;
            ExpeditionVue.Enregistrer(expedition);
            placeHolderDepense.Controls.Clear();
            placeHolderDepense.Controls.Add(new Literal { Text = ExpeditionVue.GenererAffichageDepense(expedition) });
        }

        protected void btnAjouterRecherchePrix_OnClick(object sender, EventArgs e)
        {
            string typeScan = "Inconnu";

            if (txtUrl.Text.ToLower().IndexOf("expedia", StringComparison.Ordinal) >= 0) typeScan = "Expedia";

            PlanificationScan planificationScan = new PlanificationScan
            {
                Nom = txtNomRecherche.Text,
                Utilisateur = (PageMaitre.UtilisateurAuthentifie),
                TypeScan = typeScan,
                UrlScan = txtUrl.Text
            };
            new ScanService().Enregistrer(planificationScan);
            txtNomRecherche.Text = string.Empty;
            txtUrl.Text = string.Empty;
            repeaterRecherchePrix.DataSource = RecherchePrixVue.Obtenir(PageMaitre.UtilisateurAuthentifie);
            repeaterRecherchePrix.DataBind();
        }
    }
}