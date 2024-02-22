using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
   public  class UserRegInfo
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [CustomEmailValidation(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required]
        public required int DivId { get; set; }
        [Required]
        public required int RoleId { get; set; }
        public required DateOnly DateOfJoinig { get; set; }
        public int Salary { get; set; }
    }
}
