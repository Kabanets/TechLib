using System.Data.Entity;
using TechLib.Domain.Entities;

namespace TechLib.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base("DefaultConnection") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
