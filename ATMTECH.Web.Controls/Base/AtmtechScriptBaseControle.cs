using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ATMTECHScriptBaseControle : ATMTECHBaseControl, IScriptControl
    {
        #region [ Membre privé ]
        private ModeAffichage _modeAffichage = ModeAffichage.Herite;
        private ScriptManager _scriptManager;

        #endregion

        #region [ Propriétés ]

        /// <summary>
        /// Identifiant du groupe de validation qui sera affecté au contrôle enfant
        /// de ce contrôle.
        /// </summary>
        [Category("Validation")]
        [DefaultValue("")]
        public string ValidationGroup { get; set; }

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
                _modeAffichage = value;
            }
        }

        /// <summary>
        /// Méthode pour obtenir le mode d'affichage
        /// </summary>
        /// <returns>Mode d'affichage</returns>
        public ModeAffichage ObtenirModeAffichage()
        {
            if (_modeAffichage != ModeAffichage.Herite)
            {
                return _modeAffichage;
            }
            ModeAffichage modeAffichage = ModeAffichage.Herite;
            Control controlParent = this;

            while (controlParent != null && modeAffichage == ModeAffichage.Herite)
            {
                ATMTECHUserControlBase ucb = controlParent as ATMTECHUserControlBase;
                if (ucb != null)
                {
                    modeAffichage = ucb.ModeAffichage;
                }
                ATMTECHScriptBaseControle sbc = controlParent as ATMTECHScriptBaseControle;
                if (sbc != null)
                {
                    modeAffichage = sbc._modeAffichage;
                }
                ControleBase cb = controlParent as ControleBase;
                if (cb != null)
                {
                    modeAffichage = cb.ModeAffichage;
                }
                controlParent = controlParent.Parent;
            }

            if (modeAffichage == ModeAffichage.Herite)
            {
                PageBase pb = Page as PageBase;
                if (pb != null)
                {
                    //modeAffichage = pb.ModeAffichage;
                }
            }
            if (modeAffichage == ModeAffichage.Herite)
            {
                // Par défaut
                modeAffichage = ModeAffichage.Modification;
            }
            return modeAffichage;
        }

        /// <summary>
        /// Vérification si le contrôle fait parti d'un groupe de validation.
        /// </summary>
        public bool PossedeGroupeValidation
        {
            get { return !(string.IsNullOrEmpty(ValidationGroup)); }
        }

        /// <summary>
        /// Obtient le type d'obhet du client.
        /// </summary>
        /// <value>Le type d'objet du client.</value>
        public string TypeObjetClient
        {
            get
            {
                ATMTECHClientScriptAttribute clientScriptAttribute =
                    (ATMTECHClientScriptAttribute) TypeDescriptor.GetAttributes(this)[typeof (ATMTECHClientScriptAttribute)];
                return clientScriptAttribute == null ? string.Empty : clientScriptAttribute.TypeObjetClient;
            }
        }

        #endregion

        #region [ Implementation of IScriptControl ]

        /// <summary>
        /// Retourne les propriétés qui seront dans la classe javascript.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            return ObtenirDescriptionsClients();
        }

        /// <summary>
        /// Retourne les références aux scripts qui seront utilisés pour initialiser
        /// l'objet client.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScriptReference> GetScriptReferences()
        {
            return ObtenirReferenceClient();
        }

        #endregion

        #region [ Méthodes abstraites ]

        /// <summary>
        /// Obtenir la référence du client.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<ScriptReference> ObtenirReferenceClient();

        #endregion

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList tblValeurs = (ArrayList)savedState;
                base.LoadViewState(tblValeurs[0]);
                if (tblValeurs[1] != null)
                    ModeAffichage = (ModeAffichage)tblValeurs[1];
                if (tblValeurs[2] != null)
                    ValidationGroup = tblValeurs[2].ToString();
            }
            else
            {
                base.LoadViewState(savedState);
            }
        }

        /// <summary>
        /// Enregistre les états modifiés après l'appel de la méthode <see cref="M:System.Web.UI.WebControls.Style.TrackViewState"/>.
        /// </summary>
        /// <returns>
        /// Objet qui contient l'état d'affichage actuel du contrôle ; sinon, null si aucun état d'affichage n'est associé au contrôle.
        /// </returns>
        protected override object SaveViewState()
        {
            ArrayList tblValeurs = new ArrayList();
            tblValeurs.Add(base.SaveViewState());
            tblValeurs.Add(_modeAffichage);
            tblValeurs.Add(ValidationGroup);
            return tblValeurs;
        }

        /// <summary>
        /// Récupération par réflection des propriétés qui possède l'attribut ATMTECHScriptProperty. 
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<ScriptDescriptor> ObtenirDescriptionsClients()
        {
            ScriptControlDescriptor scriptControlDescriptor
                = new ScriptControlDescriptor(TypeObjetClient, ClientID);

            //Listez toutes les propriétés de l'objet.
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);

            foreach (PropertyDescriptor prop in props)
            {
                ATMTECHScriptPropertyAttribute pesaScriptPropertyAttribute =
                    (ATMTECHScriptPropertyAttribute)
                    ATMTECHControleHelper.ObtenirAttribut(prop, typeof (ATMTECHScriptPropertyAttribute));
                //Si la propriété possède l'attribut ATMTECHScriptProperty, on 
                //ajoute cette propriété à la classe version client, si et seulement si,
                //elle possède une valeur.
                if (pesaScriptPropertyAttribute != null)
                {
                    object valeur = RecupererValeurDescriptionClient(prop);

                    if (valeur != null)
                        scriptControlDescriptor.AddProperty(pesaScriptPropertyAttribute.NomProprieteClient, valeur);
                }
            }

            return new ScriptDescriptor[] {scriptControlDescriptor};
        }

        /// <summary>
        /// On enregistre notre contrôle au scriptmanager, si il est présent.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!DesignMode)
            {
                VerifierPresenceScriptManager();
                _scriptManager.RegisterScriptControl(this);
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Dans cette override, on ne fait qu'enregistrer les propriétés de 
        /// l'objet client récupérer par la méthode GetScriptDescriptors.
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!DesignMode)
                _scriptManager.RegisterScriptDescriptors(this);
            base.Render(writer);
        }

        /// <summary>
        /// Pour qu'un contrôle qui possède une version script, on doit avoir un
        /// objet scriptmanager dans notre page.
        /// </summary>
        protected void VerifierPresenceScriptManager()
        {
            if (_scriptManager == null)
            {
                _scriptManager = ScriptManager.GetCurrent(Page);
                if (_scriptManager == null)
                    throw new HttpException("Un contrôle ScriptManager doit exister dans la page courante");
            }
        }

        /// <summary>
        /// Méthode qui recupère par réflection la valeur d une propriété
        /// </summary>
        /// <param name="propriete"></param>
        /// <returns></returns>
        private object RecupererValeurDescriptionClient(PropertyDescriptor propriete)
        {
            //Si l'attribut est présent, la valeur de la propriété est un id 
            //d'un contrôle qui doit être convertit en ClientID.
            IDReferencePropertyAttribute idReferencePropertyAttribute =
                (IDReferencePropertyAttribute)
                ATMTECHControleHelper.ObtenirAttribut(propriete, typeof (IDReferencePropertyAttribute));
            return idReferencePropertyAttribute == null
                       ? propriete.GetValue(this)
                       : ATMTECHControleHelper.ConvertirControlIdEnClientId(propriete.GetValue(this), this);
        }
    }
}