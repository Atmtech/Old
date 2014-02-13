using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Edition;
using ATMTECH.Web.Controls.Grille;
using ATMTECH.Web.Controls.Interfaces;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Classe de base à utiliser pour tous les controles
    /// </summary>
    public class ControleBase : CompositeControl, IControleAvecModeAffichage
    {
        
        #region Ctor

        /// <summary>
        /// Constructeur
        /// </summary>
        public ControleBase() : this(true)
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public ControleBase(bool validateurRequis)
        {
            ValidateurRequis = validateurRequis;
            if (ValidateurRequis)
            {
                _requiredFieldValidator = new RequiredFieldValidator();
                _requiredFieldValidator.Enabled = false;
            }
        }

        #endregion

        private readonly RequiredFieldValidator _requiredFieldValidator;

        #region Propriété

        /// <summary>
        /// Le groupe de validation
        /// </summary>
        [Category("Behavior")]
        [Description("Groupe qui doit être validé lorsque le contrôle entraîne une publication.")]
        public string ValidationGroup { get; set; }
        
        /// <summary>
        /// Le groupe de validation
        /// </summary>
        [Category("Behavior")]
        [Description("Groupe qui doit être validé lorsque le contrôle entraîne une publication.")]
        public string GroupeValidation
        {
            get { return ValidationGroup; }
            set { ValidationGroup = value; }
        }

        /// <summary>
        /// Détermine s'il y aura retour à la ligne automatique en mode lecture seule.
        /// Par défaut: non
        /// </summary>
        public bool WrapEnModeLectureSeule { get; set; }

        /// <summary>
        /// Indique si le champ est obligatoire
        /// </summary>
        public bool ValidateurRequis { get; set; }

        internal bool ConvertirSautsDeLigne { get; set; }

        /// <summary>
        /// Le nom du champ qui sera affiché dans le message du contrôle de 
        /// validation. Si non renseigné, le contenu de la propriété libelle 
        /// sera alors utilisé.
        /// </summary>
        [Category("Validateur"),
         Description("Le nom du champ qui sera affiché dans le message du contrôle de validation. Si non renseigné, le contenu de la propriété libelle sera alors utilisé.")]
        public string NomChamp
        {
            get
            {
                string nomChamp = ObtenirProprieteViewState<string>("NomChamp", null);
                if (string.IsNullOrEmpty(nomChamp))
                {
                    IControleAvecLibelle ctl = this as IControleAvecLibelle;
                    if (ctl != null)
                    {
                        nomChamp = ctl.Libelle.Trim().TrimEnd(new[] { ':' });
                    }
                }
                return nomChamp;
            }
            set { AssignerProprieteViewState("NomChamp", value); }
        }

        /// <summary>
        /// Obtenir le validateur d'élément obligatoire
        /// </summary>
        public RequiredFieldValidator ValidateurChampRequis
        {
            get { return _requiredFieldValidator; }
        }

        /// <summary>
        /// Indique si le champ est obligatoire
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("Indique si le champ est obligatoire.")]
        public virtual bool EstObligatoire { get; set; }

        internal string IdentifiantRangee { get; set; }

        #endregion

        #region Évènement du control

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (EstLectureSeule())
            {
                DesactiverValidateurs();
            }
            else
            {
                AjusterValidateurChampObligatoireAvantRendu();
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            //Ajout du validateur champ obligatoire et création de son id.
            if (ValidateurRequis)
            {
                _requiredFieldValidator.ID = "reqVal";
                Controls.Add(_requiredFieldValidator);
            }
            base.CreateChildControls();
        }

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList tblValeurs = (ArrayList)savedState;
                int i = 0;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    EstObligatoire = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    ModeAffichage = (ModeAffichage)tblValeurs[i];
                if (tblValeurs[++i] != null)
                    ValidationGroup = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    IdentifiantRangee = tblValeurs[i].ToString();
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
            ArrayList tblValeurs = new ArrayList();
            tblValeurs.Add(base.SaveViewState());
            tblValeurs.Add(EstObligatoire);
            tblValeurs.Add(_modeAffichage);
            tblValeurs.Add(ValidationGroup);
            tblValeurs.Add(IdentifiantRangee);
            return tblValeurs;
        }

        #endregion

        /// <summary>
        /// Ajuste les propriétés de configuration du validateur de champ
        /// obligatoire avant le rendu.
        /// </summary>
        private void AjusterValidateurChampObligatoireAvantRendu()
        {
            if (_requiredFieldValidator != null && Controls.Contains(_requiredFieldValidator))
            {
                _requiredFieldValidator.Visible = ValidateurRequis && EstObligatoire;
                _requiredFieldValidator.Enabled = _requiredFieldValidator.Visible;
                _requiredFieldValidator.Display = ValidatorDisplay.Dynamic;
                _requiredFieldValidator.InitialValue = String.Empty;

                string nomChamp = NomChamp;
                if (string.IsNullOrEmpty(nomChamp))
                {
                    _requiredFieldValidator.ToolTip = "Ce champ est obligatoire.";
                    _requiredFieldValidator.ErrorMessage = "Ce champ est obligatoire.";
                }
                else
                {
                    string msg = String.Format("Le champ \"{0}\" est obligatoire.", nomChamp);
                    _requiredFieldValidator.ErrorMessage = msg;
                    _requiredFieldValidator.ToolTip = msg;
                }
                _requiredFieldValidator.ValidationGroup = ValidationGroup;
                EditionUtils.CreerIndicateurErreur(this, ValidateurChampRequis);
            }
        }

        #region Méthode public

        private ModeAffichage _modeAffichage = ModeAffichage.Herite;

        /// <summary>
        /// Gère le mode d'affichage.
        /// </summary>
        /// <value>Le mode d'affichage.</value>  
        public ModeAffichage ModeAffichage
        {
            get
            {
                return ObtenirModeAffichage();
            }
            set
            {
                _modeAffichage = value;
            }
        }

        /// <summary>
        /// Permet d'obtenir le mode d'affichage du contrôle, sans aller voir dans les parents.
        /// </summary>
        public ModeAffichage ModeAffichageControle
        {
            get { return _modeAffichage; }
        }


        /// <summary>
        /// Méthode pour obtenir le mode d'affichage
        /// </summary>
        /// <returns>Mode d'affichage</returns>
        internal ModeAffichage ObtenirModeAffichage()
        {
            return ATMTECHControleHelper.ObtenirModeAffichage(this);
        }
        #endregion

        private ContexteUtilisation? _contexte;

        /// <summary>
        /// Contexte du contrôle (dans une fenêtre de dialogue,
        /// une grille ou sur la page).
        /// </summary>
        protected virtual ContexteUtilisation Contexte
        {
            get
            {
                if (!_contexte.HasValue)
                {
                    _contexte = ObtenirContexte();
                }
                return _contexte.Value;
            }
        }

        /// <summary>
        /// Permet d'obtenir le contexte du contrôle (dans une fenêtre
        /// de dialogue, une grille ou sur la page).
        /// </summary>
        protected ContexteUtilisation ObtenirContexte()
        {
            Control ctl = Parent;
            while (ctl != null)
            {
                DetailGrille dg = ctl as DetailGrille;
                if (dg != null)
                {
                    return dg.CurrentMode == FormViewMode.Edit
                               ? ContexteUtilisation.GrilleModification
                               : ContexteUtilisation.GrilleAjout;
                }
                if (ctl is FenetreDialogue)
                {
                    return ContexteUtilisation.FenetreDialogue;
                }
                ctl = ctl.Parent;
            }
            return ContexteUtilisation.Page;
        }

        /// <summary>
        /// Permet d'obtenir une propriété à partir du ViewState, ou une valeur
        /// par défaut spécifiée. Utiliser dans le "get" d'une propriété, en
        /// tandem avec AssignerProprieteViewState dans le "set".
        /// </summary>
        protected T ObtenirProprieteViewState<T>(string cle, T valeurParDefaut)
        {
            if (ViewState[cle] == null)
            {
                ViewState[cle] = valeurParDefaut;
            }
            return (T)ViewState[cle];
        }

        /// <summary>
        /// Permet de sauvegarder une propriété dans le ViewState.
        /// Utiliser dans le "set", avec ObtenirProprieterViewState dans le "get"
        /// du ViewState.
        /// </summary>
        protected void AssignerProprieteViewState<T>(string cle, T valeur)
        {
            ViewState[cle] = valeur;
        }

        private void DesactiverValidateurs()
        {
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is BaseValidator)
                {
                    Controls[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// Retourne true si le contrôle est en lecture seule
        /// </summary>
        protected bool EstLectureSeule()
        {
            return !(Enabled && ObtenirModeAffichage() == ModeAffichage.Modification);
        }
    }
}
