using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class ShoppingService : BaseService, IShoppingService
    {
        public IDAOBasket DAOBasket { get; set; }
        public IDAOLure DAOLure { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IPlayerLureService PlayerLureService { get; set; }
        public IValidateShoppingService ValidateShoppingService { get; set; }

        public void Buy(int basketType, int id, int quantity)
        {


            if (basketType == Constant.BASKET_TYPE_LURE)
            {
                Lure lure = DAOLure.GetLure(id);

                // Validation
                if (ValidateShoppingService.Validate(PlayerService.AuthenticatePlayer, lure, quantity))
                {
                    Basket basket = new Basket();
                    basket.Lure = lure;
                    basket.Price = lure.Price;
                    basket.Player = PlayerService.AuthenticatePlayer;
                    basket.Quantity = quantity;
                    DAOBasket.CreateBasket(basket);

                    PlayerLureService.AddLure(basket.Player, basket.Lure, quantity);

                    Player player = PlayerService.AuthenticatePlayer;
                    player.Money -= (basket.Price * quantity);
                    PlayerService.SavePlayer(player);
                }

            }
        }
    }
}
