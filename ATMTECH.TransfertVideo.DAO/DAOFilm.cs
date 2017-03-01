using System.Collections.Generic;
using System.Linq;
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

        public void MovieSeen(string guid)
        {
            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == guid);
            film.Visionnee = true;
            Save(film);
        }


    }
}
