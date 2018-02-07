using System.Globalization;
using System.Linq;
using Open.Data;
using Open.Data.Country;

namespace Open.Infra {
    public class CountriesDbTableInitializer {
        public static void Initialize(CountryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Countries.Any()) return;

            var cultures = CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Select(i => new RegionInfo(i.LCID))
                .Distinct()
                .ToList();

            var regions = cultures.OrderBy(p => p.EnglishName).ToList();

            foreach (var r in regions) {
                var id = r.ThreeLetterISORegionName;
                if (char.IsNumber(id[0])) continue;
                var name = r.DisplayName;
                var code = r.TwoLetterISORegionName;
                var e = CountryDbRecordFactory.Create(id, name, code);
                c.Countries.Add(e);
                c.SaveChanges();
            }
        }
    }
}
