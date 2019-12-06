using Demo.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence
{
    public class DemoDbContext : DbContext
    {
        public DbSet<EventClass> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventClass>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<EventClass>()
                .Property(e => e.Name)
                .HasMaxLength(255);
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=Data/accountingDB.db");
            optionsBuilder.UseSqlServer("Server=localhost,11433;Database=DemoDb;User Id=sa;Password=yourStrong(!)Password;");
        }

    }
}