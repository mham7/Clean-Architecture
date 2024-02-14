using Application.Interfaces.Repos;
using Application.Interfaces.Repos.Utlities;
using Domain.Models;
using Domain.Models.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Infrastructure.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAuthenticator _auth;
        public UserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //get User by credentials or email.
        public async Task<User> Get(Userdto cred)
        {
            IQueryable<User> cs = _appDbContext.Users.Where(user => user.Email == cred.email);

            User found_user = await cs.FirstAsync();

           if( found_user!=null)
            {
                return found_user;
            }
            else
            {
                throw new InvalidOperationException("User not found or invalid password.");
            }
        }

        public async Task<List<User>> Get(Expression<Func<User, bool>> filter)
        {
            IQueryable<User> users = _appDbContext.Users.Where(filter);

            List<User> filteredUsers = await users.ToListAsync();

            return filteredUsers;
        }

        public virtual async Task<IEnumerable<User>> Get()
        {
            var users = await _appDbContext.Users
                .Include(u => u.Div) // Include the Div navigation property
                .ToListAsync();

            foreach (var user in users)
            {
                // Explicitly load additional related entities if needed
                _appDbContext.Entry(user);
            }

            return users ?? throw new Exception("Data is null");
        }

        //get all data of user 
        public override async Task<User> Get(int id)
        {
            User user = await (from userEntity in _appDbContext.Users
            join role in _appDbContext.Roles on userEntity.RoleId equals role.RoleId
            join div in _appDbContext.Divisions on userEntity.DivId equals div.DivId
            where userEntity.UserId == id
            select new User
            {
              UserId=userEntity.UserId,
              FirstName = userEntity.FirstName,
              LastName = userEntity.LastName,
              Email = userEntity.Email,
              Password=userEntity.Password,
              Salary=userEntity.Salary,
              Div = div, 
              Role = role,
              RoleId=userEntity.UserId,
              DivId=userEntity.DivId
              }).FirstOrDefaultAsync();

            return user;
        }

        //Update Credentials
        public async Task<User> Patch(int id, Userdto cred)
        {
         
            User user= await _appDbContext.Users.FindAsync(id);
            if (user != null) { 
                if (cred.email != null) { user.Email = cred.email;}
                if (cred.password != null) { user.Password = cred.password; }
                return user;
            }

            else { throw new InvalidOperationException("User not found.");}      
        }


    }
}
