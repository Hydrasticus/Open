using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Country;

namespace Open.Tests.Facade.Country {

    [TestClass]
    public class CountryViewModelFactoryTests : BaseTests {
        [TestMethod]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountryViewModelFactory);
        }
    }
}
