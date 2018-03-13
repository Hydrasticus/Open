using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;

namespace Open.Tests.Aids {
    
    [TestClass]
    public class GetSolutionTests : BaseTests {
        
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetSolution);
        }

        [TestMethod]
        public void DomainTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AssembliesTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AssemblyByNameTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void TypesForAssemblyTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void TypeNamesForAssemblyTest() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void NameTest() {
            Assert.Inconclusive();
        }
    }
}
