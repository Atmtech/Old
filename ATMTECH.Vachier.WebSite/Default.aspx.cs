using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using ATMTECH.Vachier.Entities;
using ATMTECH.Vachier.Views;
using ATMTECH.Vachier.Views.Interface;

namespace ATMTECH.Vachier.WebSite
{
    public partial class Default1 : PageBaseVachier<DefaultPresenter, IDefaultPresenter>, IDefaultPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IList<Entities.Vachier> ListeTop
        {
            set
            {
                datalistTop.DataSource = value;
                datalistTop.DataBind();
            }
        }

        public Entities.Vachier MerdeDuJour
        {
            set
            {
                Session["MerdeDuJour"] = value.Id;
                string vachierTexte = value.Description + " " + value.Insulte.Description;
                lblMerdeDuJour.Text = vachierTexte;
            }
        }

        public IList<Entities.Vachier> Liste
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