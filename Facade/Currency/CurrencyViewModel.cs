using System;
using System.ComponentModel;
using Open.Core;

namespace Open.Facade.Currency {

    public class CurrencyViewModel : RootObject {

        private string name;
        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;
        private string isoCurrencySymbol;
        private string currencySymbol;

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

        [DisplayName("ISO Currency Symbol")]
        public string IsoCurrencySymbol {
            get => GetValue(ref isoCurrencySymbol, Constants.Unspecified);
            set => isoCurrencySymbol = value;
        }

        [DisplayName("Currency Symbol")]
        public string CurrencySymbol {
            get => GetValue(ref currencySymbol, Constants.Unspecified);
            set => currencySymbol = value;
        }
    }
}
