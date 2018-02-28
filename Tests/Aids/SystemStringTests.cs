using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;

namespace Open.Tests.Aids {
    [TestClass]
    public class SystemStringTests : BaseTests {

        [TestMethod]
        public void StartsWithLetterTest() {
            Assert.IsTrue(SystemString.StartsWithLetter("abc"));
            Assert.IsFalse(SystemString.StartsWithLetter("1abc"));
            Assert.IsFalse(SystemString.StartsWithLetter(""));
            Assert.IsFalse(SystemString.StartsWithLetter(null));
        }

        [TestMethod]
        public void ToBackwardsTest() {
            Assert.AreEqual("cba", SystemString.ToBackwards("abc"));
            Assert.AreEqual("   ", SystemString.ToBackwards("   "));
            Assert.AreEqual("", SystemString.ToBackwards(""));
            Assert.AreEqual(string.Empty, SystemString.ToBackwards(null));
        }
    }
}
