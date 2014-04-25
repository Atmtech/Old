using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.DenonceTonGros.Entities;
using ATMTECH.DenonceTonGros.Views;
using ATMTECH.DenonceTonGros.Views.Interface;

namespace ATMTECH.DenonceTonGros.WebSite
{
    public partial class Default1 : PageBaseDenonceTonGros<DefaultPresenter, IDefaultPresenter>, IDefaultPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IList<DenonceTonGrosTas> ListeTop
        {
            set
            {
                datalistTop.DataSource = value;
                datalistTop.DataBind();
            }
        }

        public string TotalMarde { set { lblTotalMarde.Text = value; } }

        public Entities.DenonceTonGrosTas MerdeDuJour
        {
            set
            {
                if (value != null)
                {
                    Session["MerdeDuJour"] = value.Id;
                    string DenonceTonGrosTexte = value.Description + " " + value.Insulte.Description;
                    lblMerdeDuJour.Text = DenonceTonGrosTexte;
                }
                else
                {
                    lblMerdeDuJour.Text = "Eurk tu es gros";
                }
            }
        }

        public IList<Entities.DenonceTonGrosTas> Liste
        {
            set
            {
                datalist.DataSource = value;
                datalist.DataBind();
            }
        }

        public int CompteTotal
        {
            set
            {
                ddlListePage.Items.Clear();
                int valeurPage = 0;
                int totalPage = value / Presenter.NombreInsulte;
                int page = 1;
                for (int i = 0; i < totalPage; i++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = valeurPage.ToString();
                    listItem.Text = page.ToString();
                    ddlListePage.Items.Add(listItem);
                    valeurPage += Presenter.NombreInsulte;
                    page += 1;
                }
            }
        }


        protected void selectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(ddlListePage.SelectedValue);
            Liste = Presenter.ObtenirListe(page, Presenter.NombreInsulte);
        }



        protected void ItemCommandClick(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "JaimeTaMerde")
            {
                Presenter.JaimeTaMerde(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void imgBtnLikeMerdeDujourClick(object sender, ImageClickEventArgs e)
        {
            Presenter.JaimeTaMerde(Convert.ToInt32(Session["MerdeDuJour"]));
        }

    }
}