using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests {
    public abstract class ObjectTests<T> : ClassTests<T> {
        protected T obj;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = getRandomTestObject();
        }

        protected abstract T getRandomTestObject();
    }
}
