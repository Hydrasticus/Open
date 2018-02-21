using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Open.Aids {

    public static class SystemRegionInfo {

        public static bool IsCountry(RegionInfo r) {
            return SystemString.StartsWithLetter(r.ThreeLetterISORegionName);
        }

        public static List<RegionInfo> GetRegionsList() {
            var cultures = SystemCultureInfo.GetSpecificCultures();
            var regions = SystemEnumerable.Convert(cultures, SystemCultureInfo.ToRegionInfo);
            regions = SystemEnumerable.Distinct(regions);
            regions = SystemEnumerable.OrderBy(regions, p => p.EnglishName);
            return regions.ToList();
        }
    }
}