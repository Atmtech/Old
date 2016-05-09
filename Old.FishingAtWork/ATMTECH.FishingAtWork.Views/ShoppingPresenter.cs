using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class ShoppingPresenter : BaseFishingAtWorkPresenter<IShoppingPresenter>
    {
        public ILureService LureService { get; set; }
        public IShoppingService ShoppingService { get; set; }

        public ShoppingPresenter(IShoppingPresenter view)
            : base(view)
        {
        }

        public IList<LurePlayerLure> GetLure(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return LureService.GetLureList(parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetLureCount()
        {
            return LureService.GetLureList().Count;
        }

        public void AddToBasket(int basketType, int id, int quantity)
        {
            ShoppingService.Buy(basketType, id, quantity);
            NavigationService.Redirect(Pages.Pages.SHOPPING);
        }
    }
}
