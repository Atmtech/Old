using ATMTECH.Entities;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.Tests.Builder
{
    public static class PlayerBuilder
    {
        public static Player CreateValid()
        {
            User user1 =
                UserBuilder.Create().WithLogin("riov01").WithPassword("test").WithFirstName("Vincent").WithLastName(
                    "Rioux").WithIsAdministrator(true).WithEmail("sagaan@hotmail.com");
            return Create().WithUser(user1);
        }

        public static Player Create()
        {
            return new Player();
        }

        public static Player WithImage(this Player player, string image)
        {
            player.Image = image;
            return player;
        }

        public static Player WithFirstName(this Player player, string name)
        {
            if (player.User == null)
            {
                player.User = new User();
            }
            player.User.FirstName = name;
            return player;
        }

          public static Player WithStartingMoney(this Player player, double money)
        {
            player.StartingMoney = money;
            return player;
        }
  
        public static Player WithUser(this Player player, User user)
        {
            player.User = user;
            return player;
        }
   
    }

}
