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
    public class Mapper : IMappers
    {
        private readonly AutoMapper.IMapper _autoMapper;

        public Mapper(AutoMapper.IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
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

        public Tasks TaskMapper(TskDto dto)
        {
            Tasks a = new Tasks
            {
                TaskDetail = dto.TaskDetail,
                AssignedId = dto.AssignedID,
                CreatorId = dto.CreatorID,
                CreatedTime = dto.CreatedTime,
                Deadline = dto.Deadline
            };
            return a;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _autoMapper.Map<TSource, TDestination>(source);
        }
    }
}
