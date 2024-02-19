namespace Domain.Common
{
    public static class ValidRegex
    {
        public const string EmailValidator = @"^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$";
        public const string PasswordValidator = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{6,}$";
    }
}
