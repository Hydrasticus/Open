using System.Collections.Generic;
using System.ComponentModel;
using Open.Core;

namespace Open.Facade.Location {

    public class TelecomAddressViewModel : AddressViewModel {

        private string countryCode, areaCode, number, extension, nationalDirectDialingPrefix;

        [DisplayName("Country Code")]
        public string CountryCode {
            get => getString(ref countryCode);
            set => countryCode = value;
        }

        [DisplayName("Area Code")]
        public string AreaCode {
            get => getString(ref areaCode);
            set => areaCode = value;
        }

        public string Number {
            get => getString(ref number);
            set => number = value;
        }

        public string Extension {
            get => getString(ref extension);
            set => extension = value;
        }

        [DisplayName("National Direct Dialing Prefix")]
        public string NationalDirectDialingPrefix {
            get => getString(ref nationalDirectDialingPrefix);
            set => nationalDirectDialingPrefix = value;
        }

        [DisplayName("Device Type")]
        public TelecomDevice DeviceType { get; set; }

        public List<GeographicAddressViewModel> RegisteredInAddresses { get; } =
            new List<GeographicAddressViewModel>();

        public override string ToString() {
            var s = Number;
            if (AreaCode != Constants.Unspecified) s = $"{AreaCode} {s}";
            if (NationalDirectDialingPrefix != Constants.Unspecified) s = $"({NationalDirectDialingPrefix}){s}";
            if (CountryCode != Constants.Unspecified) s = $"{CountryCode} {s}";
            if (Extension != Constants.Unspecified) s = $"{s} ext. {Extension}";
            return s;
        }
    }
}
