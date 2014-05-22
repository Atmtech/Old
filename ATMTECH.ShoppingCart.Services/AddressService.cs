using System;
using System.Collections.Generic;
using ATMTECH.Common.Context;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public IDAOCity DAOCity { get; set; }
        public IDAOCountry DAOCountry { get; set; }
        public IDAOAddress DAOAddress { get; set; }


        public Address GetAddress(int id)
        {
            if (id != 0)
            {
                Address address = DAOAddress.GetAddress(id);
                if (address != null)
                {
                    if (address.Country != null)
                    {
                        address.Country = GetCountry(address.Country.Id);    
                    }
                    if (address.City != null)
                    {
                        address.City = DAOCity.GetCity(address.City.Id);
                    }
                    
                    return address;
                }
            }
            return null;
        }
        public City FindCity(string cityName)
        {
            return DAOCity.FindCity(cityName);
        }
        public Country GetCountry(int id)
        {
            return DAOCountry.GetCountry(id);
        }
        public int CreateCity(City city)
        {
            return DAOCity.CreateCity(city);
        }
        public IList<Country> GetAllCountries()
        {
            IList<Country> countries = DAOCountry.GetAllCountries();
            Country country = new Country();
            for (int i = 0; i < countries.Count; i++)
            {
                if (countries[i].Code == "CAN")
                {
                    country = countries[i];
                    countries.RemoveAt(i);
                    break;
                }
            }
            countries.Insert(0, country);
            return countries;
        }
        public Address FindAddress(Address address)
        {
            return DAOAddress.FindAddress(address);
        }
        public IList<Address> GetShippingAddress(Customer customer)
        {
            IList<Address> addresses = customer.Enterprise.ShippingAddress;
            if (!customer.Enterprise.IsDontAddPersonnalAddress)
            {
                if (customer.ShippingAddress != null)
                {
                    addresses.Add(customer.ShippingAddress);
                }
            }
            return addresses;
        }
        public IList<Address> GetBillingAddress(Customer customer)
        {
            IList<Address> addresses = customer.Enterprise.BillingAddress;
            if (!customer.Enterprise.IsDontAddPersonnalAddress)
            {
                if (customer.BillingAddress != null)
                {
                    addresses.Add(customer.BillingAddress);
                }
            }
            return addresses;
        }
        public Address SaveNewAddress(Address address)
        {
            ContextSessionManager.Context.Session["Cities"] = null;

            City cityFind = FindCity(address.City.Description);
            if (cityFind != null)
            {
                address.City = cityFind;
            }
            else
            {
                City cityCreate = new City { Code = address.City.Description, Description = address.City.Description };
                int id = CreateCity(cityCreate);
                address.City = new City { Id = id };
            }

            address.PostalCode = address.PostalCode;
            address.Way = address.Way;


            return GetAddress(DAOAddress.SaveAdress(address));
        }
        public Address SaveAddress(Address address)
        {

            ContextSessionManager.Context.Session["Cities"] = null;

            City cityFind = FindCity(address.City.Description);
            if (cityFind != null)
            {
                address.City = cityFind;
            }
            else
            {
                City cityCreate = new City { Code = address.City.Description, Description = address.City.Description };
                int id = CreateCity(cityCreate);
                address.City = new City { Id = id };
            }

            address.PostalCode = address.PostalCode;
            address.Way = address.Way;

            if (address.Id != 0)
            {
                return GetAddress(DAOAddress.SaveAdress(address));
            }
            return GetAddress(DAOAddress.SaveAdress(FindAddress(address) ?? address));
        }
    }
}

