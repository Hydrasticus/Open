using Open.Core;
using Open.Data.Location;

namespace Open.Domain.Country {

    public class CountryObjectsList : PaginatedList<CountryObject> {

        public CountryObjectsList(IPaginatedList<CountryDbRecord> items) {
            if (items is null) return;
            PageIndex = items.PageIndex;
            TotalPages = items.TotalPages;
            
            foreach (var dbRecord in items) {
                Add(new CountryObject(dbRecord));
            }
        }
    }
}
