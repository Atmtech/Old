using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration.Views
{
    public class LookupPresenter : BaseAdministrationPresenter<ILookupPresenter>
    {
        public LookupPresenter(ILookupPresenter view) : base(view)
        {
        }

        public IDataEditorService DataEditorService { get; set; }
        public IDAOEntityProperty DAOEntityProperty { get; set; }
        public IDAOEntityInformation DAOEntityInformation { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.EnterpriseList = DataEditorService.GetByCriteria("ATMTECH.ShoppingCart.Entities", "Enterprise", 5000, 0, "");
        }
       
    }
}
