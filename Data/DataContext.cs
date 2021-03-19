using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FileDirectory> FileDirectories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RootDirectory> RootDirectories { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCatalog> UserCatalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCatalog>()
                .HasKey(uc => new { uc.UserId, uc.CatalogId });

            modelBuilder.Entity<UserCatalog>()
                .HasOne(c => c.Catalog)
                .WithMany(uc => uc.UserCatalogs)
                .HasForeignKey(c => c.CatalogId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCatalog>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserCatalogs)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}