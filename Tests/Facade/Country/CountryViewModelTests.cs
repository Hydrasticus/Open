using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Country;

namespace Open.Tests.Facade.Country {

    [TestClass]
    public class CountryViewModelTests : ObjectTests<CountryViewModel> {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryViewModel());
        }

        protected override CountryViewModel getRandomTestObject() {
            return null;
        }
    }
}
