using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _appDbContext;
        public UserRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Usercs> CheckAuthenticate(Userdto cred)
        {
            HashSet<Usercs> users= new HashSet<Usercs>();

            IQueryable<Usercs> cs = _appDbContext.Users.Where(user => user.Email == cred.email);

            Usercs found_user = await cs.FirstAsync();

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(cred.password, found_user.Password);


            if (found_user != null && isPasswordValid==true)
            {
                return found_user;
            }
            else
            {
                throw new InvalidOperationException("User not found or invalid password.");
            }
        }

        
    }
}
