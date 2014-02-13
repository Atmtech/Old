using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Barre de navigation du wizard.
    /// </summary>
    public class BarreNavigationWizard : CompositeControl
    {
        private const string COMMANDE_SUIVANT = "Suivant";
        private const string COMMANDE_PRECEDANTE = "Precedant";
        private const string COMMANDE_TERMINER = "Terminer";


        private readonly Button _suivant = new Button();
        private readonly Button _precedant = new Button();
        private readonly Button _terminer = new Button();
        private readonly Wizard _parent;


        /// <summary>
        /// Obtient la valeur <see cref="T:System.Web.UI.HtmlTextWriterTag"/> qui correspond au contrôle serveur Web. Cette propriété est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// Une des valeurs d'énumération <see cref="T:System.Web.UI.HtmlTextWriterTag"/>.
        /// </returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }    
       
        /// <summary>
        /// Retour le sélecteur jQuery du champ hidden qui persiste l'index de 
        /// l'assistant du côté client.
        /// </summary>
        protected string SelecteurJqueryIndexClient
        {
            get
            {
                return string.Concat("#", _parent.Onglets.NomEtatClient);
            }
        }

        /// <summary>
        /// Initialiste une nouvelle instance de la classe <see cref="BarreNavigationWizard"/>.
        /// </summary>
        /// <param name="parent">Le parent.</param>
        public BarreNavigationWizard(Wizard parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Obtient ou affecte une valeur du bouton de la classe CSS.
        /// </summary>
        /// <value>Le bouton de la classe CSS..</value>
        public string CssClassButton { get; set; }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _precedant.ID = "btnPrecedant";
            _precedant.CssClass = (CssClassButton ?? String.Empty) + " precedentBarreNav";
            _precedant.Click += OnButtonClick;
            _precedant.CommandName = COMMANDE_PRECEDANTE;
            _precedant.Text = "Précédent";
            _precedant.ToolTip = _precedant.Text;
            _precedant.CausesValidation = false;
            Controls.Add(_precedant);
            
            _suivant.ID = "btnSuivant";
            _suivant.CssClass = (CssClassButton ?? string.Empty) + " suivantBarreNav";
            _suivant.Click += OnButtonClick;
            _suivant.CommandName = COMMANDE_SUIVANT;
            _suivant.Text = "Suivant";
            _suivant.ToolTip = _suivant.Text;
            _suivant.CausesValidation = true;
            Controls.Add(_suivant);

            _terminer.ID = "btnTerminer";
            _terminer.CssClass = (CssClassButton ?? string.Empty) + " terminerBarreNav";
            _terminer.Click += OnButtonClick;
            _terminer.CommandName = COMMANDE_TERMINER;
            _terminer.Text = "Terminer";
            _terminer.ToolTip = _terminer.Text;
            _terminer.Visible = false;
            Controls.Add(_terminer);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button commande = sender as Button;
            if (commande != null)
            {
                switch (commande.CommandName)
                {
                    case COMMANDE_SUIVANT:
                        _parent.PoursuivreEtapeSuivante();
                        break;
                    case COMMANDE_PRECEDANTE:
                        _parent.RetournerEtapePrecedente();
                        break;
                    case COMMANDE_TERMINER:
                        _parent.TerminerAssistant();
                        break;
                    default:
                        throw new NotSupportedException("La commande désirée n'est pas supporté");
                }
            }
        }


        /// <summary>
        /// Méthode permettant d'activer la visibilité de la dernière étape.
        /// </summary>
        public void ActiverVisibiliteDerniereEtape()
        {
            _precedant.Visible = false;
            _suivant.Visible = false;
            _terminer.Visible = true;
        }

        /// <summary>
        /// Méthode permettant d'activer la visibilité d'une étape.
        /// </summary>
        public void ActiverVisibiliteEtape()
        {
            _suivant.Visible = true;
            _terminer.Visible = false;
        }

        /// <summary>
        /// Méthode permettant d'assigner un groupe de validation.
        /// </summary>
        /// <param name="groupeValidation">le groupe de validation.</param>
        public void AssignerGroupeValidation(string groupeValidation)
        {
            if (_terminer.Visible)
            {
                _terminer.ValidationGroup = groupeValidation;
            }
            else
            {
                _suivant.ValidationGroup = groupeValidation;
            }
        }

        /// <summary>
        /// Méthode permettant de changer l'accessibilité de l'étape précédante.
        /// </summary>
        /// <param name="estAccessible">if set to <c>true</c> [est accessible].</param>
        public void ChangerAccessibiliteEtapePrecedante(bool estAccessible)
        {
            _precedant.Visible = estAccessible;
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            Page.InclureRessourceJavascript("Edition.BarreNavigationWizard.js");
            // Attributs et classes CSS utilisés par le javascript.
            this.AjouterAttribut("SelecteurEtatOnglet", SelecteurJqueryIndexClient);
            this.AjouterAttribut("GroupeValidation", _suivant.ValidationGroup);
            CssClass = (CssClass ?? string.Empty) + " barreNav";
        }
    }
}
