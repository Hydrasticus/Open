using System.Globalization;

namespace Open.Aids {

    public static class SystemCultureInfo {

        public static CultureInfo[] GetSpecificCultures() {
            return GetCultures(CultureTypes.SpecificCultures);
        }

        public static CultureInfo[] GetCultures(CultureTypes types) {
            return CultureInfo.GetCultures(types);
        }

        public static RegionInfo ToRegionInfo(CultureInfo info) {
            return new RegionInfo(info.LCID);
        }
    }
}
