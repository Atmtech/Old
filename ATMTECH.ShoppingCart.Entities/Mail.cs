using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    public class Mail : BaseEntity
    {
        public const string CODE = "Code";

        public string Code { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
