using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
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

        public static Player WithUser(this Player player, User user)
        {
            player.User = user;
            return player;
        }
        public static Player WithMaximumWaypoint(this Player player, int maximum)
        {
            player.MaximumWaypoint = maximum;
            return player;
        }

        public static Player WithMoney(this Player player, double money)
        {
            player.Money = money;
            return player;
        }

        public static Player WithExperience(this Player player, int experience)
        {
            player.Experience = experience;
            return player;
        }
    }

}
