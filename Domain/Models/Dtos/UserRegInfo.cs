using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
   public  class UserRegInfo
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int DivId { get; set; }
        public required int RoleId { get; set; }
        public required DateOnly DateOfJoinig { get; set; }
        public int Salary { get; set; }
    }
}
