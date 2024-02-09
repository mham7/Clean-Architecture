using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Domain.Entities.Dtos;


namespace Application.Interfaces.Repos.Utlities
{
    public interface IAuthenticator
    {
        Usercs HashUser(Usercs user);
        bool Verification(string cred_password, string actual_password);
        string Tokenization(Usercs user, IConfiguration _config,Userdto actual);
    }
}
