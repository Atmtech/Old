using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOAddress : BaseDao<Address, int>, IDAOAddress
    {
        public IList<Address> Addresses
        {
            get
            {
                if (ContextSessionManager.Context.Session["Addresses"] == null)
                {
                    ContextSessionManager.Context.Session["Addresses"] = GetAll();
                }
                return (IList<Address>)ContextSessionManager.Context.Session["Addresses"];
            }
            set
            {
                if (ContextSessionManager.Context.Session["Addresses"] == null)
                    ContextSessionManager.Context.Session["Addresses"] = value;
            }
        }

        public Address GetAddress(int id)
        {
            Address address = Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null)
            {
                ContextSessionManager.Context.Session["Addresses"] = GetAll();
                address = Addresses.FirstOrDefault(x => x.Id == id);
            }
            return address;
        }

        public int SaveAdress(Address address)
        {
            ContextSessionManager.Context.Session["Addresses"] = null;
            return Save(address);
        }

        public Address FindAddress(Address address)
        {
            IList<Address> addresses = Addresses.Where(x => x.Way == address.Way || x.PostalCode == address.PostalCode || x.Country == address.Country || x.City == address.City).ToList();
            return addresses.Count > 0 ? addresses[0] : null;
        }
    }
}
