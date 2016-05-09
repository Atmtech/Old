using System;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOTemperature : BaseDao<Temperature, int>, IDAOTemperature
    {
        public Temperature GetTemperature(int id)
        {
            Temperature temperature = GetById(id);
            //if (temperature != null)
            //{
            //    temperature.Type = EnumTemperatureTypeDao.GetById(temperature.Type.Id);
            //}
            return temperature;
        }
    }
}
