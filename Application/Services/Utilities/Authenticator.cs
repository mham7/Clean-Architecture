using Application.Interfaces.Repos.Utlities;
using Domain.Entities;
using Domain.Entities.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Utilities
{
    public class Authenticator:IAuthenticator
    {
       
        public Usercs HashUser(Usercs user)
        {
            user.Password =BCrypt.Net.BCrypt.HashPassword(user.Password);
            return user;
        }
        public bool Verification(string cred_password,string actual_password)
        {

            bool isPasswordValid =  BCrypt.Net.BCrypt.Verify(cred_password, actual_password);
            return isPasswordValid;
        }

        public string Tokenization(Usercs user, IConfiguration _config,Userdto actualuser)
        {
            bool isvalid = Verification(actualuser.password, user.Password);

            if (isvalid)
            {
                var config = _config.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Key"]!));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Name)
            };
                var token = new JwtSecurityToken(
                    claims: claims,
                    audience: config["Audience"],
                    issuer: config["Issuer"],
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                    );
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            else
            {
                return "Password is Invalid";
            }

        }
    }
}
