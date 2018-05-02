using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
using Open.Tests.Infra.Location;

namespace Open.Tests.Infra {

    [TestClass]
    public class SentryDbContextTests : CountryDbTests<SentryDbContext> {

        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(SentryDbContext);
        }

        [TestMethod]
        public void CountriesTest() {
            Assert.IsNotNull(db.Countries);
        }

        [TestMethod]
        public void CurrenciesTest() {
            Assert.IsNotNull(db.Currencies);
        }
    }
}
