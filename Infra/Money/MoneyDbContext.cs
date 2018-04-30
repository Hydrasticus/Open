using Microsoft.EntityFrameworkCore;
using Open.Data.Money;

namespace Open.Infra.Money {

    public class MoneyDbContext : DbContext {

        public MoneyDbContext(DbContextOptions<MoneyDbContext> o) : base(o) { }

        public DbSet<CurrencyDbRecord> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<CurrencyDbRecord>().ToTable("Currency");
        }
    }
}
