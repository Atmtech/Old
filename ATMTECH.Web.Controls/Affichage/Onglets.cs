using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Classe implémentant les onglets.
    /// </summary>
    [ATMTECHClientScript("ATMTECH.Web.Controls.Affichage.Onglets",
        "ATMTECH.Web.Controls.Affichage.Onglets.js")]
    [ToolboxData("<{0}:Onglets runat=server></{0}:Onglets>"), ParseChildren(true, "Items"), PersistChildren(false)]
    public class Onglets : ATMTECHScriptBaseControle, IPostBackEventHandler, IPostBackDataHandler
    {
        #region [ Membres privés ]

        private OngletElementCollection _items;
        private bool _sauvegarderViewStateOngletSelectionne;
        private int _indexOngletSelectionne;
        const string QUERYSTRING_ONGLET_SELECTIONNE = "og";

        #endregion

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresControlState(this);

            CreerControlConteneur();
            InitializationOnglet();
        }

        /// <summary>
        /// Verification dans la collection Items, si un élément est sélectionné
        /// Si 
        /// </summary>
        private void InitializationOnglet()
        {
            if (!Page.IsPostBack)
            {
                int indexSelectionne
                    = RecuperOngletParDefautInitialisation();
                if (indexSelectionne < 0 || Items.Count <= indexSelectionne)
                {
                    Items.SelectionnerOnglet(0);
                }
                else
                {
                    Items.SelectionnerOnglet(indexSelectionne);
                }

            }
            else
            {
                if (ModeAffichageEntete == EnumModeAffichage.Onglet)
                {
                    if (IndexSelectionClient != IndexSelectionChargementPrecedent)
                    {
                        ChangerParametreQueryString(IndexSelectionClient);
                        string qs = Page.Request.QueryString.ToString();
                        Page.Response.Redirect(Page.Request.AppRelativeCurrentExecutionFilePath + "?" + qs);
                    }
                    else
                    {
                        Items.SelectionnerOnglet(IndexSelectionClient);

                    }
                }
                else
                {
                    int indexSuivant = CorroborerIndexSuivantClientPourAssistant();
                    Items.SelectionnerOnglet(indexSuivant);

                    if (indexSuivant != IndexSelectionChargementPrecedent)
                        ChargerOngletAnterieur();
                }



            }

            AfficherOngletSelectionne();


        }

        /// <summary>
        /// Cette méthode vérifie, si un onglet doit-être changé via l'url. 
        /// La détection s'effectue en vérifiant si le paramètre 
        /// QUERYSTRING_ONGLET_SELECTIONNE est présent dans les paramètres
        /// du querystring.
        /// 
        /// Si le paramètre est présent, la valeur (qui est l'index de l'onglet) 
        /// sera retourné
        /// </summary>
        private int RecuperOngletParDefautInitialisation()
        {
            int index = Items.IndexOngletSelectionne();
            if (ModeAffichageEntete == EnumModeAffichage.Assistant)
            {
                return index;
            }
            string paramNavigation =
                Page.Request.QueryString[QUERYSTRING_ONGLET_SELECTIONNE];
            return !string.IsNullOrEmpty(paramNavigation) ? int.Parse(paramNavigation) : index;
        }

        private int CorroborerIndexSuivantClientPourAssistant()
        {
            int difference = IndexSelectionClient - IndexSelectionChargementPrecedent;

            return difference <= 0 ? IndexSelectionClient : IndexSelectionChargementPrecedent + 1;
        }

        #region [ Propriété ]

        /// <summary>
        /// Obtient les items de l'onglet.
        /// </summary>
        /// <value>Les items.</value>
        public OngletElementCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new OngletElementCollection();
                    if (IsTrackingViewState)
                        _items.TrackViewState();
                }
                return _items;
            }
        }

        /// <summary>
        /// Définie si l'onglet est navigable ou non
        /// </summary>
        [DefaultValue(true)]
        public bool EstNavigable { get; set; }

        internal string NomEtatClient
        {
            get { return string.Concat("__CLIENTSTATE_", ClientID); }
        }

        internal string NomEtatClientAnterieur
        {
            get { return string.Concat("__CLIENTSTATE_", ClientID, "_anterieur"); }
        }

        /// <summary>
        /// Obtient l'index sélectionnée par le client
        /// </summary>
        /// <value>The index selection client.</value>
        protected int IndexSelectionClient
        {
            get { return int.Parse(Page.Request.Form[NomEtatClient]); }
        }

        /// <summary>
        /// Retourne la valeur de l'index persister sur le client lors du dernier chargement.
        /// </summary>
        protected int IndexSelectionChargementPrecedent
        {
            get { return int.Parse(Page.Request.Form[NomEtatClientAnterieur]); }
        }

        #region [ Propriété client ]

        /// <summary>
        /// Définie si un onglet est inactif ou non.
        /// </summary>
        [ATMTECHScriptProperty("estInactifOnglets")]
        public bool EstInactifOnglets { get; set; }

        /// <summary>
        /// Obtient ou affecte une valeur de/à mode d'affichage.
        /// </summary>
        /// <value>Le mode affichage.</value>
        public virtual EnumModeAffichage ModeAffichageEntete { get; set; }

        /// <summary>
        /// Obtient ou affecte une valeur à/de l'onglet selectionné.
        /// </summary>
        /// <value>The onglet selectionne.</value>
        [ATMTECHScriptProperty("ongletSelectionne")]
        [DefaultValue(0)]
        public int OngletSelectionne
        {
            get { return Items.IndexOngletSelectionne(); }
            set
            {
                if (Items.IndexOngletSelectionne() != value)
                {
                    Items.SelectionnerOnglet(value);
                    ChargerOnglet(Items.OngletSelectionne());
                    _sauvegarderViewStateOngletSelectionne = true;
                }
            }
        }

        #endregion

        #endregion

        #region [ Évênement ]

        private EventHandler _selectionChange;

        /// <summary>
        /// Évènement levé lorsqu'on sélectionne un onglet.
        /// </summary>
        public event EventHandler SelectionOnglet
        {
            add { _selectionChange += value; }
            remove { _selectionChange -= value; }
        }

        /// <summary>
        /// Évènement appellé lorsqu'on sélectionne un onglet.
        /// </summary>
        protected virtual void OnSelectionOnglet()
        {
            
            if (_selectionChange != null)
            {
                _selectionChange(this, new EventArgs());
            }
        }

        #endregion

        #region [ Implémentation ATMTECHScriptBaseControle ]

        /// <summary>
        /// Obtenir la référence du client.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptReference> ObtenirReferenceClient()
        {
            ScriptReference reference = new ScriptReference();
            reference.Assembly = "ATMTECH.Web.Controls";
            reference.Name = "ATMTECH.Web.Controls.Affichage.Onglets.js";
            return new[] { reference };
        }

        #endregion

        #region [ Rendu ]

        /// <summary>
        /// Méthode permettant de créer le contrôle conteneur.
        /// </summary>
        protected void CreerControlConteneur()
        {
            //On vide la collection afin d'éviter des onglets doublés.
            // Controls.Clear();

            for (int x = 0; x < Items.Count; x++)
            {
                OngletElement onglet = (OngletElement)Items[x];
                Panel panel = ObtenirPanelEnfant(ObtenirIdentifiantPanel(x));
                onglet._panelClientId = panel.ClientID;
                onglet._panelId = panel.ID;
            }
        }

        /// <summary>
        /// On enregistre notre contrôle au scriptmanager, si il est présent.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (Page.IsPostBack && IndexSelectionClient != IndexSelectionChargementPrecedent)
            {
                // Nous n'avons plus besoin du contrôle de l'onglet précédent
                // (Sauf si dans un onglet et la page n'est pas valide)
                bool nouvelOngletVisible = VerifierValiditeOnglet();
                Controls[IndexSelectionClient].Visible = nouvelOngletVisible;
                Controls[IndexSelectionChargementPrecedent].Visible = !nouvelOngletVisible;
                if (ModeAffichageEntete == EnumModeAffichage.Onglet)
                {
                    if (!_items.OngletSelectionne().Enabled)
                    {
                        FindControl(_items.OngletSelectionne()._panelId).Visible = false;
                    }

                    ChangerParametreQueryString(_items.IndexOngletSelectionne());
                }
            }

            // Valider si les onglets ser   ont visible ou pas.
            foreach (OngletElement onglet in Items)
            {
                if (!onglet.Enabled)
                {
                    string js = "$(function() {";
                    js += "$('#HideOnglet" + onglet._panelId + "').hide();";
                    js += "});";
                    Page.IncorporerJavascript("HideOnglet" + onglet._panelId, js);
                }
            }

            if (ModeAffichageEntete == EnumModeAffichage.Assistant)
                AjouterCssConteneur();
            ScriptManager.RegisterHiddenField(this, NomEtatClientAnterieur, SauvegarderEtatClient());
            ScriptManager.RegisterHiddenField(this, NomEtatClient, SauvegarderEtatClient());
            Page.RegisterRequiresPostBack(this);

            base.OnPreRender(e);
        }

        // Permet d'éviter l'exception si la validation n'a pas eu lieu 
        // (bouton Précédent du wizard)
        private bool VerifierValiditeOnglet()
        {
            if (ModeAffichageEntete == EnumModeAffichage.Onglet)
            {
                return true;
            }
            bool pageValide = true;
            try
            {
                pageValide = Page.IsValid;
            }
            catch (HttpException)
            {
            }
            return pageValide;
        }

        private void ChangerParametreQueryString(int indexOngletSelectionne)
        {
            // reflect to readonly property 
            PropertyInfo isReadOnly = typeof(NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

            // make collection editable 
            isReadOnly.SetValue(Page.Request.QueryString, false, null);
            if (string.IsNullOrEmpty(Page.Request.QueryString[QUERYSTRING_ONGLET_SELECTIONNE]))
            {
                Page.Request.QueryString.Add(QUERYSTRING_ONGLET_SELECTIONNE, indexOngletSelectionne.ToString());
            }
            else
            {
                Page.Request.QueryString.Set(QUERYSTRING_ONGLET_SELECTIONNE, indexOngletSelectionne.ToString());
            }


            // make collection readonly again 
            isReadOnly.SetValue(Page.Request.QueryString, true, null);
        }

        /// <summary>
        /// Méthode qui ajoute les classes css pour le mode d'affichage 
        /// assistant.
        /// </summary>
        private void AjouterCssConteneur()
        {
            foreach (OngletElement t in Items)
            {
                Panel conteneur = FindControl(t._panelId) as Panel;
                if (conteneur != null)
                {
                    conteneur.CssClass = t.Selectionne
                                             ? "ui-tabs-panel ui-widget-content ui-corner-bottom"
                                             : "ui-tabs-panel ui-widget-content ui-corner-bottom ui-tabs-hide";
                }
            }
        }

        private string SauvegarderEtatClient()
        {
            return OngletSelectionne.ToString();
        }

        /// <summary>
        /// Ajoute des attributs et des styles HTML qui doivent être rendus au <see cref="T:System.Web.UI.HtmlTextWriterTag"/> spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
            writer.AddAttribute("id", ClientID);
            this.AjouterAttribut("name", UniqueID);
        }

        /// <summary>
        /// Génère le rendu de la balise d'ouverture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }

        /// <summary>
        /// Génère le rendu du contenu du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Items.Count > 0)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                foreach (OngletElement t in Items)
                {
                    OngletElement onglet = t;

                    if (ModeAffichageEntete == EnumModeAffichage.Onglet)
                    {
                        RendreOnglet(writer, onglet);
                    }
                    else
                    {
                        RenderOngletWizard(writer, (Etape)t);
                    }


                }
                writer.RenderEndTag();

                RenderChildren(writer);
            }
        }

        private string ObtenirClasseEtape(Etape onglet)
        {
            List<string> classesCss = new List<string> { "wizard" };
            if (onglet.Selectionne)
            {
                classesCss.Add("selectionne");
            }
            else if (VerifierSiSuivantEstSelectionne(onglet))
            {
                classesCss.Add("precedent");
            }
            if (onglet.TypeSequence == EnumTypeSequence.Fin)
            {
                classesCss.Add("dernier-onglet");
            }
            return String.Join(" ", classesCss.ToArray());
        }

        private bool VerifierSiSuivantEstSelectionne(OngletElement onglet)
        {
            int indexSuivant = _items.IndexOf(onglet) + 1;
            return indexSuivant < _items.Count && ((OngletElement)_items[indexSuivant]).Selectionne;
        }

        /// <summary>
        /// Construit le rendu de l'onglet pour la section de navigation
        /// </summary>
        /// <param name="writer">
        /// Composante d'écriture du rendu
        /// </param>
        /// <param name="onglet">
        /// Onglet pour lequel le rendu sera crée.
        /// </param>
        protected void RendreOnglet(HtmlTextWriter writer, OngletElement onglet)
        {
            writer.WriteBeginTag("li id='HideOnglet" + onglet._panelId);
            writer.Write("'>");

            writer.WriteBeginTag("a");
            writer.WriteAttribute("href", string.Format("#{0}", ObtenirPanelEnfant(onglet._panelId).ClientID));
            writer.Write(">");

            HttpUtility.HtmlEncode(onglet.Titre, writer);
            writer.WriteEndTag("a");

            writer.WriteEndTag("li");



        }

        private void RenderOngletWizard(HtmlTextWriter writer, Etape etape)
        {
            writer.WriteBeginTag("li");
            writer.WriteAttribute("class", ObtenirClasseEtape(etape));
            writer.Write(">");
            writer.Write("<span class='debut-wiz'>");
            writer.Write(etape.Titre);
            writer.Write("</span><span class='fin-wiz'></span>");
            writer.WriteEndTag("li");
        }

        private string ObtenirIdentifiantPanel(int indexOnglet)
        {
            return string.Concat(ID, "_div", indexOnglet.ToString());
        }

        private Panel ObtenirPanelEnfant(string id)
        {
            Panel contenant = (Panel)FindControl(id);

            if (contenant == null)
            {
                contenant = new Panel();
                contenant.ID = id;
                Controls.Add(contenant);
            }

            return contenant;
        }

        /// <summary>
        /// Génère le rendu de la balise de fermeture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        #endregion

        /// <summary>
        /// Méthode permettant d'afficher l'onglet sélectionné.
        /// </summary>
        public void AfficherOngletSelectionne()
        {
            OngletElement onglet = Items.OngletSelectionne();
            _indexOngletSelectionne = Items.IndexOf(onglet);

            if (onglet != null && !string.IsNullOrEmpty(onglet._panelId))
            {
                Panel conteneur = (Panel)FindControl(onglet._panelId);

                if (conteneur.Controls.Count <= 0)
                {
                    ATMTECHUserControlBase ctrl = ChargerOnglet(onglet);
                    conteneur.Controls.Add(ctrl);
                }
            }

            if (ModeAffichageEntete == EnumModeAffichage.Onglet
                && !Page.IsPostBack)
            {
                OnSelectionOnglet();
            }
        }

        /// <summary>
        /// Méthode permettant de charger l'onglet antérieur.
        /// </summary>
        protected void ChargerOngletAnterieur()
        {
            OngletElement onglet = Items[IndexSelectionChargementPrecedent] as OngletElement;

            if (onglet == null)
                return;

            if (!string.IsNullOrEmpty(onglet._panelId))
            {
                Panel conteneur = (Panel)FindControl(onglet._panelId);

                if (conteneur.Controls.Count <= 0)
                {
                    ATMTECHUserControlBase ctrl = ChargerOnglet(onglet);
                    conteneur.Controls.Add(ctrl);
                }
            }
        }

        /// <summary>
        /// Obtenir le contrôle usager courant.
        /// </summary>
        /// <returns></returns>
        public virtual ATMTECHUserControlBase ObtenirUserControlCourant()
        {
            OngletElement onglet = Items.OngletSelectionne();
            if (onglet != null)
            {
                Panel conteneur = (Panel)FindControl(onglet._panelId);
                if (conteneur.Controls.Count > 0)
                    return conteneur.Controls[0] as ATMTECHUserControlBase;
            }

            return null;

        }

        public virtual OngletElement ObtenirOngletCourant()
        {
            return Items.OngletSelectionne();
        }

        /// <summary>
        /// Méthode permettant de changer l'onglet.
        /// </summary>
        /// <param name="ongletElement">L'élément dans l'onglet.</param>
        /// <returns></returns>
        protected ATMTECHUserControlBase ChargerOnglet(OngletElement ongletElement)
        {
            ATMTECHUserControlBase usrCtrl = (ATMTECHUserControlBase)Page.LoadControl(ongletElement.Contenu);
            usrCtrl.ID = "uc" + Items.IndexOf(ongletElement);
            return usrCtrl;
        }

        #region [ Implement of IPostBackEventHandler ]

        /// <summary>
        /// Implémenté par une classe, permet à un contrôle serveur de traiter un événement déclenché lorsqu'un formulaire est publié sur le serveur.
        /// </summary>
        /// <param name="eventArgument"><see cref="T:System.String"/> qui représente un argument d'événement facultatif à passer au gestionnaire d'événements.</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "selectionChange":
                    OnSelectionOnglet();
                    AfficherOngletSelectionne();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Amène le contrôle à suivre les modifications apportées à son état d'affichage afin qu'elles puissent être stockées dans la propriété <see cref="P:System.Web.UI.Control.ViewState"/> de l'objet.
        /// </summary>
        protected override void TrackViewState()
        {
            base.TrackViewState();
            Items.TrackViewState();
        }

        /// <summary>
        /// Enregistre les états modifiés après l'appel de la méthode <see cref="M:System.Web.UI.WebControls.Style.TrackViewState"/>.
        /// </summary>
        /// <returns>
        /// Objet qui contient l'état d'affichage actuel du contrôle ; sinon, null si aucun état d'affichage n'est associé au contrôle.
        /// </returns>
        protected override object SaveViewState()
        {
            object x = base.SaveViewState();
            object y = Items.SaveViewState();
            object z = null;
            if (_sauvegarderViewStateOngletSelectionne)
            {
                z = OngletSelectionne;
            }

            if (((x == null) && (y == null)) && (z == null))
            {
                return null;
            }


            return new Triplet(x, y, z);
        }

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                Triplet triplet = (Triplet)savedState;
                base.LoadViewState(triplet.First);
                Items.LoadViewState(triplet.Second);

                if (triplet.Third != null)
                {
                    int index = (int)triplet.Third;
                    OngletSelectionne = index;
                }
            }
            else
            {
                base.LoadViewState(null);
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
            return _indexOngletSelectionne;
        }

        /// <summary>
        /// Restaure des informations sur l'état du contrôle à partir d'une demande de page antérieure enregistrée par la méthode <see cref="M:System.Web.UI.Control.SaveControlState"/>.
        /// </summary>
        /// <param name="savedState"><see cref="T:System.Object"/> représentant l'état du contrôle à restaurer.</param>
        protected override void LoadControlState(object savedState)
        {
            if (savedState != null)
                _indexOngletSelectionne = (int)savedState;
            Items.SelectionnerOnglet(_indexOngletSelectionne);
            AfficherOngletSelectionne();
        }

        #region Implementation of IPostBackDataHandler

        /// <summary>
        /// Implémenté par une classe, traite les données de publication pour un contrôle serveur ASP.NET.
        /// </summary>
        /// <param name="postDataKey">Identificateur de clé pour le contrôle.</param>
        /// <param name="postCollection">Collection de toutes les valeurs de nom entrantes.</param>
        /// <returns>
        /// true si l'état du contrôle serveur a été modifié à la suite d'une publication ; sinon false.
        /// </returns>
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            if (!string.IsNullOrEmpty(postCollection[NomEtatClient]))
            {
                OngletSelectionne = int.Parse(postCollection[NomEtatClient]);
            }
            return true;
        }

        /// <summary>
        /// Implémenté par une classe, demande au contrôle serveur d'avertir l'application ASP.NET du changement d'état du contrôle.
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            //           OnSelectionOnglet();
        }

        #endregion

        /// <summary>
        /// Enum pour les mode d'affichage de l'onglet.
        /// </summary>
        public enum EnumModeAffichage
        {
            /// <summary>
            /// Mode Onglet.
            /// </summary>
            Onglet,
            /// <summary>
            /// Mode assistant.
            /// </summary>
            Assistant
        }
    }
}
