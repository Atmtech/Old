using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Classe qui permet de créer qui permet de créer des colonnes personnalisés
    /// plus aisément via programmation.
    /// </summary>
    public class TemplateBouton : ITemplate
    {
        private const string FONCT_JS_CONFIRMATION_SUPPRESSION =
            "return ConfirmerSuppression(\"{0}\")";

        private readonly ModeBouton _modeBouton;
        private readonly ModeBouton _modeColonne; // Mode de la colonne, pour le bouton Ajouter
        private readonly GrilleAvance _grilleParent;

        internal const string NOM_BOUTON_AJOUTER = "btnFenetreAjout";
        internal const string NOM_BOUTON_CONSULTER = "btnConsulterRow";
        internal const string NOM_BOUTON_SUPPRIMER = "btnSupprimerRow";
        internal const string NOM_BOUTON_MODIFIER = "btnModifierRow";

        /// <summary>
        /// Retourne le mode du bouton.
        /// </summary>
        internal ModeBouton Mode
        {
            get { return _modeBouton; }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TemplateBouton"/>.
        /// Constructeur pour les boutons Supprimer, Modifier et Consulter, ainsi que
        /// Ajouter de la table vide (EmptyDataTemplate).
        /// </summary>
        /// <param name="modeBouton">Le type de bouton à créeer.</param>
        /// <param name="grilleParent">La grille qui contient ce bouton.</param>
        public TemplateBouton(ModeBouton modeBouton,
                              GrilleAvance grilleParent)
        {
            _modeBouton = modeBouton;
            _grilleParent = grilleParent;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TemplateBouton"/>.
        /// Constructeur pour le bouton Ajouter, en en-tête de colonne. Permet de préciser
        /// la colonne où se trouve le bouton. Ceci nous permet de cacher les boutons
        /// dont nous n'avons pas besoin, chaque colonne contenant à l'origine un bouton
        /// en en-tête. Cette logique se trouvait avant dans le PreRender de GrilleAvance,
        /// mais cela causait des "bindings" inutiles lorsqu'on intervenait sur
        /// HeaderTemplate.
        /// </summary>
        public TemplateBouton(ModeBouton modeBouton,
                              GrilleAvance grilleParent,
                              ModeBouton modeColonne) : this(modeBouton, grilleParent)
        {
            _modeColonne = modeColonne;
        }


        #region ITemplate Membres

        /// <summary>
        /// Implémenté par une classe, définit l'objet <see cref="T:System.Web.UI.Control"/> auquel les contrôles enfants et les modèles appartiennent. Ces contrôles enfants sont à leur tour définis dans un modèle inline.
        /// </summary>
        /// <param name="container">Objet <see cref="T:System.Web.UI.Control"/> qui contiendra les instances de contrôles en provenance du modèle inline.</param>
        public void InstantiateIn(Control container)
        {
            Control ctrl;

            switch (_modeBouton)
            {
                case ModeBouton.Consulter:
                    ctrl = CreerBoutonConsulter();
                    break;
                case ModeBouton.Ajouter:
                    ctrl = CreerBoutonAjouter();
                    break;
                case ModeBouton.AjouterSansDonnee:
                    ctrl = CreerNoDataBoutonAjouter();
                    break;
                case ModeBouton.Supprimer:
                    ctrl = CreerBoutonSupprimer();
                    break;
                case ModeBouton.Modifier:
                    ctrl = CreerBoutonModifier();
                    break;
                default:
                    throw new InvalidOperationException("mode"); 
            }

            if (ctrl != null)
                container.Controls.Add(ctrl);
        }

        private Control CreerBoutonAjouter()
        {
            if (_grilleParent.ActiverBoutonAjout && CalculerColonneBoutonAjout() == _modeColonne)
            {
                string id = NOM_BOUTON_AJOUTER + _modeColonne;
                return CreerBoutonAjouter(id);
            }
            return null;
        }

        // On détermine sur quelle colonne doit se trouver le bouton Ajouter.
        private ModeBouton CalculerColonneBoutonAjout()
        {
            if (_grilleParent.EstAfficheColonneSuppression)
            {
                return ModeBouton.Supprimer;
            }
            if (_grilleParent.EstAfficheColonneEdition)
            {
                return ModeBouton.Modifier;
            }
            if (_grilleParent.EstAfficheColonneConsulter)
            {
                return ModeBouton.Consulter;
            }
            return ModeBouton.Ajouter;
        }

        private Image CreerBoutonAjouter(string id)
        {
            ImageButton imgBouton =
                CreerBouton(id, _grilleParent.BoutonsEditionAsynchrones && !_grilleParent.Detail.EstAvecAutoComplete,
                            _grilleParent.ToolTipBoutonAjout, "Ajouter", "ajouter.png");
            imgBouton.CommandName = GrilleAvance.AJOUTER_BOUTON_COMMAND;
            return imgBouton;
        }

        private Control CreerBoutonConsulter()
        {
            ImageButton imageButton = CreerBouton(NOM_BOUTON_CONSULTER, _grilleParent.EstBoutonConsulterAsynchrone,
                                                  _grilleParent.ToolTipBoutonConsulter, "Consulter", "consulter.png");
            imageButton.CommandName = GrilleAvance.CONSULTER_BOUTON_COMMAND;
            if (_grilleParent.EstRangeeCliquable || _grilleParent.EstMaitreDetail)
                imageButton.CssClass = "gvBtnSelect " + imageButton.ID;
            return imageButton;
        }

        private Control CreerBoutonSupprimer()
        {
            ImageButton imageButton = CreerBouton(NOM_BOUTON_SUPPRIMER, false, _grilleParent.ToolTipBoutonSupprimer,
                                                  "Supprimer", "supprimer.gif");
            imageButton.CommandName = "Delete";

            if (!string.IsNullOrEmpty(_grilleParent.MessageConfirmationSuppression))
            {
                imageButton.OnClientClick =
                    string.Format(FONCT_JS_CONFIRMATION_SUPPRESSION,
                                  _grilleParent.MessageConfirmationSuppression);
            }

            return imageButton;
        }

        private Control CreerBoutonModifier()
        {
            ImageButton imageButton =
                CreerBouton(NOM_BOUTON_MODIFIER,
                            _grilleParent.BoutonsEditionAsynchrones && !_grilleParent.Detail.EstAvecAutoComplete,
                            _grilleParent.ToolTipBoutonEdition, "Modifier", "edition.png");
            imageButton.CommandName = GrilleAvance.MODIFIER_BOUTON_COMMAND;
            if (_grilleParent.EstRangeeCliquable || (_grilleParent.EstMaitreDetail && !_grilleParent.EstMaitreDetailLegacy))
                imageButton.CssClass = "gvBtnSelect " + imageButton.ID;
            return imageButton;
        }

        private ImageButton CreerBouton(string idBouton, bool asynchrone, string tooltip, string tooltipParDefaut, string nomImage)
        {
            Page pageCourante = HttpContext.Current.CurrentHandler as Page;
            ImageButton imageButton = new ImageButton();
            string id = idBouton;
            imageButton.ID = id;
            imageButton.CausesValidation = false;
            imageButton.ToolTip = String.IsNullOrEmpty(tooltip) ? tooltipParDefaut : tooltip;
            imageButton.ImageUrl = pageCourante.GetResourceUrl("Grille." + nomImage);
            if (asynchrone)
            {
                if (pageCourante != null)
                {
                    ScriptManager sm = ScriptManager.GetCurrent(pageCourante);
                    if (sm != null)
                    {
                        sm.RegisterAsyncPostBackControl(imageButton);
                    }
                }
            }
            return imageButton;
        }

        /// <summary>
        /// Méthode permettant de créer le bouton ajouter quand il n'y a pas de données.
        /// </summary>
        /// <returns></returns>
        private Control CreerNoDataBoutonAjouter()
        {
            Label lblText = new Label();
            Panel pnlConteneur = new Panel();
            pnlConteneur.ID = "pnlNoData";
            lblText.Style.Add("padding-right", "5px");
            lblText.Text = _grilleParent.MessageAucuneDonnee;
            lblText.ID = "lblNoData";
            pnlConteneur.CssClass = "GridViewSansDonnee";
            pnlConteneur.Controls.Add(lblText);
            Image img = CreerBoutonAjouter(NOM_BOUTON_AJOUTER);
            pnlConteneur.Controls.Add(img);
            img.PreRender -= NoDataBoutonAjouter_PreRender;
            img.PreRender += NoDataBoutonAjouter_PreRender;
            return pnlConteneur;
        }

        // La gestion de la présence ou non du bouton dans EmptyDataTemplate s'avère
        // finalement assez compliquée...
        private void NoDataBoutonAjouter_PreRender(object sender, EventArgs e)
        {
            Control senderControl = sender as Control;

            if (_grilleParent.ActiverBoutonAjout && _grilleParent.ObtenirModeAffichage() == ModeAffichage.Modification)
            {
                senderControl.Visible = true;
            }
            else
            {
                senderControl.Visible = false;
            }
        }

        #endregion

        /// <summary>
        /// Enum pour les modes du bouton
        /// </summary>
        public enum ModeBouton
        {
            /// <summary>
            /// Mode consulter
            /// </summary>
            Consulter,
            /// <summary>
            /// Mode supprimer.
            /// </summary>
            Supprimer,
            /// <summary>
            /// Mode ajouter.
            /// </summary>
            Ajouter,
            /// <summary>
            /// Mode modifier.
            /// </summary>
            Modifier,
            /// <summary>
            /// Mode ajouter sans donnée
            /// </summary>
            AjouterSansDonnee
        }
    }
}