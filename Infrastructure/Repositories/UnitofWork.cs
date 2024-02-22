using Infrastructure.Repositories;
using Infrastructure.Context;
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Domain.Models;


namespace Infrastructure.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _appcontext;
        public IChatRepo _chat { get; }

        public static readonly Dictionary<Type, object> Repositories = new Dictionary<Type, object>();
        public IGenericRepo<Type> _Generic { get; }
        public ICommunityRepo community { get; }
        public IChatRepo chat { get; }  
        public IMessageRepo message { get; }
        public ITaskRepo tasks { get; }
        public IRoleRepo role { get; }
        public IUserChatRepo _uchat { get; }
        public IPostRepo post { get; }
        public IUserRepo users { get; }

      
        public UnitofWork(AppDbContext appcontext,
         IGenericRepo<Type> Generic, IUserRepo userrepo,IChatRepo chat,IMessageRepo messages,IUserChatRepo uchat)
        {
            _appcontext = appcontext;
            _chat = chat;
            message=messages;
            users = userrepo;
            _Generic = Generic;
            _uchat = uchat;

        }

  

        public void Dispose()
        {
            _appcontext.Dispose();
        }

        public async Task SaveChanges()
        {
            await _appcontext.SaveChangesAsync();
        }
    }
}
