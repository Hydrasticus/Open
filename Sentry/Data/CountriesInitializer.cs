using Open.Sentry.Models;
using System.Globalization;
using System.Linq;

namespace Open.Sentry.Data {
    public class CountriesInitializer {
        public static void Initialize(CountryContext c) {
            c.Database.EnsureCreated();
            if (c.Countries.Any()) return;

            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(i => new RegionInfo(i.LCID)).Distinct().ToList();
            var regions = cultures.OrderBy(p => p.EnglishName).ToList();

            foreach (var r in regions) {
                var id = r.ThreeLetterISORegionName;
                if (char.IsNumber(id[0])) continue;
                var name = r.DisplayName;
                var code = r.TwoLetterISORegionName;
                var e = new IsoCountry(id, name, code);
                c.Countries.Add(e);
                c.SaveChanges();
            }
        }
    }
}
