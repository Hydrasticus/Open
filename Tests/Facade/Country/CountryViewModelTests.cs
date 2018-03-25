using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Country;

namespace Open.Tests.Facade.Country {

    [TestClass]
    public class CountryViewModelTests : ObjectTests<CountryViewModel> {

        [TestMethod]
        public void CanCreate() {
            Assert.IsNotNull(new CountryViewModel());
        }

        protected override CountryViewModel getRandomTestObject() {
            return GetRandom.Object<CountryViewModel>();
        }
        
        [TestMethod]
        public void NameTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public void ValidFromTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public void ValidToTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public void Alpha3CodeTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public void Alpha2CodeTest() {
            Assert.Inconclusive();
        }
    }
}
