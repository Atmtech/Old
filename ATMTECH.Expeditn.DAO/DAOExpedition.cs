using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
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
        public IDAONourritureExpedition DAONourritureExpedition { get; set; }
        public IDAOGeoLocalisation DAOGeoLocalisation { get; set; }

        public Expedition ObtenirExpedition(int id)
        {
            Expedition rtn = GetById(id);
            rtn.Participant = DAOParticipant.ObtenirParticipant(rtn);
            rtn.Materiel = DAOMateriel.ObtenirMateriel(rtn);
            rtn.Media = DAOMedia.ObtenirMedia(rtn);
            rtn.Nourriture = DAONourritureExpedition.ObtenirNourritureExpedition(rtn);
            rtn.GeoLocalisation = DAOGeoLocalisation.ObtenirGeoLocalisation(rtn.GeoLocalisation.Id);
            IList<Etape> etapes = DAOEtape.ObtenirEtape(rtn);
            if (etapes != null)
            {
                rtn.Etape = DAOEtape.ObtenirEtape(rtn).OrderBy(x => x.OrderId).ToList();
            }
            return rtn;
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
        public int Enregistrer(Expedition expedition)
        {
            return Save(expedition);
        }

        public IList<Expedition> ObtenirListeExpeditionModifiable(int idUtilisateur)
        {
            //IList<Criteria> criterias = new List<Criteria>();
            //Criteria criteriaMenu = new Criteria() { Column = Participant. PAGE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = page };
            //criterias.Add(criteriaMenu);
            //IList<TitrePage> contents = GetByCriteria(criterias);
            return null;
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