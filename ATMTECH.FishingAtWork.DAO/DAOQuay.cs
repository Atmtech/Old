using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOQuay : BaseDao<Quay, int>, IDAOQuay
    {
        public Quay GetQuay(int id)
        {
            //Quay quay = GetById(id);
            //if (quay != null)
            //{
            //    // Just 1 level
            //    quay.Site = SiteDao.GetById(quay.Site.Id);
            //    return quay;
            //}
            return null;
        }
    }
}
