using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Facade {
    
    [TestClass]
    public abstract class ViewModelTests<TClass, TBaseClass> : ObjectTests<TClass> {

        [TestMethod]
        public void BaseClassTest() {
            Assert.IsInstanceOfType(obj, typeof(TBaseClass));
        }
    }
}
