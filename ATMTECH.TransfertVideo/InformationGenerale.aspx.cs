using System;
using System.Linq;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;

namespace ATMTECH.TransfertVideo
{
    public partial class InformationGenerale : PageMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(IdentifiantUnique))
                {
                    Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                    if (film != null)
                    {
                        txtEtudiant1.Text = film.Etudiant1;
                        txtEtudiant2.Text = film.Etudiant2;
                        txtEtudiant3.Text = film.Etudiant3;
                        txtEtudiant4.Text = film.Etudiant4;
                        txtEtudiant5.Text = film.Etudiant5;
                        ddlGroupe.Text = film.Groupe;
                    }

                }
            }
        }

        protected void btnSaveClick(object sender, EventArgs e)
        {
            Film film;
            if (!string.IsNullOrEmpty(txtEtudiant1.Text))
            {
                if (!string.IsNullOrEmpty(IdentifiantUnique))
                {
                    film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                    film.Etudiant1 = txtEtudiant1.Text;
                    film.Etudiant2 = txtEtudiant2.Text;
                    film.Etudiant3 = txtEtudiant3.Text;
                    film.Etudiant4 = txtEtudiant4.Text;
                    film.Etudiant5 = txtEtudiant5.Text;
                    film.Etudiant6 = txtEtudiant6.Text;
                    film.Style = ddlStyle.Text;
                    film.Groupe = ddlGroupe.Text;
                }
                else
                {
                    IdentifiantUnique = Guid.NewGuid().ToString();
                    film = new Film
                    {
                        Guid = IdentifiantUnique,
                        Etudiant1 = txtEtudiant1.Text,
                        Etudiant2 = txtEtudiant2.Text,
                        Etudiant3 = txtEtudiant3.Text,
                        Etudiant4 = txtEtudiant4.Text,
                        Etudiant5 = txtEtudiant5.Text,
                        Etudiant6 = txtEtudiant6.Text,
                        Style = ddlStyle.Text,
                        Groupe = ddlGroupe.Text
                    };
                }
                new DAOFilm().Enregistrer(film);
                Response.Redirect("Upload.aspx");
            }
            else
            {
                lblRequired.Visible = true;
                imgError.Visible = true;
            }
            
        }
    }
}