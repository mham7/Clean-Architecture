using Application.Interfaces.Repos;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostCommentRepo : GenericRepo<PostComment>, IPostCommentRepo
    {
        public PostCommentRepo(AppDbContext appcontext) : base(appcontext)
        {
        }
    }
}
