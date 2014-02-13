using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class EnterpriseBuilder
    {
        public static Enterprise Create()
        {
            return new Enterprise() { Id = 1 };
        }
        public static Enterprise CreateValid()
        {
            return Create().WithInitialBudget(10).WithName("EnterpriseName").WithIsOrderPossible(true);
        }
        public static Enterprise WithName(this Enterprise enterprise, string name)
        {
            enterprise.Name = name;
            return enterprise;
        }
        public static Enterprise WithId(this Enterprise enterprise, int id)
        {
            enterprise.Id = id;
            return enterprise;
        }
        public static Enterprise WithIsPaypal(this Enterprise enterprise, bool isPayPal)
        {
            enterprise.IsPaypal = isPayPal;
            return enterprise;
        }

        public static Enterprise WithIsPaypalRequired(this Enterprise enterprise, bool isPayPalRequired)
        {
            enterprise.IsPaypalRequired = isPayPalRequired;
            return enterprise;
        }
        public static Enterprise WithIsOrderPossible(this Enterprise enterprise, bool isOrderPossible)
        {
            enterprise.IsOrderPossible = isOrderPossible;
            return enterprise;
        }
        public static Enterprise WithIsShippingIncluded(this Enterprise enterprise, bool isShippingIncluded)
        {
            enterprise.IsShippingIncluded = isShippingIncluded;
            return enterprise;
        }

        public static Enterprise AddBillingAddress(this Enterprise enterprise, Address billingAddress)
        {
            enterprise.BillingAddress.Add(billingAddress);
            return enterprise;
        }

        public static Enterprise AddShippingAddress(this Enterprise enterprise, Address shippingAddress)
        {
            enterprise.ShippingAddress.Add(shippingAddress);
            return enterprise;
        }

        public static Enterprise WithInitialBudget(this Enterprise enterprise, decimal initialBudget)
        {
            enterprise.InitialBudget = initialBudget;
            return enterprise;
        }

        public static Enterprise WithFrenchInformations(this Enterprise enterprise, string description)
        {
            enterprise.FrenchInformation = description;
            return enterprise;
        }

        public static Enterprise WithEnglishInformations(this Enterprise enterprise, string description)
        {
            enterprise.EnglishInformation = description;
            return enterprise;
        }

        public static Enterprise WithFrenchContact(this Enterprise enterprise, string description)
        {
            enterprise.FrenchContact = description;
            return enterprise;
        }

        public static Enterprise WithEnglishContact(this Enterprise enterprise, string description)
        {
            enterprise.EnglishContact = description;
            return enterprise;
        }

        public static Enterprise WithImageUrl(this Enterprise enterprise, File image)
        {
            enterprise.Image = image;
            return enterprise;
        }
        public static Enterprise WithFrenchWelCome(this Enterprise enterprise, string welcome)
        {
            enterprise.FrenchWelcome = welcome;
            return enterprise;
        }

        public static Enterprise WithEnglishWelcome(this Enterprise enterprise, string welcome)
        {
            enterprise.EnglishWelcome = welcome;
            return enterprise;
        }
    }
}
