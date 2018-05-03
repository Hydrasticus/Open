using System.Collections.Generic;
using Open.Data.Location;
using Open.Domain.Common;
using Open.Domain.Money;

namespace Open.Domain.Location {

    public sealed class CountryObject : IdentifiedObject<CountryDbRecord> {

        private readonly List<CurrencyObject> currenciesInUse;

        public CountryObject(CountryDbRecord r) : base(r ?? new CountryDbRecord()) {
            currenciesInUse = new List<CurrencyObject>();
        }

        public IReadOnlyList<CurrencyObject> CurrenciesInUse => currenciesInUse.AsReadOnly();
    }
}
