using Open.Data.Common;

namespace Open.Data.Location {
    
    public class TelecomDeviceRegistrationDbRecord : TemporalDbRecord {

        private string addressID, deviceID;
        private GeographicAddressDbRecord address;
        private TelecomAddressDbRecord device;
        
        public string AddressID {
            get => getString(ref addressID);
            set => addressID = value;
        }

        public string DeviceID {
            get => getString(ref deviceID);
            set => deviceID = value;
        }
        
        public virtual GeographicAddressDbRecord Address {
            get => getValue(ref address);
            set => address = value;
        }
        
        public virtual TelecomAddressDbRecord Device {
            get => getValue(ref device);
            set => device = value;
        }
    }
}
