using Microsoft.EntityFrameworkCore;
using Open.Data.Location;
using Open.Data.Money;

namespace Open.Infra {

    public class SentryDbContext : DbContext {

        public SentryDbContext(DbContextOptions<SentryDbContext> o) : base(o) { }
        
        public DbSet<CountryDbRecord> Countries { get; set; }
        
        public DbSet<CurrencyDbRecord> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<CurrencyDbRecord>().ToTable("Currency");
            b.Entity<CountryDbRecord>().ToTable("Country");
        }
    }
}
