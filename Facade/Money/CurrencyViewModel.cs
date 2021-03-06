﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Location;

namespace Open.Facade.Money {

    public class CurrencyViewModel : NamedViewModel {

        private string isoCode;
        private string symbol;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Currency Code")]
        public string IsoCode {
            get => getString(ref isoCode);
            set => isoCode = value;
        }

        [Required]
        [DisplayName("Currency Symbol")]
        public string Symbol {
            get => getString(ref symbol);
            set => symbol = value;
        }

        [DisplayName("Used in countries")]
        public List<CountryViewModel> UsedInCountries { get; } = new List<CountryViewModel>();
    }
}
