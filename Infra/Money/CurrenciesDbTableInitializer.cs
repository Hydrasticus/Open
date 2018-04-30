using System.Linq;
using Open.Aids;
using Open.Domain.Money;

namespace Open.Infra.Money {

    public static class CurrenciesDbTableInitializer {
        
        public static void Initialize(MoneyDbContext c) {
            c.Database.EnsureCreated();
            if (c.Currencies.Any()) return;
            var regions = SystemRegionInfo.GetRegionsList();
            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;
                var e = CurrencyObjectFactory.Create(r);
                c.Currencies.Add(e.DbRecord);
            }

            c.SaveChanges();
        }
    }
}
