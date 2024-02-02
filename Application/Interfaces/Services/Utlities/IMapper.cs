using Domain.Entities;
using Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Utlities
{
    public interface IMapper
    {
        Userdto UserToCredMapper(Usercs cs);
    }
}
