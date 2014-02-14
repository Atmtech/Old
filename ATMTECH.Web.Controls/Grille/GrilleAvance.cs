using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

using ATMTECH.Exception;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:GrilleAvance runat=server></{0}:GrilleAvance>"), ParseChildren(true)]
    public partial class GrilleAvance : ControleBase
    {
        #region [ Constante ]

        [Obsolete] internal const string SELECTIONNER_BOUTON_COMMAND = "Select";
        
        public const string CONSULTER_BOUTON_COMMAND = "Consulter";
        public const string AJOUTER_BOUTON_COMMAND = "Ajouter";
        public const string MODIFIER_BOUTON_COMMAND = "Edit";
        public const string SUPPRIMER_BOUTON_COMMAND = "Delete";

        #endregion

        #region [ Membre privé ]

        private bool _aRecupereParametre;
        private readonly GridView _grille = new GridView { EnableTheming = false };
        private readonly ObjectDataSource _objectDataSource = new ObjectDataSource();
        private readonly ObjectDataSource _objectDataSourceDetail = new ObjectDataSource();
        private readonly FenetreDialogue _fenetreEdition = new FenetreDialogue();
        private readonly UpdatePanel _udpDetail = new UpdatePanel();
        private readonly DetailGrille _detail = new DetailGrille();
        private List<object> _entiteSelectionneEtPersistes;
        private bool _annulerModif;

        #endregion

        #region [ Propriétés ]
        /// <summary>
        /// 
        /// </summary>
        public DetailGrille Detail
        {
            get
            {
                EnsureChildControls();
                return _detail;
            }
        }

        #region [ Propriété de la Grille ]

        /// <summary>
        /// Obtient la grille.
        /// </summary>
        /// <value>La grille.</value>
        protected GridView Grille
        {
            get
            {
                EnsureChildControls();
                return _grille;
            }
        }

      

        /// <summary>
        /// Alignement de la pagination (left, right, etc.)
        /// Alignée à droite par défaut.
        /// </summary>
        public HorizontalAlign AlignementPagination
        {
            get { return ObtenirProprieteViewState("AlignementPagination", HorizontalAlign.NotSet); }
            set { AssignerProprieteViewState("AlignementPagination", value); }
        }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex
        {
            get { return _grille.PageIndex; }
            set { _grille.PageIndex = value; }
        }

        /// <summary>
        /// Retourne la valeur de la rangée sélectionnée (en fonction de DataKeyNames).
        /// Null ou valeur par défaut si aucune sélection.
        /// </summary>
        public T ObtenirValeurSelectionnee<T>()
        {
            return ValeurSelectionnee == null ? default(T) : (T)ValeurSelectionnee;
        }

        private object ObtenirValeurActuellementSelectionnee()
        {
            if (_grille.SelectedIndex == -1)
                return null;
            return _grille.SelectedValue;
        }

        /// <summary>
        /// Gets the data keys.
        /// </summary>
        /// <value>The data keys.</value>
        public DataKeyArray DataKeys
        {
            get { return _grille.DataKeys; }
        }

        /// <summary>
        /// Indique si la colonne d'édition doit-être présente.
        /// </summary>
        [Category("Grille")]
        [Description("Indique si la colonne d'édition doit-être présente.")]
        public bool EstAfficheColonneEdition
        {
            get { return ObtenirProprieteViewState("EstAfficheColonneEdition", false); }
            set { AssignerProprieteViewState("EstAfficheColonneEdition", value); }
        }
        /// <summary>
        /// Indique si la colonne de suppression doit-être présente.
        /// </summary>
        [Category("Grille")]
        [Description("Indique si la colonne de suppression doit-être présente.")]
        public bool EstAfficheColonneSuppression
        {
            get { return ObtenirProprieteViewState("EstAfficheColonneSuppression", false); }
            set { AssignerProprieteViewState("EstAfficheColonneSuppression", value); }
        }
        /// <summary>
        /// Indique si la colonne de consultation doit-être présente.
        /// </summary>
        [Category("Grille")]
        [Description("Indique si la colonne de consultation doit-être présente.")]
        public bool EstAfficheColonneConsulter
        {
            get { return ObtenirProprieteViewState("EstAfficheColonneConsulter", false); }
            set { AssignerProprieteViewState("EstAfficheColonneConsulter", value); }
        }

        private bool _estBoutonConsulterAsynchrone;
        private bool? _boutonsEditionAsynchrone;

        /// <summary>
        /// Permet d'indiquer que le bouton Consulter sera asynchrone.
        /// Si vous voulez afficher une fenêtre de dialogue Consulter, sans que
        /// la page au complet ne se rafraîchisse, mettez cette propriété à True
        /// et mettez à jour votre UpdatePanel au moment de l'appel à la méthode
        /// Consulter (méthode Update du UpdatePanel).
        /// </summary>
        [Category("Grille")]
        [Description("Indique si le bouton Consulter fera un postback asynchrone.")]
        public bool EstBoutonConsulterAsynchrone
        {
            get { return _estBoutonConsulterAsynchrone; }
            set { AssignerProprieteInit("EstBoutonConsulterAsynchrone", ref _estBoutonConsulterAsynchrone, value); }
        }

        /// <summary>
        /// Lorsque True, indique qu'on peut cliquer sur la rangée pour simuler le bouton Consulter ou Modifier.
        /// </summary>
        [Category("Grille")]
        [Description("Permet de surligner la rangée sélectionnée lors d'un clic sur le bouton Consulter.")]
        public bool EstRangeeCliquable
        {
            get { return ObtenirProprieteViewState("EstRangeeCliquable", false); }
            set { AssignerProprieteViewState("EstRangeeCliquable", value); }
        }

        /// <summary>
        /// Lorsque True, indique que la rangée sélectionnée sera surlignée lors d'un
        /// clic sur le bouton Consulter.
        /// </summary>
        [Category("Grille")]
        [Description("Permet de surligner la rangée sélectionnée lors d'un clic sur le bouton Consulter.")]
        public bool EstMaitreDetail
        {
            get { return ObtenirProprieteViewState("EstMaitreDetail", false); }
            set { AssignerProprieteViewState("EstMaitreDetail", value); }
        }

        internal bool EstMaitreDetailLegacy
        {
            get { return EstMaitreDetail; }
        }

        /// <summary>
        /// Permet d'indiquer que les bouton Ajouter et Modifier seront asynchrone.
        /// Par défaut, ils seront asynchrones si EstFenetreDialogue = true, et
        /// feront un postback normal si EstFenetreDialogue = false. Pour que le comportement
        /// par défaut fonctionne SANS fenêtre de dialogue, vous devez mettre le
        /// EstFenetreDialogue=false dans la déclaration (aspx/ascx).
        /// </summary>
        [Category("Grille")]
        [Description("Indique si les boutons Ajouter et Modifier feront un postback asynchrone.")]
        public bool BoutonsEditionAsynchrones
        {
            get { return _boutonsEditionAsynchrone.GetValueOrDefault(EstFenetreDialogue); }
            set { AssignerProprieteInit("BoutonsEditionAsynchrone", ref _boutonsEditionAsynchrone, value); }
        }

        /// <summary>
        /// Active la pagination de la grille.
        /// </summary>
        [Category("Grille")]
        [Description("Active la pagination de la grille.")]
        public bool EstPermiPagination
        {
            get { return _grille.AllowPaging; }
            set
            {
                _grille.AllowPaging = value;
                ObjectDatasource.EnablePaging = value;
            }
        }

        /// <summary>
        /// Mettre à False pour éviter le comportement par défaut d'ouvrir la
        /// fenêtre de dialogue lors d'un clic sur les boutons Modifier ou Ajouter.
        /// Par défaut, True.
        /// À utiliser si vous souhaitez gérer vous-mêmes le comportement dans
        /// les événements RowCommand (CommandName = "Ajouter" ou "Edit")
        /// ou RowEditing.
        /// Sera False par défaut pour un Maître-Détail
        /// </summary>
        [Category("Grille")]
        [Description("Permet d'annuler le comportement par défaut d'ouvrir une fenêtre de dialogue.")]
        public bool EstFenetreDialogue
        {
            get { return ObtenirProprieteViewState("EstFenetreDialogue", !EstMaitreDetail); }
            set { AssignerProprieteViewState("EstFenetreDialogue", value); }
        }

        /// <summary>
        /// Active le tri de la grille. (Activé par défaut)
        /// </summary>
        [Category("Grille")]
        [Description("Active le tri de la grille.")]
        public bool EstPermiTri
        {
            get { return ObtenirProprieteViewState("EstPermiTri", true); }
            set
            {
                AssignerProprieteViewState("EstPermiTri", value);
                _grille.AllowSorting = value;
            }
        }

        /// <summary>
        /// Définit le style visuel des lignes alternatives
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel des lignes alternatives")]
        public TableItemStyle AlternatingRowStyle
        {
            get { return Grille.AlternatingRowStyle; }
        }
        /// <summary>
        /// Définit les colonnes de la grille automatiquement selon la source de données.
        /// </summary>
        [Category("Grille")]
        [Description("Définit les colonnes de la grille automatiquement selon la source de données.")]
        public bool GenererColonneAuto
        {
            get { return Grille.AutoGenerateColumns; }
            set { _grille.AutoGenerateColumns = value; }
        }
        /// <summary>
        /// Collection de colonnes qui composent la grille.
        /// </summary>
        [Category("Grille")]
        [Description("Collection de colonnes qui composent la grille.")]
        public DataControlFieldCollection Columns
        {
            get { return Grille.Columns; }
        }
        /// <summary>
        /// Indicateur pour l'affichage de la ligne d'entête de la grille.
        /// </summary>
        public bool AEnteteAffiche
        {
            get { return _grille.ShowHeader; }
            set { _grille.ShowHeader = value; }
        }
        /// <summary>
        /// Indicateur pour l'affichage de la ligne de pied page de la grille.
        /// </summary>
        public bool APiedPageAffiche
        {
            get { return _grille.ShowFooter; }
            set { _grille.ShowFooter = value; }
        }

        public GridViewRow HeaderRow { get { return _grille.HeaderRow; } }
        public GridViewRow FooterRow { get { return _grille.FooterRow; } }

        /// <summary>
        /// Classe css de la grille (en plus des classes de base).
        /// </summary>
        [Category("Grille")]
        [Description("Classe css de la grille.")]
        public override string CssClass
        {
            get { return Grille.CssClass; }
            set { Grille.CssClass = value; }
        }

        /// <summary>
        /// Clef primaire des données liés à la grille. Peux comporter plus d'une clef qui sont séparé par une ','.
        /// </summary>
        [Category("Grille")]
        [Description(
            "Clef primaire des données liés à la grille. Peux comporter plus d'une clef qui sont séparé par une ','.")]
        [TypeConverter(typeof(StringArrayConverter)), DefaultValue((string)null),
         Editor(
             "System.Web.UI.Design.WebControls.DataFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
             , typeof(UITypeEditor))]
        public string[] DataKeyNames
        {
            get { return Grille.DataKeyNames; }
            set
            {
                Grille.DataKeyNames = value;
                _detail.DataKeyNames = value;
            }
        }

        /// <summary>
        /// Définit le style visuel d'une grille sans donnée.
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel d'une grille sans donnée.")]
        public TableItemStyle EmptyDataRowStyle
        {
            get { return Grille.EmptyDataRowStyle; }
        }

        /// <summary>
        /// Définit le gabarit qui sera affiché lorsque la grille ne possède aucune donnée.
        /// </summary>
        [Category("Grille")]
        [Description("Définit le gabarit qui sera affiché lorsque la grille ne possède aucune donnée.")]
        public ITemplate EmptyDataTemplate
        {
            get { return Grille.EmptyDataTemplate; }
            set { Grille.EmptyDataTemplate = value; }
        }

        /// <summary>
        /// Définit le style visuel du pied de page
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel du pied de page")]
        public TableItemStyle FooterStyle
        {
            get { return Grille.FooterStyle; }
        }

        /// <summary>
        /// Définit le style visuel de l'entête des colonnes
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel de l'entête des colonnes")]
        public TableItemStyle HeaderStyle
        {
            get { return Grille.HeaderStyle; }
        }

        /// <summary>
        /// Message qui sera affiché dans le cas qu'aucune donnée.
        /// </summary>
        [Category("Grille")]
        [Description("Message qui sera affiché dans le cas qu'aucune donnée.")]
        public string MessageAucuneDonnee
        {
            get { return ObtenirProprieteViewState("MessageAucuneDonnee", string.Empty); }
            set { AssignerProprieteViewState("MessageAucuneDonnee", value); }
        }

        /// <summary>
        /// Message qui sera affiché pour confirmer la suppression
        /// </summary>
        [Category("Grille")]
        [Description("Message qui sera affiché pour confirmer la suppression")]
        public string MessageConfirmationSuppression { get; set; }

        /// <summary>
        /// Configuration de la section pagination
        /// </summary>
        [Category("Grille")]
        [Description("Configuration de la section pagination")]
        public PagerSettings PagerSettings
        {
            get { return Grille.PagerSettings; }
        }

        /// <summary>
        /// Définit le style visuel de la section pagination
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel de la section pagination")]
        public TableItemStyle PagerStyle
        {
            get { return Grille.PagerStyle; }
        }

        /// <summary>
        /// Nombre d'éléments par page; par défaut: 10
        /// </summary>
        public int PageSize
        {
            get { return ObtenirProprieteViewState("PageSize", 10); }
            set { AssignerProprieteViewState("PageSize", value); }
        }

        /// <summary>
        /// Méthode d'obtention par ID du Presenter à utiliser pour obtenir l'élément sélectionné lors d'un clic sur
        /// Modifier ou Consulter, ou lors d'une sélection par rangée. Cette méthode recevra une entité dont seul
        /// l'identifiant (ou les identifiants) sera renseigné, et devra retourner l'entité complète. La propriété
        /// DataKeyNames devra être renseignée correctement.
        /// </summary>
        public string ObtenirParIdMethode { get; set; }

        /// <summary>
        /// Définit le gabarit qui sera affiché comme section pagination
        /// </summary>
        [Category("Grille")]
        [Description("Définit le gabarit qui sera affiché comme section pagination")]
        public ITemplate PagerTemplate
        {
            get { return Grille.PagerTemplate; }
            set { Grille.PagerTemplate = value; }
        }

        /// <summary>
        /// Définit le style visuel d'une ligne
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel d'une ligne")]
        public TableItemStyle RowStyle
        {
            get { return Grille.RowStyle; }
        }

        /// <summary>
        /// Définit le style visuel d'une ligne sélectionné
        /// </summary>
        [Category("Grille")]
        [Description("Définit le style visuel d'une ligne sélectionné")]
        public TableItemStyle SelectedRowStyle
        {
            get { return Grille.SelectedRowStyle; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ToolTipBoutonSupprimer
        {
            get { return ObtenirProprieteViewState("ToolTipBoutonSupprimer", string.Empty); }
            set { AssignerProprieteViewState("ToolTipBoutonSupprimer", value); }
        }

        /// <summary>
        /// Collection de rows qui composent la grille.
        /// </summary>
        /// <value>Les rows</value>
        public GridViewRowCollection Rows
        {
            get { return Grille.Rows; }
        }

        public bool AfficherNombreResultats
        {
            get { return ObtenirProprieteViewState("AfficherNombreResultats", false); }
            set { AssignerProprieteViewState("AfficherNombreResultats", value); }
        }

        internal int NombrePages
        {
            get { return _grille.PageCount; }
        }

        #endregion

        #region [ Propriété du DataSource ]

        internal int NombreResultats
        {
            get { return ObtenirProprieteViewState("NombreResultats", 0); }
            set { AssignerProprieteViewState("NombreResultats", value); }
        }

        /// <summary>
        /// Obtient l'objet datasource.
        /// </summary>
        /// <value>L'objet datasource.</value>
        protected ObjectDataSource ObjectDatasource
        {
            get
            {
                EnsureChildControls();
                return _objectDataSource;
            }
        }

        /// <summary>
        /// Obtient le formulaire de l'objet datasource.
        /// </summary>
        /// <value>Le formulaire de l'objet datasource.</value>
        protected ObjectDataSource ObjectDatasourceForm
        {
            get
            {
                EnsureChildControls();
                return _objectDataSourceDetail;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CacheDuration
        {
            get { return ObjectDatasource.CacheDuration; }
            set
            {
                ObjectDatasourceForm.CacheDuration = value;
                ObjectDatasource.CacheDuration = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataSourceCacheExpiry CacheExpirationPolicy
        {
            get { return ObjectDatasource.CacheExpirationPolicy; }
            set
            {
                ObjectDatasourceForm.CacheExpirationPolicy = value;
                ObjectDatasource.CacheExpirationPolicy = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CacheKeyDependency
        {
            get { return ObjectDatasource.CacheKeyDependency; }
            set
            {
                ObjectDatasourceForm.CacheKeyDependency = value;
                ObjectDatasource.CacheKeyDependency = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ConflictOptions ConflictDetection
        {
            get { return ObjectDatasource.ConflictDetection; }
            set
            {
                ObjectDatasourceForm.ConflictDetection = value;
                ObjectDatasource.ConflictDetection = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ConvertNullToDbNull
        {
            get { return ObjectDatasource.ConvertNullToDBNull; }
            set
            {
                ObjectDatasourceForm.ConvertNullToDBNull = value;
                ObjectDatasource.ConvertNullToDBNull = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DataObjectTypeName
        {
            get { return ObjectDatasource.DataObjectTypeName; }
            set
            {
                ObjectDatasourceForm.DataObjectTypeName = value;
                ObjectDatasource.DataObjectTypeName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Editor(
            "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        public ParameterCollection DeleteParameters
        {
            get { return ObjectDatasource.DeleteParameters; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DeleteMethod
        {
            get { return ObjectDatasource.DeleteMethod; }
            set
            {
                ObjectDatasourceForm.DeleteMethod = value;
                ObjectDatasource.DeleteMethod = value;
            }
        }

        /// <summary>
        /// Propriété qui indique si les méthodes mentionnés dans SelectMethod 
        /// et SelectCountMethod seront exécutés automatiquement. Place cette 
        /// propriété à false, si par exemple, vous avez besoin de saisir des 
        /// critère avant d'exécuter la liaison des données à la grille.
        /// </summary>
        [Category("Datasource"), DefaultValue(true)]
        public bool EstAutomatiquementLie
        {
            get { return ObtenirProprieteViewState("EstAutomatiquementLie", true); }
            set { AssignerProprieteViewState("EstAutomatiquementLie", value); }
        }

        /// <summary>
        /// Mettre à True pour assurer que la grille n'est pas générée à partir du Viewstate.
        /// </summary>
        [Category("Datasource"), DefaultValue(false)]
        public bool ToujoursRafraichir
        {
            get { return ObtenirProprieteViewState("ToujoursRafraichir", false); }
            set { AssignerProprieteViewState("ToujoursRafraichir", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EnableCaching
        {
            get { return ObjectDatasource.EnableCaching; }
            set
            {
                ObjectDatasourceForm.EnableCaching = value;
                ObjectDatasource.EnableCaching = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FilterExpression
        {
            get { return ObjectDatasource.FilterExpression; }
            set
            {
                ObjectDatasourceForm.FilterExpression = value;
                ObjectDatasource.FilterExpression = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Editor(
            "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        public ParameterCollection FilterParameters
        {
            get { return ObjectDatasource.FilterParameters; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string InsertMethod
        {
            get { return ObjectDatasource.InsertMethod; }
            set
            {
                ObjectDatasourceForm.InsertMethod = value;
                ObjectDatasource.InsertMethod = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Editor(
            "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        public ParameterCollection InsertParameters
        {
            get { return ObjectDatasource.InsertParameters; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MaximumRowsParameterName
        {
            get { return ObjectDatasource.MaximumRowsParameterName; }
            set { ObjectDatasource.MaximumRowsParameterName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OldValuesParameterFormatString
        {
            get { return ObjectDatasource.OldValuesParameterFormatString; }
            set { ObjectDatasource.OldValuesParameterFormatString = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SelectCountMethod
        {
            get { return ObjectDatasource.SelectCountMethod; }
            set { ObjectDatasource.SelectCountMethod = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SelectMethod
        {
            get { return ObjectDatasource.SelectMethod; }
            set
            {
                ObjectDatasourceForm.SelectMethod = value;
                ObjectDatasource.SelectMethod = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Editor(
            "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        public ParameterCollection SelectParameters
        {
            get { return ObjectDatasource.SelectParameters; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SortParameterName
        {
            get { return ObjectDatasource.SortParameterName; }
            set { ObjectDatasource.SortParameterName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SqlCacheDependency
        {
            get { return ObjectDatasource.SqlCacheDependency; }
            set
            {
                ObjectDatasourceForm.SqlCacheDependency = value;
                ObjectDatasource.SqlCacheDependency = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StartRowIndexParameterName
        {
            get { return ObjectDatasource.StartRowIndexParameterName; }
            set { ObjectDatasource.StartRowIndexParameterName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            get { return ObjectDatasource.TypeName; }
            set
            {
                ObjectDatasourceForm.TypeName = value;
                ObjectDatasource.TypeName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateMethod
        {
            get { return ObjectDatasource.UpdateMethod; }
            set
            {
                ObjectDatasourceForm.UpdateMethod = value;
                ObjectDatasource.UpdateMethod = value;
            }
        }

        /// <summary>
        /// Index de la rangée sélectionnée. Peut aussi être utilisé pour sélectionner une rangée.
        /// </summary>
        public int SelectedIndex
        {
            get { return _grille.SelectedIndex; }
            set { _grille.SelectedIndex = value; }
        }

        /// <summary>
        /// Rangée sélectionnée
        /// </summary>
        public GridViewRow SelectedRow
        {
            get { return _grille.SelectedRow; }
        }

        /// <summary>
        /// Optionnel - Si on veut un comportement différent pour un clic sur la rangée.
        /// </summary>
        [Obsolete("Utiliser ConsulterMethode ou ModifierMethode, car le clic sur la rangée doit avoir le même comportement qu'un clic sur un de ces boutons (normes).")]
        public string SelectionnerRangeeMethode { get; set; }

        /// <summary>
        /// Méthode appelée lors d'un clic sur un bouton Consulter, ou (grille maître) lors d'un clic sur une rangée
        /// contenant un bouton Consulter.
        /// </summary>
        public string ConsulterMethode { get; set; }

        /// <summary>
        /// Méthode appelée lors d'un clic sur un bouton Modifier, ou (grille maître) lors d'un clic sur une rangée
        /// contenant un bouton Modifier.
        /// </summary>
        public string ModifierMethode { get; set; }

        /// <summary>
        /// Méthode appelée lors d'un clic sur le bouton Ajouter.
        /// </summary>
        public string AjouterMethode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Editor(
            "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        public ParameterCollection UpdateParameters
        {
            get { return ObjectDatasource.UpdateParameters; }
        }

        #endregion

        #region [ Propriété de la fenêtre d'édition ]

        /// <summary>
        /// Obtient ou affecte une valeur de/à l'entité sélectionnée.
        /// </summary>
        /// <value>L'entité sélectionnée.</value>

        protected List<object> EntiteSelectionneEtPersistes
        {
            get { return _entiteSelectionneEtPersistes ?? (_entiteSelectionneEtPersistes = new List<object>()); }
            set { _entiteSelectionneEtPersistes = value; }
        }

        /// <summary>
        /// Permet d'afficher ou non un bouton d'ajout ouvrant une fenêtre d'ajout.
        /// </summary>
        public bool ActiverBoutonAjout
        {
            get
            {
                bool? activer = ObtenirProprieteViewState<bool?>("ActiverBoutonAjout", null);
                return activer.GetValueOrDefault(false);
            }
            set
            {
                bool? activer = ObtenirProprieteViewState<bool?>("ActiverBoutonAjout", null);
                AssignerProprieteViewState<bool?>("ActiverBoutonAjout", value);
                if (activer != null && activer != value && EstAutomatiquementLie)
                {
                    RafraichirGrille();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string ToolTipBoutonConsulter
        {
            get { return ObtenirProprieteViewState("ToolTipBoutonConsulter", string.Empty); }
            set { AssignerProprieteViewState("ToolTipBoutonConsulter", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ToolTipBoutonAjout
        {
            get { return ObtenirProprieteViewState("ToolTipBoutonAjout", string.Empty); }
            set { AssignerProprieteViewState("ToolTipBoutonAjout", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ToolTipBoutonEdition
        {
            get { return ObtenirProprieteViewState("ToolTipBoutonEdition", string.Empty); }
            set { AssignerProprieteViewState("ToolTipBoutonEdition", value); }
        }

        #endregion

        #endregion

        #region Méthodes publiques
        // ====================================================================


        /// <summary>
        /// Si EstMaitreDetail = True, permet d'effacer la ligne sélectionnée.
        /// Par défaut, déclenche la méthode ConsulterMethode en lui envoyant la valeur null.
        /// </summary>
        public void EffacerSelection(bool appelerMethodeSelectionner = true)
        {
            AnnulerSurlignageSelection();
            if (ValeurSelectionnee == null && _grille.SelectedIndex == -1) return;

            ValeurSelectionnee = null;
            _grille.SelectedIndex = -1;
            if (appelerMethodeSelectionner)
                AppelerMethodeSelectionner();
        }

        private object ValeurSelectionnee
        {
            get { return ObtenirProprieteViewState("ValeurSelectionnee", (object)null); }
            set { AssignerProprieteViewState("ValeurSelectionnee", value); }
        }

        /// <summary>
        /// Permet de sélectionner (surligner) une rangée visible dans la grille.
        /// La sélection se fait en fonction de la clé et doit être du même type que la clé inscrite dans DataKeyNames.
        /// Ne fonctionne que s'il y a une seule clé.
        /// </summary>
        public void SelectionnerValeur(object valeur)
        {
            ValeurSelectionnee = valeur;
            SelectionnerValeur();
        }

        private void SelectionnerValeur()
        {
            if (ValeurSelectionnee == null) return;

            object valeurActuelle = ObtenirValeurActuellementSelectionnee();
            if (ValeurSelectionnee.Equals(valeurActuelle)) return;

            SelectionnerValeurSurPageCourante(ValeurSelectionnee);
        }

        private void SelectionnerValeurSurPageCourante(object valeur)
        {
            for (int i = DataKeys.Count - 1; i >= 0; i--)
            {
                object identifiant = DataKeys[i].Value;
                if (identifiant.Equals(valeur))
                {
                    _grille.SelectedIndex = i;
                    SurlignerRangeeSelectionnee();
                    break;
                }
            }
        }

        public GridViewRow ObtenirSelection()
        {
            return Grille.Rows[Detail.PageIndex];
        }

        /// <summary>
        /// Obtiens l'objet de donnée qui est lié à la ligne sélectionné. 
        /// Celui-ci est récupéré lorsqu'une commande consulter est géré 
        /// sans que la propriété ConsulterMethode soit renseigné.
        /// </summary>
        /// <typeparam name="T">
        /// Type de l'objet de donnée.
        /// </typeparam>
        /// <returns>
        /// Objet de donnée lié.
        /// </returns>
        public T ObtenirSelectionRecherche<T>()
        {
            return EntiteSelectionneEtPersistes.Count > 0 ? (T)EntiteSelectionneEtPersistes[0] : default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        public void Sort(string sortExpression, SortDirection sortDirection)
        {
            _grille.Sort(sortExpression, sortDirection);
        }

        /// <summary>
        /// La méthode qui permet de lier les données à la grille. La propriété
        /// EstAutomatiquementLie sera affecté de la valeur true.
        /// </summary>
        public override void DataBind()
        {
            EstAutomatiquementLie = true;
            _grille.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<T> ObtenirSelections<T>()
        {
            PersisterEntiteSelectionneAvantPaging();
            List<T> retour = new List<T>();

            foreach (object o in EntiteSelectionneEtPersistes)
            {
                retour.Add((T)o);
            }

            return retour;
        }

        /// <summary>
        /// Reinitialisers the selections.
        /// </summary>
        public void ReinitialiserSelections()
        {
            EntiteSelectionneEtPersistes.Clear();
            ReinitialiserChampSelectionPourLaPageCourante();
        }

        /// <summary>
        /// Vide la grille
        /// </summary>
        public void ViderLigneGrille()
        {
            string idDatasource = _grille.DataSourceID;
            bool permiTri = EstPermiTri;
            EstPermiTri = false;
            _grille.DataSource = null;
            _grille.DataBind();
            EstPermiTri = permiTri;
            _grille.DataSourceID = idDatasource;
            EstAutomatiquementLie = false;
        }

        /// <summary>
        /// Cette méthode forcera un DataBind, mais pas immédiatement.
        /// </summary>
        public void RafraichirGrille()
        {
            // Il doit bien exister un meilleur moyen, mais celui-ci fonctionne...
            _grille.ShowHeader = !_grille.ShowHeader;
            _grille.ShowHeader = !_grille.ShowHeader;
        }

        /// <summary>
        /// Rafraichit l'update panel de la grille.
        /// </summary>
        public void RafraichirFenetre()
        {
            if (!_detail.EstAvecAutoComplete)
                _udpDetail.Update();
        }

        /// <summary>
        /// Permet de cacher un bouton pour une rangée.
        /// </summary>
        public void CacherBouton(GridViewRow rangee, EnumBoutonRangee bouton)
        {
            if (!_rowDataBinding)
            {
                const string msg = "La méthode CacherBouton doit être appelée dans l'événement RowDataBound";
                throw new InvalidOperationException(msg);
            }
            switch (bouton)
            {
                case EnumBoutonRangee.Consulter:
                    CacherBouton(rangee, TemplateBouton.NOM_BOUTON_CONSULTER);
                    break;
                case EnumBoutonRangee.Modifier:
                    CacherBouton(rangee, TemplateBouton.NOM_BOUTON_MODIFIER);
                    break;
                case EnumBoutonRangee.Supprimer:
                    CacherBouton(rangee, TemplateBouton.NOM_BOUTON_SUPPRIMER);
                    break;
            }
        }

        private void CacherBouton(GridViewRow rangee, string nomBouton)
        {
            Control btn = rangee.FindControl(nomBouton);
            if (btn != null)
            {
                btn.Visible = false;
            }
        }

        /// <summary>
        /// Permet d'obtenir le premier contrôle héritant de ATMTECHUserControlBase à
        /// l'intérieur de la fenêtre de détail, peu importe le mode d'édition actuel.
        /// Très utile pour obtenir un UserControl de manière standard.
        /// </summary>
        public ATMTECHUserControlBase ObtenirUserControl()
        {
            return ObtenirUserControl(_detail);
        }

        // Fonction récursive pour obtenir le premier User Control

        private ATMTECHUserControlBase ObtenirUserControl(Control parent)
        {
            if (parent.HasControls())
            {
                foreach (Control ctl in parent.Controls)
                {
                    if (ctl is ATMTECHUserControlBase)
                    {
                        return (ATMTECHUserControlBase)ctl;
                    }
                    ATMTECHUserControlBase ctlEnfant = ObtenirUserControl(ctl);
                    if (ctlEnfant != null)
                    {
                        return ctlEnfant;
                    }
                }
            }
            return null;
        }

        private void AnnulerSurlignageSelection()
        {
            ScriptManager scriptMan = ScriptManager.GetCurrent(Page);
            if (scriptMan != null && scriptMan.IsInAsyncPostBack)
            {
                // UpdatePanel
                string js = String.Format("$.ATMTECH.grilleAvance.annulerSurlignage('{0}');", _grille.ClientID);
                string key = Guid.NewGuid().ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), key, js, true);
            }
        }

        private void SurlignerRangeeSelectionnee()
        {
            ScriptManager scriptMan = ScriptManager.GetCurrent(Page);
            if (scriptMan != null && scriptMan.IsInAsyncPostBack)
            {
                // UpdatePanel
                string js = String.Format("$.ATMTECH.grilleAvance.surlignerRangee('{0}', {1});",
                                          _grille.ClientID, _grille.SelectedIndex);
                string key = Guid.NewGuid().ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), key, js, true);
            }
        }

        public IList<IDictionary> ObtenirValeursEditables()
        {
            IList<IDictionary> resultat = new List<IDictionary>();
            foreach (GridViewRow row in _grille.Rows)
            {
                IDictionary valeurs = ObtenirValeursRangee(row);
                AjouterCles(row.RowIndex, valeurs);
                resultat.Add(valeurs);
            }
            return resultat;
        }

        private void AjouterCles(int rowIndex, IDictionary valeurs)
        {
            DataKey dataKey = DataKeys[rowIndex];
            foreach (string nomPropriete in DataKeyNames)
            {
                valeurs[nomPropriete] = dataKey[nomPropriete];
            }
        }

        /// <summary>
        /// Retourne les valeurs de la rangée (champs éditables) sous forme de dictionnaire.
        /// La clé correspond à la propriété "DataField" du champ lié.
        /// </summary>
        public static IDictionary ObtenirValeursRangee(GridViewRow row)
        {
            // http://weblogs.asp.net/davidfowler/archive/2008/12/12/getting-your-data-out-of-the-data-controls.aspx
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
            }
            return values;
        }

        public void EnregistrerEtat()
        {
            Page.Session[_grille.UniqueID] = new EtatGrille(_grille, ValeurSelectionnee);
        }

        public void RetablirEtat()
        {
            EtatGrille etat = (EtatGrille) Page.Session[_grille.UniqueID];
            if (etat == null)
            {
                PageIndex = 0;
            }
            else
            {
                PageIndex = etat.PageIndex;
                if (!string.IsNullOrEmpty(etat.SortExpression))
                {
                    _grille.Sort(etat.SortExpression, etat.SortDirection);
                }
                if (EstMaitreDetail && etat.ValeurSelectionnee != null)
                {
                    SelectionnerValeur(etat.ValeurSelectionnee);
                }
                EffacerEtat();
            }
        }

        public void EffacerEtat()
        {
            Page.Session.Remove(_grille.UniqueID);
        }
        
        public void AssignerTotal(string nomDataField, decimal? total)
        {
            BoundFieldAvance colonne = ObtenirColonneLiee<BoundFieldAvance>(nomDataField);
            colonne.AssignerTotal(total);
        }

        // ====================================================================
        #endregion

        #region Méthodes privées
        // ====================================================================

        private TCol ObtenirColonneLiee<TCol>(string nomDataField) where TCol: BoundField
        {
            foreach (DataControlField col in _grille.Columns)
            {
                if (col is TCol && ((BoundField)col).DataField == nomDataField)
                {
                    return (TCol)col;
                }
            }
            string msg = string.Format("Le champ '{0}' n'a pas été trouvé dans la grille", nomDataField);
            throw new ArgumentException(msg, nomDataField);
        }

        private int CalculerIndexLigneGrille()
        {
            int indexLigneGrille = (_grille.PageIndex * _grille.PageSize);
            return indexLigneGrille < 0 ? 0 : indexLigneGrille;
        }

        /// <summary>
        /// Permet de créer une colonne pour la commande désiré.
        /// Présentement que la modification et la suppression sont 
        /// supporté.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private DataControlField CreerCommandeColonne(TemplateBouton.ModeBouton type)
        {
            TemplateField field = new TemplateField();
            field.ItemStyle.CssClass = "gvCommande";
            field.HeaderTemplate = new TemplateBouton(TemplateBouton.ModeBouton.Ajouter, this, type);

            switch (type)
            {
                case TemplateBouton.ModeBouton.Consulter:
                case TemplateBouton.ModeBouton.Modifier:
                case TemplateBouton.ModeBouton.Supprimer:
                    field.ItemTemplate = new TemplateBouton(type, this);
                    break;
            }
            return field;
        }

        /// <summary>
        /// Ajoutes des tooltips au entête
        /// </summary>
        /// <param name="e">
        /// 
        /// </param>
        private void CreerTooltipEntete(GridViewRowEventArgs e)
        {
            foreach (DataControlFieldHeaderCell entete in e.Row.Cells)
            {
                string tooltip = entete.ContainingField.HeaderText;
                if (!string.IsNullOrEmpty(tooltip))
                {
                    entete.Attributes.Add("title", tooltip);
                }
            }
        }

        /// <summary>
        /// Permet d'obtenir l'index de la colonne qui est présentement
        /// trié par la grille.
        /// </summary>
        /// <returns></returns>
        private int ObtenirIndexColonneTrie()
        {
            foreach (DataControlField column in Grille.Columns)
            {
                if (!string.IsNullOrEmpty(Grille.SortExpression) && column.SortExpression.Equals(Grille.SortExpression)
                    && !string.IsNullOrEmpty(column.HeaderText))
                    return Grille.Columns.IndexOf(column);
            }

            return -1;
        }

        /// <summary>
        /// Méthode qui ajoute une image pour informer la direction et la colonne de tri
        /// </summary>
        /// <param name="e">
        /// GridViewRowEventArgs de l'entête de la grille. 
        /// </param>
        private void IndiquerColonneDeTri(GridViewRowEventArgs e)
        {
            int index = ObtenirIndexColonneTrie();
            Image indicateurDirectionTri = new Image();

            if (index < 0)
                return;

            switch (Grille.SortDirection)
            {
                case SortDirection.Ascending:
                    indicateurDirectionTri.ImageUrl = Page.GetResourceUrl("Grille.asc.gif");
                    indicateurDirectionTri.AlternateText = "Ordre ascendant";
                    break;
                case SortDirection.Descending:
                    indicateurDirectionTri.ImageUrl = Page.GetResourceUrl("Grille.desc.gif");
                    indicateurDirectionTri.AlternateText = "Ordre descendant";
                    break;
                default:
                    return;
            }

            indicateurDirectionTri.Style.Add(HtmlTextWriterStyle.Padding, "2 2 2 2");

            e.Row.Cells[index].Controls.Add(indicateurDirectionTri);
        }

        /// <summary>
        /// Crée les colonnes de boutons (Modifier, Supprimer, Consulter, Ajouter).
        /// Tous les boutons sont ajoutés. Ils seront supprimés au besoin lors du rendu.
        /// </summary>
        private void InitialiserBoutons()
        {
            _grille.EmptyDataTemplate = new TemplateBouton(TemplateBouton.ModeBouton.AjouterSansDonnee, this);
            _grille.Columns.Add(CreerCommandeColonne(TemplateBouton.ModeBouton.Consulter));
            _grille.Columns.Add(CreerCommandeColonne(TemplateBouton.ModeBouton.Modifier));
            _grille.Columns.Add(CreerCommandeColonne(TemplateBouton.ModeBouton.Supprimer));
            _grille.Columns.Add(CreerCommandeColonne(TemplateBouton.ModeBouton.Ajouter));

        }

        /// <summary>
        /// Dissimule les colonnes de boutons non nécessaires lors du rendu,
        /// et replace le bouton Ajouter en fonction des colonnes disponibles.
        /// Voir tâches 4621 et 4373.
        /// </summary>
        private void AjusterColonnesBoutons()
        {
            TemplateField colSelection, colModification, colSuppression, colInsertion;
            ObtenirColonnesBoutons(out colSelection, out colModification, out colSuppression, out colInsertion);

            // On supprime au besoin: Modifier, Consulter, Supprimer, Ajouter
            ModeAffichage modeAff = ObtenirModeAffichage();
            if (modeAff == ModeAffichage.Modification)
            {
                AjusterColonne(EstAfficheColonneConsulter, ref colSelection);
                AjusterColonne(EstAfficheColonneEdition, ref colModification);
                AjusterColonne(EstAfficheColonneSuppression, ref colSuppression);

                // On met la bouton Ajouter sur une colonne contenant d'autres boutons,
                // si possible. Toutes les colonnes contiennent un bouton Ajouter, et
                // il sera caché lors de l'instantiation des boutons (TemplateBouton).
                TemplateField col = colSuppression ?? colModification ?? colSelection;
                AjusterColonne(col == null && ActiverBoutonAjout, ref colInsertion);
            }
            else
            {
                AjusterColonne(false, ref colModification);
                AjusterColonne(false, ref colSuppression);
                AjusterColonne(EstAfficheColonneConsulter, ref colSelection);
                AjusterColonne(false, ref colInsertion);
            }
        }

        private TemplateField ObtenirColonneModification()
        {
            TemplateField colSelection, colModification, colSuppression, colInsertion;
            ObtenirColonnesBoutons(out colSelection, out colModification, out colSuppression, out colInsertion);

            return colModification;
        }

        /// <summary>
        /// Permet d'aller chercher les colonnes de boutons pour l'ajustement
        /// subséquent
        /// </summary>
        private void ObtenirColonnesBoutons(out TemplateField colSelection, out TemplateField colModification, out TemplateField colSuppression, out TemplateField colInsertion)
        {
            colSelection = colModification = colSuppression = colInsertion = null;
            for (int i = _grille.Columns.Count - 1; i >= 0; i--)
            {
                TemplateField col = _grille.Columns[i] as TemplateField;
                if (col != null)
                {
                    TemplateBouton bouton = (col.ItemTemplate ?? col.HeaderTemplate) as TemplateBouton;
                    if (bouton != null)
                    {
                        switch (bouton.Mode)
                        {
                            case TemplateBouton.ModeBouton.Consulter:
                                colSelection = col;
                                break;
                            case TemplateBouton.ModeBouton.Ajouter:
                                colInsertion = col;
                                break;
                            case TemplateBouton.ModeBouton.Modifier:
                                colModification = col;
                                break;
                            case TemplateBouton.ModeBouton.Supprimer:
                                colSuppression = col;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Dissumule une colonne si le premier argument est Faux, et met
        /// la colonne à null. Sinon, s'assure que la colonne soit affichée.
        /// </summary>
        private static void AjusterColonne(bool conserverColonne, ref TemplateField col)
        {
            if (col != null)
            {
                col.Visible = conserverColonne;
                if (!conserverColonne)
                {
                    col = null;
                }
            }
        }

        /// <summary>
        /// Initialise les contrôles enfants de la grille.
        /// </summary>
        private void InitialiserChildControl()
        {
            _objectDataSource.ID = "ods";
            _objectDataSource.EnableViewState = true;

            _objectDataSourceDetail.ID = "FormDataSource";
            _objectDataSourceDetail.EnableViewState = true;

            _grille.EnableViewState = true;
            _grille.ID = "gridview";
            _grille.DataSourceID = _objectDataSource.ID;
            _grille.AutoGenerateColumns = false;

            _grille.RowStyle.CssClass = "gvRangee";
            _grille.AlternatingRowStyle.CssClass = "gvRangee gvAlternate";
            _grille.SelectedRowStyle.CssClass = "gvRangee gvSelection";
            _grille.HeaderStyle.CssClass = "gvHeader";
            _grille.FooterStyle.CssClass = "gvFooter";
            _grille.GridLines = GridLines.None;
            _grille.PagerStyle.CssClass = "gvPager";
            _grille.EmptyDataRowStyle.CssClass = "gvVide";
            _grille.PagerTemplate = new TemplatePager(this);

            if (EstMaitreDetail)
            {
                _grille.EnablePersistedSelection = true;
            }

            if (!_detail.EstAvecAutoComplete)
            {
                _udpDetail.ID = "udp";
                _udpDetail.UpdateMode = UpdatePanelUpdateMode.Conditional;
            }

            _fenetreEdition.ID = "dialog";

            //Transfert des propriétés saisies par le détail pour la 
            //fenêtre de dialogue.
            _fenetreEdition.EstDeplacable = _detail.EstDeplacable;
            _fenetreEdition.EstRedimentionnable = _detail.EstRedimentionnable;
            _fenetreEdition.Titre = _detail.TitreInsertion;
            _fenetreEdition.EstAvecAutoComplete = _detail.EstAvecAutoComplete;

            if (!string.IsNullOrEmpty(_detail.Largeur))
            {
                _fenetreEdition.Largeur = _detail.Largeur;
                _detail.Width = Unit.Percentage(100);
            }

            if (!string.IsNullOrEmpty(_detail.Hauteur))
            {
                _fenetreEdition.Hauteur = _detail.Hauteur;
            }
            _fenetreEdition.EstModal = true;

            InitialiserBoutons();

            _detail.ID = "detail";
            _detail.DataSourceID = _objectDataSourceDetail.ID;
        }

        /// <summary>
        /// Synchronise les collections de paramètres de l'objectDatasource du détail.
        /// </summary>
        /// <param name="aSynchroniser">Collection de paramètre à synchroniser</param>
        /// <param name="source">Collection de paramètre source</param>
        private void SynchroniserParametresDataSource(ParameterCollection aSynchroniser, ParameterCollection source)
        {
            //Vider la collection cible.
            aSynchroniser.Clear();

            for (int i = 0; i < source.Count; i++)
            {
                aSynchroniser.Add(source[i]);
            }
        }

        private void CorroborerArgumentDataSource(ObjectDataSourceSelectingEventArgs e)
        {
            //Vérifier si l'argument MaximumRow est présent dans le datasource de la grille
            if (!string.IsNullOrEmpty(ObjectDatasource.MaximumRowsParameterName))
            {
                //Ajouter le paramètre MaximumRow avec comme valeur le nombre d'élément
                //afficher de la grille.
                e.Arguments.MaximumRows = _grille.PageSize;
            }
            //Vérifier si l'argument index de départ est présent dans le datasource de la grille
            if (!string.IsNullOrEmpty(ObjectDatasource.StartRowIndexParameterName))
            {
                e.Arguments.StartRowIndex = CalculerIndexLigneGrille();
            }
            //Vérifier si l'argument de tri est présent dans le datasource de la grille
            if (!string.IsNullOrEmpty(ObjectDatasource.SortParameterName))
            {
                e.Arguments.SortExpression = _grille.SortExpression;
                if (_grille.SortDirection == SortDirection.Descending)
                {
                    e.Arguments.SortExpression += " DESC";
                }
            }
        }

        private void RenseignerCommandArgument(GridViewRow row)
        {
            IButtonControl btn;
            if (ObtenirModeAffichage() == ModeAffichage.Modification)
            {
                if (EstAfficheColonneEdition)
                {
                    btn = (IButtonControl)row.FindControl(TemplateBouton.NOM_BOUTON_MODIFIER);
                    btn.CommandArgument = row.RowIndex.ToString();
                }
                if (EstAfficheColonneSuppression)
                {
                    btn = (IButtonControl)row.FindControl(TemplateBouton.NOM_BOUTON_SUPPRIMER);
                    btn.CommandArgument = row.RowIndex.ToString();
                }
            }
            if (EstAfficheColonneConsulter || !String.IsNullOrEmpty(ConsulterMethode))
            {
                btn = (IButtonControl)row.FindControl(TemplateBouton.NOM_BOUTON_CONSULTER);
                if (btn != null)
                {
                    btn.CommandArgument = row.RowIndex.ToString();
                }
            }
        }

        // ====================================================================
        #endregion

        #region [ Override method ]
        // ====================================================================

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Add(_objectDataSource);
            Controls.Add(_objectDataSourceDetail);
            Controls.Add(_grille);
            _udpDetail.ContentTemplateContainer.Controls.Add(_detail);
            _fenetreEdition.Controls.Add(_udpDetail);

            Controls.Add(_fenetreEdition);
        }

        private bool _estInitialise;

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (_detail.EstAvecAutoComplete)
            {
                _fenetreEdition.Controls.Remove(_udpDetail);
                _fenetreEdition.Controls.Add(_detail);
            }
            _annulerModif = false;
            Page.RegisterRequiresControlState(this);

            _estInitialise = true;
            InitialiserChildControl();

            AttacherEvenements();
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Load"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (ObjectDatasource.SelectParameters.Count > 0)
            {
                SynchroniserParametresDataSource(
                    ObjectDatasourceForm.SelectParameters,
                    ObjectDatasource.SelectParameters);
            }

            if (ObjectDatasource.UpdateParameters.Count > 0)
            {
                SynchroniserParametresDataSource(
                    ObjectDatasourceForm.UpdateParameters,
                    ObjectDatasource.UpdateParameters);
            }

            if (ObjectDatasource.DeleteParameters.Count > 0)
            {
                SynchroniserParametresDataSource(
                    ObjectDatasourceForm.DeleteParameters,
                    ObjectDatasource.DeleteParameters);
            }

            if (ObjectDatasource.InsertParameters.Count > 0)
            {
                SynchroniserParametresDataSource(
                    ObjectDatasourceForm.InsertParameters,
                    ObjectDatasource.InsertParameters);
            }
            if (ToujoursRafraichir)
            {
                RafraichirGrille();
            }
        }

        /// <summary>
        /// Restaure des informations sur l'état du contrôle à partir d'une demande de page antérieure enregistrée par la méthode <see cref="M:System.Web.UI.Control.SaveControlState"/>.
        /// </summary>
        /// <param name="savedState"><see cref="T:System.Object"/> représentant l'état du contrôle à restaurer.</param>
        protected override void LoadControlState(object savedState)
        {
            if (VerifierPresenceChampSelection() && savedState != null)
            {
                EntiteSelectionneEtPersistes = savedState as List<object>;
            }

        }

        /// <summary>
        /// Enregistre les modifications éventuellement apportées à l'état du contrôle serveur depuis la publication de la page sur le serveur.
        /// </summary>
        /// <returns>
        /// Retourne l'état actuel du contrôle serveur. Si aucun état n'est associé au contrôle, cette méthode retourne null.
        /// </returns>
        protected override object SaveControlState()
        {
            return VerifierPresenceChampSelection() ? EntiteSelectionneEtPersistes : null;
        }


        #region [ Méthode de rendu ]

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            string css = Regex.Replace(_grille.CssClass ?? string.Empty, @"\b(?:gridView|grilleAvance|maitreDetail)\b ?", "").Trim();
            css += " gridView grilleAvance";
            if (EstMaitreDetail)
            {
                css += " maitreDetail";
            }
            else if (EstRangeeCliquable)
            {
                css += " rangeeCliquable";
            }
            _fenetreEdition.Visible = EstFenetreDialogue && !EstLectureSeule();

            _grille.CssClass = css.TrimStart();
            base.OnPreRender(e);
            AjusterColonnesBoutons();

            _grille.PageSize = PageSize;
            Page.InclureRessourceJavascript("Grille.GrilleAvance.js");
        }

        /// <summary>
        /// Écrit le contenu <see cref="T:System.Web.UI.WebControls.CompositeControl"/> dans l'objet <see cref="T:System.Web.UI.HtmlTextWriter"/> spécifié pour qu'il s'affiche sur le client.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (EstMaitreDetail)
            {
                PreparerClicRangee();
            }
            _objectDataSource.RenderControl(writer);
            _fenetreEdition.RenderControl(writer);
            _grille.RenderControl(writer);
        }

        #endregion

        // ====================================================================
        #endregion

        internal static string ObtenirBlocCss()
        {
            StringBuilder css = new StringBuilder();
            //Image entête...
            css.AppendLine(".grilleAvance th { background: url(@@Grille.gridViewHeader.png@@) repeat-x top; }");
            //Image Pager
            css.AppendLine(".grilleAvance tr.gvPager { background: #D0D5D9 url(@@Grille.gridViewPager.png@@) repeat-x top; }");

            return css.ToString();
        }

        private void AppelerMethodeSelectionner()
        {
            string methode = ConsulterMethode;
            object entite = null;
            if (_grille.SelectedIndex >= 0)
            {
                ValeurSelectionnee = _grille.SelectedValue;
                entite = RecupererEntiteLigneSelectionnee(_grille.SelectedIndex);

                TemplateField colModification = ObtenirColonneModification();
                if (colModification != null && colModification.Visible)
                {
                    if (!EstMaitreDetailLegacy)
                    {
                        Control boutonModifier = _grille.SelectedRow.FindControl(TemplateBouton.NOM_BOUTON_MODIFIER);
                        if (boutonModifier != null && boutonModifier.Visible)
                        {
                            methode = ModifierMethode;
                        }
                    }
                }
            }
            AppelerMethode(methode, true, entite);
        }

        private void AppelerMethodeAjouter()
        {
            AppelerMethode(AjouterMethode, false, null);
        }

        private void AppelerMethodePourEntite(string nomMethode, int rowIndex)
        {
            object entite = RecupererEntiteLigneSelectionnee(rowIndex);
            AppelerMethode(nomMethode, true, entite);
            if (EstMaitreDetail)
            {
                _grille.SelectedIndex = rowIndex;
                ValeurSelectionnee = _grille.SelectedValue;
            }
        }

        // Méthode générique utilisée par les autres
        private object AppelerMethode(string nomMethode, bool recoitEntite, object entite)
        {
            if (!String.IsNullOrEmpty(nomMethode))
            {
                object instance = Parent.ObtenirPresenter();

                if (instance != null)
                {
                    object[] args = recoitEntite ? new[] { entite } : null;

                    Type instanceType = instance.GetType();
                    if (instanceType.FullName != _objectDataSource.TypeName)
                    {
                        string msg =
                            String.Format(
                                "Le type spécifié par TypeName ({0}) est différent du type de Presenter de la vue ({1}).",
                                _objectDataSource.TypeName, instanceType.FullName);
                        throw new TypeLoadException(msg);
                    }
                    Type[] types = new Type[0];
                    MethodInfo method = instanceType.GetMethod(nomMethode,
                                                               BindingFlags.InvokeMethod | BindingFlags.Instance |
                                                               BindingFlags.Public, null,
                                                               recoitEntite ? new[] { ObtenirTypeEntite() } : types, null);
                    if (method == null)
                    {
                        string msg =
                            String.Format(
                                "La signature '{0}({1})' n'a pas été trouvée dans l'instance de la classe '{2}'.",
                                nomMethode,
                                recoitEntite ? _objectDataSource.DataObjectTypeName : "",
                                instanceType.FullName);
                        throw new MemberAccessException(msg);
                    }
                    return method.Invoke(instance, args);
                }
            }
            return null;
        }

        private IList<int> RecupererIndexLignesSelectionnesPageCourante()
        {
            IList<int> liste = new List<int>();

            //Si la colonne de sélection n'est pas présente à la première colonne,
            // ben rien va ce faire.
            if (VerifierPresenceChampSelection())
            {
                foreach (GridViewRow ligne in _grille.Rows)
                {
                    if (VerifierSiLigneSelectionne(ligne))
                    {
                        liste.Add(ligne.RowIndex);
                    }
                }
            }

            return liste;
        }

        /// <summary>
        /// Méthode permettant de persister les entités avant un changement de pagination.
        /// </summary>
        protected void PersisterEntiteSelectionneAvantPaging()
        {
            //Enlever les données déselectionnées de liste persistée
            MettreAjourSelectionPersisteeAvantPaging();


            IList<object> entiteSelectionnes = RecupererDonneesLignesSelectionnes();

            if (entiteSelectionnes.Count <= 0)
                return;

            //Si on n'est pas en multi-selection, on doit persister qu'une seul sélection
            if (!VerifierMultiSelection())
            {
                EntiteSelectionneEtPersistes.Clear(); //vide la collection.
                EntiteSelectionneEtPersistes.Add(entiteSelectionnes[0]);
            }
            else
            {
                foreach (object entite in entiteSelectionnes)
                {
                    if (!EntiteSelectionneEtPersistes.Contains(entite))
                    {
                        EntiteSelectionneEtPersistes.Add(entite);
                    }
                }
            }
        }

        private void MettreAjourSelectionPersisteeAvantPaging()
        {
            IList<int> index = RecupererIndexLignesNonSelectionneesPageCourante();

            //Si aucune ligne est sélectionné.
            if (index == null || index.Count == 0)
                return;

            _aRecupereParametre = true;
            //Obtenir les données liés à la grille.
            IEnumerable data = ObjectDatasource.Select();

            _aRecupereParametre = false;

            if (data == null)
                return;

            int cpt = 0;

            IEnumerator data2 = data.GetEnumerator();

            while (data2.MoveNext())
            {
                if (index.Contains(cpt) &&
                    (EntiteSelectionneEtPersistes.Contains(data2.Current)))
                {
                    EntiteSelectionneEtPersistes.Remove(data2.Current);
                }

                cpt++;
            }

        }

        private IList<int> RecupererIndexLignesNonSelectionneesPageCourante()
        {
            IList<int> liste = new List<int>();

            //Si la colonne de sélection n'est pas présente à la première colonne,
            // ben rien va ce faire.
            if (VerifierPresenceChampSelection())
            {
                foreach (GridViewRow ligne in _grille.Rows)
                {
                    if (!VerifierSiLigneSelectionne(ligne))
                    {
                        liste.Add(ligne.RowIndex);
                    }
                }
            }

            return liste;
        }

        private bool VerifierMultiSelection()
        {
            if (VerifierPresenceChampSelection())
            {
                ChampSelection champSelection = _grille.Columns[0] as ChampSelection;
                if (champSelection != null) return champSelection.EstMultiSelection;
            }
            return false;
        }

        private bool VerifierPresenceChampSelection()
        {
            return Columns.Count > 0 && Columns[0].GetType() == typeof(ChampSelection);
        }


        private IList<object> RecupererDonneesLignesSelectionnes()
        {
            return RecupererDonneesLignesSelectionnes(RecupererIndexLignesSelectionnesPageCourante());
        }

        private object RecupererEntiteLigneSelectionnee(int index)
        {
            return string.IsNullOrEmpty(ObtenirParIdMethode)
                       ? RecupererDonneesLignesSelectionnes(new List<int> { index }).FirstOrDefault()
                       : ObtenirEntiteParId(index);
        }

        private object ObtenirEntiteParId(int index)
        {
            if (DataKeyNames == null || DataKeyNames.Length == 0)
            {
                throw new BaseException(
                    "GrilleAvance: La propriété DataKeyNames doit être renseignée correctement pour utiliser ObtenirParIdMethode");
            }
            object critere = CreerCritereId(index);
            return ObtenirEntiteParIdParMethodePresenter(critere);
        }

        // Crée une entité pouvant servir de critère pour obtention par ID. Les propriétés indiquées par la propriété
        // DataKeyNames seront remplies avec les valeurs dans le ViewState.
        private object CreerCritereId(int index)
        {
            object entite = Activator.CreateInstance(ObtenirTypeEntite(), true);
            DataKey dataKey = DataKeys[index];
            foreach (string nomPropriete in DataKeyNames)
            {
                object valeur = dataKey[nomPropriete];
                PropertyInfo propriete = entite.GetType().GetProperty(
                    nomPropriete,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                MethodInfo setter = propriete.GetSetMethod(true);
                setter.Invoke(entite, new[] { valeur });
            }
            return entite;
        }

        private object ObtenirEntiteParIdParMethodePresenter(object critere)
        {
            return AppelerMethode(ObtenirParIdMethode, true, critere);
        }

        private IList<object> RecupererDonneesLignesSelectionnes(ICollection<int> index)
        {
            IList<object> resultat = new List<object>();

            //Si aucune ligne est sélectionné.
            if (index == null || index.Count == 0)
                return resultat;

            _aRecupereParametre = true;
            //Obtenir les données liés à la grille.
            IEnumerable data = ObjectDatasource.Select();

            _aRecupereParametre = false;

            if (data == null)
                return resultat;

            int cpt = 0;

            IEnumerator data2 = data.GetEnumerator();

            while (data2.MoveNext())
            {
                if (index.Contains(cpt))
                {
                    resultat.Add(data2.Current);
                }

                cpt++;
            }

            return resultat;
        }

        private bool VerifierSiLigneSelectionne(Control sender)
        {
            GridViewRow ligne = sender as GridViewRow;

            if (ligne == null)
                return false;

            CheckBox chkSelection =
                ligne.Cells[0].Controls[0] as CheckBox;

            return chkSelection != null && chkSelection.Checked;
        }

        /// <summary>
        /// Méthode permettant de cocher une sélection.
        /// </summary>
        /// <param name="ligne">La ligne sélectionnée.</param>
        protected void CocherChampSelection(GridViewRow ligne)
        {

            //Si la propriété existe dans l'entité lié à la ligne, 
            //on vérifie si on doit sélectionner la ligne
            CheckBox chkSelection =
                ligne.Cells[0].Controls[0] as CheckBox;

            if (chkSelection != null && EntiteSelectionneEtPersistes.Contains(ligne.DataItem))
            {
                chkSelection.Checked = true;
            }
        }


        private void ReinitialiserChampSelectionPourLaPageCourante()
        {
            if (!VerifierPresenceChampSelection())
                throw new BaseException("Aucune colonne ChampSelection est présente dans la grille");

            foreach (GridViewRow row in _grille.Rows)
            {
                CheckBox chkSelection = (CheckBox)row.Cells[0].Controls[0];
                chkSelection.Checked = false;
            }
        }

        // Assigne une propriété en vérifiant que le contrôle n'est pas complètement initialisé.
        // Dans ce cas, lance une exception.
        private void AssignerProprieteInit<T>(string nomPropriete, ref T varPropriete, T value)
        {
            if (_estInitialise)
            {
                string msg =
                    String.Format("La propriété {0} ne peut être renseignée après l'initialisation de la grille.",
                                  nomPropriete);
                throw new ArgumentException(msg);
            }
            varPropriete = value;
        }

        private Type ObtenirTypeEntite()
        {
            string nomType = ObjectDatasource.DataObjectTypeName;
            Type t = Type.GetType(nomType);
            if (t != null)
            {
                // Nom qualifié, pas besoin de fouiller dans les assemblies
                return t;
            }

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                t = asm.GetType(nomType, false);
                if (t != null)
                    return t;
            }

            string msg = string.Format("Nom de type (DataObjectTypeName) non trouvé: '{0}'", nomType);
            throw new TypeLoadException(msg);
        }

        private void PreparerClicRangee()
        {
            if (!EstAfficheColonneConsulter && (EstMaitreDetailLegacy || !EstAfficheColonneEdition))
            {
                // On "enregistre" les événements, sinon ça va planter si
                // enableEventValidation = true pour la page
                foreach (GridViewRow row in _grille.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        Control boutonConsulter = row.FindControl(TemplateBouton.NOM_BOUTON_CONSULTER);
                        if (boutonConsulter != null)
                        {
                            Page.ClientScript.RegisterForEventValidation(boutonConsulter.UniqueID);
                        }
                    }
                }
            }
        }
    }
}
