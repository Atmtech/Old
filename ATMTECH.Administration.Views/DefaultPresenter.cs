using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration.Views
{
    public class DefaultPresenter : BaseAdministrationPresenter<IDefaultPresenter>
    {
     
        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

      

    }
}
