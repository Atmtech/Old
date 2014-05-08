
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOLocalization : BaseDao<Localization, int>, IDAOLocalization
    {

        public IList<Localization> Localizations
        {
            get
            {
                if (ContextSessionManager.Context.Session["Localization"] == null)
                {
                    ContextSessionManager.Context.Session["Localization"] = GetAll();
                }
                return (IList<Localization>)ContextSessionManager.Context.Session["Localization"];
            }
            set
            {
                if (ContextSessionManager.Context.Session["Localization"] == null)
                    ContextSessionManager.Context.Session["Localization"] = value;
            }
        }

        public Localization GetLocalization(string objectId, string page)
        {
            Localization localization = Localizations.FirstOrDefault(x => x.ObjectId == objectId && x.Page == page) ??
                                        Localizations.FirstOrDefault(x => x.ObjectId == objectId);
            return localization;
        }


    }
}
