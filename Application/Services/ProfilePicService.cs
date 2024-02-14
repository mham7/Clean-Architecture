using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Utlities;
using Domain.Models;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfilePicService : GenericService<ProfilePic>, IProfilePicService
    {
        private readonly IHelper _help;
        public ProfilePicService(IGenericRepo<ProfilePic> gen, IHelper help) : base(gen)
        {
            _help = help;
        }

        public async Task<ProfilePic> Post(ProfilePicDto DTO)
        {
            ProfilePic pic = _help.ImagetoByteConverter(DTO);
            await post(pic);
            return pic;      
                
        }
    }
}
