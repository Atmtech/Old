using ATMTECH.BillardLoretteville.Views.Base;
using ATMTECH.BillardLoretteville.Views.Interface;
using ATMTECH.Common.Constant;

namespace ATMTECH.BillardLoretteville.Views
{
    public class BillardLorettevillePresenter : BaseBillardLorettevillePresenter<IBillardLorettevillePresenter>
    {
        public BillardLorettevillePresenter(IBillardLorettevillePresenter view)
            : base(view)
        {
            CurrentLanguage = LocalizationLanguage.FRENCH;
        }
    }
}
