using Microsoft.EntityFrameworkCore;
using BibliothequeC_.Models;

namespace BibliothequeC_.Data
{
    public class BookDb : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookDb(DbContextOptions<BookDb> options) : base(options)
        {
            Books = Set<Book>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration spécifique au modèle peut être ajoutée ici
        }
    }

    public class UserDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDb(DbContextOptions<UserDb> options): base(options)
        {
            Users = Set<User>();
        }
    }

}
