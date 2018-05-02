using Open.Data.Location;

namespace Open.Domain.Location {

    public sealed class WebAddressObject : AddressObject<WebAddressDbRecord> {

        public WebAddressObject(WebAddressDbRecord r) : base(r ?? new WebAddressDbRecord()) { }
    }
}
