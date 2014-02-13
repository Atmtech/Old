using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI;
using System.Web.UI.Design;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Contrôle qui permet d'afficher une bordure ronde
    /// autour de plusieurs contrôles.
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <ATMTECH:GroupeBoite runat="server"><table>
    /// <tr>
    ///  <ATMTECH:ContenuLabelAvance runat="server" Libelle="Nombre d'étages" LibelleLargeur="200" text="4" />
    ///  <ATMTECH:ContenuLabelAvance runat="server" Libelle="Année de construction" LibelleLargeur="200" text="1921" />
    /// </tr>
    /// <tr>
    ///  <ATMTECH:TextBoxAvance runat="server" Libelle="Escaliers mécaniques" Width="35px" />
    ///  <ATMTECH:TextBoxAvance runat="server" Libelle="Année de rénovation majeure" Width="35px" />
    /// </tr>
    /// </table></ATMTECH:GroupeBoite>
    /// ]]></code>
    [PersistChildren(true)]
    [ParseChildren(false)]
    [Designer(typeof(ContainerControlDesigner))]
    public class GroupeBoite : ControleBase
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public GroupeBoite() : base(false)
        {
        }

        /// <summary>
        /// Le contenu du libellé associé au libellé de contenu.
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le contenu du libellé associé au groupe.")]
        public string Libelle
        {
            get { return ObtenirProprieteViewState("Libelle", string.Empty); }
            set { AssignerProprieteViewState("Libelle", value); }
        }

        /// <summary>
        /// Obtient la valeur <see cref="T:System.Web.UI.HtmlTextWriterTag"/> qui correspond au contrôle serveur Web. Cette propriété est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// Une des valeurs d'énumération <see cref="T:System.Web.UI.HtmlTextWriterTag"/>.
        /// </returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            CssClass = "groupeBoite";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            CreerHautBoiteRonde(writer);

            CreerLibelle(writer);

            CreerContenu(writer);

            CreerBasBoiteRonde(writer);
        }

        private void CreerContenu(HtmlTextWriter writer)
        {
            writer.Write(@"<div class=""groupeBoitec");

            if (!String.IsNullOrEmpty(Libelle))
            {
                writer.Write(@" groupeBoitecl"); // Plus de padding haut lorsqu'il y a un titre
            }

            writer.Write(@""">");
            base.RenderContents(writer);
            writer.Write(@"</div>");
        }

        private void CreerLibelle(TextWriter writer)
        {
            if (!String.IsNullOrEmpty(Libelle))
            {
                writer.Write(@"<div class=""groupeBoitel"">");
                writer.Write(Libelle);
                writer.Write("</div>");
            }
        }

        private static void CreerBasBoiteRonde(TextWriter writer)
        {
            writer.Write(@"<div class=""groupeBoiteb""><div></div></div>");
        }

        private static void CreerHautBoiteRonde(TextWriter writer)
        {
            writer.Write(@"<div class=""groupeBoitet""><div></div></div>");
        }

        internal static string ObtenirBlocCss()
        {
            string[] cssArray = new[]
                {
                    ".groupeBoitet div { background: url(@@Affichage.groupeBoite_tl.png@@) no-repeat top left; }",
                    ".groupeBoitet { background: url(@@Affichage.groupeBoite_tr.png@@) no-repeat top right; }",
                    ".groupeBoiteb div { background: url(@@Affichage.groupeBoite_bl.png@@) no-repeat bottom left; }",
                    ".groupeBoiteb { background: url(@@Affichage.groupeBoite_br.png@@) no-repeat bottom right; }"
                };
            return String.Join("\n", cssArray);
        }
    }
}