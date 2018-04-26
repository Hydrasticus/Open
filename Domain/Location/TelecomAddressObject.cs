using Open.Data.Location;

namespace Open.Domain.Location {

    public sealed class TelecomAddressObject : AddressObject<TelecomAddressDbRecord> {

        public TelecomAddressObject(TelecomAddressDbRecord r) : base(r ?? new TelecomAddressDbRecord()) { }
    }
}
