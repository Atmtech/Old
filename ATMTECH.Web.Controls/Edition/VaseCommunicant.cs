using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;


namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// </summary>
    public class VaseCommunicant : ControleBase
    {
        private readonly Button _boutonAjouter;
        private readonly Button _boutonRetirer;
        private readonly Image _image;
        private readonly Image _imageEtoile;
        private readonly TitreLabelAvance _lblTitreDepart;
        private readonly TitreLabelAvance _lblTitreResultat;
        private readonly ListBox _listBoxDepart;
        private readonly ListBox _listBoxResultat;
        private CustomValidator _validateurPersonnalise;

        private ISet<string> _valeursInactives = new HashSet<string>();

        public VaseCommunicant()
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
            _validateurPersonnalise = new CustomValidator();

            // Dimensions par défaut des deux listes
            LargeurListBox = Unit.Pixel(200);
            HauteurListBox = Unit.Pixel(200);
        }

        /// <summary>
        /// Hauteur en pixel des 2 listbox
        /// </summary>
        public Unit HauteurListBox { get; set; }

        /// <summary>
        /// Largeur en pixel des 2 Listbox
        /// </summary>
        public Unit LargeurListBox { get; set; }

        /// <summary>
        /// Titre de la liste de résultats
        /// </summary>
        public string TitreDroite
        {
            get { return _lblTitreResultat.Text; }
            set { _lblTitreResultat.Text = value; }
        }

        /// <summary>
        /// Titre de la liste d'éléments disponibles
        /// </summary>
        public string TitreGauche
        {
            get { return _lblTitreDepart.Text; }
            set { _lblTitreDepart.Text = value; }
        }

        /// <summary>
        /// Charge les deux listes avec les valeurs initiales. Pour les résultats, on doit quand même préciser la
        /// description, car il se peut qu'une valeur soit inactive.
        /// </summary>
        public void ChargerListes<TCode>(IList<KeyValuePair<TCode, string>> elementsActifs,
            IList<KeyValuePair<TCode, string>> resultatsInitiaux = null)
        {
            _listBoxDepart.Items.Clear();
            _listBoxResultat.Items.Clear();
            _listBoxDepart.Items.AddRange(
                elementsActifs.Select(e => new ListItem(e.Value.ToString(), e.Key.ToString())).ToArray());

            if (resultatsInitiaux != null)
                AjouterResultats(resultatsInitiaux);

            AjouterTooltips(_listBoxDepart);
            AjouterTooltips(_listBoxResultat);
        }

        /// <summary>
        /// Charge les deux listes avec les valeurs initiales. Pour les résultats, on doit quand même préciser la
        /// description, car il se peut qu'une valeur soit inactive.
        /// </summary>
        public void ChargerListes<T>(ICollection<T> elementsActifs, ICollection<T> resultatsInitiaux = null) where T: BaseEnumeration
        {
            _listBoxDepart.Items.Clear();
            _listBoxResultat.Items.Clear();
            _listBoxDepart.Items.AddRange(elementsActifs.Select(e => new ListItem(e.Description, e.Code)).ToArray());

            if (resultatsInitiaux != null)
                AjouterResultats(resultatsInitiaux);

            AjouterTooltips(_listBoxDepart);
            AjouterTooltips(_listBoxResultat);
        }

        private static void AjouterTooltips(ListControl liste)
        {
            //Afficher un tooltip sur chaque item de la liste
            foreach (ListItem item in liste.Items)
            {
                item.Attributes.Add("title", item.Text);
            }
        }

        private void AjouterResultat(ListItem item)
        {
            ListItem itemOrigine = _listBoxDepart.Items.FindByValue(item.Value);
            if (itemOrigine != null)
            {
                _listBoxDepart.Items.Remove(itemOrigine);
                item = itemOrigine;
            }
            else
            {
                _valeursInactives.Add(item.Value);
                MarquerInactif(item);
            }
            _listBoxResultat.Items.Add(item);
        }

        private static void MarquerInactif(ListItem item)
        {
            item.Attributes.Add("class", "elementInactif");
            item.Text += "*";
        }

        /// <summary>
        /// Transfert plusieurs éléments dans la liste de droite, tout en gérant les valeurs inactives.
        /// </summary>
        public void AjouterResultats<TCode>(ICollection<KeyValuePair<TCode, string>> listeElements)
        {
            AjouterResultats(listeElements.Select(e => new ListItem(e.Value.ToString(), e.Key.ToString())).ToList());
        }

        /// <summary>
        /// Transfert plusieurs éléments dans la liste de droite, tout en gérant les valeurs inactives.
        /// </summary>
        public void AjouterResultats<T>(ICollection<T> listeElements) where T: BaseEnumeration
        {
            AjouterResultats(listeElements.Select(e => new ListItem(e.Description, e.Code)).ToList());
        }

        private void AjouterResultats(ICollection<ListItem> listeElements)
        {
            _listBoxResultat.ClearSelection();
            foreach (ListItem item in listeElements)
                AjouterResultat(item);

            TrierListe(_listBoxResultat);
        }

        private void RetirerResultat(string valeur)
        {
            ListItem elementListe = _listBoxResultat.Items.FindByValue(valeur);
            bool estInactif = elementListe.Text.EndsWith("*");
            _listBoxResultat.Items.Remove(elementListe);
            if (estInactif)
            {
                _valeursInactives.Remove(valeur);
            }
            else
            {
                _listBoxDepart.Items.Add(elementListe);
            }
        }

        private void RetirerResultats(IList<string> listeValeurs)
        {
            _listBoxDepart.ClearSelection();
            foreach (string valeur in listeValeurs)
                RetirerResultat(valeur);

            TrierListe(_listBoxDepart);
        }

        private void AjusterControlPourValidateurPersonnalise()
        {
            CreerJavaScriptValidationRequis();
            Page.InclureRessourceJavascript("Edition.VaseCommuniquantAvance.js");
            _validateurPersonnalise.Visible = EstObligatoire;
            _imageEtoile.Visible = EstObligatoire;

            if (String.IsNullOrEmpty(NomChamp))
            {
                NomChamp = TitreDroite;
            }
            string msgErr = string.Format("Au moins un élément doit être présent dans la liste {0}.", NomChamp);
            _validateurPersonnalise.ToolTip = msgErr;
            _validateurPersonnalise.ErrorMessage = msgErr;

            _lblTitreResultat.Style.Add("margin-left", "8px");
            if (!EstObligatoire)
            {
                _listBoxResultat.Style.Add("margin-left", "8px");
            }
            else
            {
                _listBoxResultat.Style.Remove("margin-left");
            }
        }

        private void AjusterControlPourValidateurPersonnaliserAbsent()
        {
            _validateurPersonnalise.Visible = false;
            _imageEtoile.Visible = false;
            _listBoxResultat.Style.Remove("margin-left");
        }

        private void AjusterControles()
        {
            if (String.IsNullOrEmpty(TitreDroite))
            {
                TitreGauche = "Liste départ";
                TitreDroite = "Liste résultat";
            }

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
            _listBoxDepart.SelectionMode = ListSelectionMode.Multiple;

            _listBoxResultat.Width = LargeurListBox;
            _listBoxResultat.Height = HauteurListBox;
            _listBoxResultat.SelectionMode = ListSelectionMode.Multiple;

            _lblTitreDepart.CssClass = "sdlLibelle";
            _lblTitreResultat.CssClass = "sdlLibelle";
            _listBoxDepart.CssClass = "sdlContenu";
            _listBoxResultat.CssClass = "sdlContenu";

            _listBoxDepart.SelectedIndex = -1;

            _listBoxDepart.DataBind();
            _listBoxResultat.DataBind();
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsSelectionnes = ObtenirListeItems(_listBoxDepart)
                .Where(li => li.Selected)
                .ToList();
            if (itemsSelectionnes.Count > 0)
                AjouterResultats(itemsSelectionnes);
        }

        protected void btnRetirer_Click(object sender, EventArgs e)
        {
            List<string> itemsSelectionnes = ObtenirListeItems(_listBoxResultat)
                .Where(li => li.Selected)
                .Select(li => li.Value)
                .ToList();
            if (itemsSelectionnes.Count > 0)
                RetirerResultats(itemsSelectionnes);
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

        private TableRow ConstruireRangeCompte()
        {
            TableRow tableRowCompte = new TableRow();
            TableCell cellule = new TableCell();
            tableRowCompte.Controls.Add(cellule);
            cellule = new TableCell();
            tableRowCompte.Controls.Add(cellule);
            cellule = new TableCell();
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

        private Table ConstruireTable()
        {
            Table table = new Table();
            table.Controls.Add(ConsrtuireRangeTitre());
            table.Controls.Add(ConstruireRangeContenu());
            table.Controls.Add(ConstruireRangeCompte());
            return table;
        }

        private Panel ConstruireVaseCommuniquant()
        {
            Panel panneau = new Panel();
            panneau.Controls.Add(ConstruireTable());
            return panneau;
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

        private void CreerJavaScriptValidationRequis()
        {
            string js = @"function " + ObtenirNomFonctionJsValidation() + @"(source, args) {" +
                        @"$.ATMTECH.validerListBox(" + _listBoxResultat.Items.Count +
                        @",args);" +
                        @"}";

            Page.IncorporerJavascript(ObtenirNomFonctionJsValidation(), js);
        }

        private Image CreerRenduCelluleIndicateurObligatoire()
        {
            _imageEtoile.ImageUrl = Page.GetEncodedResourceUrl("Edition.indicateurObligatoire.gif");
            _imageEtoile.ToolTip = "Ce champ est obligatoire.";
            _imageEtoile.CssClass = "obligatoire";
            return _imageEtoile;
        }

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

        private void DefinirIdSurControls()
        {
            _listBoxDepart.ID = ID + "_lstBoxDepart";
            _listBoxResultat.ID = ID + "_lstBoxResultat";
            _boutonAjouter.ID = ID + "_btnAjouter";
            _boutonRetirer.ID = ID + "_btnRetirer";
            _lblTitreDepart.ID = ID + "_titreDepart";
            _lblTitreResultat.ID = ID + "_titreResultat";
            _image.ID = ID + "_image";
            _image.ToolTip = "Impossible d'ajouter deux fois le même item.";
        }

        /// <summary>
        /// Retourne la liste des résultats (valeurs seulement). Généralement utile lors de la sauvegarde à la base de données.
        /// </summary>
        public IList<string> ObtenirListeResultats()
        {
            List<string> list = new List<string>();
            foreach (ListItem listItem in _listBoxResultat.Items)
            {
                list.Add(listItem.Value);
            }
            return list;
        }

        protected override object SaveViewState()
        {
            ArrayList tblValeurs = new ArrayList();
            tblValeurs.Add(base.SaveViewState());
            tblValeurs.Add(LargeurListBox.ToString());
            tblValeurs.Add(HauteurListBox.ToString());
            tblValeurs.Add(TitreGauche);
            tblValeurs.Add(TitreDroite);
            tblValeurs.Add(_valeursInactives);
            return tblValeurs;
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof (ArrayList))
            {
                int i = 0;
                ArrayList tblValeurs = (ArrayList) savedState;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    LargeurListBox = Unit.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    HauteurListBox = Unit.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    TitreGauche = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    TitreDroite = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    _valeursInactives = tblValeurs[i] as ISet<string>;
            }
            else
            {
                base.LoadViewState(savedState);
            }
        }

        private string ObtenirNomFonctionJsValidation()
        {
            return "VcaValRequis" + ClientID;
        }

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
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            RafraichirStyleValeursInactives();
            AjusterControles();

            if (!(ObtenirModeAffichage() != ModeAffichage.Modification || !Enabled))
            {
                // inclure le validateur de champs obligatoire
                AjusterControlPourValidateurPersonnalise();
            }
            else
            {
                AjusterControlPourValidateurPersonnaliserAbsent();
            }

            base.OnPreRender(e);
        }

        private void RafraichirStyleValeursInactives()
        {
            foreach (string codeValeurInactive in _valeursInactives)
            {
                ListItem item = _listBoxResultat.Items.FindByValue(codeValeurInactive);
                if (item != null)
                {
                    item.Attributes.Add("class", "elementInactif");
                }
            }
        }

        private void OnValidateurServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (_listBoxResultat.Items.Count > 0);
        }

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

        private static void TrierListe(ListControl liste)
        {
            List<ListItem> items = ObtenirListeItems(liste);

            foreach (ListItem item in items)
                item.Selected = false;

            items.Sort(ComparerElements);
            liste.Items.Clear();
            liste.Items.AddRange(items.ToArray());
        }

        private static List<ListItem> ObtenirListeItems(ListControl liste)
        {
            List<ListItem> items = new List<ListItem>();
            foreach (ListItem item in liste.Items)
                items.Add(item);
            return items;
        }

        private static int ComparerElements(ListItem li1, ListItem li2)
        {
            return String.Compare(li1.Text, li2.Text);
        }
    }
}
