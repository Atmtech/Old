using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// 
    /// </summary>
    public class VaseCommuniquantAvance : ControleBase
    {
        #region Membres privés

        private readonly ListBox _listBoxDepart;
        private readonly ListBox _listBoxResultat;
        private readonly Button _boutonAjouter;
        private readonly Button _boutonRetirer;
        private readonly Image _image;
        private readonly Image _imageEtoile;
        private readonly TitreLabelAvance _lblTitreDepart;
        private readonly TitreLabelAvance _lblTitreResultat;
        private readonly TitreLabelAvance _lblCompteDepart;
        private readonly TitreLabelAvance _lblCompteResultat;
        private readonly TitreLabelAvance _lblNombreItemDepart;
        private readonly TitreLabelAvance _lblNombreItemResultat;
        private CustomValidator _validateurPersonnalise;
        private bool _estValide = true;

        #endregion

        #region Ctor
        /// <summary>
        /// Constructeur du control VaseCommuniquantAvance
        /// </summary>
        public VaseCommuniquantAvance()
            : base(false)
        {
            _listBoxDepart = new ListBox();
            _listBoxResultat = new ListBox();
            _boutonAjouter = new Button();
            _boutonRetirer = new Button();
            _image = new Image();
            _imageEtoile = new Image();
            _lblTitreDepart = new TitreLabelAvance();
            _lblTitreResultat = new TitreLabelAvance();
            _lblCompteDepart = new TitreLabelAvance();
            _lblCompteResultat = new TitreLabelAvance();
            _lblNombreItemDepart = new TitreLabelAvance();
            _lblNombreItemResultat = new TitreLabelAvance();
            _validateurPersonnalise = new CustomValidator();

            // Dimensions par défaut des deux listes
            LargeurListBox = Unit.Pixel(200);
            HauteurListBox = Unit.Pixel(200);

            // Rendre les variables qui indiquent le nombre d'items des vases invisibles
            _lblNombreItemDepart.Visible = false;
            _lblNombreItemResultat.Visible = false;
            _lblCompteDepart.Visible = false;
            _lblCompteResultat.Visible = false;
        }
        #endregion

        #region propriétés

        /// <summary>
        /// 
        /// </summary>
        public bool AfficherErreurIcon
        {
            get { return _image.Visible; }
            set { _image.Visible = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AfficherErreurIconMessage
        {
            get { return _image.ToolTip; }
            set { _image.ToolTip = value; }
        }

        /// <summary>
        /// Propriété sur la visibilité du nombre d'item du label sur le nombre d'item de la listbox de départ
        /// </summary>
        public bool VisibiliteNombreItemLsbDepart
        {
            get
            {
                return _lblNombreItemDepart.Visible;
            }
            set
            {
                _lblNombreItemDepart.Visible = value;
                _lblCompteDepart.Visible = value;
            }
        }

        /// <summary>
        /// Propriété sur la visibilité du nombre d'item du label sur le nombre d'item de la listbox resultat
        /// </summary>
        public bool VisibiliteNombreItemLsbResultat
        {
            get
            {
                return _lblNombreItemResultat.Visible;
            }
            set
            {
                _lblNombreItemResultat.Visible = value;
                _lblCompteResultat.Visible = value;
            }
        }

        /// <summary>
        /// Propriété sur le titre du label de la listbox de Depart
        /// </summary>
        public string TitreLsbDepart
        {
            get
            {
                return _lblTitreDepart.Text;
            }
            set
            {
                _lblTitreDepart.Text = value;
            }
        }

        /// <summary>
        /// Propriété sur le titre du label de la listbox résultat
        /// </summary>
        public string TitreLsbResultat
        {
            get
            {
                return _lblTitreResultat.Text;
            }
            set
            {
                _lblTitreResultat.Text = value;
            }
        }

        /// <summary>
        /// Largeur en pixel des 2 Listbox
        /// </summary>
        public Unit LargeurListBox { get; set; }

        /// <summary>
        /// Hauteur en pixel des 2 listbox
        /// </summary>
        public Unit HauteurListBox { get; set; }

        /// <summary>
        /// Détermine si on peut faire de la selection multiple
        /// </summary>
        public bool EstSelectionMultiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TooltipFlecheDroite
        {
            get { return _boutonAjouter.ToolTip; }
            set
            {
                _boutonAjouter.ToolTip = value;
            }
        }

        public string CssClassFlecheDroite
        {
            set { _boutonAjouter.CssClass = value; }
        }

        public string CssClassFlecheGauche
        {
            set { _boutonRetirer.CssClass = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TooltipFlecheGauche
        {
            get { return _boutonRetirer.ToolTip; }
            set
            {
                _boutonRetirer.ToolTip = value;
            }
        }

        /// <summary>
        /// Propriété qui permet de définir si le contrôle permet l'insertion de doublon.
        /// </summary>
        public bool EstPermiDoublon { get; set; }

        #endregion

        #region évènement


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public delegate void OnAjouterSelection(VaseCommuniquantAvanceEventArgs e);
        /// <summary>
        /// 
        /// </summary>
        public event OnAjouterSelection BtnAjouterHandler;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public delegate void OnRetirerSelection(VaseCommuniquantAvanceEventArgs e);
        /// <summary>
        /// 
        /// </summary>
        public event OnRetirerSelection BtnRetirerHandler;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBoxComplete"></param>
        public delegate void OnRemplirListeComplete(ListBox listBoxComplete);
        /// <summary>
        /// 
        /// </summary>
        public event OnRemplirListeComplete SurChargementListeCompleteHandler;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBoxResultat"></param>
        public delegate void OnRemplirListeResultat(ListBox listBoxResultat);
        /// <summary>
        /// 
        /// </summary>
        public event OnRemplirListeResultat SurChargementListeResultatHandler;

        #endregion

        #region Implémentation

        /// <summary>
        /// Methode d'initialisation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            _image.Visible = false;
            _image.ImageUrl = "~/Images/indicateurErreur.png";

            // Ajouter les évènemnts des boutons
            _boutonAjouter.Click += btnAjouter_Click;
            _boutonRetirer.Click += btnRetirer_Click;

            // Ajout du validationGroup
            if (!string.IsNullOrEmpty(ValidationGroup))
            {
                _boutonAjouter.ValidationGroup = ValidationGroup;
            }

            if (SurChargementListeResultatHandler != null)
            {
                SurChargementListeResultatHandler(_listBoxResultat);
            }
            base.OnInit(e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SurChargementListeCompleteHandler != null)
                {
                    SurChargementListeCompleteHandler(_listBoxDepart);
                    _lblCompteDepart.Text = _listBoxDepart.Items.Count.ToString();
                }
            }
        }


        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {

            // Ajout des controls au vaseCommuniquantAvance
            DefinirIdSurControls();
            Controls.Add(ConstruireVaseCommuniquant());

            base.CreateChildControls();
        }

        /// <summary>
        /// Écrit le contenu <see cref="T:System.Web.UI.WebControls.CompositeControl"/> dans l'objet <see cref="T:System.Web.UI.HtmlTextWriter"/> spécifié pour qu'il s'affiche sur le client.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (ObtenirModeAffichage() == ModeAffichage.Modification && Enabled)
            {
                ConstruireVaseCommuniquantActif(writer);
            }
            else
            {
                ConstruireVaseCommuniquantLectureSeule(writer);
            }
        }

        /// <summary>
        /// Définit des attribut d'affichage avant le rendu de la page
        /// </summary>
        /// <param name="e"><see cref="T:System.EventArgs"/> Évènement du PreRender</param>
        protected override void OnPreRender(EventArgs e)
        {
            AjusterControls();

            if (!(ObtenirModeAffichage() != ModeAffichage.Modification || !Enabled))
            {
                // inclure le validateur de champs obligatoire
                AjusterControlPourValidateurPersonnaliser();
            }
            else
            {
                AjusterControlPourValidateurPersonnaliserAbsent();
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                int i = 0;
                ArrayList tblValeurs = (ArrayList)savedState;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    LargeurListBox = Unit.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    HauteurListBox = Unit.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    EstSelectionMultiple = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    EstPermiDoublon = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    TitreLsbDepart = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    TitreLsbResultat = tblValeurs[i].ToString();
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
            tblValeurs.Add(LargeurListBox.ToString());
            tblValeurs.Add(HauteurListBox.ToString());
            tblValeurs.Add(EstSelectionMultiple);
            tblValeurs.Add(EstPermiDoublon);
            tblValeurs.Add(TitreLsbDepart);
            tblValeurs.Add(TitreLsbResultat);
            return tblValeurs;
        }

        /// <summary>
        /// Événement qui est lancé à chaque fois que le bouton ajouter est appuyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            if (BtnAjouterHandler == null)
            {
                // Mode automatique, on transfert simplement d'une liste à l'autre.
                TransfererSelections(_listBoxDepart, _listBoxResultat);
                return;
                // Mode automatique, on transfert simplement d'une liste à l'autre.
            }
            if (EstSelectionMultiple)
            {
                bool possedeDoublons = false;
                IList<ListItem> listeSelection = new List<ListItem>();

                int[] indexSelectionne = _listBoxDepart.GetSelectedIndices();

                foreach (int i in indexSelectionne)
                {
                    listeSelection.Add(_listBoxDepart.Items[i]);
                    possedeDoublons = possedeDoublons || VerifierPresenceDoublon(_listBoxDepart.Items[i].Value);
                }
                if (EstPermiDoublon)
                {
                    possedeDoublons = false;
                }
                _estValide = !possedeDoublons;
                if (listeSelection.Count > 0)
                {
                    BtnAjouterHandler(new VaseCommuniquantAvanceEventArgs(
                                                EstPermiDoublon,
                                                listeSelection,
                                                _image.ToolTip,
                                                possedeDoublons));
                }
            }
            else if (_listBoxDepart.SelectedItem != null)
            {
                // Vérifier que l'item n'existe pas dans la liste
                bool possedeDoublons = VerifierPresenceDoublon(_listBoxDepart.SelectedItem.Value);
                if (EstPermiDoublon)
                {
                    possedeDoublons = false;
                }
                _estValide = !possedeDoublons;
                BtnAjouterHandler(new VaseCommuniquantAvanceEventArgs(
                                            EstPermiDoublon,
                                            _listBoxDepart.SelectedIndex,
                                            _listBoxDepart.SelectedItem.Text,
                                            _listBoxDepart.SelectedItem.Value,
                                            _image.ToolTip,
                                            possedeDoublons));
            }
        }

        /// <summary>
        /// Événement qui est lancé quand l'utilisateur pese sur enlever un item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRetirer_Click(object sender, EventArgs e)
        {
            if (BtnRetirerHandler == null)
            {
                // Mode automatique, on transfert simplement d'une liste à l'autre.
                TransfererSelections(_listBoxResultat, _listBoxDepart);
                return;
            }
            if (EstSelectionMultiple)
            {
                IList<ListItem> listeSelection = new List<ListItem>();
                int[] indexSelectionne = _listBoxResultat.GetSelectedIndices();

                foreach (int i in indexSelectionne)
                {
                    listeSelection.Add(_listBoxResultat.Items[i]);
                }

                if (listeSelection.Count > 0)
                {
                    BtnRetirerHandler(new VaseCommuniquantAvanceEventArgs(
                                                  EstPermiDoublon,
                                                  listeSelection,
                                                  _image.ToolTip,
                                                  false));
                }
                _lblCompteResultat.Text = _listBoxResultat.Items.Count.ToString();
            }
            else if (!EstSelectionMultiple && _listBoxResultat.SelectedItem != null)
            {
                BtnRetirerHandler(new VaseCommuniquantAvanceEventArgs(
                                            EstPermiDoublon,
                                            _listBoxResultat.SelectedIndex,
                                            _listBoxResultat.SelectedItem.Text,
                                            _listBoxResultat.SelectedItem.Value,
                                            _image.ToolTip,
                                            false));
            }
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Charge la liste de gauche avec les valeurs poussé par l'interface
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="listeValeurs"></param>
        /// <param name="champValeur"></param>
        /// <param name="champTexte"></param>
        public void ChargerListeDepart<TType>(IList<TType> listeValeurs, string champValeur, string champTexte)
        {
            _listBoxDepart.DataSource = listeValeurs;
            _listBoxDepart.DataTextField = champTexte;
            _listBoxDepart.DataValueField = champValeur;
            _listBoxDepart.DataBind();

            //Afficher un tooltip sur chaque item de la liste
            foreach (ListItem item in _listBoxDepart.Items)
            {
                item.Attributes.Add("title", item.Text);
            }
        }


        /// <summary>
        /// Charge la liste de droite avec les valeurs de l'interface
        /// </summary>
        /// <param name="listeValeurs"></param>
        /// <param name="champValeur"></param>
        /// <param name="champTexte"></param>
        public void ChargerListeResultat<TType>(IList<TType> listeValeurs, string champValeur, string champTexte)
        {
            _listBoxResultat.DataSource = listeValeurs;
            _listBoxResultat.DataTextField = champTexte;
            _listBoxResultat.DataValueField = champValeur;
            _listBoxResultat.DataBind();

            //Afficher un tooltip sur chaque item de la liste
            foreach (ListItem item in _listBoxResultat.Items)
            {
                item.Attributes.Add("title", item.Text);
            }
        }

        /// <summary>
        /// Obtient la liste des résultats, généralement utile lors de la sauvegarde à la base de données.
        /// </summary>
        /// <returns></returns>
        public IList<ListItem> ObtenirListeResultat()
        {
            var list = new List<ListItem>();
            foreach (ListItem listItem in _listBoxResultat.Items)
            {
                list.Add(listItem);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valeur"></param>
        /// <param name="texte"></param>
        public void AjouterResultat(string valeur, string texte)
        {
            ListItem item = new ListItem(texte, valeur);
            _listBoxResultat.Items.Add(item);
            if (!EstPermiDoublon)
            {
                _listBoxDepart.Items.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valeur"></param>
        /// <param name="texte"></param>
        public void EnleverResultat(string valeur, string texte)
        {
            ListItem item = new ListItem(texte, valeur);
            _listBoxResultat.Items.Remove(item);
            if (!EstPermiDoublon)
            {
                _listBoxDepart.Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listeELements"></param>
        public void AjouterResultatMultiple(IList<ListItem> listeELements)
        {
            foreach (ListItem item in listeELements)
            {
                _listBoxResultat.Items.Add(new ListItem(item.Text, item.Value));
                if (!EstPermiDoublon)
                {
                    _listBoxDepart.Items.Remove(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listeElements"></param>
        public void EnleverResultatMultiple(IList<ListItem> listeElements)
        {

            foreach (ListItem item in listeElements)
            {
                _listBoxResultat.Items.Remove(item);
                if (!EstPermiDoublon)
                {
                    _listBoxDepart.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reinitialiser<TType>(IList<TType> listeValeurs, string champValeur, string champTexte)
        {
            ChargerListeDepart(listeValeurs, champValeur, champTexte);
            _listBoxResultat.Items.Clear();
        }

        #endregion

        #region Méthodes privées

        private static void TransfererSelections(ListControl listeSource, ListControl listeDestination)
        {
            listeDestination.SelectedIndex = -1;
            for (int i = listeSource.Items.Count - 1; i >= 0; --i)
            {
                ListItem item = listeSource.Items[i];
                if (item.Selected)
                {
                    listeDestination.Items.Add(item);
                    listeSource.Items.RemoveAt(i);
                }
            }
        }

        private void ConstruireVaseCommuniquantActif(HtmlTextWriter writer)
        {
            base.Render(writer);
        }

        private void ConstruireVaseCommuniquantLectureSeule(HtmlTextWriter writer)
        {
            // Retirer les boutons
            _boutonAjouter.Visible = false;
            _boutonRetirer.Visible = false;

            base.Render(writer);
        }

        private void DefinirIdSurControls()
        {
            _listBoxDepart.ID = ID + "_lstBoxDepart";
            _listBoxResultat.ID = ID + "_lstBoxResultat";
            _boutonAjouter.ID = ID + "_btnAjouter";
            _boutonRetirer.ID = ID + "_btnRetirer";
            _lblTitreDepart.ID = ID + "_titreDepart";
            _lblTitreResultat.ID = ID + "_titreResultat";
            _lblCompteDepart.ID = ID + "_compteDepart";
            _lblCompteResultat.ID = ID + "_compteResultat";
            _lblNombreItemDepart.ID = ID + "_nombreItemDepart";
            _lblNombreItemResultat.ID = ID + "_nombreItemResultat";
            _image.ID = ID + "_image";
            _image.ToolTip = "Impossible d'ajouter deux fois le même item.";
        }

        private Panel ConstruireVaseCommuniquant()
        {
            Panel panneau = new Panel();
            panneau.Controls.Add(ConstruireTable());
            return panneau;
        }

        private Table ConstruireTable()
        {
            Table table = new Table();
            table.Controls.Add(ConsrtuireRangeTitre());
            table.Controls.Add(ConstruireRangeContenu());
            table.Controls.Add(ConstruireRangeCompte());
            return table;
        }

        private TableRow ConstruireRangeCompte()
        {
            TableRow tableRowCompte = new TableRow();
            TableCell cellule = new TableCell();
            cellule.Controls.Add(_lblCompteDepart);
            cellule.Controls.Add(_lblNombreItemDepart);
            tableRowCompte.Controls.Add(cellule);
            cellule = new TableCell();
            tableRowCompte.Controls.Add(cellule);
            cellule = new TableCell();
            cellule.Controls.Add(_lblCompteResultat);
            cellule.Controls.Add(_lblNombreItemResultat);
            tableRowCompte.Controls.Add(cellule);
            cellule = new TableCell();
            tableRowCompte.Controls.Add(cellule);
            return tableRowCompte;
        }

        private TableRow ConstruireRangeContenu()
        {
            TableRow tableRowContenu = new TableRow();
            TableCell cellule = new TableCell();
            cellule.Controls.Add(_listBoxDepart);
            tableRowContenu.Controls.Add(cellule);
            cellule = new TableCell();
            cellule.Controls.Add(_boutonAjouter);
            Literal literal = new Literal();
            literal.Text = "<br />";
            cellule.Controls.Add(literal);
            literal = new Literal();
            literal.Text = "<br />";
            cellule.Controls.Add(literal);
            cellule.Controls.Add(_boutonRetirer);
            tableRowContenu.Controls.Add(cellule);
            cellule = new TableCell();
            cellule.Controls.Add(CreerRenduCelluleIndicateurObligatoire());
            cellule.Controls.Add(_listBoxResultat);
            tableRowContenu.Controls.Add(cellule);
            cellule = new TableCell();
            cellule.VerticalAlign = VerticalAlign.Top;
            cellule.Controls.Add(_image);
            cellule.Controls.Add(CreerValidateurPersonnalise());
            tableRowContenu.Controls.Add(cellule);
            return tableRowContenu;
        }

        private TableRow ConsrtuireRangeTitre()
        {
            TableRow tableRowTitre = new TableRow();
            TableCell cellule = new TableCell();
            cellule.Controls.Add(_lblTitreDepart);
            tableRowTitre.Controls.Add(cellule);
            cellule = new TableCell();
            tableRowTitre.Controls.Add(cellule);
            cellule = new TableCell();
            cellule.Controls.Add(_lblTitreResultat);
            tableRowTitre.Controls.Add(cellule);
            cellule = new TableCell();
            tableRowTitre.Controls.Add(cellule);
            return tableRowTitre;
        }

        private bool VerifierPresenceDoublon(string valeur)
        {

            IEnumerator enumerator = _listBoxResultat.Items.GetEnumerator();

            while (enumerator.MoveNext())
            {
                ListItem item = (ListItem)enumerator.Current;

                if (item.Value.Equals(valeur))
                    return true;
            }

            return false;
        }

        private void AjusterControls()
        {
            if (String.IsNullOrEmpty(TitreLsbResultat))
            {
                TitreLsbDepart = "Liste départ";
                TitreLsbResultat = "Liste résultat";
            }

            _lblCompteDepart.Text = _listBoxDepart.Items.Count.ToString();
            _lblCompteResultat.Text = _listBoxResultat.Items.Count.ToString();
            _lblNombreItemDepart.Text = " items";
            _lblNombreItemResultat.Text = " items";

            _boutonAjouter.ToolTip = "Ajouter";
            _boutonRetirer.ToolTip = "Retirer";
            _boutonAjouter.Text = ">";
            _boutonRetirer.Text = "<";
            _boutonAjouter.Width = Unit.Pixel(25);
            _boutonRetirer.Width = Unit.Pixel(25);
            _boutonAjouter.CausesValidation = false;
            _boutonRetirer.CausesValidation = false;
            _boutonAjouter.UseSubmitBehavior = false;
            _boutonRetirer.UseSubmitBehavior = false;

            _listBoxDepart.Width = LargeurListBox;
            _listBoxDepart.Height = HauteurListBox;
            _listBoxDepart.SelectionMode = EstSelectionMultiple ? ListSelectionMode.Multiple : ListSelectionMode.Single;

            _listBoxResultat.Width = LargeurListBox;
            _listBoxResultat.Height = HauteurListBox;
            _listBoxResultat.SelectionMode = EstSelectionMultiple ? ListSelectionMode.Multiple : ListSelectionMode.Single;

            _lblTitreDepart.CssClass = "sdlLibelle";
            _lblTitreResultat.CssClass = "sdlLibelle";
            _listBoxDepart.CssClass = "sdlContenu";
            _listBoxResultat.CssClass = "sdlContenu";
            _lblNombreItemDepart.CssClass = "sdlLibelle";
            _lblNombreItemResultat.CssClass = "sdlLibelle";
            _lblCompteDepart.CssClass = "sdlLibelle";
            _lblCompteResultat.CssClass = "sdlLibelle";

            _listBoxDepart.SelectedIndex = -1;

            _listBoxDepart.DataBind();
            _listBoxResultat.DataBind();

            _image.Visible = !_estValide;
        }

        #endregion

        #region Validateurs

        private CustomValidator CreerValidateurPersonnalise()
        {
            _validateurPersonnalise = new CustomValidator();
            _validateurPersonnalise.ErrorMessage = "La liste est obligatoire";
            _validateurPersonnalise.ToolTip = _validateurPersonnalise.ErrorMessage;
            _validateurPersonnalise.Display = ValidatorDisplay.Dynamic;
            _validateurPersonnalise.EnableClientScript = true;
            _validateurPersonnalise.ServerValidate += OnValidateurServerValidate;
            _validateurPersonnalise.ClientValidationFunction = ObtenirNomFonctionJsValidation();
            _validateurPersonnalise.ValidationGroup = ValidationGroup;

            EditionUtils.CreerIndicateurErreur(this, _validateurPersonnalise);

            return _validateurPersonnalise;
        }

        private void OnValidateurServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (_listBoxResultat.Items.Count > 0)
            {
                args.IsValid = true;
            }
        }

        private string ObtenirNomFonctionJsValidation()
        {
            return "VcaValRequis" + ClientID;
        }

        private void CreerJavaScriptValidationRequis()
        {
            string js = @"function " + ObtenirNomFonctionJsValidation() + @"(source, args) {" +
                        @"$.ATMTECH.validerListBox(" + _listBoxResultat.Items.Count +
                        @",args);" +
                        @"}";

            Page.IncorporerJavascript(ObtenirNomFonctionJsValidation(), js);
        }
        /// <summary>
        /// Creers the rendu cellule indicateur obligatoire.
        /// </summary>
        /// <returns></returns>
        private Image CreerRenduCelluleIndicateurObligatoire()
        {
            _imageEtoile.ImageUrl = Page.GetEncodedResourceUrl("Edition.indicateurObligatoire.gif");
            _imageEtoile.ToolTip = "Ce champ est obligatoire.";
            _imageEtoile.CssClass = "obligatoire";
            return _imageEtoile;
        }

        private void AjusterControlPourValidateurPersonnaliserAbsent()
        {
            _validateurPersonnalise.Visible = false;
            _imageEtoile.Visible = false;
            _listBoxResultat.Style.Remove("margin-left");
            _lblCompteResultat.Style.Remove("margin-left");
        }

        private void AjusterControlPourValidateurPersonnaliser()
        {
            CreerJavaScriptValidationRequis();
            Page.InclureRessourceJavascript("Edition.VaseCommuniquantAvance.js");
            _validateurPersonnalise.Visible = EstObligatoire;
            _imageEtoile.Visible = EstObligatoire;

            if (String.IsNullOrEmpty(NomChamp))
            {
                NomChamp = TitreLsbResultat;
            }
            string msgErr = string.Format("Au moins un élément doit être présent dans la liste {0}.", NomChamp);
            _validateurPersonnalise.ToolTip = msgErr;
            _validateurPersonnalise.ErrorMessage = msgErr;

            _lblTitreResultat.Style.Add("margin-left", "8px");
            _lblCompteResultat.Style.Add("margin-left", "8px");
            if (!EstObligatoire)
            {
                _listBoxResultat.Style.Add("margin-left", "8px");
            }
            else
            {
                _listBoxResultat.Style.Remove("margin-left");
            }
        }

        #endregion

    }
}
