using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO.Interface
{
    public interface IDAOStory
    {
        IList<Story> GetByProduct(int idProduct);
        IList<Story> GetBySprint(int idSprint);
        IList<Story> GetUnlinkedStory();
        Story GetStory(int idStory);
        int SaveStory(Story story);
    }
}
