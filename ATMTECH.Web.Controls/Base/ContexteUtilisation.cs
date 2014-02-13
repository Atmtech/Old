namespace ATMTECH.Web.Controls.Base
{
    ///<summary>
    /// Contexte d'utilisation d'un contrôle. Permet de modifier le
    /// comportement des boutons (et éventuellement d'autres contrôles)
    /// en fonction de leur contexte.
    ///</summary>
    public enum ContexteUtilisation
    {
        ///<summary>
        /// Contrôle directement sur la page
        ///</summary>
        Page,
        ///<summary>
        /// Contrôle dans une FenetreDialogue (autre que GrilleAvance)
        ///</summary>
        FenetreDialogue,
        ///<summary>
        /// Contrôle dans la fenêtre de la grille, en mode Modification
        ///</summary>
        GrilleModification,
        /// <summary>
        /// Contrôle dans la fenêtre de la grille, en mode Ajout
        /// </summary>
        GrilleAjout
    }
}
