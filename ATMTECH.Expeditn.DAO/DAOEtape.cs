using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOEtape : BaseDao<Etape, int>, IDAOEtape
    {
        public IDAOEtapeParticipant DAOEtapeParticipant { get; set; }
        public IDAOVehicule DAOVehicule { get; set; }

        public IList<Etape> ObtenirEtape(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Etape.EXPEDITION, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Etape> rtn = GetByCriteria(criterias);
            IList<Vehicule> obtenirVehicule = DAOVehicule.ObtenirVehicule();
            foreach (Etape etape in rtn)
            {
                etape.Expedition = expedition;
                etape.EtapeParticipant = DAOEtapeParticipant.ObtenirEtapeParticipant(etape);
                etape.Vehicule = obtenirVehicule.FirstOrDefault(x => x.Id == etape.Vehicule.Id);
            }
            return rtn.Count > 0 ? rtn : null;
        }


        public int Enregistrer(Etape etape)
        {
            return Save(etape);
        }
    }
}
