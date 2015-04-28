using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views.Francais;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Common.Utils.Web;
using ATMTECH.Entities;
using ATMTECH.Web;

namespace ATMTECH.Administration.Commerce
{
    public partial class Edition : PageBase<EditionPresenter, IEditionPresenter>, IEditionPresenter
    {
        public string NomEntite
        {
            get
            {
                string nomEntite = QueryString.GetQueryStringValue("NomEntite");
                lblTitre.Text = nomEntite;
                return nomEntite;
            }
        }

        public int ValeurId
        {
            get
            {
                if (Session["IdEntite"] == null)
                {
                    Session["IdEntite"] = 0;
                }
                return Convert.ToInt32(Session["IdEntite"]);
            }
            set { Session["IdEntite"] = value; }
        }

        public string CritereRecherche
        {
            get { return txtCritereRecherche.Text; }
            set { txtCritereRecherche.Text = value; }
        }
        public object ValeurRetrouve
        {
            set
            {
                grdData.DataSource = value;
                grdData.DataBind();
            }
        }
        public int NombreValeurRetrouve
        {
            set { lblNombreElementTrouve.Text = value.ToString(); }
        }
        public void AfficherColonneGrille()
        {
            DataControlField dataControlField1 = grdData.Columns[0];
            DataControlField dataControlField2 = grdData.Columns[1];
            DataControlField dataControlField3 = grdData.Columns[2];
            DataControlField dataControlField4 = grdData.Columns[3];

            grdData.Columns.Clear();

            dataControlField1.HeaderText = "";
            dataControlField2.HeaderText = "";
            dataControlField3.HeaderText = "";

            grdData.Columns.Add(dataControlField1);
            grdData.Columns.Add(dataControlField2);
            grdData.Columns.Add(dataControlField3);
            grdData.Columns.Add(dataControlField4);

            IList<Propriete> obtenirListePropriete = Presenter.ObtenirListePropriete();
            obtenirListePropriete = obtenirListePropriete.Where(x => x.Nom != "SearchUpdate").ToList();
            obtenirListePropriete = obtenirListePropriete.Where(x => x.Nom != "ComboboxDescriptionUpdate").ToList();
            obtenirListePropriete = obtenirListePropriete.Where(x => x.Nom != "Search").ToList();
            obtenirListePropriete = obtenirListePropriete.Where(x => x.Nom != "IsActive").ToList();
            obtenirListePropriete = obtenirListePropriete.Where(x => x.Nom != "ComboboxDescription").ToList();

            foreach (Propriete propriete in obtenirListePropriete)
            {
                if (propriete.PropertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                {
                    TemplateField champsPersonnalise = new TemplateField
                    {
                        ItemTemplate =
                            new GridViewTemplate(DataControlRowType.DataRow,
                                                 propriete.Libelle, propriete.Nom, propriete.EstProprieteNative, NomEntite),
                        HeaderTemplate =
                            new GridViewTemplate(DataControlRowType.Header,
                                                 propriete.Libelle, propriete.Nom, propriete.EstProprieteNative, NomEntite)
                    };
                    champsPersonnalise.HeaderText = propriete.Libelle;
                    grdData.Columns.Add(champsPersonnalise);
                }
            }
        }
        public void GenererControles()
        {
            pnlControl.Controls.Clear();
            IList<Controle> listeControles = Presenter.ObtenirListeControle();
            
            Table table = new Table { Width = new Unit(100, UnitType.Percentage) };

            foreach (Controle controle in listeControles)
            {
                if (controle.Objet != null)
                {
                    TableRow rangee = new TableRow();
                    TableCell celluleLibelle = new TableCell { Width = new Unit(175, UnitType.Pixel) };
                    TableCell celluleControle = new TableCell();

                    celluleLibelle.Controls.Add(controle.Libelle);
                    celluleControle.Controls.Add(controle.Objet);

                    rangee.Cells.Add(celluleLibelle);
                    rangee.Cells.Add(celluleControle);
                    table.Rows.Add(rangee);
                }
            }
            pnlControl.Controls.Add(table);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GenererControles();
            Rechercher();
        }
        protected void btnRechercheClick(object sender, EventArgs e)
        {
            Rechercher();
        }
        protected void btnEnregistrerClick(object sender, EventArgs e)
        {
            if (Presenter.Enregistrer(pnlControl) != 0)
            {
                ShowMessage(new Message { Description = "Enregistrement complété", MessageType = Message.MESSAGE_TYPE_SUCCESS });
            }

        }
        protected void btnAnnulerClick(object sender, EventArgs e)
        {
            pnlEdition.Visible = false;
            pnlPilotage.Visible = true;
            GenererControles();
        }
        protected void btnAjouterClick(object sender, EventArgs e)
        {
            pnlEdition.Visible = true;
            pnlPilotage.Visible = false;
            ValeurId = 0;
            GenererControles();
        }
        protected void grdDataRowCommandClick(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index <= grdData.Rows.Count - 1)
            {
                GridViewRow selectedRow = grdData.Rows[index];
                ValeurId = Convert.ToInt32(selectedRow.Cells[3].Text);
                switch (e.CommandName)
                {
                    case "Copie":
                        break;
                    case "Edition":
                        pnlEdition.Visible = true;
                        pnlPilotage.Visible = false;
                        GenererControles();
                        break;
                    case "Inactive":
                        break;
                }
            }
        }
        protected void grdDataPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            grdData.DataBind();
            Rechercher();
        }

        private void Rechercher()
        {
            AfficherColonneGrille();
            Presenter.Rechercher();
        }
    }
}