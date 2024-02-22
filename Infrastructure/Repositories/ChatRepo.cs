using Application.Interfaces.Repos;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ChatRepo : GenericRepo<Chats>, IChatRepo
    {
        private readonly AppDbContext _appcontext;
        public ChatRepo(AppDbContext appcontext) : base(appcontext)
        {
            _appcontext = appcontext;
        }

        public async Task<List<UserChat>> get(int id)
        {
            List<UserChat> chats = await _appcontext.UserChats
           .Where(u => u.SenderId == id || u.RecieverId==id)
           .ToListAsync();
            return chats;
        }
        
    }
}
