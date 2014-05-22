using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Enterprise : BaseEntity
    {
        public string Name { get; set; }
        public bool IsPaypal { get; set; }
        public bool IsPaypalRequired { get; set; }
        public IList<Address> ShippingAddress { get; set; }
        public IList<Address> BillingAddress { get; set; }
        public File Image { get; set; }
        public bool IsOrderPossible { get; set; }
        public Customer Contact { get; set; }
        public bool IsShippingIncluded { get; set; }
        public decimal InitialBudget { get; set; }

        public bool IsShippingAddressFixed { get; set; }
        public bool IsBillingAddressFixed { get; set; }

        public string FrenchInformation { get; set; }
        public string EnglishInformation { get; set; }

        public string FrenchContact { get; set; }
        public string EnglishContact { get; set; }

        public string FrenchWelcome { get; set; }
        public string EnglishWelcome { get; set; }

        public string FrenchPublicRelation { get; set; }
        public string EnglishPublicRelation { get; set; }

        public string FrenchStep { get; set; }
        public string EnglishStep { get; set; }

        public string ComboboxDescriptionUpdate { get { return Name; } }

        public bool IsCreateCustomerPossible { get; set; }

        public bool IsDisplayChangeLanguage { get; set; }
        public bool IsShippingManaged { get; set; }
        public bool IsSecure { get; set; }
        public bool IsDontAddPersonnalAddress { get; set; }

        public bool IsManageOrderInformation1 { get; set; }
        public bool IsManageOrderInformation2 { get; set; }

        public string SubDomainName { get; set; }

        public bool IsShippingQuotationRequired { get; set; }

    }
}
