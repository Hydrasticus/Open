using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Open.Data.Country;
using Open.Infra.Country;

namespace Open.Infra {
    public class CountriesDbTableInitializer {
        public static void Initialize(CountryDbContext c) {
            if (IsAlreadyInitialized(c)) return;
            var regions = GetRegionsList();
            foreach (var r in regions) {
                if (IsCountry(r, out var id)) continue;
                var e = CreateCountryDbRecord(r, id);
                AddCountry(c, e);
            }
        }

        private static void AddCountry(CountryDbContext c, CountryDbRecord e) {
            c.Countries.Add(e);
            c.SaveChanges();
        }

        private static CountryDbRecord CreateCountryDbRecord(RegionInfo r, string id) {
            var name = r.DisplayName;
            var code = r.TwoLetterISORegionName;
            var e = CountryDbRecordFactory.Create(id, name, code);
            return e;
        }

        private static bool IsCountry(RegionInfo r, out string id) {
            id = r.ThreeLetterISORegionName;
            if (char.IsNumber(id[0])) return true;
            return false;
        }

        private static List<RegionInfo> GetRegionsList() {
            var cultures = CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Select(i => new RegionInfo(i.LCID))
                .Distinct()
                .ToList();
            var regions = cultures.OrderBy(p => p.EnglishName).ToList();
            return regions;
        }

        private static bool IsAlreadyInitialized(CountryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Countries.Any()) return true;
            return false;
        }
    }
}
