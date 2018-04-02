using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Country;
using Open.Domain.Country;

namespace Open.Tests.Aids {
    
    [TestClass]
    public class GetMemberTests : BaseTests {

        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetMember);
        }

        [TestMethod]
        public void NameTest() {
            Assert.AreEqual("DbRecord", GetMember.Name<CountryObject>(o=>o.DbRecord));
            Assert.AreEqual("Name", GetMember.Name<CountryDbRecord>(o=>o.Name));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o=>o.NameTest()));
        }
    }
}