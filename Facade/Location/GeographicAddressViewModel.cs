using System.Collections.Generic;
using System.ComponentModel;

namespace Open.Facade.Location {

    public class GeographicAddressViewModel : AddressViewModel {

        private string addressLine, city, regionOrState, zipOrPostalCode;
        private CountryViewModel country;

        [DisplayName("Address Line")]
        public string AddressLine {
            get => getString(ref addressLine);
            set => addressLine = value;
        }

        public string City {
            get => getString(ref city);
            set => city = value;
        }

        [DisplayName("Region or State")]
        public string RegionOrState {
            get => getString(ref regionOrState);
            set => regionOrState = value;
        }

        [DisplayName("Zip or Postal Code")]
        public string ZipOrPostalCode {
            get => getString(ref zipOrPostalCode);
            set => zipOrPostalCode = value;
        }

        public CountryViewModel Country {
            get => getValue(ref country);
            set => country = value;
        }

        public List<TelecomAddressViewModel> RegisteredTelecomAddresses { get; } = new List<TelecomAddressViewModel>();
    }
}