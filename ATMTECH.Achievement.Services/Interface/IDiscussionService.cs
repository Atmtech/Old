using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Services.Interface
{
    public interface IDiscussionService
    {
        IList<Discussion> ObtenirDiscussion(int idUtilisateur);
        int Creer(Discussion discussion);
    }
}
