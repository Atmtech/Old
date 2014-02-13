using ATMTECH.Entities;
using WebFormsMvp;

namespace ATMTECH.Views.Interface
{
    public interface IViewBase : IView
    {
        void ShowMessage(Message message);
    }
}
