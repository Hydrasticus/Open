using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Controllers;

namespace Open.Tests.Sentry.Controllers {

    [TestClass]
    public class CountryControllerTests {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryController(null));
        }
    }
}
