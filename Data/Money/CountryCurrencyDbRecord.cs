using Open.Core;
using Open.Data.Common;
using Open.Data.Location;

namespace Open.Data.Money {

    public class CountryCurrencyDbRecord : TemporalDbRecord {

        private string countryID;
        private CountryDbRecord country;
        private string currencyID;
        private CurrencyDbRecord currency;

        public string CountryID {
            get => getValue(ref countryID, Constants.Unspecified);
            set => countryID = value;
        }

        public string CurrencyID {
            get => getValue(ref currencyID, Constants.Unspecified);
            set => currencyID = value;
        }

        public virtual CountryDbRecord Country {
            get => getValue(ref country);
            set => country = value;
        }

        public virtual CurrencyDbRecord Currency {
            get => getValue(ref currency);
            set => currency = value;
        }
    }
}
