using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using AjaxControlToolkit;
using ATMTECH.Web;

namespace ATMTECH.TransfertVideo
{
    public partial class Etape1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                string guid = QueryString.GetQueryStringValue("Guid");
                if (!string.IsNullOrEmpty(guid))
                {
                    Film film = new DAO().ObtenirListeFilm().FirstOrDefault(x => x.Guid == guid);
                    if (film != null)
                    {
                        txtEtudiant1.Text = film.Etudiant1;
                        txtEtudiant2.Text = film.Etudiant2;
                        txtEtudiant3.Text = film.Etudiant3;
                        txtEtudiant4.Text = film.Etudiant4;
                        txtEtudiant5.Text = film.Etudiant5;
                        txtGroupe.Text = film.Groupe;
                    }

                }
            }
        }

        protected void btnSuivantClick(object sender, EventArgs e)
        {
            Film film = new Film
            {
                Guid = string.IsNullOrEmpty(QueryString.GetQueryStringValue("Guid")) ? Guid.NewGuid().ToString() : QueryString.GetQueryStringValue("Guid"),
                Etudiant1 = txtEtudiant1.Text,
                Etudiant2 = txtEtudiant2.Text,
                Etudiant3 = txtEtudiant3.Text,
                Etudiant4 = txtEtudiant4.Text,
                Etudiant5 = txtEtudiant5.Text,
                Groupe = txtGroupe.Text
            };
            new DAO().EcrireFilm(film, Server.MapPath("/Data/") + "Film.xml");
            Response.Redirect("Etape2.aspx?guid=" + film.Guid);
        }


    }
}