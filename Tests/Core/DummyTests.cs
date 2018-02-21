using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Tests.Core
{

    [TestClass] public class DummyTests
    {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new Dummy());
        }
    }
}
