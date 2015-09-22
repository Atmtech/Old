using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.XWingCampaign.DAO.Interface;
using ATMTECH.XWingCampaign.Entities;

namespace ATMTECH.XWingCampaign.DAO
{
    public class DAOIntelligenceArtificiel : BaseDao<IntelligenceArtificiel, int>, IDAOIntelligenceArtificiel
    {
        public IntelligenceArtificiel ObtenirIntelligenceArtificiel(Vaisseau vaisseau, int de, string pointCardinal, string positionVaisseau)
        {

            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(IsActive());
            criterias.Add(new Criteria() { Column = IntelligenceArtificiel.VAISSEAU, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = vaisseau.Id.ToString() });
            criterias.Add(new Criteria() { Column = IntelligenceArtificiel.POSITION_VAISSEAU, Operator = DatabaseOperator.OPERATOR_LIKE, Value = positionVaisseau });
            criterias.Add(new Criteria() { Column = IntelligenceArtificiel.QUADRAN, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = pointCardinal });
            criterias.Add(new Criteria() { Column = IntelligenceArtificiel.DE_REQUIS, Operator = DatabaseOperator.OPERATOR_LIKE, Value = de.ToString() });

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = IntelligenceArtificiel.VAISSEAU, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            List<IntelligenceArtificiel> intelligenceArtificiels = GetByCriteria(criterias, pagingOperation, orderOperation).ToList();
            return intelligenceArtificiels.Count > 0 ? intelligenceArtificiels[0] : null;
        }

        public IList<IntelligenceArtificiel> ObtenirIntelligenceArtificiel(Vaisseau vaisseau)
        {
            return GetAllOneCriteria(IntelligenceArtificiel.VAISSEAU, vaisseau.Id.ToString());
        }
    }
}
