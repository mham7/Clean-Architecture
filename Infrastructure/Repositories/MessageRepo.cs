using Application.Interfaces.Repos;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MessageRepo : GenericRepo<Message>, IMessageRepo
    {
        private readonly AppDbContext _appDbContext;    
        public MessageRepo(AppDbContext appcontext) : base(appcontext)
        {
            _appDbContext = appcontext;
        }

        //public async Task<List<Message>>GetInbox(int chatId)
        //{
        //    List<Message> messages=await _appDbContext.Messages.Where(c=>c.ChatId == chatId).OrderByDescending(m => m.CreatedTime).ToListAsync();
        //    return messages;
        //}
        public async Task<List<Message>> Get(Expression<Func<Message, bool>> filter)
        {
            IQueryable<Message> msg = _appDbContext.Messages.Where(filter);

            List<Message> convo = await msg.ToListAsync();

            return convo;
        }
        //Update Message detail
        public async Task<Message>Patch(int id,string message)
        {
            Message a =await Get(id);
            a.MessageDetail= message;
            await Put(a);
            return a;
        }
    }
}
