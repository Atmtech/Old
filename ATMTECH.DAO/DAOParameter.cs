using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOParameter : BaseDao<Parameter, int>, IDAOParameter
    {
        public void UpdateParameter(Parameter parameter)
        {
            Save(parameter);
        }

        public Parameter GetParameter(string code)
        {
            IList<Parameter> parameters = GetAllOneCriteria(BaseEnumeration.CODE, code);
            return parameters.Count > 0 ? parameters[0] : null;
        }

        public Parameter GetParameter(string code, string language)
        {

            IList<Parameter> parameters = GetAllOneCriteria(BaseEnumeration.CODE, code);
            IList<Parameter> parametersLanguage = parameters.Where(x => x.Language == language).ToList();

            if (parametersLanguage.Count > 0)
            {
                return parametersLanguage[0];
            }

            return parameters.Count > 0 ? parameters[0] : null;


        }
    }
}
