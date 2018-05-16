using System.Threading.Tasks;
using Open.Core;
using Open.Data.Location;

namespace Open.Domain.Location {
    
    //TODO: different than Lab17End
    public interface IAddressObjectsRepository : IObjectsRepository<IAddressObject, AddressDbRecord> {
        Task<IPaginatedList<IAddressObject>> GetDevicesList();
    }
}
