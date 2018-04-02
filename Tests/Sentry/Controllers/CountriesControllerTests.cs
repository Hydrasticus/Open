using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Controllers;

namespace Open.Tests.Sentry.Controllers {

    [TestClass]
    public class CountryControllerTests : AcceptanceTests {

        [TestMethod]
        public async Task IndexTestWhenLoggedOut() {
            var response = await client.GetAsync("/countries");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task IndexTestWhenLoggedIn() {
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync("/countries");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(stringResponse.Contains("Countries"));
        }
    }
}
