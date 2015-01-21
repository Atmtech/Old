using System;
using System.Collections.Generic;
using ATMTECH.Mediator.Entities;

namespace ATMTECH.Mediator.WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        private GestionPresentation _gestionPresentation;

        public GestionPresentation GestionPresentation
        {
            get
            {
                return _gestionPresentation ??
                       (_gestionPresentation =
                        new GestionPresentation {});
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GestionPresentation.Panel = UpdatePanel1;
            IList<Clavardage> clavardages = GestionPresentation.AfficherClavardage();
            //if (clavardages != null)
            //{
            //    foreach (Clavardage clavardage in clavardages.Where(clavardage => !GestionPresentation.EstCommande(clavardage.Texte)))
            //    {
            //        //if (PlatformInvocationService.IsActive(Handle) == false) FlashWindow.Flash(this, 3);
            //    }
            //}
        }
    }
}