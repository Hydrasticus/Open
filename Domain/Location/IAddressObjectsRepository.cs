using Open.Core;
using Open.Data.Location;

namespace Open.Domain.Location {
    
    public interface IAddressObjectsRepository : IObjectsRepository<AddressObject<AddressDbRecord>, AddressDbRecord> {
        
    }
}
