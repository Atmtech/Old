using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class MailPresenter : BaseFishingAtWorkPresenter<IMailPresenter>
    {
        public MailPresenter(IMailPresenter view)
            : base(view)
        {
        }

    }
}
