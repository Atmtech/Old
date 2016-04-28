using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class AdminPresenter : BaseFishingAtWorkPresenter<IAdminPresenter>
    {
        public AdminPresenter(IAdminPresenter view)
            : base(view)
        {
        }

    }
}
