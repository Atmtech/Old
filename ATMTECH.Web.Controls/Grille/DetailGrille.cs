using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Grille
{

    /// <summary>
    /// Conteneur du détail d'une grille. 
    /// </summary>
    [ToolboxData("<{0}:ATMTECHDetailGrille runat=server></{0}:ATMTECHDetailGrille>")]
    public class DetailGrille : FormView
    {
        /// <summary>
        /// Permet d'annuler la modification en cours. C'est un petit hack
        /// pour permettre la validation au moment de l'appel de la méthode
        /// du Presenter (update/insert), et non avant (OnInserting).
        /// </summary>
        internal bool AnnulerModification { get; set; }

        /// <summary>
        /// Titre de la fenêtre dans le cas d'une utilisation en lecture seul.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Titre de la fenêtre dans le cas d'une utilisation en modification.
        /// </summary>
        public string TitreModification { get; set; }

        /// <summary>
        /// Titre de la fenêtre dans le cas d'une utilisation en mode d'ajout.
        /// </summary>
        public string TitreInsertion { get; set; }

        /// <summary>
        /// Largeur de la fenêtre modal
        /// </summary>
        public string Largeur { get; set; }

        /// <summary>
        /// Hauteur de la fenêtre modal
        /// </summary>
        public string Hauteur { get; set; }

        private bool? _estDeplacable;

        /// <summary>
        /// Permet de déplacer la fenêtre flottante (vrai par défaut)
        /// </summary>
        public bool EstDeplacable
        {
            get { return _estDeplacable ?? true; }
            set { _estDeplacable = value; }
        }

        /// <summary>
        /// Permet de redimentionné la fenêtre flottante
        /// </summary>
        public bool EstRedimentionnable { get; set; }

        #region [ Méthode public ]

        /// <summary>
        /// Active le mode d'édition pour la ligne sélectionné.
        /// </summary>
        /// <param name="index">
        /// Index de la ligne dans le datasource.
        /// </param>
        public void EntrerModeEdition(int index)
        {
            PageIndex = index;
            ChangeMode(FormViewMode.Edit);
           
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstAvecAutoComplete
        {
            get { return (bool)(ViewState["estAvecAutoComplete"] ?? false); }
            set { ViewState["estAvecAutoComplete"] = value; }
        }
        /// <summary>
        /// On va avoir des problèmes en read-only pour une grille non initialisée
        /// (EstAutomatiquementLie = false), donc on empêche le DataBind
        /// </summary>
        protected override void EnsureDataBound()
        {
            if (CurrentMode != FormViewMode.ReadOnly && !AnnulerModification)
            {
                base.EnsureDataBound();
            }
        }

        
// ReSharper disable UnaccessedField.Local
        private FormViewMode _modeDefaut = FormViewMode.ReadOnly;
// ReSharper restore UnaccessedField.Local

        /// <summary>
        /// Toujours = FormViewMode.ReadOnly pour ce contrôle
        /// </summary>
        public override FormViewMode DefaultMode
        {
            get { return FormViewMode.ReadOnly; }
            set { _modeDefaut = value; }
        }

        /// <summary>
        /// Active le mode ajout (Insert)
        /// </summary>
        public void EntrerModeAjout()
        {
            ChangeMode(FormViewMode.Insert);
        }
        /// <summary>
        /// Méthode permettant de retourner le mode par défaut.
        /// </summary>
        public void RetournerModeParDefaut()
        {
            ChangeMode(DefaultMode);
        }

        #endregion
    }
}