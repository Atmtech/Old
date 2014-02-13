using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    interface IDAOContent
    {
        ContentCms GetContent(string pageName, string language);
        IList<ContentCms> GetContent();

    }
}
