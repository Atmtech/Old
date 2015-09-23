using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class EntrepriseService : BaseService, IEntrepriseService
    {

        public IDAOEnterprise DAOEntreprise { get; set; }

        public Enterprise ObtenirEntreprise(int id)
        {
            return DAOEntreprise.GetEnterprise(id);
        }

       public IList<Enterprise> ObtenirEntreprise()
        {
            return DAOEntreprise.GetEnterprise();
        }
    }
}

