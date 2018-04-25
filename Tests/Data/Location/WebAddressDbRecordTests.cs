using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;

namespace Open.Tests.Data.Location {

    [TestClass]
    public class WebAddressDbRecordTests : ObjectTests<WebAddressDbRecord> {

        protected override WebAddressDbRecord getRandomTestObject() {
            return GetRandom.Object<WebAddressDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressDbRecord), obj.GetType().BaseType);
        }

        [TestMethod]
        public void WebAddressTest() {
            testReadWriteProperty(() => obj.WebAddress, x => obj.WebAddress = x);
            testNullEmptyAndWhitespaceCases(() => obj.WebAddress, x => obj.WebAddress = x, () => Constants.Unspecified);
        }
    }
}
