using System;
using System.Web.UI;

namespace ATMTECH.Web.Controls.Validation
{
    /// <summary>
    /// Classe  de la structure de message qui sera affiché par le 
    /// contrôle ValidationSummaryAvance.
    /// </summary>
    public class Message : IStateManager
    {
        #region [ Membres privés]

        private const string GABARIT_DE_RENDU_PAR_DEFAUT = "{0} ({1})";
        private string _gabaritDeRendu;

        #endregion

        #region [ Propriétés ]

        /// <summary>
        /// Contenu du message à afficher par la vue.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Numéro de la règle d'affaire auquel le message se rapporte.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Gabarit représentant le format d'affichage du message lorsque l'on
        /// doit afficher le numéro et le texte.
        /// </summary>
        public string GabaritDeRendu
        {
            get
            {
                if (string.IsNullOrEmpty(_gabaritDeRendu))
                    _gabaritDeRendu = GABARIT_DE_RENDU_PAR_DEFAUT;
                return _gabaritDeRendu;
            }
            set { _gabaritDeRendu = value; }
        }

        /// <summary>
        /// Indicateur d'affichage du numéro de la règle d'affaire avec le 
        /// texte. Par défaut l'assignation est à 'true'.
        /// </summary>
        public bool AfficheNumero
        {
            get { return !string.IsNullOrEmpty(Numero); }
        }

        /// <summary>
        /// Indicateur de persistance du message entre les aller-retours de 
        /// la vue. Par défaut l'assignation est à 'false'.
        /// </summary>
        public bool EstPersistant { get; set; }

        /// <summary>
        /// Catégorie que se retrouve le message, ce qui déterminera sa 
        /// disposition lors de l'affichage.
        /// </summary>
        public EnumCategorieMessage Categorie { get; set; }

        #endregion

        #region [ Override Methode ]

        /// <summary>
        /// Représentation d'un message en chaîne de caractères.
        /// </summary>
        /// <returns>
        /// Le texte a affiché par la vue.
        /// </returns>
        public override string ToString()
        {
            return AfficheNumero ? string.Format(GabaritDeRendu, Text, Numero) : Text;
        }

        #endregion

        /// <summary>
        /// Implémenté par une classe, charge dans un contrôle serveur son état d'affichage précédemment enregistré.
        /// </summary>
        /// <param name="state"><see cref="T:System.Object"/> qui contient les valeurs d'état d'affichage enregistrées du contrôle.</param>
        public void LoadViewState(object state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implémenté par une classe, enregistre les modifications de l'état d'affichage d'un contrôle serveur dans un <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// 	<see cref="T:System.Object"/> qui contient les changements de l'état d'affichage.
        /// </returns>
        public object SaveViewState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implémenté par une classe, commande au contrôle serveur d'effectuer le suivi des modifications de son état d'affichage.
        /// </summary>
        public void TrackViewState()
        {
            EstPersistant = true;
        }

        /// <summary>
        /// Implémenté par une classe, obtient une valeur indiquant si un contrôle serveur effectue le suivi des changements de son état d'affichage.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// true si le contrôle serveur effectue le suivi des changements de son état d'affichage ; sinon, false.
        /// </returns>
        public bool IsTrackingViewState
        {
            get { return EstPersistant; }
        }
    }
}