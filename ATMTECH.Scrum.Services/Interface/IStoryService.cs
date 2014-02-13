using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Services.Interface
{
    public interface IStoryService
    {
        IList<Story> GetByProduct(int idProduct);
        IList<Story> GetUnlinkedStory();
        Story GetStory(int idStory);
        int SaveStory(Story story);
        Dictionary<string, string> GetListStatus();
        IList<int> GetListPoints();
    }
}
