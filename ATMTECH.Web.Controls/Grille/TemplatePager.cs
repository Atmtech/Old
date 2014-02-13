using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Classe qui gère l'affichage de la section de pagination au bas de la grille.
    /// </summary>
    public class TemplatePager : ITemplate
    {
        private readonly GrilleAvance _grilleParent;

        public TemplatePager(GrilleAvance grilleParent)
        {
            _grilleParent = grilleParent;
        }

        /// <summary>
        /// Implémenté par une classe, définit l'objet <see cref="T:System.Web.UI.Control"/> auquel les contrôles enfants et les modèles appartiennent. Ces contrôles enfants sont à leur tour définis dans un modèle inline.
        /// </summary>
        /// <param name="container">Objet <see cref="T:System.Web.UI.Control"/> qui contiendra les instances de contrôles en provenance du modèle inline.</param>
        public void InstantiateIn(Control container)
        {
            Panel pnl = new Panel {CssClass = "pagination"};
            AjouterControlePagination(pnl);
            container.Controls.Add(pnl);
        }

        private void AjouterControlePagination(Control container)
        {
            Panel partieGauche = new Panel {CssClass = "gauche"};
            Panel partieDroite = new Panel {CssClass = "droite"};
            if (_grilleParent.AlignementPagination == HorizontalAlign.Left)
            {
                AjouterLiensPagination(partieGauche);
                AjouterNombreResultats(partieDroite);
            }
            else
            {
                AjouterNombreResultats(partieGauche);
                AjouterLiensPagination(partieDroite);
            }
            container.Controls.Add(partieGauche);
            container.Controls.Add(partieDroite);
        }

        private void AjouterNombreResultats(Panel pnl)
        {
            if (_grilleParent.AfficherNombreResultats)
                pnl.Controls.Add(ConstruireNombreResultats());
        }

        private void AjouterLiensPagination(Panel pnl)
        {
            if (_grilleParent.EstPermiPagination && _grilleParent.NombrePages > 1)
                pnl.Controls.Add(ConstruireLiensPagination());
        }

        private Control ConstruireNombreResultats()
        {
            HtmlGenericControl container = CreerSpan("nbResultats");
            container.InnerText = string.Format("{0} résultat(s)", _grilleParent.NombreResultats);
            return container;
        }

        private Control ConstruireLiensPagination()
        {
            Control container = CreerSpan("pages");
            int indexCourant = _grilleParent.PageIndex;
            int pageCourante = _grilleParent.PageIndex + 1;
            int noTranche = indexCourant/10;
            int debutSectionCourante = noTranche * 10 + 1;
            int finSectionCourante = debutSectionCourante + 9;
            if (finSectionCourante > _grilleParent.NombrePages)
            {
                finSectionCourante = _grilleParent.NombrePages;
                debutSectionCourante = Math.Max(1, finSectionCourante - 9);
            }

            if (debutSectionCourante > 1)
                container.Controls.Add(CreerLienPage(debutSectionCourante - 1, "..."));

            for (int noPage = debutSectionCourante; noPage <= finSectionCourante; noPage++)
            {
                if (noPage == pageCourante)
                    container.Controls.Add(CreerLienPageCourante(noPage));
                else
                    container.Controls.Add(CreerLienPage(noPage));
            }

            if (finSectionCourante < _grilleParent.NombrePages)
                container.Controls.Add(CreerLienPage(finSectionCourante + 1, "..."));

            return container;
        }

        private Control CreerLienPageCourante(int noPage)
        {
            HtmlGenericControl span = CreerSpan();
            span.InnerText = noPage.ToString();
            return span;
        }

        private Control CreerLienPage(int noPage, string texte = null)
        {
            LinkButton lien = new LinkButton();
            lien.ID = "btnPage" + noPage;
            lien.CausesValidation = false;
            lien.CommandName = "Page";
            lien.CommandArgument = noPage.ToString();
            lien.Text = texte ?? noPage.ToString();

            HtmlGenericControl span = CreerSpan();
            span.Controls.Add(lien);
            return span;
        }

        private HtmlGenericControl CreerSpan(string cssClass = null)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            if (!string.IsNullOrEmpty(cssClass))
            {
                span.Attributes["class"] = cssClass;
            }
            return span;
        }
    }
}