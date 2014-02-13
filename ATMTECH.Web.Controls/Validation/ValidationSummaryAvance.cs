using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Validation
{
    /// <summary>
    /// Contrôle maison pour l'affichage des messages de validations, 
    /// informationnels et de confirmation.
    /// </summary>
    [ToolboxData("<{0}:ValidationSummaryAvance runat=server></{0}:ValidationSummaryAvance>")]
    public class ValidationSummaryAvance : ValidationSummary
    {
        #region [ Ctor ]

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ValidationSummaryAvance"/>.
        /// </summary>
        public ValidationSummaryAvance()
        {
            Messages.MessageErreurAjoute += Messages_MessageErreurAjoute;
        }

        private void Messages_MessageErreurAjoute(object sender, EventArgs e)
        {
            RequiredFieldValidator bidon = new RequiredFieldValidator();
            bidon.IsValid = false;
            bidon.ValidationGroup = "Bidon";
            Page.Validators.Add(bidon);
        }

        #endregion

        #region[ Membres privés ]

        private MessageCollection _messages;

        private string[] ValidationGroups
        {
            get
            {
                return string.IsNullOrEmpty(ValidationGroup) ? new[] {""} : ValidationGroup.Split(SeparateurValidationGroup);
            }
        }

        private bool _possedeCssErreur;

        private bool _aVerifieGroupValidationParDefaut;

        //Balises de rendu
        private const string BALISE_CONTENEUR_MSG_BEGIN = "<ul>";
        private const string BALISE_CONTENEUR_MSG_END = "</ul>";
        private const string BALISE_MSG_CSS_BEGIN = "<li class=\"{0}\">";
        private const string BALISE_MSG_ATTENTION_BEGIN = "<li style=\"color:Navy;\">";
        private const string BALISE_MSG_END = "</li>";
        private const string CLASS_CSS_DEFAULT = "val-summary";
        private const string CLASS_CSS_MSG_ERR_DEFAULT = "val-summary-msg-erreur";
        private const string CLASS_CSS_MSG_SUCCES_DEFAULT = "val-summary-msg-succes";

        #endregion

        #region [ Propriétés ]

        /// <summary>
        /// Retourne Faux si le VSA n'est pas visible à l'écran
        /// </summary>
        public bool EstVisible()
        {
            bool visible = true;
            Control courant = this;
            while(courant != null && courant != courant.Parent)
            {
                if (!courant.Visible)
                {
                    visible = false;
                    break;
                }
                FenetreDialogue fen = courant as FenetreDialogue;
                if (fen != null && !fen.EstOuverte)
                {
                    visible = false;
                    break;
                }
                courant = courant.Parent;
            }
            return visible;
        }

        /// <summary>
        /// Nom de la classe css qui sera appliqué au message de catégorie
        /// "message d'attention".
        /// </summary>
        [Description("Nom de la classe css qui sera appliqué au message de catégorie \"message d'attention\".")]
        [Category("Appearance")]
        [CssClassProperty]
        public string CssClassMessageAttention
        {
            get
            {
                if (ViewState["CssClassMessageAttention"] == null)
                    return string.Empty;
                return (string) ViewState["CssClassMessageAttention"];
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ViewState["CssClassMessageAttention"] = value;
                }
            }
        }

        /// <summary>
        /// Nom de la classe css qui sera appliqué au message de catégorie 
        /// "message de confirmation".
        /// </summary>
        [Description("Nom de la classe css qui sera appliqué au message de catégorie \"message de confirmation\".")]
        [Category("Appearance")]
        [CssClassProperty]
        public string CssClassMessageConfirmation
        {
            get
            {
                if (ViewState["CssClassMessageConfirmation"] == null)
                    return string.Empty;
                return (string) ViewState["CssClassMessageConfirmation"];
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ViewState["CssClassMessageConfirmation"] = value;
                }
            }
        }

        /// <summary>
        /// Nom de la classe css qui sera appliqué au message de catégorie 
        /// "message de succès".
        /// </summary>
        [Description("Nom de la classe css qui sera appliqué au message de catégorie \"message de succès\".")]
        [Category("Appearance")]
        [CssClassProperty]
        public string CssClassMessageDeSucces
        {
            get
            {
                if (ViewState["CssClassMessageDeSucces"] == null)
                    return CLASS_CSS_MSG_SUCCES_DEFAULT;
                return (string) ViewState["CssClassMessageDeSucces"];
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ViewState["CssClassMessageDeSucces"] = value;
                }
            }
        }

        /// <summary>
        /// Nom de la classe css qui sera appliqué au message de catégorie 
        /// "message d'erreur".
        /// </summary>
        [Description("Nom de la classe css qui sera appliqué au message de catégorie \"message d'erreur\".")]
        [Category("Appearance")]
        [CssClassProperty]
        public string CssClassMessageErreur
        {
            get
            {
                if (ViewState["CssClassMessageErreur"] == null)
                    return CLASS_CSS_MSG_ERR_DEFAULT;
                return (string) ViewState["CssClassMessageErreur"];
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ViewState["CssClassMessageErreur"] = value;
                    _possedeCssErreur = true;
                }
            }
        }

        /// <summary>
        /// Indiquateur EstPrincipalSommaire
        /// </summary>
        /// <value>
        /// 	<c>Vrai</c> si [est principal sommaire]; autrement, <c>faux</c>.
        /// </value>
        [Category("Behavior")]
        [Description("Indicateur que le control est celui qui est générale à la page.")]
        public bool EstPrincipalSommaire
        {
            get
            {
                if (ViewState["EstPrincipalSommaire"] == null)
                    return false;
                return (bool) ViewState["EstPrincipalSommaire"];
            }
            set { ViewState["EstPrincipalSommaire"] = value; }
        }

        /// <summary>
        /// Indique que le ValidationSummaryAvance (VSA) servira à afficher les messages
        /// à l'intérieur d'un UserControl. Un appel à View.AfficherMessage pour un
        /// UserControl (ATMTECHUserControlBase) utilisera alors ce VSA pour l'affichage.
        /// </summary>
        public bool EstSommaireUserControl
        {
            get
            {
                if (ViewState["EstSommaireUserControl"] == null)
                    return false;
                return (bool)ViewState["EstSommaireUserControl"];
            }
            set { ViewState["EstSommaireUserControl"] = value; }
        }

        /// <summary>
        /// Obtient les messages.
        /// </summary>
        /// <value>Les messages.</value>
        public MessageCollection Messages
        {
            get { return _messages ?? (_messages = new MessageCollection()); }
        }

        /// <summary>
        /// SeparateurValidationGroup
        /// </summary>
        /// <value>Le séparateur de validation.</value>
        [Category("Behavior")]
        [DefaultValue(',')]
        public char SeparateurValidationGroup
        {
            get
            {
                if (ViewState["SeparateurValidationGroup"] == null)
                    return ',';
                return (char) ViewState["SeparateurValidationGroup"];
            }
            set { ViewState["SeparateurValidationGroup"] = value; }
        }

        #endregion

        #region [ Méthode protégé ]

        /// <summary>
        /// Compte le nombre de Valideur invalide
        /// </summary>
        /// <param name="validationGroup">Le groupe de validation.</param>
        /// <returns></returns>
        protected int CompterValidateurInvalide(string validationGroup)
        {
            int compte = 0;
            ValidatorCollection validators =
                RechercherControleValidation(validationGroup);

            for (int i = 0; i < validators.Count; i++)
            {
                if (VerifierPresenceMessage(validators[i]))
                {
                    compte++;
                }
            }

            return compte;
        }

        /// <summary>
        /// Obtient les messages attention
        /// </summary>
        /// <param name="enAttention">: Si = <c>vrai</c>alors [en attention].</param>
        /// <returns></returns>
        protected string[] ObtenirMessagesAttention(out bool enAttention)
        {
            string[] messageAttention = null;

            enAttention = false;

            IList<Message> listMsgAttention = Messages.RechercherMessageAttention();
            int nombreMessageAttention = listMsgAttention.Count;

            if (nombreMessageAttention > 0)
            {
                messageAttention = new string[nombreMessageAttention];

                for (int i = 0; i < nombreMessageAttention; i++)
                {
                    messageAttention[i] = listMsgAttention[i].ToString();
                }

                enAttention = true;
            }

            return messageAttention;
        }

        /// <summary>
        /// Obtient le message d'erreur.
        /// </summary>
        /// <param name="enErreur">: Si = <c>vrai</c>alors [en erreur].</param>
        /// <returns></returns>
        protected string[] ObtenirMessagesErreurs(out bool enErreur)
        {
            string[] messageErreurs = null;
            ArrayList groupeValidationAvecMessage = null;
            int nombreValidateurInvalide = 0;
            enErreur = false;

            if (ValidationGroups.Length > 0)
            {
                groupeValidationAvecMessage = new ArrayList();

                //Pour chacun des groupes de validations, on décompte le nombre
                //de validateur qui est invalide.
                foreach (string t in ValidationGroups)
                {
                    int compte = CompterValidateurInvalide(t);

                    if (compte > 0)
                    {
                        groupeValidationAvecMessage.Add(t);
                    }

                    if (string.IsNullOrEmpty(t))
                        _aVerifieGroupValidationParDefaut = true;
                    nombreValidateurInvalide += compte;
                }

                // Dans le cas de multiple groupe de validation.
                //TODO : Refactoring possible ici.
                if (!_aVerifieGroupValidationParDefaut && EstPrincipalSommaire)
                {
                    int compte = CompterValidateurInvalide(string.Empty);

                    if (compte > 0)
                    {
                        groupeValidationAvecMessage.Add(string.Empty);
                    }

                    nombreValidateurInvalide += compte;
                }
            }

            int nombreMessageErreur = nombreValidateurInvalide + Messages.CompterMessageErreur();

            if (nombreMessageErreur != 0)
            {
                messageErreurs = new string[nombreMessageErreur];
                int indexMessageErreur = 0;

                if (nombreValidateurInvalide > 0)
                {
                    if (groupeValidationAvecMessage != null)
                        foreach (object t in groupeValidationAvecMessage)
                        {
                            ValidatorCollection validators = RechercherControleValidation(
                                (string) t);

                            for (int j = 0; j < validators.Count; j++)
                            {
                                if (VerifierPresenceMessage(validators[j]))
                                {
                                    messageErreurs[indexMessageErreur]
                                        = validators[j].ErrorMessage;
                                    indexMessageErreur++;
                                }
                            }
                        }
                }

                if (nombreMessageErreur > 0)
                {
                    IList<Message> msgErrs = Messages.RechercherMessageErreur();
                    foreach (Message t in msgErrs)
                    {
                        if (VerifierPresenceMessage(t))
                        {
                            messageErreurs[indexMessageErreur]
                                = t.ToString();
                            indexMessageErreur++;
                        }
                    }
                }

                //Change l'état de l'indicateur d'erreur.
                enErreur = true;
            }
            return messageErreurs;
        }

        /// <summary>
        /// Obtient le message de succes.
        /// </summary>
        /// <param name="estSucces">: Si = <c>vrai</c> alors [est succes].</param>
        /// <returns></returns>
        protected string[] ObtenirMessagesSucces(out bool estSucces)
        {
            string[] messageSucces = null;

            estSucces = false;

            IList<Message> listMsgSucces = Messages.RechercherMessageSucces();
            int nombreMessageSucces = listMsgSucces.Count;

            if (nombreMessageSucces > 0)
            {
                messageSucces = new string[nombreMessageSucces];

                for (int i = 0; i < nombreMessageSucces; i++)
                {
                    messageSucces[i] = listMsgSucces[i].ToString();
                }

                estSucces = true;
            }

            return messageSucces;
        }

        /// <summary>
        /// Recherche le contrôle de validation.
        /// </summary>
        /// <param name="validationGroup">Le groupe de validation.</param>
        /// <returns></returns>
        protected ValidatorCollection RechercherControleValidation(string validationGroup)
        {
            return Page.GetValidators(validationGroup);
        }

        /// <summary>
        /// Vérifie si le message est vide ou non.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <returns></returns>
        protected bool VerifierPresenceMessage(Message message)
        {
            if (message == null)
                return false;

            return !string.IsNullOrEmpty(message.ToString());
        }

        /// <summary>
        /// Vérifie la présence d'un message du validateur.
        /// </summary>
        /// <param name="validator">Le validateur.</param>
        /// <returns></returns>
        protected bool VerifierPresenceMessage(IValidator validator)
        {
            if (validator == null)
                return false;

            return (!validator.IsValid &&
                    !string.IsNullOrEmpty(validator.ErrorMessage));
        }

        #endregion

        #region [ Méthodes de rendu ]

        /// <summary>
        /// Méthode permettant d'ajouter des attributs à la classe CSS.
        /// </summary>
        protected void AjouterAttributs()
        {
            if (EstPrincipalSommaire)
            {
                this.AjouterAttribut("estPrincipalSommaire", EstPrincipalSommaire.ToString());
            }

            //if (_possedeCssErreur)
            this.AjouterAttribut("cssClassErreur", CssClassMessageErreur);
            this.AjouterAttribut("separateurValidationGroup", SeparateurValidationGroup.ToString());
        }


        /// <summary>
        /// Méthode permettant d'écrire le message attention
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <param name="writer">le writer.</param>
        protected void EcrireMessageAttention(string message, TextWriter writer)
        {
            if (_possedeCssErreur)
            {
                writer.Write(BALISE_MSG_CSS_BEGIN, CssClassMessageAttention);
            }
            else
            {
                writer.Write(BALISE_MSG_ATTENTION_BEGIN);
            }

            writer.Write(message);

            writer.Write(BALISE_MSG_END);
        }

        /// <summary>
        /// Méthode permettant d'écrire le message d'erreur
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <param name="writer">Le writer.</param>
        protected void EcrireMessageErreur(string message, TextWriter writer)
        {
            //if (_possedeCssErreur)
            //{
            writer.Write(BALISE_MSG_CSS_BEGIN, CssClassMessageErreur);
            //}
            //else
            //{
            //    writer.Write(BALISE_MSG_ERR_BEGIN);
            //}

            writer.Write(message);

            writer.Write(BALISE_MSG_END);
        }

        /// <summary>
        /// Ecrirele message de succès.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <param name="writer">Le writer.</param>
        protected void EcrireMessageSucces(string message, TextWriter writer)
        {
            //if (_possedeCssSucces)
            //{
            writer.Write(BALISE_MSG_CSS_BEGIN, CssClassMessageDeSucces);
            //}
            //else
            //{
            //    writer.Write(BALISE_MSG_SUCCES_BEGIN);
            //}

            writer.Write(message);

            writer.Write(BALISE_MSG_END);
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e"><see cref="T:System.EventArgs"/> qui contient les données de l'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.InclureRessourceJavascript("Validation.ValidationSummaryAvance.js");
            EnregistrerClassCss();
        }

        private void EnregistrerClassCss()
        {
            if (string.IsNullOrEmpty(CssClass))
                CssClass = CLASS_CSS_DEFAULT;
        }

        internal static string ObtenirBlocCss()
        {
            string[] cssArray = new[]
                {
                    "." + CLASS_CSS_MSG_ERR_DEFAULT + " { list-style-image: url(@@Validation.indicateurErreur.png@@); }",
                    "." + CLASS_CSS_MSG_SUCCES_DEFAULT + " { list-style-image: url(@@Validation.checkVert.png@@); }"
                };
            return String.Join("\n", cssArray);
        }

        /// <summary>
        /// Envoie le contenu du contrôle serveur à un objet <see cref="T:System.Web.UI.HtmlTextWriter"/> fourni, qui écrit le contenu à rendre sur le client.
        /// </summary>
        /// <param name="writer">Flux de sortie qui génère le rendu du contenu HTML sur le client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            string[] msgErrs;
            bool estAffiche;

            string[] msgAttentions;
            string[] msgSucces;

            if (DesignMode)
            {
                //Création de message d'erreur 'fake' pour démontrer le layout.
                msgErrs = new[]
                              {
                                  "Message design 1 (XX00001S)",
                                  "Message design 2 (XX00002S)"
                              };
                msgSucces = new []
                                {
                                    "Succès 1 (XX00001C)"
                                };
                msgAttentions = new []
                                    {
                                        "Message d'avertissement (XX00023I)"
                                    };
                estAffiche = true;
            }
            else
            {
                bool enErreur;
                bool enSucces;
                bool enAttention;

                if (!Enabled)
                    return;

                msgSucces = ObtenirMessagesSucces(out enSucces);
                msgErrs = ObtenirMessagesErreurs(out enErreur);
                msgAttentions = ObtenirMessagesAttention(out enAttention);
                estAffiche = (ShowSummary && (enErreur) || enSucces || enAttention);
            }
            if (!estAffiche)
                Style["display"] = "none";

            //Vérification si la page contient une balise FORM.
            if (Page != null)
            {
                Page.VerifyRenderingInServerForm(this);
            }

            AjouterAttributs();

            RenderBeginTag(writer);

            if (HeaderText.Length > 0)
            {
                writer.Write("<span>{0}</span>", HeaderText);
                writer.WriteBreak();
            }

            if (estAffiche)
            {
                writer.Write(BALISE_CONTENEUR_MSG_BEGIN);
                if (msgSucces != null)
                {
                    foreach (string t in msgSucces)
                    {
                        EcrireMessageSucces(t, writer);
                    }
                }

                if (msgAttentions != null)
                {
                    foreach (string t in msgAttentions)
                    {
                        EcrireMessageAttention(t, writer);
                    }
                }

                if (msgErrs != null)
                {
                    foreach (string t in msgErrs)
                    {
                        EcrireMessageErreur(t, writer);
                    }
                }
                writer.Write(BALISE_CONTENEUR_MSG_END);
            }

            RenderEndTag(writer);
        }

        #endregion
    }
}