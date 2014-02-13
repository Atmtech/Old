using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Interfaces;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// 
    /// </summary>
    public class ContenuLabelAvance : ControleBase, IControleAvecLibelle
    {

        /// <summary>
        /// 
        /// </summary>
        public ContenuLabelAvance()
            : base(false)
        {
        }

        /// <summary>
        /// Gère le texte affiché dans le libellé de contenu.
        /// </summary>
        [Category("Appearance")]
        [Description("Valeur du texte dans le libellé de contenu.")]
        public string Text { get; set; }

        /// <summary>
        /// Ce champ n'est jamais obligatoire.
        /// </summary>
        public override bool EstObligatoire
        {
            get { return false; }
        }

        /// <summary>
        /// Contrôle en lecture seule, donc Enabled toujours à false.
        /// </summary>
        public override bool Enabled
        {
            get { return false; }
        }

        public bool EncoderHtml { get; set; }

        #region IControleAvecLibelle ------------------------------------------

        /// <summary>
        /// Le contenu du libellé associé au contrôle
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le contenu du libellé associé au textbox.")]
        public string Libelle
        {
            get { return ObtenirProprieteViewState("Libelle", string.Empty); }
            set { AssignerProprieteViewState("Libelle", value); }
        }

        /// <summary>
        /// La largeur du libellé.
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("La largeur du libellé.")]
        public Unit LibelleLargeur
        {
            get { return ObtenirProprieteViewState("LibelleLargeur", Unit.Empty); }
            set { AssignerProprieteViewState("LibelleLargeur", value); }
        }

        /// <summary>
        /// Le style de la cellule du libelle
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le style de la cellule de libelle.")]
        public string StyleCelluleLibelle
        {
            get { return ObtenirProprieteViewState("StyleCelluleLibelle", string.Empty); }
            set { AssignerProprieteViewState("StyleCelluleLibelle", value); }
        }

        /// <summary>
        /// Le style de la cellule de contenu
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le style de la cellule de contenu.")]
        public string StyleCelluleContenu
        {
            get { return ObtenirProprieteViewState("StyleCelluleContenu", string.Empty); }
            set { AssignerProprieteViewState("StyleCelluleContenu", value); }
        }

        /// <summary>
        /// Le nombre de colonnes que va occuper le contrôle (cellule de contenu)
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le nombre de colonnes que va occuper le contrôle.")]
        public int ColumnSpan
        {
            get { return ObtenirProprieteViewState("ColumnSpan", 0); }
            set { AssignerProprieteViewState("ColumnSpan", value); }
        }

        #endregion ------------------------------------------------------------

        /// <summary>
        /// Écrit le contenu <see cref="T:System.Web.UI.WebControls.CompositeControl"/> dans l'objet <see cref="T:System.Web.UI.HtmlTextWriter"/> spécifié pour qu'il s'affiche sur le client.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.CreerCelluleLibelle(writer);
            this.OuvrirCelluleContenu(writer, "contenuLabelAvance");
            this.EcrireControleLectureSeule(writer, Text, EncoderHtml);
            this.FermerCelluleContenu(writer);
        }

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState is Pair)
            {
                Pair pair = (Pair)savedState;
                base.LoadViewState(pair.First);
                if (pair.Second != null)
                Text = pair.Second.ToString();
            }
            else
            {
                base.LoadViewState(savedState);
            }
        }

        /// <summary>
        /// Enregistre les états modifiés après l'appel de la méthode <see cref="M:System.Web.UI.WebControls.Style.TrackViewState"/>.
        /// </summary>
        /// <returns>
        /// Objet qui contient l'état d'affichage actuel du contrôle ; sinon, null si aucun état d'affichage n'est associé au contrôle.
        /// </returns>
        protected override object SaveViewState()
        {
            Pair pair = new Pair();
            pair.First = base.SaveViewState();
            pair.Second = Text;

            return pair;
        }
    }
}
