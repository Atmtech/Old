using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.Services.Interface
{
    public interface IExpeditionService
    {
        Expedition ObtenirExpedition(int id);
    }
}
