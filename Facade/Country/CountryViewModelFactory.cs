using Open.Domain.Country;

namespace Open.Facade.Country {
    
    public static class CountryViewModelFactory {
        
        public static CountryViewModel Create(CountryObject o) {
            var v = new CountryViewModel {
                Name = o?.DbRecord.Name,
                Alpha3Code = o?.DbRecord.ID,
                Alpha2Code = o?.DbRecord.Code
            };

            if (o is null) return v;
            v.ValidFrom = o.DbRecord.ValidFrom;
            v.ValidTo = o.DbRecord.ValidTo;
            return v;
        }
    }
}
