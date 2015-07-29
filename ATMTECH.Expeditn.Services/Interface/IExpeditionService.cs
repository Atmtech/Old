using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.Services.Interface
{
    public interface IExpeditionService
    {
        Expedition ObtenirExpedition(int id);
        IList<Expedition> ObtenirExpedition();
        IList<Expedition> ObtenirMesExpedition(int idUtilisateur);
        IList<Expedition> ObtenirExpeditionTop(int nombreExpeditionPrise);
    }
}
