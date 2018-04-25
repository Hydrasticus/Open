using System.Collections.Generic;
using Open.Core;
using Open.Data.Money;

namespace Open.Domain.Currency {
    
    public class CurrencyObjectsList : PaginatedList<CurrencyObject> {

        public CurrencyObjectsList(IPaginatedList<CurrencyDbRecord> items) {
            if (items is null) return;
            PageIndex = items.PageIndex;
            TotalPages = items.TotalPages;
            
            foreach (var dbRecord in items) {
                Add(new CurrencyObject(dbRecord));
            }
        }
    }
}
