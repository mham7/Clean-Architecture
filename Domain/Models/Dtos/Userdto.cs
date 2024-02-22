using Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace Domain.Models.Dtos
{
    public class Userdto
    {
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [CustomEmailValidation(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [Required]
        //[RegularExpression(ValidRegex.PasswordValidator, ErrorMessage = MagicString.PasswordMessage)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
