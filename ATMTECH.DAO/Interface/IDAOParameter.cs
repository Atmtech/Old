using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOParameter
    {
        void UpdateParameter(Parameter parameter);
        Parameter GetParameter(string code, string language);
        Parameter GetParameter(string code);
    }
}
