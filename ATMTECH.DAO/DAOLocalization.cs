
using System.Collections.Generic;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOLocalization : BaseDao<Localization, int>, IDAOLocalization
    {
        public Localization GetLocalization(string objectId, string page)
        {
            if (!string.IsNullOrEmpty(objectId))
            {
                IList<Localization> localizations;
                var criterias = GetLocalizationWithPage(objectId, page, out localizations);
                if (localizations != null)
                {
                    if (localizations.Count > 0)
                    {
                        return localizations[0];
                    }
                    else
                    {
                        var localizationsSansPage = GetLocalizationWithoutPage(objectId);
                        return localizationsSansPage.Count > 0 ? localizationsSansPage[0] : null;
                    }
                }
            }
            return null;
        }

        private IList<Localization> GetLocalizationWithoutPage(string objectId)
        {
            IList<Criteria> criteriasSansPage = new List<Criteria>();
            Criteria criteriaObjectIdSansPage = new Criteria()
                                                    {
                                                        Column = Localization.OBJECTID,
                                                        Operator = DatabaseOperator.OPERATOR_EQUAL,
                                                        Value = objectId
                                                    };
            criteriasSansPage.Add(criteriaObjectIdSansPage);
            IList<Localization> localizationsSansPage = GetByCriteria(criteriasSansPage);
            return localizationsSansPage;
        }

        private IList<Criteria> GetLocalizationWithPage(string objectId, string page, out IList<Localization> localizations)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaObjectId = new Criteria()
                                            {
                                                Column = Localization.OBJECTID,
                                                Operator = DatabaseOperator.OPERATOR_EQUAL,
                                                Value = objectId
                                            };
            Criteria criteriaPage = new Criteria() { Column = Localization.PAGE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = page };
            criterias.Add(criteriaObjectId);
            criterias.Add(criteriaPage);
            localizations = GetByCriteria(criterias);
            return criterias;
        }
    }
}
