using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOMedia
    {
        IList<Media> ObtenirMedia(Expedition expedition);
    }
}
