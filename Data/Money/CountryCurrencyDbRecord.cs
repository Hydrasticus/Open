using Open.Core;
using Open.Data.Common;
using Open.Data.Location;

namespace Open.Data.Money {

    public class CountryCurrencyDbRecord : TemporalDbRecord {

        private string countryID;
        private string currencyID;
        private CountryDbRecord country;
        private CurrencyDbRecord currency;

        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }

        public string CurrencyID {
            get => getString(ref currencyID);
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
