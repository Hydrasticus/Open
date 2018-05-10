using System.Threading.Tasks;
using Open.Core;

namespace Open.Domain.Location {

    //TODO: different than Lab17End
    public interface ITelecomDeviceRegistrationObjectsRepository : ICrudRepository<TelecomDeviceRegistrationObject> {

        Task LoadAddresses(TelecomAddressObject device);
        Task LoadDevices(GeographicAddressObject address);
    }
}
