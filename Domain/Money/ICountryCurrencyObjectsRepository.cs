using Open.Core;
using Open.Data.Money;

namespace Open.Domain.Money {

    public interface
        ICountryCurrencyObjectsRepository : IObjectsRepository<CountryCurrencyObject, CountryCurrencyDbRecord> { }
}
