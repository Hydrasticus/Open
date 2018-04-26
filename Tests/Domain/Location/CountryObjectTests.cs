using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class CountryObjectTests : DomainObjectTests<CountryObject, CountryDbRecord> {

        protected override CountryObject getRandomTestObject() {
            createdWithNullArg = new CountryObject(null);
            dbRecordType = typeof(CountryDbRecord);
            return GetRandom.Object<CountryObject>();
        }
    }
}
