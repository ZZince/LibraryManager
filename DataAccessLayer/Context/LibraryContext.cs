using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Microsoft.Data.Sqlite;

namespace DataAccessLayer.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> dbcontext): base(dbcontext)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasKey(l => l.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);

            modelBuilder.Entity<Library>()
                .HasMany(l => l.Books)
                .WithMany(b => b.Libraries)
                .UsingEntity<Dictionary<string, object>>(
                    "Stock",
                    j => j.HasOne<Book>().WithMany().HasForeignKey("id_book"),
                    j => j.HasOne<Library>().WithMany().HasForeignKey("id_library")
                );

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.id_author);
        }
    }
}
