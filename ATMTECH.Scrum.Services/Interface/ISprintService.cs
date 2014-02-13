using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Services.Interface
{
    public interface ISprintService
    {
        IList<Sprint> GetSprintByProduct(int idProduct);
        IList<Sprint> GetAllSprint();
        Sprint GetSprint(int idSprint);
        int SaveSprint(Sprint sprint);
    }
}
