using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;

namespace Open.Tests.Aids {
    [TestClass]
    public class GetEnumTests : BaseTests {
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetEnum);

        }

        [TestMethod]
        public void CountTest() {
            Assert.AreEqual(4, GetEnum.Count<IsoGender>());
            Assert.AreEqual(-1, GetEnum.Count<object>());
        }
    }
}
