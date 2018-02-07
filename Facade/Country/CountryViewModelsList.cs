using System.Collections.Generic;
using Open.Domain.Country;

namespace Open.Facade.Country {
    public class CountryViewModelsList : List<CountryViewModel> {
        public CountryViewModelsList(IEnumerable<CountryObject> l) {
            foreach (var e in l) {
                Add(CountryViewModelFactory.Create(e));
            }
        }
    }
}
