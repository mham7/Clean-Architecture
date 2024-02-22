using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Domain.Models.Dtos;
using Domain.Models;


namespace Application.Interfaces.Repos.Utlities
{
    public interface IAuthenticator
    {
        User HashUser(User user);
        Userdto HashUser(Userdto user);
        bool Verification(string cred_password, string actual_password);
        string Tokenization(User user, IConfiguration _config,Userdto actual);
    }
}
