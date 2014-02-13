using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Interfaces
{
    /// <summary>
    /// Cet interface permet de centraliser les propriétés des contrôles qui
    /// contiennent un libellé. Surtout utile pour centraliser la génération
    /// dudit libellé, et permet aussi d'éviter de polluer ControleBase avec
    /// des trucs pas utilisés par tous les contrôles.
    /// </summary>
    internal interface IControleAvecLibelle
    {
        /// <summary>
        /// Le contenu du libellé associé au contrôle
        /// </summary>
        string Libelle { get; set; }

        /// <summary>
        /// La largeur du libellé.
        /// </summary>
        Unit LibelleLargeur { get; set; }

        /// <summary>
        /// Le style de la cellule du libelle
        /// </summary>
        string StyleCelluleLibelle { get; set; }

        /// <summary>
        /// Le style de la cellule de contenu
        /// </summary>
        string StyleCelluleContenu { get; set; }

        /// <summary>
        /// Le nombre de colonnes que va occuper le contrôle (cellule de contenu)
        /// </summary>
        int ColumnSpan { get; set; }
    }

    /// <summary>
    /// Méthodes d'extension pour les contrôles qui implémentent l'interface
    /// IControleAvecLibelle.
    /// </summary>
    internal static class ControleAvecLibelleExtensions
    {
        private static readonly Regex _classeRegex = new Regex(@"\bcelluleContenu\b");

        /// <summary>
        /// Méthode pour les contrôles contenant un libellé (deux cellules d'une table).
        /// Ici nous "rendons" le contenu de la cellule de titre (libellé).
        /// </summary>
        internal static void CreerCelluleLibelle(this IControleAvecLibelle controle, TextWriter writer)
        {
            if (!string.IsNullOrEmpty(controle.Libelle))
            {
                string style = ObtenirStyleCelluleLibelle(controle);
                if (!string.IsNullOrEmpty(style))
                {
                    style = string.Format(" style='{0}'", style);
                }
                writer.Write("<td class='titreLabelAvance'{0}>{1}</td>", style, HttpUtility.HtmlEncode(controle.Libelle));
            }
        }

        /// <summary>
        /// Cette méthode permet d'ouvrir la cellule du contenu, s'il y lieu.
        /// Un span sera utilisé s'il n'y pas de cellule, et la classe CSS par défaut
        /// (celluleContenu) sera utilisée.
        /// </summary>
        internal static void OuvrirCelluleContenu(this IControleAvecLibelle controle, TextWriter writer)
        {
            OuvrirCelluleContenu(controle, writer, string.Empty);
        }

        /// <summary>
        /// Cette méthode permet d'ouvrir la cellule du contenu, s'il y lieu, en spécifiant
        /// des classes CSS supplémentaires pour le contenu.
        /// Un span sera utilisé s'il n'y pas de cellule. Si le champ est actif et obligatoire,
        /// un indicateur sera ajouté.
        /// </summary>
        internal static void OuvrirCelluleContenu(this IControleAvecLibelle controle, TextWriter writer, string classeCssCellule)
        {
            string classeCss = classeCssCellule ?? string.Empty;
            if (!_classeRegex.Match(classeCssCellule).Success)
            {
                classeCss += " celluleContenu";
                classeCss = classeCss.Trim();
            }
            ControleBase ctl = (ControleBase) controle;
            bool lectureSeule = ctl.ObtenirModeAffichage() != ModeAffichage.Modification || !ctl.Enabled;
            if (lectureSeule)
            {
                classeCss += " lectureSeule";
            }
            else
            {
                classeCss += ctl.EstObligatoire ? " obligatoire" : " facultatif";
            }
            if (!string.IsNullOrEmpty(controle.Libelle))
            {
                writer.Write("<td class='{0}'", classeCss);
                if (!string.IsNullOrEmpty(controle.StyleCelluleContenu))
                {
                    writer.Write(" style='{0}'", controle.StyleCelluleContenu);
                }
                if (controle.ColumnSpan > 1)
                {
                    writer.Write(" colspan='{0}'", controle.ColumnSpan);
                }
                writer.Write(">");
            }
            else
            {
                writer.Write("<span class='{0}'>", classeCss);
            }
            if (!lectureSeule && ctl.EstObligatoire)
            {
                const string titre = "Ce champ est obligatoire";
                string img = ctl.Page.GetEncodedResourceUrl("Edition.indicateurObligatoire.gif");
                writer.Write("<img class='indicObligatoire' title='{0}' src='{1}' alt='*' />", titre, img);
            }
        }

        /// <summary>
        /// Cette méthode permet de fermer la cellule du contenu, s'il y lieu. S'il n'y a
        /// pas de libellé, la balise par défaut (span) est fermée.
        /// </summary>
        internal static void FermerCelluleContenu(this IControleAvecLibelle controle, TextWriter writer)
        {
            writer.Write(!string.IsNullOrEmpty(controle.Libelle) ? "</td>" : "</span>");
        }

        private static string ObtenirStyleCelluleLibelle(IControleAvecLibelle controle)
        {
            List<string> styles = new List<string>();
            if (!string.IsNullOrEmpty(controle.StyleCelluleLibelle))
            {
                styles.Add(controle.StyleCelluleLibelle.TrimEnd(new[] { ';' }));
            }
            if (!controle.LibelleLargeur.IsEmpty)
            {
                styles.Add(string.Format("width: {0}", controle.LibelleLargeur.ToString()));
            }
            return string.Join("; ", styles.ToArray());
        }
    }
}
