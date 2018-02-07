using System;
using System.ComponentModel;

namespace Open.Facade.Country {
    public class CountryViewModel {
        public string Name { get; set; }

        [DisplayName("Valid From")]
        public DateTime ValidFrom { get; set; }

        [DisplayName("Valid To")]
        public DateTime ValidTo { get; set; }

        [DisplayName("ISO Three Character Code")]
        public string Alpha3Code { get; set; }

        [DisplayName("ISO Two Character Code")]
        public string Alpha2Code { get; set; }
    }
}
