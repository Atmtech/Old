using System.Text.RegularExpressions;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Services.Validate
{
    public class ValidatePlayerService : BaseService, IValidatePlayerService
    {
        public IMessageService MessageService { get; set; }
        public IDAOUser DAOUser { get; set; }

        private void ValidateIfUserAlreadyExist(Player player)
        {
            User user = DAOUser.GetUser(player.User.Login);
            if (user != null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_THIS_USER_ALREADY_EXIST);
            }
        }

        private void ValidateEmail(string email)
        {
            const string matchEmailPattern =
                @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";

            if (!Regex.IsMatch(email, matchEmailPattern))
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_INVALID_EMAIL);
            }
        }

        public void IsValidPlayerOnCreate(Player player)
        {
            ValidateEmail(player.User.Email);
            ValidateIfUserAlreadyExist(player);
        }

        public void IsValidPlayerOnUpdate(Player player)
        {
            ValidateEmail(player.User.Email);
        }
    }
}
