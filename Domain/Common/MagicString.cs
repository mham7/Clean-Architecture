using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
     public class MagicString
    {
        public const string EmailMessage = "Invalid Email Format";
        public const string PasswordMessage = "Invalid Password Format";
        public const string DateMessage = "Invalid Date Time.It should be greater than current date time";
        public const string BadRequest = "Sorry something went wrong, request cannot be completed";
        public const string ServerError = "Internal Server Error";
        public const string UnhandleError = "An Unhandled Error has occured";
        public const string NotFound = "Not Found";
        public const string UpdateSucess = "Update Success";
        public const string NullData = "Data is Null";
    }
}
