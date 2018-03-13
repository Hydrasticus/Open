using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Country;

namespace Open.Tests.Data.Country {
    [TestClass] public class CountryDbRecordTests : ObjectTests<CountryDbRecord> {
        [TestMethod] public void CanCreateTest() {
            Assert.IsNotNull(new CountryDbRecord());
        }

        protected override CountryDbRecord getRandomTestObject() {
            return null;
        }
    }
}
