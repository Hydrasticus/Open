using System;
using Open.Data.Country;

namespace Open.Domain.Country {
    public static class CountryObjectFactory {
        public static CountryObject Create(string id, string name, string code, DateTime? validFrom = null,
            DateTime? validTo = null) {
            var o = CountryDbRecordFactory.Create(id, name, code, validFrom, validTo);
            return new CountryObject(o);
        }
    }
}
