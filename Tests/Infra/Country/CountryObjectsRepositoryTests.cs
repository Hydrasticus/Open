using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Country;

namespace Open.Tests.Infra.Country {

    [TestClass]
    public class CountryObjectsRepositoryTests : ObjectTests<CountryObjectsRepository> {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryObjectsRepository(null));
        }

        protected override CountryObjectsRepository getRandomTestObject() {
            return null;
        }

        [TestMethod]
        public void GetObjectTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetObjectsListTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddObjectTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void UpdateObjectTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void DeleteObjectTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IsInitializedTest() {
            Assert.Inconclusive();
        }
    }
}
