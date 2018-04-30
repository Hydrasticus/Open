using Microsoft.EntityFrameworkCore;
using Open.Data.Location;

namespace Open.Infra.Location {
    
    public class LocationDbContext : DbContext {
        
        public LocationDbContext(DbContextOptions<LocationDbContext> o) : base(o) { }

        public DbSet<CountryDbRecord> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<CountryDbRecord>().ToTable("Country");
        }
    }
}
