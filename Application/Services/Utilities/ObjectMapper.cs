
using Domain.Entities;
using Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Utilities
{
    public class ObjectMapper 
    {
        public static Userdto UserToCredMapper(Usercs cs)
        {
            Userdto Dto = new Userdto
            {
                email = cs.Email,
                password = cs.Password
            };
            return Dto;
        }
    }
}
