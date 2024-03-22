using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Panel.DatabaseContexts
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Kategori> Kategori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>()
                .Property(m => m.Id)
                .HasColumnType("uniqueidentifier rowguidcol")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
