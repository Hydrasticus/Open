using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Domain.Country;

namespace Open.Tests.Domain.Country {

    [TestClass]
    public class CountryObjectTests : ObjectTests<CountryObject> {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryObject(null));
        }

        protected override CountryObject getRandomTestObject() {
            return null;
        }
    }
}
