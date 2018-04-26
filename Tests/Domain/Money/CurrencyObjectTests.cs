using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Money;
using Open.Domain.Money;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Money {

    [TestClass]
    public class CurrencyObjectTests : DomainObjectTests<CurrencyObject, CurrencyDbRecord> {

        protected override CurrencyObject getRandomTestObject() {
            createdWithNullArg = new CurrencyObject(null);
            dbRecordType = typeof(CurrencyDbRecord);
            return GetRandom.Object<CurrencyObject>();
        }
    }
}
