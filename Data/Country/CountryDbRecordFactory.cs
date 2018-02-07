using System;
using System.Globalization;

namespace Open.Data.Country {
    public static class CountryDbRecordFactory {
        public static CountryDbRecord Create(string id, string name, string code, DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new CountryDbRecord() {
                ID = id,
                Name = name,
                Code = code,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return o;
        }

        public static CountryDbRecord Create(RegionInfo r) {
            var id = r.ThreeLetterISORegionName;
            var name = r.DisplayName;
            var code = r.TwoLetterISORegionName;
            return Create(id, name, code);
        }
    }
}
