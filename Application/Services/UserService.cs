using Domain.Entities;
using Domain.Entities.Dtos;
using Microsoft.Extensions.Configuration;
using Application.Interfaces.UnitOfWork;
using Application.Services.Utilities;
using Application.Interfaces.Services;
using Application.Interfaces.Repos.Utlities;
using Application.Interfaces.Services.Utlities;

namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitofWork _unit;
        private readonly IConfiguration _config;
        private readonly IAuthenticator _auth;
        private readonly IMapper _mapper;
        public UserService(IUnitofWork unit, IConfiguration config,IAuthenticator auth,IMapper mapper)
        {
            _unit = unit;
            _config = config;   
            _auth = auth;
            _mapper = mapper;
        }
        public async Task Add(Usercs users)
        {
           await  _unit.users.Add(users);
        }

        public async Task Delete(Usercs users)
        {
           await _unit.users.Delete(users);
        }

        public async Task<IEnumerable<Usercs>> GetAll()
        {
            return await _unit.users.GetAll();
        }

        public async Task<Usercs> GetById(int id)
        {
            return await _unit.users.GetById(id);
        }

        public async Task<string> Login(Userdto user)
        { 
            Usercs authuser =await _unit.users.GetUserByCredentials(user);
            
            return _auth.Tokenization(authuser,_config,user);

        }

        public async Task<Userdto> Register(Usercs user)
        {
            try
            {
                user = _auth.HashUser(user);
                await _unit.users.Add(user);
                return _mapper.UserToCredMapper(user);
            }
            catch(Exception ex)
            {
                throw;
            }


            }






        public async Task Update(Usercs users)
        {
           await _unit.users.Update(users);
        }
    }
}
