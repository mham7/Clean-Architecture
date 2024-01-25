global using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= .\\SQLEXPRESS;Database=Perseus;Trusted_Connection=true;MultipleActiveResultSets=True; TrustServerCertificate=true; ");
        }


        public DbSet<Admin> Admin { get; set; }
        public DbSet<Dev> Devs { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Usercs> Users { get; set; }

    }
}
