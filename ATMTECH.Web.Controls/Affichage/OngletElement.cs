using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Interfaces;
using AttributeCollection = System.Web.UI.AttributeCollection;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Structure qui définit les onglets qui seront rendu par le contrôle
    /// ATMTECHOnglets. 
    /// </summary>
    [ControlBuilder(typeof (OngletControlBuilder)), TypeConverter(typeof (ExpandableObjectConverter)),
     ParseChildren(true, "ContenuControl"),
     AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class OngletElement : CompositeControl, IParserAccessor, IAttributeAccessor, IStateManager, IControleAvecModeAffichage, IViewIdentifiant
    {
        #region [ ctor ]

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OngletElement"/>.
        /// </summary>
        public OngletElement()
            : this(null, null, true, ModeAffichage.Herite)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OngletElement"/>.
        /// </summary>
        /// <param name="titre">Le titre.</param>
        public OngletElement(string titre)
            : this(titre, null, true, ModeAffichage.Herite)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OngletElement"/>.
        /// </summary>
        /// <param name="titre">Le titre.</param>
        /// <param name="contenu">Le contenu.</param>
        public OngletElement(string titre, string contenu)
            : this(titre, contenu, true, ModeAffichage.Herite)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OngletElement"/>.
        /// </summary>
        /// <param name="titre">Le titre.</param>
        /// <param name="contenu">Le contenu.</param>
        /// <param name="enabled">Si <c>vrai</c> [enabled].</param>
        public OngletElement(string titre, string contenu, bool enabled)
            : this(titre, contenu, enabled, ModeAffichage.Herite)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OngletElement"/>.
        /// </summary>
        /// <param name="titre">Le titre.</param>
        /// <param name="contenu">Le contenu.</param>
        /// <param name="enabled">Si <c>vrai</c> [enabled].</param>
        /// <param name="modeAffichage">Le mode d'affichage de l'onglet.</param>
        public OngletElement(string titre, string contenu, bool enabled, ModeAffichage modeAffichage)
        {
            Titre = titre;
            Contenu = contenu;
            Enabled = enabled;
            ModeAffichage = modeAffichage;
        }

        #endregion

        #region [ Membre privé]

        /// <summary>
        /// TAG de Ongletelement
        /// </summary>
        public const string TAG = "ATMTECHOngletElement";
        private AttributeCollection _attributes;
        private bool _contenuIsDirty;
        private bool _titreIsDirty;
        private bool _selectionne;
        private bool _selectionneIsDirty;
        private bool _modeAffichageIsDirty;
        private string _contenu;
        private string _titre;
        private ModeAffichage _modeAffichage;
        private ATMTECHUserControlBase _contenuControl;
        
        internal string _panelClientId;
        internal string _panelId;

        #endregion

        #region [ Propriétés ]

        ///<summary>
        /// Id de sécurité pour l'onglet
        /// </summary>
        public string IdObjetSecurite { get; set; }

        /// <summary>
        /// Id d'aide contextuelle pour l'onglet
        /// </summary>
        public string IdAideContextuelle { get; set; }

        public new bool Enabled { get; set; }

        /// <summary>
        /// Url du contrôle qui sera chargé dynamiquement lors de la sélection
        /// de l'onglet. La propriété peut-être renseigné via le designer
        /// 
        /// ex: ATMTECHOngletElement Contenu="~/UserControl/MonControl.ascx";
        /// </summary>
        public string Contenu
        {
            get { return _contenu; }
            set
            {
                _contenu = value;
                _contenuIsDirty = true;
            }
        }

        /// <summary>
        /// Cette propriété est renseigné par un control enfant de ATMTECHOngletElement.
        /// Son contenu n'est pas persisté lorsque l'onglet est traité. Son url est 
        /// seulement sera conservé dans la propriété Contenu.
        /// </summary>
        public Control ContenuControl
        {
            get { return _contenuControl; }
            set
            {
                if (value != null && value.Controls.Count > 1)
                {
                    _contenuControl = (ATMTECHUserControlBase) value.Controls[1];
                    Contenu = _contenuControl.AppRelativeVirtualPath;
                }
            }
        }

        /// <summary>
        /// Libellé qui sera affiché dans l'onglet.
        /// </summary>
        [Localizable(true), DefaultValue("")]
        public string Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                _titreIsDirty = true;
            }
        }

        /// <summary>
        /// Indicateur d'état si l'onglet est celui actif.
        /// </summary>
        public bool Selectionne
        {
            get { return _selectionne; } 
            set { _selectionne = value;
                _selectionneIsDirty = true;
            }
        }

        /// <summary>
        /// Indicateur pour savoir si on doit sauvegarder l'état de l'onglet
        /// dans le ViewState.
        /// </summary>
        internal bool Dirty
        {
            get { return _titreIsDirty | _contenuIsDirty | _selectionneIsDirty | _modeAffichageIsDirty; }
            set
            {
                _titreIsDirty = value;
                _contenuIsDirty = value;
                _selectionneIsDirty = value;
                _modeAffichageIsDirty = value;
            }
        }

        /// <summary>
        /// Permet l'utilisation d'attribut dans le designer.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public new AttributeCollection Attributes
        {
            get { return _attributes ?? (_attributes = new AttributeCollection(new StateBag(true))); }
        }

        /// <summary>
        /// Permet d'obtenir le mode d'affichage du contrôle, sans aller voir dans les parents.
        /// </summary>
        public ModeAffichage ModeAffichageControle
        {
            get { return ModeAffichage; }
        }

        /// <summary>
        /// Gère le mode d'affichage.
        /// </summary>
        /// <value>Le mode d'affichage.</value>  
        public ModeAffichage ModeAffichage
        {
            get { return _modeAffichage; }
            set
            {
                _modeAffichage = value;
                _modeAffichageIsDirty = true;
            }
        }

        #endregion

        #region [ Implementation de IParserAccessor ]

        /// <summary>
        /// Méthode qui est appellé lors que l'onglet est traité. Si un noeud
        /// enfant ce retrouve dans la structure, on vérifie si il hérite de
        /// la classe ATMTECHUserControlBase. 
        /// </summary>
        /// <param name="obj"></param>
        public new void AddParsedSubObject(object obj)
        {
            if (obj.GetType().IsSubclassOf(typeof (ATMTECHUserControlBase)))
            {
                Contenu = obj.GetType().ToString();
            }
            else
            {
                throw new HttpParseException("Le control n'accepte pas ce type de composante comme enfant.");
            }
        }

        #endregion

        #region [ Implementation de IAttributeAccessor  ]

        /// <summary>
        /// Permet de récupérer les propriétés configurés dans le designer.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAttribute(string key)
        {
            return Attributes[key];
        }

        /// <summary>
        /// Permet d'affecter une valeur au propriété via un attribut dans le designer.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetAttribute(string key, string value)
        {
            Attributes[key] = value;
        }

        #endregion

        #region IStateManager Membres

        /// <summary>
        /// Implémenté par une classe, obtient une valeur indiquant si un contrôle serveur effectue le suivi des changements de son état d'affichage.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// true si le contrôle serveur effectue le suivi des changements de son état d'affichage ; sinon, false.
        /// </returns>
        public new bool IsTrackingViewState { get; private set; }

        /// <summary>
        /// Implémenté par une classe, charge dans un contrôle serveur son état d'affichage précédemment enregistré.
        /// </summary>
        /// <param name="stateBrute"><see cref="T:System.Object"/> qui contient les valeurs d'état d'affichage enregistrées du contrôle.</param>
        public new void LoadViewState(object stateBrute)
        {
            if (stateBrute != null)
            {
                object[] state = (object[]) stateBrute;
                if (state[0] != null) Titre = (string) state[0];
                if (state[1]!= null) Contenu = (string) state[1];
                if (state[2] != null) Selectionne = (bool) state[2];
                if (state[3] != null) ModeAffichage = (ModeAffichage) state[3];
            }
        }

        /// <summary>
        /// Implémenté par une classe, enregistre les modifications de l'état d'affichage d'un contrôle serveur dans un <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// 	<see cref="T:System.Object"/> qui contient les changements de l'état d'affichage.
        /// </returns>
        public new object SaveViewState()
        {
            object[] state = new object[4];

            if (_titreIsDirty)
                state[0] = Titre;
            if (_contenuIsDirty)
                state[1] = Contenu;
            if (_selectionneIsDirty)
                state[2] = Selectionne;
            if (_modeAffichageIsDirty)
                state[3] = ModeAffichage;

            return state;
        }

        /// <summary>
        /// Implémenté par une classe, commande au contrôle serveur d'effectuer le suivi des modifications de son état d'affichage.
        /// </summary>
        public new void TrackViewState()
        {
            IsTrackingViewState = true;
        }

        #endregion

    }
}
