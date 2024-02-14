using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class UserDetails
    {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public decimal Salary { get; set; }
            public ProfilePic ProfilePic { get; set; } // Assuming ProfilePic is a class
            public Division Div { get; set; } // Assuming Division is a class
            public Role Role { get; set; } // Assuming Role is a class
            public int RoleId { get; set; }
            public int DivId { get; set; }
        }

    }

