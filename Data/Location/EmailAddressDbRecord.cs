using Open.Core;

namespace Open.Data.Location {

    public class EmailAddressDbRecord : AddressDbRecord {

        private string emailAddress;

        public string EmailAddress {
            get => getValue(ref emailAddress, Constants.Unspecified);
            set => emailAddress = value;
        }
    }
}