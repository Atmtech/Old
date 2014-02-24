using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Services.Interface
{
    public interface IDiscussionService
    {
        IList<Discussion> ObtenirListeDiscussion(int idUtilisateur);
        Discussion ObtenirDiscussion(int id);
        int Creer(string message);
        int AjouterCommentaire(int idDiscussion, string commentaire);
    }
}
