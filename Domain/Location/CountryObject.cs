using Open.Data.Location;
using Open.Domain.Common;

namespace Open.Domain.Location {

    public sealed class CountryObject : IdentifiedObject<CountryDbRecord> {

        public CountryObject(CountryDbRecord r) : base(r ?? new CountryDbRecord()) { }
    }
}
