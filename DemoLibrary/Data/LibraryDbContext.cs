using DemoLibrary.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoLibrary.Data
{
    public class LibraryDbContext : IdentityDbContext
    {
        #pragma warning disable CS8618
        #pragma warning disable CS8604
        public LibraryDbContext()
        {
        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<User> Users { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        public DbSet<Country> Countries { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ReaderBook> ReadersBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReaderBook>()
                .HasKey(x => new { x.ReaderId, x.BookId });

            builder.Entity<Worker>()
                .HasMany(x => x.Books).WithOne(x => x.Worker)
                .HasForeignKey(z => z.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        #pragma warning restore CS8618
        #pragma warning restore CS8604
    }
}