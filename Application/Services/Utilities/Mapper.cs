using Application.Interfaces.Services.Utlities;
using Domain.Entities;
using Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Utilities
{
    public class Mapper : IMapper
    {
        public Userdto UserToCredMapper(Usercs cs)
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
