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

        public DbSet<Urun> Urun { get; set; }

        public DbSet<Kullanici> Kullanici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>()
                .Property(m => m.Id)
                .HasColumnType("uniqueidentifier rowguidcol")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Kullanici>()
                .Property(m => m.Id)
                .HasColumnType("uniqueidentifier rowguidcol")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Urun>()
                .Property(m => m.Id)
                .HasColumnType("uniqueidentifier rowguidcol")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Urun>()
                .Property(m => m.KategoriId)
                .HasColumnType("uniqueidentifier");

            base.OnModelCreating(modelBuilder);
        }
    }
}
