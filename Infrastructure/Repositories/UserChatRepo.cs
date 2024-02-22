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
    public class UserChatRepo : GenericRepo<UserChat>, IUserChatRepo
    {
        private readonly AppDbContext _context;
        public UserChatRepo(AppDbContext appcontext) : base(appcontext)
        {
            _context=appcontext;
        }
        public async Task<UserChat> Get(Expression<Func<UserChat, bool>> filter)
        {
            IQueryable<UserChat> chats = _context.UserChats.Where(filter);

            UserChat filteredchat = await chats.FirstOrDefaultAsync();

            return filteredchat;
        }

    }
}
