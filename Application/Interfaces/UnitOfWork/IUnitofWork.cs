using Application.Interfaces.Repos;
using System;
using System.Collections.Generic;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
       
        IUserRepo users { get; }
        IGenericRepo<Type> _Generic { get; }
        public IChatRepo _chat { get; }
        public ICommunityRepo community { get; }
        public IChatRepo chat { get; }
        public IUserChatRepo _uchat { get; }
        public IMessageRepo message { get; }
        public ITaskRepo tasks { get; }
        public IRoleRepo role { get; }

        public IPostRepo post { get; }
       
        Task SaveChanges();

    }
}
