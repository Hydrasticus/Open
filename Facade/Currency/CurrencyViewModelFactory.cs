using Open.Domain.Currency;

namespace Open.Facade.Currency {
    
    public static class CurrencyViewModelFactory {

        public static CurrencyViewModel Create(CurrencyObject o) {
            var v = new CurrencyViewModel {
                Name = o?.DbRecord.Name,
                IsoCurrencySymbol = o?.DbRecord.ID,
                CurrencySymbol = o?.DbRecord.Code
            };

            if (o is null) return v;
            v.ValidFrom = o.DbRecord.ValidFrom;
            v.ValidTo = o.DbRecord.ValidTo;
            return v;
        }
    }
}