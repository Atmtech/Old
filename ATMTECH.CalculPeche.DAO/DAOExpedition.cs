using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOExpedition : BaseDao<Expedition, int>, IDAOExpedition
    {
      
        public IList<Expedition> ObtenirExpedition()
        {
            return GetAllActive().ToList();
        }

        public void CreerExpedition(string nom, string dateDebut, string dateFin)
        {
            ExecuteSql(string.Format("[dbo].[spCalculPeche_CreerExpedition] @nom = '{0}', @dateDebut = '{1}', @dateFin ='{2}'", nom.Replace("'","''"), dateDebut, @dateFin) );
        }

        public int Enregistrer(Expedition expedition)
        {
            return Save(expedition);
        }
    }
}
