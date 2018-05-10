using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Infra.Location {

    //TODO: different than Lab17End
    public class TelecomDeviceRegistrationObjectsRepository : ITelecomDeviceRegistrationObjectsRepository {

        private readonly DbSet<TelecomDeviceRegistrationDbRecord> dbSet;
        private readonly DbContext db;

        public TelecomDeviceRegistrationObjectsRepository(SentryDbContext c) {
            db = c;
            dbSet = c?.TelecomDeviceRegistrations;
        }

        public Task<TelecomDeviceRegistrationObject> GetObject(string id) {
            throw new System.NotImplementedException();
        }

        public async Task AddObject(TelecomDeviceRegistrationObject o) {
            dbSet.Add(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task UpdateObject(TelecomDeviceRegistrationObject o) {
            dbSet.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task DeleteObject(TelecomDeviceRegistrationObject o) {
            dbSet.Remove(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task LoadAddresses(TelecomAddressObject device) {
            if (device is null) return;
            var id = device.DbRecord?.ID ?? string.Empty;
            var addresses = await dbSet.Include(x => x.Address).Where(x => x.DeviceID == id).AsNoTracking()
                .ToListAsync();
            foreach (var a in addresses) {
                device.RegisteredInAddress(new GeographicAddressObject(a.Address));
            }
        }

        public async Task LoadDevices(GeographicAddressObject address) {
            if (address is null) return;
            var id = address.DbRecord?.ID ?? string.Empty;
            var devices = await dbSet.Include(x => x.Device).Where(x => x.AddressID == id).AsNoTracking().
                ToListAsync();
            foreach (var d in devices) {
                address.RegisteredTelecomDevice(new TelecomAddressObject(d.Device));
            }
        }
    }
}
