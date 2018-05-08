using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location {

    [TestClass]
    public class AddressViewModelTests : ObjectTests<AddressViewModel> {

        private class testClass : AddressViewModel { }

        protected override AddressViewModel getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsUniqueEntityViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType.BaseType, typeof(UniqueEntityViewModel));
        }

        [TestMethod]
        public void AddressTypeTest() {
            testReadWriteProperty(() => obj.AddressType, x => obj.AddressType = x);
        }
    }
}
