using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class GererRechercheForfaitExpediPresenter : BaseExpeditnPresenter<IGererRechercheForfaitExpediPresenter>
    {
        public IExpediaService ExpediaService { get; set; }


        public GererRechercheForfaitExpediPresenter(IGererRechercheForfaitExpediPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();



        }


        public void Enregistrer()
        {
            throw new System.NotImplementedException();
        }
    }
}