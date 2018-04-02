using System;
using System.ComponentModel;
using Open.Core;

namespace Open.Facade.Country {

    public class CountryViewModel : RootObject {

        private string name;
        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;
        private string alpha3Code;
        private string alpha2Code;

        public string Name {
            get => GetValue(ref name, Constants.Unspecified);
            set => name = value;
        }

        [DisplayName("Valid From")]
        public DateTime ValidFrom {
            get => GetMinValue(ref validFrom, ref validTo);
            set => validFrom = value;
        }

        [DisplayName("Valid To")]
        public DateTime ValidTo {
            get => GetMaxValue(ref validTo, ref validFrom);
            set => validTo = value;
        }

        [DisplayName("ISO Three Character Code")]
        public string Alpha3Code {
            get => GetValue(ref alpha3Code, Constants.Unspecified);
            set => alpha3Code = value;
        }

        [DisplayName("ISO Two Character Code")]
        public string Alpha2Code {
            get => GetValue(ref alpha2Code, Constants.Unspecified);
            set => alpha2Code = value;
        }
    }
}
