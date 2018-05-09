using System.ComponentModel;

namespace Open.Facade.Location {

    public class EMailAddressViewModel : AddressViewModel {

        private string emailAddress;

        [DisplayName("Email")]
        public string EmailAddress {
            get => getString(ref emailAddress);
            set => emailAddress = value;
        }

        public override string ToString() {
            return EmailAddress;
        }
    }
}
