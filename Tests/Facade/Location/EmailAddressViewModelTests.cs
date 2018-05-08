using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location {

    [TestClass]
    public class EmailAddressViewModelTests : ObjectTests<EMailAddressViewModel> {

        protected override EMailAddressViewModel getRandomTestObject() {
            return GetRandom.Object<EMailAddressViewModel>();
        }

        [TestMethod]
        public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressViewModel));
        }

        [TestMethod]
        public void EmailAddressTest() {
            testReadWriteProperty(() => obj.EmailAddress, x => obj.EmailAddress = x);
        }
    }
}
