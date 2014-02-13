using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxEditors.Design;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Interfaces;
using ATMTECH.Entities;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle à toujours utiliser au lieu du asp:DropDownList standard.
    /// 
    /// Ce contrôle permet le chargement et filtrage dynamique des données
    /// lorsque EstObligatoire="true".
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <table>
    /// <tr>
    ///    <ATMTECH:ComboBoxAvance runat="server" Libelle="Regulier:" EstAutoComplet="false" DataTextField="item" DataValueField="id" />
    ///
    /// <tr>
    ///    <ATMTECH:ComboBoxAvance runat="server" Libelle="Auto Complet:" EstAutoComplet="true" DataTextField="item" DataValueType="System.Int32" DataValueField="id" OnObtenirItems="OnObtenirItems" OnObtenirItemParValeur="OnObtenirItemParValeur" />
    /// </tr>
    /// </table>
    /// ]]></code>
    /// </summary>
    [Serializable]
    public class ComboBoxAvance : ControleBase, IControleAvecLibelle
    {
        #region Ctor

        /// <summary>
        /// Constructeur sans paramètre
        /// </summary>
        public ComboBoxAvance()
        {
            _devExpressComboBox = new ASPxComboBox();
            _dropDownList = new DropDownList();
            _updatePanel = new UpdatePanel();
            Enabled = true;
        }

        #endregion

        #region Membres privés

        private class SelectionForcee
        {
            private SelectionForcee(object value, string text, bool? marquerInactive)
            {
                Value = value;
                Text = text;
                MarquerInactive = marquerInactive;
            }

            public SelectionForcee(ListItem item, bool? marquerInactive)
                : this(item.Value, item.Text, marquerInactive)
            {
            }

            public SelectionForcee(ListEditItem item, bool? marquerInactive)
                : this(item.Value, item.Text, marquerInactive)
            {
            }

            public object Value { get; private set; }
            public string Text { get; private set; }
            public bool? MarquerInactive { get; private set; }
        }

        private bool _supprimerLigneVide;

        private SelectionForcee _selectionForcee;
        private object _ancienneValeurSelectionForcee;
        private object _nouvelleValeurSelectionForcee;

        private bool _estLigneVide;
        private readonly ASPxComboBox _devExpressComboBox;
        private readonly DropDownList _dropDownList;
        private readonly UpdatePanel _updatePanel;
        private CompareValidator _compareValidator;

        #endregion

        #region Propriétés

        protected object DerniereValeurAutoComplet { get; set; }

        /// <summary>
        /// Indique si le combo box est en mode chargement dynamique 
        /// </summary>
        [Category("Behavior")]
        [Description("Indique si le combo box est en mode chargement dynamique et auto-completition.")]
        public bool EstAutoComplet { get; set; }

        /// <summary>
        /// Indique si le combobox est dans un updatePanel
        /// </summary>
        [Category("Behavior")]
        [Description("Indique si le combobox est entouré d'un update panel.")]
        public bool EstUpdatePanel { get; set; }

        /// <summary>
        /// Indique si le combobox a une ligne vide.
        /// </summary>
        [Category("Behavior")]
        [Description("Indique si le combobox a une ligne vide.")]
        public bool EstLigneVide
        {
            get { return _estLigneVide; }
            set
            {
                if (value)
                    AjouterLigneVide();

                _estLigneVide = value;
            }
        }

        public bool EstLigneVideSupprimeeApresSelection { get; set; }

        /// <summary>
        /// Si le combo box (non autocomplet) ne contient qu'une valeur, sélectionne
        /// cette valeur et supprime la ligne vide au besoin.
        /// </summary>
        [Category("Behavior")]
        public bool EstSelectionAutomatique { get; set; }

        /// <summary>
        /// Retourne vrai si rien n'est sélectionné
        /// </summary>
        public bool EstValeurNull
        {
            get
            {
                bool estValeurNull;
                if (EstAutoComplet)
                {
                    estValeurNull = _devExpressComboBox.SelectedIndex == -1 || string.IsNullOrEmpty(SelectedValue);
                }
                else
                {
                    estValeurNull = string.IsNullOrEmpty(SelectedValue);
                }
                return estValeurNull;
            }
        }

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
        /// Collection d'éléments dans la liste.
        /// </summary>
        public ListItemCollection Items
        {
            get { return EstAutoComplet ? null : _dropDownList.Items; }
        }

      

        /// <summary>
        /// Champ, dans la source de données, qui fournit le texte de l'élément.
        /// </summary>
        [Category("Data")]
        [Description("Champ, dans la source de données, qui fournit le texte de l'élément.")]
        public string DataTextField
        {
            get { return EstAutoComplet ? _devExpressComboBox.TextField : _dropDownList.DataTextField; }
            set
            {
                if (EstAutoComplet)
                {
                    _devExpressComboBox.TextField = value;
                }
                else
                {
                    _dropDownList.DataTextField = value;
                }
            }
        }

        /// <summary>
        /// Champ, dans la source de données, qui fournit la valeur de l'élément.
        /// </summary>
        [Category("Data")]
        [Description("Champ, dans la source de données, qui fournit la valeur de l'élément.")]
        public string DataValueField
        {
            get { return EstAutoComplet ? _devExpressComboBox.ValueField : _dropDownList.DataValueField; }
            set
            {
                if (EstAutoComplet)
                {
                    _devExpressComboBox.ValueField = value;
                }
                else
                {
                    _dropDownList.DataValueField = value;
                }
            }
        }

        /// <summary>
        /// Type de donnée qui fournit la valeur de l'élément
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof (ListEditValueTypeTypeConverter))]
        [Description("Type de donnée qui fournit la valeur de l'élément.")]
        public Type DataValueType
        {
            get { return EstAutoComplet ? _devExpressComboBox.ValueType : null; }
            set { _devExpressComboBox.ValueType = EstAutoComplet ? value : null; }
        }

        /// <summary>
        /// La source de données.
        /// </summary>
        public object DataSource
        {
            get { return EstAutoComplet ? null : _dropDownList.DataSource; }
            set { _dropDownList.DataSource = EstAutoComplet ? null : value; }
        }

        /// <summary>
        /// Retourne la valeur sous forme de type natif int
        /// </summary>
        public int ValeurInt
        {
            get { return Convert.ToInt32(SelectedValue); }
        }

        public int? ValeurIntNullable
        {
            get { return EstValeurNull ? (int?) null : ValeurInt; }
        }

        /// <summary>
        /// Retourne ou sélectionne la valeur sous forme de type natif string
        /// </summary>
        public string SelectedValue
        {
            get
            {
                if (_selectionForcee != null)
                {
                    return _selectionForcee.Value.ToString();
                }
                string valeur = string.Empty;
                if (EstAutoComplet)
                {
                    if (_devExpressComboBox.SelectedItem != null && _devExpressComboBox.SelectedItem.Value != null)
                    {
                        string valDevEx = _devExpressComboBox.SelectedItem.Value.ToString();
                        if (valDevEx != "-1")
                        {
                            valeur = valDevEx;
                        }
                    }
                }
                else
                {
                    valeur = _dropDownList.SelectedValue;
                }

                return valeur;
            }
            set
            {
                // Ne pas assigner si on a fait appel à ForcerSelection, c'est un cas
                // de zèle par le FormView. L'assignation se fera au PreRender.
                if (_selectionForcee == null || _selectionForcee.Value.ToString() != value)
                {
                    if (!EstAutoComplet)
                    {
                        _dropDownList.SelectedValue = value;
                    }
                    else
                    {
                        // Attention, ce n'est pas une méthode fiable de changer
                        // la sélection du ComboBox AutoComplet.
                        _devExpressComboBox.Value = value;
                    }
                }
            }
        }

        /// <summary>
        /// Retourne ou sélectionne l'item sous forme de IStateManager
        /// </summary>
        public IStateManager SelectedItem
        {
            get
            {
                IStateManager item = null;
                if (EstAutoComplet)
                {
                    if (_devExpressComboBox.SelectedItem != null)
                    {
                        item = _devExpressComboBox.SelectedItem;
                    }
                }
                else
                {
                    item = _dropDownList.SelectedItem;
                }
                return item;
            }
            set
            {
                if (!EstAutoComplet)
                {
                    ListItem v = value as ListItem;
                    if (v != null)
                    {
                        _dropDownList.SelectedValue = v.Value;
                    }
                    else
                    {
                        EffacerSelection();
                    }
                }
                else
                {
                    ListEditItem v = value as ListEditItem;
                    if (v == null)
                    {
                        EffacerSelection();
                    }
                    else
                    {
                        _devExpressComboBox.SelectedItem = v;
                    }
                }
            }
        }

        /// <summary>
        /// Retourne ou sélectionne selon l'index
        /// </summary>
        public int SelectedIndex
        {
            get { return EstAutoComplet ? _devExpressComboBox.SelectedIndex : _dropDownList.SelectedIndex; }
            set
            {
                if (EstAutoComplet)
                {
                    if (_devExpressComboBox.SelectedIndex == -1)
                    {
                        // Ces valeurs sont conservées sinon.
                        _devExpressComboBox.Value = null;
                        _devExpressComboBox.Text = null;
                    }
                    _devExpressComboBox.SelectedIndex = value;
                }
                else
                {
                    _dropDownList.SelectedIndex = value;
                }
            }
        }

        /// <summary>
        /// Publication automatique sur le serveur après changement de la sélection.
        /// </summary>
        [Category("Comportement")]
        [Description("Publication automatique sur le serveur après changement de la sélection.")]
        public bool AutoPostBack
        {
            get { return EstAutoComplet ? _devExpressComboBox.AutoPostBack : _dropDownList.AutoPostBack; }
            set
            {
                if (EstAutoComplet)
                {
                    _devExpressComboBox.AutoPostBack = value;
                }
                else
                {
                    _dropDownList.AutoPostBack = value;
                }
            }
        }

        /// <summary>
        /// Obtient ou définit une valeur indiquant si le contrôle serveur Web est activé.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// true si le contrôle est activé ; sinon, false. La valeur par défaut est true.
        /// </returns>
        public override sealed bool Enabled { get; set; }

        /// <summary>
        /// ClientID du DropDown - permet de fonctionner correctement
        /// avec ScriptManager
        /// </summary>
        public override string ClientID
        {
            get { return EstAutoComplet ? _devExpressComboBox.ClientID : _dropDownList.ClientID; }
        }

        private string _valeurParDefaut;

        /// <summary>
        /// Valeur par défaut en mode ajout d'une grille. Utiliser cette propriété
        /// pour préciser que le champ doit contenir une valeur initiale lors de
        /// l'ajout.
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("Permet de préciser une valeur par défaut en mode ajout d'une grille")]
        public virtual string ValeurParDefaut
        {
            get { return _valeurParDefaut; }
            set
            {
                _valeurParDefaut = value;
                DataBinding -= OnDataBindingValeurParDefaut;
                if (!String.IsNullOrEmpty(_valeurParDefaut))
                {
                    DataBinding += OnDataBindingValeurParDefaut;
                }
            }
        }

        #endregion

        #region Event Handlers

        // Assignation de la valeur par défaut en mode ajout.
        private void OnDataBindingValeurParDefaut(object sender, EventArgs args)
        {
            if (Contexte == ContexteUtilisation.GrilleAjout)
            {
                SelectedValue = _valeurParDefaut;
            }
        }

        #endregion

        #region Évènement public

        /// <summary>
        /// Se déclenche lorsque l'index sélectionné a changé.
        /// </summary>
        [Category("Action")]
        [Description("Se déclenche lorsque l'index sélectionné a changé.")]
        public event EventHandler SelectedIndexChanged;

        #endregion

        #region Évènement pour DevExpress

        /// <summary>
        /// Delegate pour l'évènement ObtenirItems.
        /// Doit retourner un IEnumerable (normalement une IList d'entités) qui correspond
        /// à la plage indexDebut - indexFin, et cela, filtrer par le filtre.
        /// </summary>
        public delegate IEnumerable ObtenirItemsEventHandler(int indexDebut, int indexFin, string filtre);

        /// <summary>
        /// Se déclenche lorsque le combobox a besoin d'items.
        /// L'évènement doit retourner un IEnumerable.
        /// Voir ObtenirItemsEventHandler.
        /// </summary>
        [Category("Action")]
        [Description("Se déclenche lorsque le combobox a besoin d'items.")]
        public event ObtenirItemsEventHandler ObtenirItems;

        /// <summary>
        /// Delegate pour l'évènement ObtenirItemParValeur
        /// Doit retourner l'objet (normalement un entité) qui correspond à la valeur.
        /// </summary>
        public delegate object ObtenirItemParValeurEventHandler(object valeur);

        /// <summary>
        /// Se déclenche lorsque le combobox a besoin d'un item correspondant
        /// à une valeur.
        /// L'évènement doit retourner la valeur.
        /// Voir ObtenirItemParValeurEventHandler.
        /// </summary>
        [Category("Action")]
        [Description("Se déclenche lorsque le combobox a besoin d'un item correspondant à une valeur.")]
        public event ObtenirItemParValeurEventHandler ObtenirItemParValeur;

        #endregion

        #region Évènement de la page

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {

            // Ajout du dropDownList (ASP ou DevExpress)
            Controls.Add(CreerComboBox());

            //Ajout du validateur de comparaison et création de son id.
            if (EstAutoComplet)
            {
                if (ValidateurRequis)
                {
                    _compareValidator = new CompareValidator();
                    _compareValidator.ID = "compVal";
                    _compareValidator.ControlToValidate = _devExpressComboBox.ID;

                    _compareValidator.Operator = ValidationCompareOperator.NotEqual;
                    _compareValidator.ValueToCompare = "-1";
                    _compareValidator.Type = ValidationDataType.String;

                    Controls.Add(_compareValidator);
                }
            }

            // Affecter le controle a valider pour champs obligatoire
            ValidateurChampRequis.ControlToValidate = EstAutoComplet ? _devExpressComboBox.ID : _dropDownList.ID;

            base.CreateChildControls();
        }

        /// <summary>
        /// Permet de faire le rendu final de la page. C'est ici qu'on détermine
        /// le mode d'affichage de la page
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.CreerCelluleLibelle(writer);
            this.OuvrirCelluleContenu(writer, EstAutoComplet ? "comboBoxAutoComplet" : "comboBox");

            // Créer le dropDownList ou le libelle selon le mode d'affichage
            if (ObtenirModeAffichage() == ModeAffichage.Modification && Enabled)
            {
                base.Render(writer);
            }
            else
            {
                EcrireComboBoxInactif(writer);
            }

            this.FermerCelluleContenu(writer);
        }

        /// <summary>
        /// Lie une source de données au <see cref="T:System.Web.UI.WebControls.CompositeControl"/> et à tous ses contrôles enfants.
        /// </summary>
        public override void DataBind()
        {
            base.DataBind();
            if (EstLigneVide)
            {
                AjouterLigneVide();
            }
        }

        /// <summary>
        /// Évènement appelé juste avant le Render, permet d'ajuster le validateur
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!EstAutoComplet)
            {
                if (EstLigneVide && !_supprimerLigneVide)
                {
                    AjouterLigneVide();
                }
            }
            if (_selectionForcee != null)
            {
                ForcerSelection(_selectionForcee.Value, _selectionForcee.Text, _selectionForcee.MarquerInactive, true);
            }
            else
            {
                EffectuerSelectionAutomatique();
            }
            if (EstLigneVideASupprimer())
            {
                _SupprimerLigneVide();
            }

            if (ObtenirModeAffichage() == ModeAffichage.Modification && Enabled)
            {
                //_devExpressComboBox.Visible = true;
                _dropDownList.Visible = true;
            }
            else
            {
                //_devExpressComboBox.Visible = false;
                _dropDownList.Visible = false;
            }
            if (!EstLectureSeule() && EstAutoComplet)
            {
                AjusterValidateurComparaisonAvantRendu();
            }

            base.OnPreRender(e);
        }

        private void EffectuerSelectionAutomatique()
        {
            if (EstSelectionAutomatique && !EstAutoComplet && ContientUneSeuleValeur() && EstValeurNull)
            {
                _dropDownList.SelectedIndex = ContientLigneVide() ? 1 : 0;
                CbxBoxSelectedIndexChanged(_dropDownList, new EventArgs());
            }
        }

        private bool EstLigneVideASupprimer()
        {
            return _supprimerLigneVide || (EstLigneVideSupprimeeApresSelection && !EstValeurNull);
        }


        // Pas besoin de <span>...</span> autour de nos contrôles

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof (ArrayList))
            {
                ArrayList tblValeurs = (ArrayList) savedState;
                int i = 0;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    Enabled = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    EstLigneVide = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    EstAutoComplet = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    _ancienneValeurSelectionForcee = tblValeurs[i];
                if (tblValeurs[++i] != null)
                    EstSelectionAutomatique = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    EstLigneVideSupprimeeApresSelection = bool.Parse(tblValeurs[i].ToString());
                if (EstAutoComplet)
                {
                    if (tblValeurs[++i] != null)
                        DerniereValeurAutoComplet = tblValeurs[i];
                }
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
            MettreAJourValeurInactive();
            ArrayList tblValeurs = new ArrayList();
            tblValeurs.Add(base.SaveViewState());
            tblValeurs.Add(Enabled);
            tblValeurs.Add(EstLigneVide);
            tblValeurs.Add(EstAutoComplet);
            tblValeurs.Add(_nouvelleValeurSelectionForcee);
            tblValeurs.Add(EstSelectionAutomatique);
            tblValeurs.Add(EstLigneVideSupprimeeApresSelection);
            if (EstAutoComplet)
            {
                tblValeurs.Add(DerniereValeurAutoComplet);
            }
            return tblValeurs;
        }

        #endregion

        #region Méthode pour DevExpres

        private void InitDevExpressComboBox()
        {

            _devExpressComboBox.ID = "devExpressComboBox";
            _devExpressComboBox.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith;
            _devExpressComboBox.EnableCallbackMode = true;
            _devExpressComboBox.CallbackPageSize = 30;

            _devExpressComboBox.Width = Width;
            _devExpressComboBox.ShowShadow = false;
            _devExpressComboBox.LoadingPanelText = "Chargement&hellip;";

            _devExpressComboBox.Border.BorderColor = Color.FromArgb(8363449);
            _devExpressComboBox.ListBoxStyle.Border.BorderColor = Color.FromArgb(8363449);
            _devExpressComboBox.ItemStyle.SelectedStyle.BackColor = Color.FromArgb(207, 226, 255);
            _devExpressComboBox.ItemStyle.SelectedStyle.ForeColor = Color.Black;
            _devExpressComboBox.ItemStyle.HoverStyle.BackColor = Color.FromArgb(3238597);
            _devExpressComboBox.ItemStyle.HoverStyle.ForeColor = Color.White;
            _devExpressComboBox.ButtonStyle.BackgroundImage.ImageUrl = Page.GetResourceUrl("Edition.dropdown1.png");
            _devExpressComboBox.ButtonStyle.PressedStyle.BackgroundImage.ImageUrl =
                Page.GetResourceUrl("Edition.dropdown2.png");
            _devExpressComboBox.ButtonStyle.HoverStyle.BackgroundImage.ImageUrl =
                Page.GetResourceUrl("Edition.dropdown2.png");
            _devExpressComboBox.ButtonStyle.Border.BorderStyle = BorderStyle.None;
            _devExpressComboBox.CssClass = "controleAutoComplet";

            _devExpressComboBox.ItemsRequestedByFilterCondition += ItemsRequestedByFilterCondition;
            _devExpressComboBox.ItemRequestedByValue += ItemRequestedByValue;

            _devExpressComboBox.SelectedIndexChanged += CbxBoxSelectedIndexChanged;
            _devExpressComboBox.ClientSideEvents.GotFocus = "$.ATMTECH.appliquerCorrectifsDevExpress";
        }

        private void ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            int beginIndex = e.BeginIndex;
            int endIndex = e.EndIndex;
            if (EstLigneVide && String.IsNullOrEmpty(e.Filter))
            {
                // Première page, on demande de les (N - 1) premiers car on va ajouter une ligne
                endIndex--;
                if (e.BeginIndex > 0)
                {
                    // Pour les pages suivantes, il faut s'assurer de ne pas sauter un élément
                    beginIndex--;
                }
            }
            _devExpressComboBox.DataSource = ObtenirItems(beginIndex, endIndex, e.Filter);
            _devExpressComboBox.DataBind();
            if (EstLigneVide && String.IsNullOrEmpty(e.Filter) && e.BeginIndex == 0)
            {
                // Première page, on ajoute la ligne vide
                object val = _devExpressComboBox.ValueType.IsValueType ? (object) -1 : "-1";
                _devExpressComboBox.Items.Insert(0, new ListEditItem("", val));
            }
        }

        /// <summary>
        /// obtient les items par valeur.
        /// </summary>
        /// <param name="source">La source.</param>
        /// <param name="e">L'instance de <see cref="DevExpress.Web.ASPxEditors.ListEditItemRequestedByValueEventArgs"/> contenant les données sur l'évènement.</param>
        private void ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            if (EstValeurDevExpressVide(e.Value))
            {
                return;
            }
            object resultat = null;
            // Gros taponnage ici car DevExpress inverse parfois la description et la valeur, et perd la sélection!
            if (e.Value.GetType() == DataValueType)
            {
                resultat = ObtenirItemParValeur(e.Value);
            }
            if (resultat != null)
            {
                PropertyInfo prop = resultat.GetType().GetProperty(DataValueField);
                DerniereValeurAutoComplet = prop.GetValue(resultat, null);
            }
            else if (DerniereValeurAutoComplet != null && DerniereValeurAutoComplet.GetType() == DataValueType)
            {
                if (EstValeurDevExpressVide(DerniereValeurAutoComplet))
                {
                    _devExpressComboBox.SelectedIndex = -1;
                }
                else
                {
                    resultat = ObtenirItemParValeur(DerniereValeurAutoComplet);
                    if (resultat != null)
                        _devExpressComboBox.Value = DerniereValeurAutoComplet;
                }
            }
            if (resultat != null)
            {
                PropertyInfo prop = resultat.GetType().GetProperty(DataValueField);
                DerniereValeurAutoComplet = prop.GetValue(resultat, null);
                _devExpressComboBox.DataSource = new[] { resultat };
                _devExpressComboBox.DataBind();
            }
        }

        private static bool EstValeurDevExpressVide(object valeur)
        {
            return valeur == null
                   || (valeur is string && string.IsNullOrEmpty((string) valeur) || valeur.ToString() == "-1");
        }

        #endregion

        #region Méthode public

        /// <summary>
        /// Forcer la sélection pour une KeyValuePair.
        /// Contrepartie de ChargerDonneesDictionnaire.
        /// </summary>
        public void ForcerSelection<TCode>(KeyValuePair<TCode, string> kvpBatiment)
        {
            ForcerSelection(kvpBatiment.Key, kvpBatiment.Value);
        }

        /// <summary>
        /// Forcer la sélection pour un enum. Contrepartie de ChargerDonneesEnum.
        /// </summary>
        public void ForcerSelection(BaseEnumeration entite)
        {
            ForcerSelection(entite.Code, entite.Description);
        }

        /// <summary>
        /// Sélectionne la valeur spécifiée, en l'ajoutant préalablement.
        /// Si la valeur n'y est pas, elle sera marquée comme inactive
        /// (EstAutoComplet=false). Pour avoir le même effet avec la version
        /// AutoComplet, il faut appeler la méthode surchargée avec le
        /// paramètre marquerInactive.
        /// </summary>
        /// <param name="valeur">Valeur à sélectionner</param>
        /// <param name="description">Description de la valeur</param>
        public void ForcerSelection(object valeur, string description)
        {
            ForcerSelection(valeur, description, null, false);
        }

        /// <summary>
        /// Sélectionne la valeur spécifiée, en l'ajoutant préalablement.
        /// Si la valeur n'y est pas, elle sera marquée comme inactive
        /// (EstAutoComplet=false). Pour avoir le même effet avec la version
        /// AutoComplet, il faut appeler la ForcerSelectionInactive.
        /// </summary>
        /// <param name="valeur">Valeur à sélectionner</param>
        /// <param name="description">Description de la valeur</param>
        /// <param name="marquerInactive">Marquer ou non cette valeur comme inactive.</param>
        public void ForcerSelection(object valeur, string description, bool marquerInactive)
        {
            ForcerSelection(valeur, description, marquerInactive, false);
        }

        /// <summary>
        /// Permet de supprimer la valeur inactive ajoutée par ForcerSelection().
        /// </summary>
        private void MettreAJourValeurInactive()
        {
            if (!EstAutoComplet)
            {
                MettreAJourValeurInactive_ClasATMTECHue();
            }
            // Pour les AutoComplete, cela se fait dans le javascript.
        }

        private void MettreAJourValeurInactive_ClasATMTECHue()
        {
            if (_ancienneValeurSelectionForcee == null) return;

            ListItem item = _dropDownList.Items.FindByValue(_ancienneValeurSelectionForcee.ToString());
            if (item == null) return;

            // Ne pas exécuter cette logique si le contrôle ne sera pas mis à jour.
            // L'alternative serait d'envoyer du javascript pour supprimer une valeur inactive.
            if (!this.SeraMisAJour())
            {
                _nouvelleValeurSelectionForcee = _ancienneValeurSelectionForcee;
                return;
            }

            if (item.Selected)
            {
                _nouvelleValeurSelectionForcee = _ancienneValeurSelectionForcee;
                // On ramène notre style car il n'est pas persisté dans le ViewState
                if (string.IsNullOrEmpty(item.Attributes["class"]))
                    item.Attributes["class"] = "elementInactif";
            }
            else
            {
                // On supprime l'élément de la liste car il n'est plus pertinent
                _dropDownList.Items.Remove(item);
            }
        }

        /// <summary>
        /// Annule la sélection actuelle (s'il y en a une) et remets la
        /// sélection sur la première ligne.
        /// </summary>
        public void EffacerSelection()
        {
            if (!EstAutoComplet)
            {
                _dropDownList.ClearSelection();
            }
            else
            {
                _devExpressComboBox.SelectedItem = null;
            }
        }
        /// <summary>
        /// Vide les élément du comboBox 
        /// </summary>
        public void ViderDropDown()
        {
            if (!EstAutoComplet)
            {
                _dropDownList.Items.Clear();
            }
            else
            {
                if (_devExpressComboBox.Items != null)
                    _devExpressComboBox.Items.Clear();
            }
        }
        /// <summary>
        /// Permet d'enlever la ligne vide une fois que la première sélection est effectuée.
        /// Utilse seulement si EstAutoComplet = false.
        /// </summary>
        public void SupprimerLigneVide()
        {
            _supprimerLigneVide = true;
        }

        private void _SupprimerLigneVide()
        {
            if (!EstAutoComplet && ContientLigneVide())
            {
                Items.RemoveAt(0);
            }
        }

        private bool ContientLigneVide()
        {
            return _dropDownList.Items.Count > 0 && string.IsNullOrEmpty(_dropDownList.Items[0].Value);
        }

        private bool ContientUneSeuleValeur()
        {
            return (ContientLigneVide() ? _dropDownList.Items.Count == 2 : _dropDownList.Items.Count == 1);
        }

        #endregion

        #region Méthode privée

        private void CbxBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (AutoPostBack)
            {
                PageBase page = Page as PageBase;
                if (page != null)
                {
                    page.FocusSurControl(EstAutoComplet ? (Control) _devExpressComboBox : _dropDownList);
                }
            }
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }

        private Control CreerComboBox()
        {
            Control comboBox;
            if (EstAutoComplet)
            {
                InitDevExpressComboBox();
                comboBox = _devExpressComboBox;
            }
            else
            {
                if (EstUpdatePanel)
                {
                    InitUpdatePanelAspComboBox();
                    comboBox = _updatePanel;
                }
                else
                {
                    InitAspComboBox();
                    comboBox = _dropDownList;
                }
            }
            return comboBox;

        }

        private void InitAspComboBox()
        {
            _dropDownList.ID = "AspCbxBox";
            _dropDownList.Width = Width;
            _dropDownList.SelectedIndexChanged += CbxBoxSelectedIndexChanged;
        }

        private void InitUpdatePanelAspComboBox()
        {
            InitAspComboBox();
            _updatePanel.ID = "udp";
            _updatePanel.RenderMode = UpdatePanelRenderMode.Inline;
            _updatePanel.ContentTemplateContainer.Controls.Add(_dropDownList);
        }

        private void EcrireComboBoxInactif(HtmlTextWriter writer)
        {
            string texte = string.Empty;
            if (SelectedItem != null)
            {
                texte = EstAutoComplet ? _devExpressComboBox.SelectedItem.Text : _dropDownList.SelectedItem.Text;
            }
            this.EcrireControleLectureSeule(writer, texte);
            // Rendu du ComboBox invisible
            if (EstAutoComplet)
            {
                _dropDownList.RenderControl(writer);
            }
            else
            {
                _devExpressComboBox.Visible = false;
                _devExpressComboBox.RenderControl(writer);
            }
        }

        private void AjouterLigneVide()
        {
            if (!ContientLigneVide())
            {
                _dropDownList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            }
        }

        private void ForcerSelection(object valeur, string description, bool? inactive, bool rendering)
        {
            if (!EstAutoComplet)
            {
                ForcerSelection_ClasATMTECHue(valeur.ToString(), description, inactive, rendering);
            }
            else
            {
                ForcerSelection_AutoComplet(valeur, description, inactive, rendering);
            }
        }

        private void ForcerSelection_ClasATMTECHue(string valeur, string description, bool? inactive, bool rendering)
        {
            if (rendering)
            {
                _selectionForcee = null;
            }
            ListItem item = _dropDownList.Items.FindByValue(valeur);
            if (item != null)
            {
                SelectedValue = valeur;
                _selectionForcee = null;
            }
            else
            {
                item = new ListItem(description, valeur);
                _nouvelleValeurSelectionForcee = item.Value;
                if (DataSource != null && !rendering)
                {
                    // On est obligé de faire ceci pour éviter que le FormView
                    // (GrilleAvance) plante lors du EnsureDataBound
                    _selectionForcee = new SelectionForcee(item, inactive);
                }
                else
                {
                    item.Attributes.Add("class", "elementInactif");
                    if (inactive.GetValueOrDefault(true))
                    {
                        item.Text += "*";
                    }
                    _dropDownList.Items.Add(item);
                    SelectedValue = valeur;
                }
            }
        }

        private void ForcerSelection_AutoComplet(object valeur, string description, bool? inactive, bool rendering)
        {
            if (rendering)
            {
                _selectionForcee = null;
            }
            ListEditItem item = _devExpressComboBox.Items.FindByValue(valeur);
            if (item != null)
            {
                item.Selected = true;
                _selectionForcee = null;
            }
            else
            {
                item = new ListEditItem(description, valeur);
                if (!rendering)
                {
                    _selectionForcee = new SelectionForcee(item, inactive);
                }
                else
                {
                    if (inactive.GetValueOrDefault(false))
                    {
                        _nouvelleValeurSelectionForcee = item.Value;
                        item.Text += "*";
                    }
                    _devExpressComboBox.Items.Add(item);
                    item.Selected = true;
                }
            }
        }

        private void AjusterValidateurComparaisonAvantRendu( )
        {
            if (_compareValidator != null && Controls.Contains(_compareValidator))
            {
                _compareValidator.Visible = EstObligatoire;
                _compareValidator.ValidationGroup = ValidationGroup;
                _compareValidator.Display = ValidatorDisplay.Dynamic;

                string nomChamp = NomChamp;
                if (string.IsNullOrEmpty(nomChamp))
                {
                    _compareValidator.ToolTip = "Ce champ est obligatoire.";
                    _compareValidator.ErrorMessage = "Ce champ est obligatoire.";
                }
                else
                {
                    string msg = String.Format("Le champ \"{0}\" est obligatoire.", nomChamp);
                    _compareValidator.ErrorMessage = msg;
                    _compareValidator.ToolTip = msg;
                }
                EditionUtils.CreerIndicateurErreur(this, _compareValidator);
            }
       }

        #endregion
    }
}