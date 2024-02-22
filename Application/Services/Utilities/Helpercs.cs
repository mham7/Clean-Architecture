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
    public class Helpercs:IHelper 
    {

        public ProfilePic ImagetoByteConverter(ProfilePicDto profilePicDto)
        {
            ProfilePic a=new ProfilePic();
            a.UserId = profilePicDto.UserId;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                profilePicDto.ProfilePic1.CopyTo(memoryStream);
                
               a.Profilepic1 =memoryStream.ToArray();
            }


            return a;
        }
    }
}
