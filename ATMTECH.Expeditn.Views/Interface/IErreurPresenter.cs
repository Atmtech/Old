using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IErreurPresenter : IViewBase
    {
       Message Message { get; set; }
        void AfficherMessage();
    }
}
