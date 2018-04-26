using Open.Data.Location;

namespace Open.Domain.Location {

    public sealed class GeographicAddressObject : AddressObject<GeographicAddressDbRecord> {

        public GeographicAddressObject(GeographicAddressDbRecord r) : base(r ?? new GeographicAddressDbRecord()) { }
    }
}
