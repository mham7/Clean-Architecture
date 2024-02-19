
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
using Application.Interfaces.Repos;

namespace Application.Services
{
    public class UserService :GenericService<User>, IUserService
    {

        private readonly IUnitofWork _unit;
        private readonly IConfiguration _config;
        private readonly IAuthenticator _auth;
        private readonly IMappers _mapper;
        public UserService(IGenericRepo<User> gen, IUnitofWork unit, IConfiguration config,IAuthenticator auth,IMappers mapper):base (gen)
        {
            _unit = unit;
            _config = config;   
            _auth = auth;
            _mapper = mapper;
        }
       
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
        public override async Task<User> Get(int id)
        {
            return await _unit.users.Get(id);
        } 
       

        public async Task<string> Post(Userdto user)
        { 
            User authuser =await _unit.users.Get(user);
            
            return _auth.Tokenization(authuser,_config,user);

        }

        public async Task<Userdto> Post(UserRegInfo user)
        {
            
                User auth = _mapper.RegToUserMapper(user);
                auth = _auth.HashUser(auth);
                await _unit.users.Post(auth);
                return _mapper.UserToCredMapper(auth);
            


            }

        
    }
}
