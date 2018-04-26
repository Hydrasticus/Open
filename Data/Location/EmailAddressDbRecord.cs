using Open.Core;

namespace Open.Data.Location {

    public class EmailAddressDbRecord : AddressDbRecord {

        private string emailAddress;

        public string EmailAddress {
            get => GetValue(ref emailAddress, Constants.Unspecified);
            set => emailAddress = value;
        }
    }
}