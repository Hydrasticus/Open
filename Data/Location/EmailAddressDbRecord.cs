using Open.Core;

namespace Open.Data.Location {

    public class EmailAddressDbRecord : AddressDbRecord {

        private string emailAddress;

        public string EmailAddress {
            get => getString(ref emailAddress, Constants.Unspecified);
            set => emailAddress = value;
        }
    }
}