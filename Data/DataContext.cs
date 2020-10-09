using dms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dms_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions{get; set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<Section> Sections{get; set;}
    }
}