using Application.Interfaces.Services.Utlities;
using Domain.Models;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Utilities
{
    public class Mapper : IMapper
    {
        public Userdto UserToCredMapper(User cs)
        {
            Userdto Dto = new Userdto
            {
                email = cs.Email,
                password = cs.Password
            };
            return Dto;
        }

        public User RegToUserMapper(UserRegInfo userRegInfo)
        {
            User user = new User
            {
                FirstName = userRegInfo.FirstName,
                LastName = userRegInfo.LastName,
                Email = userRegInfo.Email,
                Password = userRegInfo.Password,
                Salary = userRegInfo.Salary,
                DateOfJoining = userRegInfo.DOJ,
            };
            return user;
        }
    }
}
