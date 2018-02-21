using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Domain.Country;

namespace Tests.Domain.Country {

    [TestClass]
    public class CountryObjectTests {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryObject(null));
        }
    }
}
