using System.Collections.Generic;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Scrum.Services
{
    public class SprintService : BaseService, ISprintService
    {
        public IDAOSprint DaoSprint { get; set; }
        public IList<Sprint> GetSprintByProduct(int idProduct)
        {
            return DaoSprint.GetByProduct(idProduct);
        }


        public Sprint GetSprint(int idSprint)
        {
            return DaoSprint.GetSprint(idSprint);
        }

        public IList<Sprint> GetAllSprint()
        {
            return DaoSprint.GetAllSprint();
        }

        public int SaveSprint(Sprint sprint)
        {
            return DaoSprint.SaveSprint(sprint);
        }
    }
}
