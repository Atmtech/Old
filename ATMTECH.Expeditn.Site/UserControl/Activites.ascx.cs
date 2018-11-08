using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entites;
using MongoDB.Bson;

namespace ATMTECH.Expeditn.Site.UserControl
{
    public partial class Activites : UserControlBase
    {
        public event EventHandler SurAction;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Affichage();

            }
        }
        public void Affichage()
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            repeaterActivite.DataSource = expedition.ListeActivite;
            repeaterActivite.DataBind();

            ddlDateActivite.DataSource = Enumerable.Range(0, 1 + expedition.Fin.Subtract(expedition.Debut).Days)
                .Select(offset => expedition.Debut.AddDays(offset).ToShortDateString())
                .ToArray();
            ddlDateActivite.DataBind();

        }

        protected void repeaterActivite_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater repeater = e.Item.FindControl("repeaterListeParticipantActivite") as Repeater;
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            repeater.DataSource = expedition.ListeUtilisateur;
            repeater.DataBind();
        }

        protected void repeaterActivite_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            Activite activite = expedition.ListeActivite.FirstOrDefault(x => x.Id == ObjectId.Parse(e.CommandArgument.ToString()));

            if (e.CommandName == "delete")
            {
                expedition.ListeActivite.Remove(expedition.ListeActivite.SingleOrDefault(x => x.Id == activite.Id));
                ExpeditionService.Enregistrer(expedition);
                ExpeditionService.Supprimer(activite);

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
                ExpeditionService.Enregistrer(activite);
                ExpeditionService.Enregistrer(expedition);

                repeaterActivite.DataSource = expedition.ListeActivite;
                repeaterActivite.DataBind();

                SurAction?.Invoke(this, EventArgs.Empty);
            }
        }

        protected void repeaterListeParticipantActivite_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            Utilisateur utilisateur = UtilisateurService.Obtenir(e.CommandArgument.ToString());
            Label lblIdActivite = ((Label)e.Item.Parent.Parent.FindControl("lblIdActivite"));
            if (lblIdActivite != null)
            {
                Activite activite = expedition.ListeActivite.FirstOrDefault(x => x.Id == ObjectId.Parse(lblIdActivite.Text));
                if (activite != null)
                {
                    if (activite.ListeUtilisateur == null) activite.ListeUtilisateur = new List<Utilisateur>();

                    if (e.CommandName == "Absent")
                    {
                        if (EstUtilisateurPresentActivite(activite,utilisateur))
                        {
                            activite.ListeUtilisateur.Remove(
                                activite.ListeUtilisateur.SingleOrDefault(x => x.Id == utilisateur.Id));
                            ExpeditionService.Enregistrer(activite);
                            ExpeditionService.Enregistrer(expedition);
                            repeaterActivite.DataSource = expedition.ListeActivite;
                            repeaterActivite.DataBind();
                        }

                    }
                    if (e.CommandName == "Present")
                    {
                        if (!EstUtilisateurPresentActivite(activite, utilisateur))
                        {
                            activite.ListeUtilisateur.Add(utilisateur);
                            ExpeditionService.Enregistrer(activite);
                            ExpeditionService.Enregistrer(expedition);
                            repeaterActivite.DataSource = expedition.ListeActivite;
                            repeaterActivite.DataBind();
                        }
                    }

                    SurAction?.Invoke(this, EventArgs.Empty);

                }
            }
        }

        private bool EstUtilisateurPresentActivite(Activite activite, Utilisateur utilisateur)
        {
            if (activite.ListeUtilisateur.Count(x => x.Id == utilisateur.Id) > 0) return true;
            return false;
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

        protected void btnAjouterActivite_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            if (expedition.ListeActivite == null) expedition.ListeActivite = new List<Activite>();

            Activite activite = new Activite
            {
                Nom = txtNomActivite.Text,
                Description = txtDescriptionActivite.Text,
                Date = Convert.ToDateTime(ddlDateActivite.Text),
                TypeActivite = txtTypeActivite.Text
            };
            ExpeditionService.Enregistrer(activite);

            expedition.ListeActivite.Add(activite);
            ExpeditionService.Enregistrer(expedition);
            NavigationService.RafraichirPage();
        }

        protected void btnFermerActivite_OnClick(object sender, EventArgs e)
        {
            NavigationService.RafraichirPage();
        }
    }
}