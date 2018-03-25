using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Country;

namespace Open.Tests.Domain.Country {

    [TestClass]
    public class CountryObjectTests : ObjectTests<CountryObject> {

        protected override CountryObject getRandomTestObject() {
            return GetRandom.Object<CountryObject>();
        }

        [TestMethod]
        public void DbRecordTest() {
            Assert.Inconclusive();
        }
    }
}
