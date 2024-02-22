using Domain.Models;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Utlities
{
    public interface IHelper
    {
        public ProfilePic ImagetoByteConverter(ProfilePicDto profilePicDto);
    }
}
