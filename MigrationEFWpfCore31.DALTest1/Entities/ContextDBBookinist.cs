
using Microsoft.EntityFrameworkCore;


namespace MigrationEFWpfCore31.DALTest1.Entities
{
    public class ContextDBBookinist : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public ContextDBBookinist(DbContextOptions<ContextDBBookinist> options) : base(options)
        {
            
        }
    }
}
