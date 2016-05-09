using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Services.Validate
{
    public class ValidateShoppingService : BaseService, IValidateShoppingService
    {
        public IMessageService MessageService { get; set; }

        private bool ValidateQuantity(int quantity)
        {
            if (quantity == 0)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.FW_CANT_BUY_QUANTITY_0);
                return false;
            }
            return true;
        }
        private bool ValidateMoney(Player player, Lure lure, int quantity)
        {
            if (player.Money < lure.Price * quantity)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.FW_NOT_ENOUGH_MONEY_TO_BUY);
                return false;
            }
            return true;
        }


        public bool Validate(Player player, Lure lure, int quantity)
        {
            if (ValidateQuantity(quantity))
            {
                if (!ValidateMoney(player, lure, quantity))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;

        }
    }
}
