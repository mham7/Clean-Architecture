using Application.Interfaces.Repos;
using Application.Interfaces.Repos.Utlities;
using Domain.Entities;
using Domain.Entities.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Infrastructure.Repositories
{
    public class UserRepo : GenericRepo<Usercs>, IUserRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAuthenticator _auth;
        public UserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Usercs> GetUserByCredentials(Userdto cred)
        {
            IQueryable<Usercs> cs = _appDbContext.Users.Where(user => user.Email == cred.email);

            Usercs found_user = await cs.FirstAsync();

           if( found_user!=null)
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
