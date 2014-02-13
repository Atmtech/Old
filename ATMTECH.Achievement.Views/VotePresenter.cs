using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;

namespace ATMTECH.Achievement.Views
{
    public class VotePresenter : BaseAccomplissementPresenter<IVotePresenter>
    {

        public VotePresenter(IVotePresenter view)
            : base(view)
        {
        }


    }
}
