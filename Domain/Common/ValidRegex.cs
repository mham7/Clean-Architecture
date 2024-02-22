using System.Text.RegularExpressions;

namespace Domain.Common
{
    public static class ValidRegex
    {
        public const string EmailValidator = @"^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$";
        public const string PasswordValidator = @"^(? !.([A - Za - z0 - 9])\1{1})(?=.?[A - Z])(?=.?[a - z])(?=.?[0 - 9])(?=.?[#?!@$%^&-]).{8,}$";
    }
}
