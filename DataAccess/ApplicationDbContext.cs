using BookCollection.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public ApplicationDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BookCollectionDb;Persist Security Info=True;User ID=sa;Password=*****");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
        }
    }
}
