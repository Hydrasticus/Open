using Open.Core;

namespace Open.Data.Location {
    
    public class WebAddressDbRecord : AddressDbRecord {

        private string webAddress;

        public string WebAddress {
            get => GetValue(ref webAddress, Constants.Unspecified);
            set => webAddress = value;
        }
    }
}