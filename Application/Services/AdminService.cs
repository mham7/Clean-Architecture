﻿using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
namespace Contouring_App.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitofWork _unit;
        

        public AdminService(IUnitofWork unit)
        {
            _unit= unit;
        }
        public async Task Add(Admin admin)
        {
           await _unit.admins.Add(admin);   
        }

        public async Task Delete(Admin admin)
        {
            await _unit.admins.Delete(admin);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
           return await _unit.admins.GetAll();
        }

        public async Task<Admin> GetById(int id)
        {
            Admin admin = await _unit.admins.GetById(id);
            return admin;
        }

        public async Task<List<Admin>> GetAdminsByLocation(string location)
        {
            return await _unit.admins.GetAdminbyOfficeLocation(location);
        }

       

        public async Task Update(Admin admin)
        {
           await _unit.admins.Update(admin);
        }
    }
}
