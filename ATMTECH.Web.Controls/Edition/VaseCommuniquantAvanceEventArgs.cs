using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Argument des évênements lancés par le "usercontrol" SelectionDoubleListe.
    /// </summary>
    public class VaseCommuniquantAvanceEventArgs
    {
        private readonly bool _permetDoublons;
        private readonly int _indexSelectionne;
        private readonly string _texteSelectionne;
        private readonly string _valeurSelectionne;
        private readonly string _messageErreur;
        private readonly bool _valeurEnDoublons;
        private readonly IList<ListItem> _listeSelection;

        /// <summary>
        /// Constructeur qui initialise l'evenement
        /// </summary>
        /// <param name="permetDoublons"></param>
        /// <param name="indexSelectionne"></param>
        /// <param name="texteSelectionne"></param>
        /// <param name="valeurSelectionne"></param>
        /// <param name="messageErreur"></param>
        /// <param name="valeurEnDoublons"></param>
        public VaseCommuniquantAvanceEventArgs(bool permetDoublons,
                                              int indexSelectionne,
                                           string texteSelectionne,
                                           string valeurSelectionne,
                                           string messageErreur,
                                             bool valeurEnDoublons)
        {
            _permetDoublons = permetDoublons;
            _indexSelectionne = indexSelectionne;
            _valeurEnDoublons = valeurEnDoublons;
            _texteSelectionne = texteSelectionne;
            _valeurSelectionne = valeurSelectionne;
            _messageErreur = messageErreur;
            _listeSelection = new List<ListItem> { new ListItem(texteSelectionne, valeurSelectionne) };
        }

        /// <summary>
        /// Constructeur qui initialise l'evenement
        /// </summary>
        /// <param name="permetDoublons"></param>
        /// <param name="listeSelection"></param>
        /// <param name="messageErreur"></param>
        /// <param name="valeurEnDoublons"></param>
        public VaseCommuniquantAvanceEventArgs(bool permetDoublons,
                                           IList<ListItem> listeSelection,
                                               string messageErreur,
                                             bool valeurEnDoublons)
        {
            _permetDoublons = permetDoublons;
            _indexSelectionne = -1;
            _valeurEnDoublons = valeurEnDoublons;
            _listeSelection = listeSelection;
            _messageErreur = messageErreur;
        }

        /// <summary>
        /// Index de l'élément sélectionné.
        /// </summary>
        public int IndexSelectionne
        {
            get { return _indexSelectionne; }
        }

        /// <summary>
        /// Texte de l'élément sélectionné.
        /// </summary>
        public string TexteSelectionne
        {
            get { return _texteSelectionne; }
        }
        /// <summary>
        /// Indicateur qui 
        /// </summary>
        public bool PermetDoublons
        {
            get { return _permetDoublons; }
        }

        /// <summary>
        /// Valeur de l'élément sélectionné.
        /// </summary>
        public string ValeurSelectionne
        {
            get { return _valeurSelectionne; }
        }

        /// <summary>
        /// Message d'erreur
        /// </summary>
        public string MessageErreur
        {
            get { return _messageErreur; }
        }

        /// <summary>
        /// Liste des valeurs sélectionnées (EstSelectionMultiple = true)
        /// </summary>
        public IList<ListItem> ListeSelection
        {
            get { return _listeSelection; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ValeurEnDoublons
        {
            get { return _valeurEnDoublons; }
        }
    }
}
