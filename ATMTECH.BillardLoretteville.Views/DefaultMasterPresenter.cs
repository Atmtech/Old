using ATMTECH.BillardLoretteville.Views.Base;
using ATMTECH.BillardLoretteville.Views.Interface;

namespace ATMTECH.BillardLoretteville.Views
{
    public class DefaultMasterPresenter : BaseBillardLorettevillePresenter<IDefaultMasterPresenter>
    {
        public DefaultMasterPresenter(IDefaultMasterPresenter view) : base(view)
        {
        }
    }
}
