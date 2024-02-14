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
    public class PostRepo : GenericRepo<PostImage>, IPostImageRepo
    {
        private readonly AppDbContext _appcontext;
        public PostRepo(AppDbContext appcontext) : base(appcontext)
        {
            _appcontext = appcontext;
        }

        public async Task<IEnumerable<Post>>Get(int id)
        {
            IEnumerable<Post> posts= await _appcontext.Posts.Where(u=>u.CommunityId==id).ToListAsync();
            return posts;
        }
    }
}
