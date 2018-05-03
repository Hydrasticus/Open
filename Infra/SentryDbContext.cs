using Microsoft.EntityFrameworkCore;
using Open.Data.Location;
using Open.Data.Money;

namespace Open.Infra {

    public class SentryDbContext : DbContext {

        public SentryDbContext(DbContextOptions<SentryDbContext> o) : base(o) { }

        public DbSet<CountryDbRecord> Countries { get; set; }

        public DbSet<CurrencyDbRecord> Currencies { get; set; }

        public DbSet<CountryCurrencyDbRecord> CountryCurrencies { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<CurrencyDbRecord>().ToTable("Currency");
            b.Entity<CountryDbRecord>().ToTable("Country");
            createCountryCurrencyTable(b);
        }

        private static void createCountryCurrencyTable(ModelBuilder b) {
            const string table = "CountryCurrency";

            b.Entity<CountryCurrencyDbRecord>().ToTable(table).HasKey(a => new {a.CountryID, a.CurrencyID});
            b.Entity<CountryCurrencyDbRecord>().ToTable(table).HasOne(x => x.Country).WithMany()
                .HasForeignKey(x => x.CountryID).OnDelete(DeleteBehavior.Restrict);
            b.Entity<CountryCurrencyDbRecord>().ToTable(table).HasOne(x => x.Currency).WithMany()
                .HasForeignKey(x => x.CurrencyID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
