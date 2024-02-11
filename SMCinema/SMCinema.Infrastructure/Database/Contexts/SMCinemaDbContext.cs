using Microsoft.EntityFrameworkCore;
using SMCinema.Infrastructure.Database.Entities;

namespace SMCinema.Infrastructure.Database.Contexts
{
    public class SMCinemaDbContext : DbContext
    {
        public SMCinemaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
