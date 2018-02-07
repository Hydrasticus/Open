using Open.Domain.Country;

namespace Open.Facade.Country {
    public static class CountryViewModelFactory {
        public static CountryViewModel Create(CountryObject o) {
            return new CountryViewModel {
                Name = o.DbRecord.Name,
                ValidFrom = o.DbRecord.ValidFrom,
                ValidTo = o.DbRecord.ValidTo,
                Alpha3Code = o.DbRecord.ID,
                Alpha2Code = o.DbRecord.Code
            };
        }
    }
}
