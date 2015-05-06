using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOMedia : BaseDao<Media, int>, IDAOMedia
    {
        public IDAOFile DAOFile { get; set; }

        public IList<Media> ObtenirMedia(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Media> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                foreach (Media media     in rtn)
                {
                    media.Fichier = DAOFile.GetFile(media.Fichier.Id);
                }

                return rtn;
            }
            return null;
        }
    }
}
