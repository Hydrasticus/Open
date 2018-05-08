using Open.Core;

namespace Open.Data.Location {
    
    public class WebAddressDbRecord : AddressDbRecord {

        private string webAddress;

        public string WebAddress {
            get => getString(ref webAddress, Constants.Unspecified);
            set => webAddress = value;
        }
    }
}