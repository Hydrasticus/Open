using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;

namespace Open.Facade.Currency {

    public class CurrencyViewModel : RootObject {

        private string name;
        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;
        private string isoCurrencySymbol;
        private string currencySymbol;

        [Required]
        [RegularExpression((RegularExpressionFor.EnglishTextOnly))]
        public string Name {
            get => getValue(ref name, Constants.Unspecified);
            set => name = value;
        }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Currency Symbol")]
        public string IsoCurrencySymbol {
            get => getValue(ref isoCurrencySymbol, Constants.Unspecified);
            set => isoCurrencySymbol = value;
        }

        [Required]
        [StringLength(4, MinimumLength = 1)]
        [DisplayName("Currency Symbol")]
        public string CurrencySymbol {
            get => getValue(ref currencySymbol, Constants.Unspecified);
            set => currencySymbol = value;
        }

        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }
    }
}
