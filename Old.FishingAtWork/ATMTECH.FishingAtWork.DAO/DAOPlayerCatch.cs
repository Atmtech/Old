using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOPlayerCatch : BaseDao<PlayerCatch, int>, IDAOPlayerCatch
    {
        public PlayerCatch GetPlayerCatch(Species species, Site site, Player player)
        {
            Criteria criteria1 = new Criteria() { Column = PlayerCatch.SITE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = site.Id.ToString() };
            Criteria criteria2 = new Criteria() { Column = PlayerCatch.SPECIES, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = species.Id.ToString() };
            Criteria criteria3 = new Criteria() { Column = PlayerCatch.PLAYER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = player.Id.ToString() };

            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            criterias.Add(criteria3);

            IList<PlayerCatch> playerCatches = GetByCriteria(criterias);
            if (playerCatches.Count > 0)
            {
                return playerCatches[0];

            }
            else
            {
                return null;
            }
        }

        public void SavePlayerCatch(PlayerCatch playerCatch)
        {
            Save(playerCatch);
        }
    }
}
