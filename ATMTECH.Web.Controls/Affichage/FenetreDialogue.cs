using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Classe implémentant la fenêtre de dialogie.
    /// </summary>
    [ATMTECHClientScript("ATMTECH.Web.Controls.Affichage.FenetreDialogue",
        "ATMTECH.Web.Controls.Affichage.FenetreDialogue.js")]
    [ToolboxData("<{0}:FenetreDialogue runat=server></{0}:FenetreDialogue>"), ParseChildren(false),
     PersistChildren(true)]
    public class FenetreDialogue : ATMTECHScriptBaseControle, INamingContainer, IPostBackEventHandler
    {
        #region [ Évênement ]

        private EventHandler _fermer;

        /// <summary>
        /// Évènement levé lorsque la fenêtre de dialogue est fermée.
        /// </summary>
        public event EventHandler Fermer
        {
            add { _fermer += value; }
            remove { _fermer -= value; }
        }

        /// <summary>
        /// Fermer l'évènement de dialogue.
        /// </summary>
        protected virtual void FermerDialogueEvent()
        {
            EstOuverte = false;
            if (_fermer != null)
                _fermer(this, new EventArgs());
        }

        #endregion

        #region [ Constante et membre privé ]

        private const string MESURE_PAR_DEFAULT = "auto";

        #endregion

        #region [ Propriété ]

        /// <summary>
        /// Obtient ou affecte une valeur de/à hauteur.
        /// </summary>
        /// <value>The hauteur.</value>
        [Category("Configuration"),
         Description("Détermine la hauteur de la fenêtre de dialogue, avec l'espace titre comprise."),
         DefaultValue("")]
        [ATMTECHScriptProperty("hauteur")]
        public string Hauteur
        {
            get { return (string)(ViewState["Hauteur"] ?? string.Empty); }
            set { ViewState["Hauteur"] = value; }
        }

        /// <summary>
        /// Obtient ou affecte une valeur de/à largeur (nombre en PIXELS).
        /// </summary>
        [Category("Configuration"),
         Description("Déterminer la largeur de la fenêtre de dialogue. Nombre en PIXELS."),
         DefaultValue("")]
        [ATMTECHScriptProperty("largeur")]
        public string Largeur
        {
            get { return (string)(ViewState["Largeur"] ?? string.Empty); }
            set { ViewState["Largeur"] = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Category("Configuration"),
         Description("Rend le comboBox autocomplete pour qu'il puisse s'étale plus loin que le popin"),
         DefaultValue("false")]
        public bool EstAvecAutoComplete
        {
            get { return (bool)(ViewState["estAvecAutoComplete"] ?? false); }
            set { ViewState["estAvecAutoComplete"] = value; }
        }
        /// <summary>
        /// Propriété qui affecte sa valeur à l'option "draggable" du widget dialog de jQuery. 
        /// Cette option détermine, si la fenêtre de dialogue peut-être déplacé.
        /// <see href="http://jqueryui.com/demos/dialog/#option-draggable"/>
        /// </summary>
        [Category("Configuration")]
        [ATMTECHScriptProperty("estDeplacable")]
        [DefaultValue(true)]
        public bool EstDeplacable
        {
            get { return (bool)(ViewState["EstDeplacable"] ?? true); }
            set { ViewState["EstDeplacable"] = value; } 
        }

        /// <summary>
        /// Propriété indiquant si la fenêtre est modal ou non.
        /// </summary>
        /// <value><c>vrai</c> si [est modal]; sinon, <c>faux</c>.</value>
        [Category("Configuration"),
         Description("Détermine si la fenêtre de dialogue est modal. Par défaut, la valeur est 'true'."),
         DefaultValue(true)]
        [ATMTECHScriptProperty("estModal")]
        public bool EstModal
        {
            get { return (bool)(ViewState["EstModal"] ?? true); }
            set { ViewState["EstModal"] = value; }
        }

        /// <summary>
        /// Indique si la fenêtre est ouverte ou non
        /// </summary>
        [Category("Configuration")]
        [DefaultValue(false)]
        [ATMTECHScriptProperty("estOuverte")]
        public bool EstOuverte
        {
            get { return (bool) (ViewState["EstOuverte"] ?? false); }
            private set { ViewState["EstOuverte"] = value; }
        }

        /// <summary>
        /// Ouvre la boîte de dialogue
        /// </summary>
        public void OuvrirFenetre()
        {
            OuvrirFenetre(null);
        }

        /// <summary>
        /// Ouvre la boîte de dialogue et affecte un nouveau titre
        /// </summary>
        public void OuvrirFenetre(string title)
        {
            EstOuverte = true;
            ScriptManager scriptMan = ScriptManager.GetCurrent(Page);
            if(!string.IsNullOrEmpty(title))
                Titre = title;
            if (scriptMan != null && scriptMan.IsInAsyncPostBack)
            {
                // UpdatePanel
                string js = String.Format("ATMTECH.Web.Controls.Affichage.FenetreDialogue.OuvrirDialogue('{0}', {1});",
                                          ClientID, title == null ? "null" : "'" + title.Replace("'", "\\'") + "'");
                string key = "od_" + UniqueID + (title ?? "");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), key, js, true);
            }
        }

        /// <summary>
        /// Fermer la boîte de dialogue
        /// </summary>
        public void FermerFenetre()
        {
            EstOuverte = false;
            ScriptManager scriptMan = ScriptManager.GetCurrent(Page);
            if (scriptMan != null && scriptMan.IsInAsyncPostBack)
            {
                // UpdatePanel
                string js = String.Format("ATMTECH.Web.Controls.Affichage.FenetreDialogue.FermerDialogue('{0}');",
                                          ClientID);
                string key = "fd_" + UniqueID;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), key, js, true);
            }
        }

        /// <summary>
        /// Propriété qui affecte sa valeur à l'option "title" du widget dialog de jQuery. Cette
        /// option représente le texte qui sera affiché comme titre de la fenêtre.
        /// <see href="http://jqueryui.com/demos/dialog/#option-title"/>
        /// </summary>
        [Category("Configuration"),
         Description(
             "Propriété qui affecte sa valeur à l'option \"title\" du widget dialog de jQuery. Cette  option représente le texte qui sera affiché comme titre de la fenêtre."
             ),
         DefaultValue("")]
        [ATMTECHScriptProperty("titre")]
        public string Titre 
        {
            get { return (string) (ViewState["Titre"] ?? string.Empty); }
            set { ViewState["Titre"] = value; }
        }

        /// <summary>
        /// Obtient ou affecte la valeur de/à EstRedimentionnable à savoir si la fenêtre de dialogie peut être redimentionnée ou
        /// non.
        /// </summary>
        /// <value><c>vrai</c> si [est redimentionnable]; sinon, <c>faux</c>.</value>
        [Category("Configuration"),
         Description("Propriété qui permet la redimention de la fenêtre."),
         DefaultValue(false)]
        [ATMTECHScriptProperty("estRedimentionnable")]
        public bool EstRedimentionnable
        {
            get { return (bool)(ViewState["EstRedimentionnable"] ?? false); }
            set { ViewState["EstRedimentionnable"] = value; } 
        }

        #endregion

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FenetreDialogue"/>.
        /// </summary>
        public FenetreDialogue()
        {
            Hauteur = MESURE_PAR_DEFAULT;
            // Largeur = MESURE_PAR_DEFAULT;
            EstDeplacable = true;
            EstModal = true;
            EstDeplacable = true;
        }

        #region [ Implémentation de JQueryBaseControle ]

        /// <summary>
        /// Obtenir la référence du client.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ScriptReference> ObtenirReferenceClient()
        {
            ScriptReference reference = new ScriptReference();
            reference.Assembly = "ATMTECH.Web.Controls";
            reference.Name = "ATMTECH.Web.Controls.Affichage.FenetreDialogue.js";
            return new[] { reference };
        }

        #endregion

        #region [ Méthode de Rendu ]

        /// <summary>
        /// Ajoute des attributs et des styles HTML qui doivent être rendus au <see cref="T:System.Web.UI.HtmlTextWriterTag"/> spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            string cssClass = (CssClass ?? string.Empty) + " fenetreDialogue";
            if (EstAvecAutoComplete)
            {
                cssClass += " avecAutoComplete";
            }
            writer.AddAttribute("class", cssClass.TrimStart());
            this.AjouterAttribut("name", UniqueID);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
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
        /// Génère le rendu de la balise de fermeture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        #endregion

        #region [ Implémentation IPostBackEventHandler ]

        /// <summary>
        /// Implémenté par une classe, permet à un contrôle serveur de traiter un événement déclenché lorsqu'un formulaire est publié sur le serveur.
        /// </summary>
        /// <param name="eventArgument"><see cref="T:System.String"/> qui représente un argument d'événement facultatif à passer au gestionnaire d'événements.</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            FermerDialogueEvent();
        }

        #endregion

        /// <summary>
        /// Permet de fermer la boîte de dialogue qui contient le contrôle
        /// </summary>
        /// <param name="sender">The sender.</param>
        public static void FermerDialogueParent(object sender)
        {
            Control ctlOrigine = (Control) sender;
            Control ctlCourant = ctlOrigine;
            while (ctlCourant.GetType() != typeof(FenetreDialogue))
            {
                ctlCourant = ctlCourant.Parent;
                if (ctlCourant == null)
                {
                    string msg = String.Format("Le contrôle spécifié '{0}' ne fait pas partie d'une boîte de dialogue",
                                               ctlOrigine.UniqueID);
                    throw new ArgumentException(msg);
                }
            }
            ((FenetreDialogue) ctlCourant).FermerFenetre();
        }
    }
}