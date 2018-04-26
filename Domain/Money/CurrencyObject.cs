using Open.Data.Money;
using Open.Domain.Common;

namespace Open.Domain.Money {

    public sealed class CurrencyObject : MetricObject<CurrencyDbRecord> {

        public CurrencyObject(CurrencyDbRecord r) : base(r ?? new CurrencyDbRecord()) { }
    }
}
