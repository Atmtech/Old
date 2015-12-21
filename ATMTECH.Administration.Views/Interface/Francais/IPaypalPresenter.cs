using ATMTECH.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.Administration.Views.Interface.Francais
{
    public interface IPaypalPresenter : IViewBase
    {
        PaypalReturn PaypalReturn { get; set; }
        bool PaypalReussi {set; }
    }
}
