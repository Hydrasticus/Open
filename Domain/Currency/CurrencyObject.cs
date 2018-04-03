using Open.Data.Currency;

namespace Open.Domain.Currency {

    public class CurrencyObject {

        public readonly CurrencyDbRecord DbRecord;

        public CurrencyObject(CurrencyDbRecord r) {
            DbRecord = r ?? new CurrencyDbRecord();
        }
    }
}