using System.Collections.Generic;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOContent : BaseDao<ContentCms, int>, IDAOContent
    {
        public ContentCms GetContent(string pageName, string language)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = ContentCms.PAGENAME, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = pageName };
            Criteria criteriaActive = new Criteria() { Column = BaseEntity.LANGUAGE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = language };
            criterias.Add(criteriaMenu);
            criterias.Add(criteriaActive);
            IList<ContentCms> contents = GetByCriteria(criterias);
            if (contents.Count > 0 )
            {
                return contents[0];
            }
            return null;
        }

        public IList<ContentCms> GetContent()
        {
            return GetAllActive();
        }

        public void SaveContent(ContentCms content)
        {
            Save(content);
        }
    }
}
