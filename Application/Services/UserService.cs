
using Microsoft.Extensions.Configuration;
using Application.Interfaces.UnitOfWork;
using Application.Services.Utilities;
using Application.Interfaces.Services;
using Application.Interfaces.Repos.Utlities;
using Application.Interfaces.Services.Utlities;
using Domain.Models.Dtos;
using Domain.Models;
using AutoMapper;
using System.Linq.Expressions;

namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitofWork _unit;
        private readonly IConfiguration _config;
        private readonly IAuthenticator _auth;
        private readonly IMappers _mapper;
        public UserService(IUnitofWork unit, IConfiguration config,IAuthenticator auth,IMappers mapper)
        {
            _unit = unit;
            _config = config;   
            _auth = auth;
            _mapper = mapper;
        }
        public async Task post(User users)
        {
           await  _unit.users.Post(users);
        }

        public async Task Delete(User users)
        {
           await _unit.users.Delete(users);
        }

        //update email and password;
        public async Task<User> Patch(int id,Userdto dto)
        {
            return await _unit.users.Patch(id,dto);
        }

        //public async Task<List<User>>Get()
        //{
        //    DateOnly sixMonthsAgo = DateOnly.FromDateTime(DateTime.Today.AddMonths(-6));

        //    // Create a filter expression to get users with DateOfJoining more than 6 months ago
        //    Expression<Func<User, bool>> filter = u => u.DateOfJoining < sixMonthsAgo;

        //    // Call the Get method with the filter
        //    List<User> result = await Get(filter);

        //    return result;
        //}

        public async Task<IEnumerable<User>>Get()
        {
            return await _unit.users.Get();
        }

        public async Task<User> Get(int id)
        {
            return await _unit.users.Get(id);
        }

        public async Task<string> Login(Userdto user)
        { 
            User authuser =await _unit.users.Get(user);
            
            return _auth.Tokenization(authuser,_config,user);

        }

        public async Task<Userdto> Register(UserRegInfo user)
        {
            try
            {
                User auth = _mapper.RegToUserMapper(user);
                auth = _auth.HashUser(auth);
                await _unit.users.Post(auth);
                return _mapper.UserToCredMapper(auth);
            }
            catch(Exception ex)
            {
                throw;
            }


            }

        public async Task Put(User users)
        {
           await _unit.users.Put(users);
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
