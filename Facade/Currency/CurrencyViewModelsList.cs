using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Domain.Currency;

namespace Open.Facade.Currency {
    
    public class CurrencyViewModelsList : PaginatedList<CurrencyViewModel> {

        public CurrencyViewModelsList(IPaginatedList<CurrencyObject> l, string sortOrder = null) {
            
            if (l is null) return;
            PageIndex = l.PageIndex;
            TotalPages = l.TotalPages;
            var currencies = new List<CurrencyViewModel>();
            IOrderedEnumerable<CurrencyViewModel> ordered;
            foreach (var e in l) {
                currencies.Add(CurrencyViewModelFactory.Create(e));
            }

            switch (sortOrder) {
                case "name_desc":
                    ordered = currencies.OrderByDescending(s => s.Name);
                    break;
                case "isoCurrency":
                    ordered = currencies.OrderBy(s => s.IsoCurrencySymbol);
                    break;
                case "isoCurrency_desc":
                    ordered = currencies.OrderByDescending(s => s.IsoCurrencySymbol);
                    break;
                case "currency":
                    ordered = currencies.OrderBy(s => s.CurrencySymbol);
                    break;
                case "currency_desc":
                    ordered = currencies.OrderByDescending(s => s.CurrencySymbol);
                    break;
                case "validFrom":
                    ordered = currencies.OrderBy(s => s.ValidFrom);
                    break;
                case "validFrom_desc":
                    ordered = currencies.OrderByDescending(s => s.ValidFrom);
                    break;
                case "validTo":
                    ordered = currencies.OrderBy(s => s.ValidTo);
                    break;
                case "validTo_desc":
                    ordered = currencies.OrderByDescending(s => s.ValidTo);
                    break;
                default:
                    ordered = currencies.OrderBy(s => s.Name);
                    break;
            }
            
            AddRange(ordered);
        }
    }
}
