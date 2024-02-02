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
 
        public UserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
       
        }
        public async Task<Usercs> GetUserbyCred(Userdto cred)
        {
            IQueryable<Usercs> cs = _appDbContext.Users.Where(user => user.Email == cred.email && user.Password == cred.password);

            Usercs found_user = await cs.FirstOrDefaultAsync();

           if(found_user!=null)
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
