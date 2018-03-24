using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Country;

namespace Open.Tests.Data.Country {
    
    [TestClass]
    public class CountryDbRecordTests : ObjectTests<CountryDbRecord> {
        
        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(obj);
        }

        protected override CountryDbRecord getRandomTestObject() {
            return GetRandom.Object<CountryDbRecord>();
        }

        [TestMethod]
        public void IDTest() {
            testReadWriteProperty(() => obj.ID, x => obj.ID = x);
        }

        [TestMethod]
        public void NameTest() {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void CodeTest() {
            testReadWriteProperty(() => obj.Code, x => obj.Code = x);
        }

        [TestMethod]
        public void ValidFromTest() {
            testReadWriteProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
        
        [TestMethod]
        public void ValidToTest() {
            testReadWriteProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }
    }
}
