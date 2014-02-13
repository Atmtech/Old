using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Classe implémentant le wizard.
    /// </summary>
    [ParseChildren(true, "Etapes")]
    public class Wizard : CompositeControl
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Wizard"/>.
        /// </summary>
        public Wizard()
        {
            _barreNavigation = new BarreNavigationWizard(this);
            _etapes = new EtapeCollection(this);
            _onglets = new Onglets();
            //Clef évênement
            _onNextEventKey = new object();
            _onBackEventKey = new object();
            _onCompleteEventKey = new object();
        }

        
       
        private readonly BarreNavigationWizard _barreNavigation;
        private readonly Onglets _onglets ;
        private readonly EtapeCollection _etapes;
        private readonly object _onNextEventKey;
        private readonly object _onBackEventKey;
        private readonly object _onCompleteEventKey;


        /// <summary>
        /// Levé lorsque l'on procède à l'étape suivante.
        /// </summary>
        public event EventHandler<EtapeSuivanteEventArgs> EtapeSuivante
        {
            add { Events.AddHandler(_onNextEventKey, value); }
            remove { Events.RemoveHandler(_onNextEventKey, value); }
        }

        /// <summary>
        /// Levé lorsqu'on revient à l'étape précédente.
        /// </summary>
        public event EventHandler<EtapePrecedenteEventArgs> EtapePrecedente
        {
            add { Events.AddHandler(_onBackEventKey, value); }
            remove { Events.RemoveHandler(_onBackEventKey, value); }
        }

        /// <summary>
        /// Levé lorsque l'assistant se termine.
        /// </summary>
        public event EventHandler<EtapeTermineEventArgs> AssistantTermine
        {
            add { Events.AddHandler(_onCompleteEventKey, value); }
            remove { Events.RemoveHandler(_onCompleteEventKey, value); }
        }

        /// <summary>
        /// Obtient ou affecte une valeur à l'index étape courante.
        /// </summary>
        /// <value>The index etape courante.</value>
        public int IndexEtapeCourante
        {
            get;
            
            private set;
            
        }
     
        /// <summary>
        /// 
        /// </summary>
        public EtapeCollection Etapes
        {
            get { return _etapes;}
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
          
            Page.RegisterRequiresControlState(this);
            InitOnglets();
            InitBarreNavigation(); 
        }

        private void InitOnglets()
        {
            _onglets.ID = "onglets";
            _onglets.ModeAffichageEntete = Onglets.EnumModeAffichage.Assistant;
            Controls.Add(_onglets);
            // _onglets.DesactiverOnglets = true;
        }

        /// <summary>
        /// Génère le rendu de la balise d'ouverture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            // Rien
        }

        /// <summary>
        /// Génère le rendu de la balise de fermeture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            // Rien
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (VerifierPresenceEtape())
            {
                //SelectionnerOnglet();
                ConfigurerBarreNavigation();
            }
        }

        private void ConfigurerBarreNavigation()
        {
            bool estEtapeFinal = Etapes.VerifierSiEtapeFinal();

            if (estEtapeFinal)
            {
                _barreNavigation.ActiverVisibiliteDerniereEtape();
            }
           
            _barreNavigation.ChangerAccessibiliteEtapePrecedante(
                    Etapes.VerifierEtapePrecedanteAccessible());

            string groupeValidation = Etapes.ObtenirEtapeCourante().GroupeValidation;
            if (!string.IsNullOrEmpty(groupeValidation))
            {
                _barreNavigation.AssignerGroupeValidation(groupeValidation);
            }
        }

        private void SelectionnerOnglet()
        {
            if (IndexEtapeCourante == -1)
                IndexEtapeCourante = 0;

            _onglets.Items.SelectionnerOnglet(IndexEtapeCourante);
            _onglets.AfficherOngletSelectionne();
        }

        private bool VerifierPresenceEtape()
        {
            return (Etapes.Count > 0) && (_onglets.Items.Count > 0);
        }

        private void InitBarreNavigation()
        {
            _barreNavigation.ID = "btnNav";
            _barreNavigation.CssClass = "barreAction";
            _barreNavigation.CssClassButton = "button";
            Controls.Add(_barreNavigation);
        }

        internal void ChargerOnglet(Etape value)
        {
            if (!_onglets.Items.Contains(value))
            {
                int index = Etapes.IndexOf(value);
                value.Selectionne = index == IndexEtapeCourante;
                _onglets.Items.Add(value);
            }
        }

        internal Onglets Onglets
        {
            get { return _onglets; }
        }

        /// <summary>
        /// Restaure des informations sur l'état du contrôle à partir d'une demande de page antérieure enregistrée par la méthode <see cref="M:System.Web.UI.Control.SaveControlState"/>.
        /// </summary>
        /// <param name="savedState"><see cref="T:System.Object"/> représentant l'état du contrôle à restaurer.</param>
        protected override void LoadControlState(object savedState)
        {
            if (savedState != null)
                IndexEtapeCourante = (int) savedState;
        }

        /// <summary>
        /// Enregistre les modifications éventuellement apportées à l'état du contrôle serveur depuis la publication de la page sur le serveur.
        /// </summary>
        /// <returns>
        /// Retourne l'état actuel du contrôle serveur. Si aucun état n'est associé au contrôle, cette méthode retourne null.
        /// </returns>
        protected override object SaveControlState()
        {
            return IndexEtapeCourante > -1 ? (object) IndexEtapeCourante : null;
        }

        /// <summary>
        /// Méthode permettant de poursuivre à l'étape suivante.
        /// </summary>
        public void PoursuivreEtapeSuivante()
        {
            int indexEtapeSuivante = IndexEtapeCourante + 1;

            if(Etapes.VerifierExistanteEtapeParIndex(indexEtapeSuivante))
            {
                EventHandler<EtapeSuivanteEventArgs> handler = (EventHandler<EtapeSuivanteEventArgs>)Events[_onNextEventKey];
                EtapeSuivanteEventArgs e = new EtapeSuivanteEventArgs(ObtenirUserControl(IndexEtapeCourante),
                                                                      ObtenirUserControl(indexEtapeSuivante));
                if (handler != null)
                    handler(this, e);
                //Vérifier si l'utilisateur continue avec le changement d'étape.
                if(!e.Cancel)
                {
                    IndexEtapeCourante = indexEtapeSuivante;
                }
                    
            }
            //Vu qui a eu un chargement de l'étape au préalable pour la persistance
            //nous devons chargée malgré tout l'onglet
            SelectionnerOnglet();
        }

        /// <summary>
        /// Retourne l'étape précédente.
        /// </summary>
        public void RetournerEtapePrecedente()
        {
            int indexEtapePrecedente = IndexEtapeCourante - 1;
           

            if(Etapes.VerifierExistanteEtapeParIndex(indexEtapePrecedente))
            {
                EventHandler<EtapePrecedenteEventArgs> handler = (EventHandler<EtapePrecedenteEventArgs>)Events[_onBackEventKey];
                EtapePrecedenteEventArgs e = new EtapePrecedenteEventArgs(ObtenirUserControl(IndexEtapeCourante),
                                                                          ObtenirUserControl(indexEtapePrecedente));

                if (handler != null)
                    handler(this,e);

                if (!e.Cancel)
                {
                    //Réaffiche le bouton étape suivante, si on est présentement à l'étape final.
                    if (Etapes.VerifierSiEtapeFinal())
                    {
                        _barreNavigation.ActiverVisibiliteEtape();
                    }

                    DetruireUserControl(IndexEtapeCourante);
                    IndexEtapeCourante = indexEtapePrecedente;
                    
                }
               
                
            }

            SelectionnerOnglet();

        }

        private void DetruireUserControl(int index)
        {
            Panel pnl = _onglets.FindControl(((Etape) Etapes[index])._panelId) as Panel;
            if(pnl != null)
            {
                pnl.Controls.Clear();
            }
        }

        /// <summary>
        /// Méthode permettant de terminer l'assistant.
        /// </summary>
        public void TerminerAssistant()
        {
            EventHandler<EtapeTermineEventArgs> handler = (EventHandler<EtapeTermineEventArgs>)Events[_onCompleteEventKey];
            if (handler != null)
                handler(this, new EtapeTermineEventArgs(ObtenirUserControl(IndexEtapeCourante)));
        }

        /// <summary>
        /// Obtient le contrôle usager.
        /// </summary>
        /// <param name="index">L'index.</param>
        /// <returns></returns>
        protected ATMTECHUserControlBase ObtenirUserControl(int index)
        {
            OngletElement onglet = _onglets.Items[index] as OngletElement;
            if (onglet != null)
            {
                Panel conteneur = (Panel)FindControl(onglet._panelId);
                if (conteneur.Controls.Count > 0)
                    return conteneur.Controls[0] as ATMTECHUserControlBase;
            }

            return null;
        }

        internal static string ObtenirBlocCss()
        {
            string[] cssArray = new[]
                {
                    ".debut-wiz { background-image: url(@@Edition.wizard_background_unselected.jpg@@); }",
                    ".selectionne .debut-wiz { background-image: url(@@Edition.wizard_background_selected.jpg@@); color: #ffffff; }",
                    ".fin-wiz { background-image: url(@@Edition.wizard_rightcorner_unselected_unselected.jpg@@); }",
                    ".precedent .fin-wiz { background-image: url(@@Edition.wizard_rightcorner_unselected_onselected.jpg@@); }",
                    ".selectionne .fin-wiz { background-image: url(@@Edition.wizard_rightcorner_selected.jpg@@); }",
                    ".dernier-onglet .fin-wiz { background-image: url(@@Edition.wizard_rightcorner_unselected_end.jpg@@); width: 6px; }",
                    ".dernier-onglet.selectionne .fin-wiz { background-image: url(@@Edition.wizard_rightcorner_selected_end.jpg@@); }"
                };
            return String.Join("\n", cssArray);
        }
    }
}
