using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.TransfertVideo.Entites;

namespace ATMTECH.TransfertVideo.DAO
{
    public class DAOFilm : BaseDao<Film, int>
    {
        public IList<Film> ObtenirListeFilm()
        {
            return GetAllActive();
        }

        public int Enregistrer(Film film)
        {
            return Save(film);
        }
    }
}
