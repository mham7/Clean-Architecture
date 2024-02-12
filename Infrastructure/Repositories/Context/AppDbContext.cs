global using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repos.DbConfiguration;
using Domain.Models;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IDbConfiguration _DbConfig;

        public AppDbContext(DbContextOptions<AppDbContext> options,IDbConfiguration DbConfig) : base(options)
        {
            _DbConfig = DbConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_DbConfig.ConnectionString);
        }



        public DbSet<Chats> Chat { get; set; }

        public DbSet<Community> Communities { get; set; }

        public DbSet<Domain.Models.Division> Divisions { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostComment> PostComments { get; set; }

        public  DbSet<PostImage> PostImages { get; set; }

        public  DbSet<ProfilePic> ProfilePics { get; set; }

        public  DbSet<Role> Roles { get; set; }

        public  DbSet<Tasks> Tasks { get; set; }

        public  DbSet<User> Users { get; set; }

        public  DbSet<UserChat> UserChats { get; set; }

    }
}
