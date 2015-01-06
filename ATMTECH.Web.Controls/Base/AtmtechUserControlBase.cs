using System;
using System.Linq;
using System.Web.UI;
using ATMTECH.Web.Controls.Interfaces;
using ATMTECH.Web.Controls.Utils;
using ATMTECH.Web.Controls.Validation;
using WebFormsMvp.Web;


namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Classe de base que doivent hériter tous les UserControles qui seront
    /// utilisés par ATMTECHOnglets et ATMTECHFenetreDialogue.
    /// </summary>
    [ToolboxData("<{0}:ATMTECHUserControlBase runat=server></{0}:ATMTECHUserControlBase>")]
    public class ATMTECHUserControlBase : MvpUserControl, IControleAvecModeAffichage
    {
        public object EntiteContextuelleVersion
        {
            get { return ViewState["_PageBase_EntiteContextuelleVersion"]; }
            set { ViewState["_PageBase_EntiteContextuelleVersion"] = value; }
        }

        public object EntiteContextuelleId
        {
            get { return ViewState["_PageBase_EntiteContextuelleId"]; }
            set { ViewState["_PageBase_EntiteContextuelleId"] = value; }
        }

        /// <summary>
        /// Id de l'objet utilisé pour la sécurité.
        /// </summary>
        [Obsolete("Utiliser l'ID dans le markup HTML pour les onglets et l'ID de IViewIdentifiant pour les pages")]
        public string IdObjetSecurite { get; set; }

        /// <summary>
        /// Permet d'obtenir le mode d'affichage du contrôle, sans aller voir dans les parents.
        /// </summary>
        public ModeAffichage ModeAffichageControle
        {
            get { return ViewState["ModeAffichage"] == null ? ModeAffichage.Herite : (ModeAffichage)ViewState["ModeAffichage"]; }
        }

        public void OuvrirUrl(string url)
        {
            WebUtils.OuvrirUrl(this, url);
        }

        /// <summary>
        /// Gère le mode d'affichage.
        /// </summary>
        /// <value>Le mode d'affichage.</value>  
        public ModeAffichage ModeAffichage
        {
            get
            {
                return ObtenirModeAffichage();
            }
            set
            {
                ViewState["ModeAffichage"] = value;
            }
        }

        private ModeAffichage ObtenirModeAffichage()
        {
            return ATMTECHControleHelper.ObtenirModeAffichage(this);
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public ATMTECHUserControlBase()
        {
            AutoDataBind = false;
        }

        #region IViewBase Membres




        /// <summary>
        /// Permet d'afficher un rapport à partir d'un URL construit par RapportUtils.
        /// </summary>
        /// <param name="url">L'URL du rapport.</param>
        public void AfficherRapport(string url)
        {
          //  PageBase.AfficherRapport(Page, url);
        }



       
        #endregion
    }
}