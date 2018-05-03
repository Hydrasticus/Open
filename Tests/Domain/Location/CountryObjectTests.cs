using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class CountryObjectTests : DomainObjectTests<CountryObject, CountryDbRecord> {

        protected override CountryObject getRandomTestObject() {
            createdWithNullArg = new CountryObject(null);
            dbRecordType = typeof(CountryDbRecord);
            return GetRandom.Object<CountryObject>();
        }

        [TestMethod]
        public void CurrenciesInUseTest() {
            Assert.IsNotNull(obj.CurrenciesInUse);
            Assert.IsNotInstanceOfType(obj.CurrenciesInUse, typeof(IReadOnlyList<CurrencyObject>));
        }
    }
}
