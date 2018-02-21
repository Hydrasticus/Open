using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Country;

namespace Tests.Facade.Country {

    [TestClass]
    public class CountryViewModelTests {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryViewModel());
        }
    }
}
