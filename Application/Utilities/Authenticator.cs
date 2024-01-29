using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
   public static class Authenticator
    {

    
       
        public static string tokenization(Usercs user, IConfiguration _config)
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
    }
}
