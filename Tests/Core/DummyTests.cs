using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Open.Tests.Core {

    [TestClass]
    public class DummyTests : ObjectTests<Dummy> {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new Dummy());
        }

        protected override Dummy getRandomTestObject() {
            return null;
        }
    }
}
