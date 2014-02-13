namespace ATMTECH.Web.Controls.Base
{
    ///<summary>
    /// Mode d'affichage
    ///</summary>
    public enum ModeAffichage
    {
        ///<summary>
        /// Mode modification
        ///</summary>
        Modification,
        ///<summary>
        /// Mode consultation
        ///</summary>
        Consultation,
        ///<summary>
        /// Mode approbation
        ///</summary>
        Approbation,
        /// <summary>
        /// Prendre le mode du premier parent qui en contient un
        /// </summary>
        Herite
    }
}
