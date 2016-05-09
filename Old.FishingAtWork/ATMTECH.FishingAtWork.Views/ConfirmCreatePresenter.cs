using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class ConfirmCreatePresenter : BaseFishingAtWorkPresenter<IConfirmCreatePresenter>
    {
        public IPlayerService PlayerService { get; set; }
        public ConfirmCreatePresenter(IConfirmCreatePresenter view)
            : base(view)
        {
        }

        public void ConfirmCreate()
        {
            View.IsConfirmed = PlayerService.ConfirmCreate(View.IdConfirm);
        }
    }
}
