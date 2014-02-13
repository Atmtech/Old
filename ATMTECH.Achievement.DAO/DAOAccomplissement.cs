using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;

namespace ATMTECH.Achievement.DAO
{
    public class DAOAccomplissement : BaseDao<Accomplissement, int>, IDAOAccomplissement
    {
        public IDAOCategorie DAOCategorie { get; set; }
        public IDAOFile DAOFile { get; set; }
        public IDAOAccomplissementTrait DAOAccomplissementTrait { get; set; }

        public IList<Accomplissement> ObtenirAccomplissementActifParCategorie(int idCategorie)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaCategorie = new Criteria { Column = Accomplissement.CATEGORIE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idCategorie.ToString() };
            criterias.Add(criteriaCategorie);
            criterias.Add(IsActive());
            IList<Accomplissement> accomplissements = GetByCriteria(criterias);
            foreach (Accomplissement accomplissement in accomplissements)
            {
                accomplissement.Categorie = DAOCategorie.ObtenirParId(accomplissement.Categorie.Id);
                accomplissement.Image = DAOFile.GetFile(accomplissement.Image.Id);
                accomplissement.AccomplissementTraits = DAOAccomplissementTrait.ObtenirTousActivePourAccomplissement(accomplissement.Id);
            }

            return accomplissements;
        }

        public IList<Accomplissement> ObtenirTousActive()
        {
            return GetAllActive();
        }

        public Accomplissement ObtenirAccomplissement(int id)
        {
            Accomplissement accomplissement = GetById(id);
            accomplissement.Categorie = DAOCategorie.ObtenirParId(accomplissement.Categorie.Id);
            accomplissement.Image = DAOFile.GetFile(accomplissement.Image.Id);
            accomplissement.AccomplissementTraits = DAOAccomplissementTrait.ObtenirTousActivePourAccomplissement(accomplissement.Id);
            return accomplissement;
        }

        public int Enregistrer(Accomplissement accomplissement)
        {
            return Save(accomplissement);
        }
    }
}
