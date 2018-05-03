using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Money;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Money {

    [TestClass]
    public class CurrencyObjectTests : DomainObjectTests<CurrencyObject, CurrencyDbRecord> {

        protected override CurrencyObject getRandomTestObject() {
            createdWithNullArg = new CurrencyObject(null);
            dbRecordType = typeof(CurrencyDbRecord);
            return GetRandom.Object<CurrencyObject>();
        }

        [TestMethod]
        public void UsedInCountriesTest() {
            Assert.IsNotNull(obj.UsedInCountries);
            Assert.IsInstanceOfType(obj.UsedInCountries, typeof(IReadOnlyList<CountryObject>));
        }
    }
}
