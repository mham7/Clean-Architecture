using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Application.Utilities;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repos;

namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitofWork _unit;
        private readonly IConfiguration _config;
        public UserService(IUnitofWork unit, IConfiguration config)
        {
            _unit = unit;
            _config = config;   
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
            Usercs authuser =await _unit.users.CheckAuthenticate(user);
            if(authuser == null) {

                return "Not Authenicated";
            }
            return Authenticator.Tokenization(authuser,_config);

        }

        public async Task<Userdto> Register(Usercs user)
        {
            string password = user.Password;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            user.Password=hashedPassword;
            await _unit.users.Add(user);
            Userdto userdto = new Userdto();
            userdto.password=hashedPassword;
            userdto.email=user.Email;
            return userdto;

        }

      

      

        public async Task Update(Usercs users)
        {
           await _unit.users.Update(users);
        }
    }
}
