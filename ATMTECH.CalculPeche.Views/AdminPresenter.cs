using System;
using System.Linq;
using ATMTECH.CalculPeche.Services.Interface;
using ATMTECH.CalculPeche.Views.Base;
using ATMTECH.CalculPeche.Views.Interface;

namespace ATMTECH.CalculPeche.Views
{
    public class AdminPresenter : BaseCalculPechePresenter<IAdminPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }


        public AdminPresenter(IAdminPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
        
        }

 
        public void CreerExpedition(string nom, string dateDebut, string dateFin)
        {
            ExpeditionService.CreerExpedition(nom, dateDebut, dateFin);
        }
    }
}