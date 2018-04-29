using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;

namespace Open.Facade.Money {

    public class CurrencyViewModel : NamedViewModel {

        private string isoCode;
        private string symbol;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Currency Code")]
        public string IsoCode {
            get => GetValue(ref isoCode, Constants.Unspecified);
            set => isoCode = value;
        }

        [Required]
        [DisplayName("Currency Symbol")]
        public string Symbol {
            get => GetValue(ref symbol, Constants.Unspecified);
            set => symbol = value;
        }
    }
}
