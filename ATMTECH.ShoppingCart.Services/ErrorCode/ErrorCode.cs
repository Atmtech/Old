namespace ATMTECH.ShoppingCart.Services.ErrorCode
{
    public static class ErrorCode
    {

        public const string MESSAGE_CONTROL_STOCK_ORDERLINE_NO_MATCH = "Aucune correspondance dans les transactions de stock";
        public const string MESSAGE_CONTROL_STOCK_ORDERLINE_ORDERLINE_QUANTITY_VS_TRANSACTION_NOT_EQUAL = "La quantité commandé n'est pas la même que dans la transaction de stock";
        public const string MESSAGE_CONTROL_STOCK_ORDERLINE_TRANSACTION_NOT_EXISTS_IN_ORDERLINE = "La transaction sur la commande n'existe pas dans les lignes de commandes";


        public const string SC_ENTERPRISE_CANT_ORDER = "SC0001";
        public const string SC_ENTERPRISE_NULL_ORDER = "SC0002";
        public const string SC_ORDERSTATUS_UNKNOWN = "SC0003";
        public const string SC_SHIPPING_ADDRESS_NULL = "SC0004";
        public const string SC_BILLING_ADDRESS_NULL = "SC0005";
        public const string SC_ORDERLINE_NULL = "SC0006";
        public const string SC_ORDERLINE_COUNT_ZERO = "SC0007";
        public const string SC_ORDERLINE_PRODUCT_ID_ZERO = "SC0008";
        public const string SC_ORDER_CREATE_NOT_ZERO = "SC0009";
        public const string SC_ORDER_NULL = "SC0010";
        public const string SC_NO_USER_AUTHENTICATED = "SC0011";
        public const string SC_NO_TAXE_TYPE = "SC0012";
        public const string SC_NO_CUSTOMER_LINKED_TO_ORDER = "SC0013";
        public const string SC_THIS_PRODUCT_NUMBER_DONT_EXIST = "SC0014";
        public const string SC_PUROLATOR_ERROR = "SC0015";
        public const string SC_SEND_MAIL_FAILED = "SC0016";
        public const string SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM = "SC0017";
        public const string SC_INVALID_EMAIL = "SC0018";
        public const string SC_THIS_USER_ALREADY_EXIST = "SC0019";
        public const string SC_CUSTOMER_IS_NULL = "SC0020";
        public const string SC_SHIPPING_PARAMETER_CANNOT_BE_NULL = "SC0021";
        public const string SC_USER_NOT_EXIST_ON_CONFIRM = "SC0022";
        public const string SC_CAPTCHA_INVALID = "SC0023";
        public const string SC_SHIPPING_CODE_DONT_EXIST = "SC0024";
        public const string SC_STOCK_INSUFICIENT = "SC0025";
        public const string SC_WEIGHT_EQUAL_ZERO_CANNOT_EVALUATE_SHIPPING_COST = "SC0026";
        public const string SC_IF_ORDER_INFORMATION_MANAGED_CANT_BE_EMPTY = "SC0027";
        public const string SC_ASK_SHIPPING_QUOTATION = "SC0028";
        public const string SC_NO_ADRESSE = "SC0029";
        public const string SC_NO_CATEGORY = "SC0030";
    }
}
