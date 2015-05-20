using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class SalesReportPresenter : BaseShoppingCartPresenter<ISalesReportPresenter>
    {
        public IOrderService OrderService { get; set; }
        public IReportService ReportService { get; set; }

        public SalesReportPresenter(ISalesReportPresenter view)
            : base(view)
        {
        }

       
    }
}
