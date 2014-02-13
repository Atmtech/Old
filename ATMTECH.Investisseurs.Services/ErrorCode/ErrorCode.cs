namespace ATMTECH.Investisseurs.Services.ErrorCode
{
    public static class ErrorCode
    {
        public const string SC_NO_USER_AUTHENTICATED = "FW001";
        public const string SC_SEND_MAIL_FAILED = "FW002";
        public const string SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM = "FW003";
        public const string SC_INVALID_EMAIL = "FW004";
        public const string SC_THIS_USER_ALREADY_EXIST = "FW005";
        public const string SC_USER_NOT_EXIST_ON_CONFIRM = "FW006";
        public const string SC_CAPTCHA_INVALID = "FW007";

        public const string IN_ACCOUNT_BALANCE_TO_LOW = "IN008";
        

    }
}
