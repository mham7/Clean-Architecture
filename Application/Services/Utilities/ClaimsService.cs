using Application.Interfaces.Services.Utlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Utilities
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService() { }
        public int GetUserID(ClaimsPrincipal User)
        {
            var claims = User.FindFirst(ClaimTypes.NameIdentifier);
            int id = int.Parse(claims.Value);
            return id;
        }
    }
}

