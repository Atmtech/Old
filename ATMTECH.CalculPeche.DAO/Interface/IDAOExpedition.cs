using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOExpedition
    {
       
        IList<Expedition> ObtenirExpedition();

        void CreerExpedition(string nom, string dateDebut, string dateFin);
        int Enregistrer(Expedition expedition);
    }
}
