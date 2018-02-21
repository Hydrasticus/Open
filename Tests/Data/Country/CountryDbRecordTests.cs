using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Country;

namespace Tests.Data.Country {
    [TestClass] public class CountryDbRecordTests {
        [TestMethod] public void CanCreateTest() {
            Assert.IsNotNull(new CountryDbRecord());
        }
    }
}
