using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Money;

namespace Open.Tests.Facade.Money {

    [TestClass]
    public class CurrencyViewModelTests : ViewModelTests<CurrencyViewModel, NamedViewModel> {

        protected override CurrencyViewModel getRandomTestObject() {
            return GetRandom.Object<CurrencyViewModel>();
        }

        [TestMethod]
        public void IsoCodeTest() {
            testReadWriteProperty(() => obj.IsoCode, x => obj.IsoCode = x);
        }

        [TestMethod]
        public void SymbolTest() {
            testReadWriteProperty(() => obj.Symbol, x => obj.Symbol = x);
        }
    }
}
