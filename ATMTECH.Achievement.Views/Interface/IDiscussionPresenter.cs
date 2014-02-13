using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Achievement.Views.Interface
{
    public interface IDiscussionPresenter : IViewBase
    {
        IList<Discussion> Discussions { set; }
        string Commentaire {get;}
        string IdDiscussion { get;  set; }
    }
}
