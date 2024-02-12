
using Microsoft.Extensions.Configuration;
using Application.Interfaces.UnitOfWork;
using Application.Services.Utilities;
using Application.Interfaces.Services;
using Application.Interfaces.Repos.Utlities;
using Application.Interfaces.Services.Utlities;
using Domain.Models.Dtos;
using Domain.Models;

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
        public async System.Threading.Tasks.Task Post(User users)
        {
           await  _unit.users.Post(users);
        }

        public async System.Threading.Tasks.Task Delete(User users)
        {
           await _unit.users.Delete(users);
        }

        public async Task<IEnumerable<User>> Get()
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

        public async System.Threading.Tasks.Task Put(User users)
        {
           await _unit.users.Put(users);
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
