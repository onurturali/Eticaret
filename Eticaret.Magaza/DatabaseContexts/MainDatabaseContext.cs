using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Magaza.DatabaseContexts
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<Urun> Urun { get; set; }

        public DbSet<Satis> Satis { get; set; }

        public DbSet<SatisDetay> SatisDetay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SatisDetay>()
                .Property(m => m.Id)
                .HasColumnType("uniqueidentifier rowguidcol")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Kategori>()
                .Property(m => m.Id)
                .HasColumnType("uniqueidentifier rowguidcol")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Satis>()
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
