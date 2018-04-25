using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;

namespace Open.Tests.Data.Location {
    
    [TestClass]
    public class GeographicAddressDbRecordTests : ObjectTests<GeographicAddressDbRecord> {
        
        protected override GeographicAddressDbRecord getRandomTestObject() {
            return GetRandom.Object<GeographicAddressDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressDbRecord), obj.GetType().BaseType);
        }
    }
}
