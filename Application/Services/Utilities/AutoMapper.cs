using AutoMapper;
using Domain.Models.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services.Utilities
{
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
            CreateMap<TskDto, Tasks>();
            CreateMap<Tasks, TskDto>();
            CreateMap<User, UserRegInfo>();
            CreateMap<UserRegInfo, User>();
            CreateMap<Community, CommunityDto>();
            CreateMap<CommunityDto, Community>();
            CreateMap<ProfilePic, ProfilePicDto>();
            CreateMap<ProfilePicDto, ProfilePic>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();


        }
    }
    
}
