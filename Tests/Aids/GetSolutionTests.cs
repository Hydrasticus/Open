using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;

namespace Open.Tests.Aids {
    [TestClass]
    public class GetSolutionTests : ObjectTests<GetSolution> {
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetSolution);
        }

        protected override GetSolution getRandomTestObject() {
            return null;
        }

        [TestMethod]
        public void InitializeTest() {
            Assert.Inconclusive();
        }
    }
}
