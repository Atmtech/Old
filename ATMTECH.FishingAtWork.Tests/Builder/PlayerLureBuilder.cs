using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class PlayerLureBuilder
    {
        public static PlayerLure Create()
        {
            return new PlayerLure();
        }

        public static PlayerLure WithPlayer(this PlayerLure playerLure, Player player)
        {
            playerLure.Player = player;
            return playerLure;
        }
        public static PlayerLure WithLure(this PlayerLure playerLure, Lure lure)
        {
            playerLure.Lure = lure;
            return playerLure;
        }
        public static PlayerLure WithQuantity(this PlayerLure playerLure, int quantity)
        {
            playerLure.Quantity = quantity;
            return playerLure;
        }
        public static PlayerLure WithId(this PlayerLure playerLure, int id)
        {
            playerLure.Id = id;
            return playerLure;
        }



    }
}
