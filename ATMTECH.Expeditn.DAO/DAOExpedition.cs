                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      using System.Collections;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOExpedition : BaseDao<Expedition, int>, IDAOExpedition
    {
        public IDAOParticipant DAOParticipant { get; set; }
        public IDAOMateriel DAOMateriel { get; set; }
        public IDAOMedia DAOMedia { get; set; }
        public IDAOEtape DAOEtape { get; set; }
        public IDAONourriture DAONourriture { get; set; }

        public Expedition ObtenirExpedition(int id)
        {

            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Expedition> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                rtn[0].Participant = DAOParticipant.ObtenirParticipant(rtn[0]);
                rtn[0].Materiel = DAOMateriel.ObtenirMateriel(rtn[0]);
                rtn[0].Media = DAOMedia.ObtenirMedia(rtn[0]);
                rtn[0].Nourriture = DAONourriture.ObtenirNourriture(rtn[0]);
                IList<Etape> etapes = DAOEtape.ObtenirEtape(rtn[0]);
                if (etapes != null)
                {
                    rtn[0].Etape = DAOEtape.ObtenirEtape(rtn[0]).OrderBy(x => x.OrderId).ToList();    
                }
                
                return rtn[0];
            }
            return null;
        }


        public IList<Expedition> ObtenirExpeditionTop(int nombreExpeditionPrise)
        {
            List<Expedition> expeditions = GetAllActive().Where(x => x.EstPrive == false).OrderByDescending(x => x.DateCreated).Take(nombreExpeditionPrise).ToList();
            return RemplirColonneExpedition(expeditions);
        }

        public IList<Expedition> ObtenirExpedition()
        {
            List<Expedition> expeditions = GetAllActive().Where(x => x.EstPrive == false).ToList();
            return RemplirColonneExpedition(expeditions);
        }

        private IList<Expedition> RemplirColonneExpedition(List<Expedition> expeditions)
        {
            foreach (Expedition expedition in expeditions)
            {
                expedition.Participant = DAOParticipant.ObtenirParticipant(expedition);
                expedition.Media = DAOMedia.ObtenirMedia(expedition);
            }
            return expeditions;
        }
    }
}                                                    