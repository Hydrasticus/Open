using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Data {
    [TestClass]
    public class IsDataTested : AssemblyTests {
        private const string assembly = "Open.Data";

        protected override string Namespace(string name) {
            return $"{assembly}.{name}";
        }

        [TestMethod]
        public void IsCountryTested() {
            isAllClassesTested(assembly, Namespace("Country"));
        }
    }
}
