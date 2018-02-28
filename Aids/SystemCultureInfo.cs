using System.Globalization;

namespace Open.Aids {

    public static class SystemCultureInfo {

        public static CultureInfo[] GetSpecificCultures() {
            return GetCultures(CultureTypes.SpecificCultures);
        }

        public static CultureInfo[] GetCultures(CultureTypes types) {
            try {
                return CultureInfo.GetCultures(types);
            } catch {
                return new CultureInfo[0];
            }
        }

        public static RegionInfo ToRegionInfo(CultureInfo info) {
            if (info is null) return null;
            try {
                return new RegionInfo(info.LCID);
            } catch {
                return null;
            }
        }
    }
}
