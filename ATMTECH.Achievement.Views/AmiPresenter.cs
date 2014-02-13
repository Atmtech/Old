using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class AmiPresenter : BaseAccomplissementPresenter<IAmiPresenter>
    {
        public AmiPresenter(IAmiPresenter view)
            : base(view)
        {
        }
    }
}
