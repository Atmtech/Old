using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOTemperature
    {
        Temperature GetTemperature(int id);
    }
}
