using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IAddressService
    {
        City FindCity(string cityName);
        Country GetCountry(int id);
        int CreateCity(City city);
        IList<Country> GetAllCountries();
        Address SaveAddress(Address address);
        Address GetAddress(int id);
        Address FindAddress(Address address);
        IList<Address> GetShippingAddress(Customer customer);
        IList<Address> GetBillingAddress(Customer customer);
        Address SaveNewAddress(Address address);
    }
}
