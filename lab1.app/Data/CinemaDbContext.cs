using Microsoft.EntityFrameworkCore;
using lab1.app.Data.Models;
using System.Security.Cryptography.X509Certificates;

namespace lab1.app.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext() { }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
        public DbSet <Film> Films { get; set; }
        public DbSet <Cinema> Cinemas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(film => film.Id)
                .UseIdentityColumn();
            modelBuilder.Entity<Cinema>()
                .Property(cinema=> cinema.Id)
                .UseIdentityColumn() ;
            base.OnModelCreating(modelBuilder);
        }


    }
}
