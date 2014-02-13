using ATMTECH.Atorp.Views.Base;
using ATMTECH.Atorp.Views.Interface;

namespace ATMTECH.Atorp.Views
{
    public class DefaultMasterPresenter : BaseAtorpPresenter<IDefaultMasterPresenter>
    {
        public DefaultMasterPresenter(IDefaultMasterPresenter view) : base(view)
        {
        }
    }
}
