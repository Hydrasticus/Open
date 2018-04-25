using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;

namespace Open.Tests.Data.Location {

    [TestClass]
    public class AddressDbRecordTests : ObjectTests<AddressDbRecord> {

        class testClass : AddressDbRecord { }

        protected override AddressDbRecord getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsAbstract() {
            Assert.IsTrue(typeof(AddressDbRecord).IsAbstract);
        }

        [TestMethod]
        public void BaseTypeIsUniqueDbRecord() {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(AddressDbRecord).BaseType);
        }
    }
}
