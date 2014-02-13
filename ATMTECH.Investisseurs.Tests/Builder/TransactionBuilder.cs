using ATMTECH.Entities;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.Tests.Builder
{
    public static class TransactionBuilder
    {
        public static Transaction CreateValid()
        {
            return Create().WithAmount(5000).WithPlayer(PlayerBuilder.CreateValid());
        }

        public static Transaction Create()
        {
            return new Transaction();
        }

        public static Transaction WithAmount(this Transaction transaction, double amount)
        {
            transaction.Amount = amount;
            return transaction;
        }

        public static Transaction WithPlayer(this Transaction transaction, Player player)
        {
            transaction.Player = player;
            return transaction;
        }

    }

}
