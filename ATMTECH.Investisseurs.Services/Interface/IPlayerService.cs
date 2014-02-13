
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.Services.Interface
{
    public interface IPlayerService
    {
        Player AuthenticatePlayer { get; }
        Player GetPlayer(int id);
    }
}
