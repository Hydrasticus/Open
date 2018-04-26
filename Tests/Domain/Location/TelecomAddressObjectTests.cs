using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class TelecomAddressObjectTests : DomainObjectTests<TelecomAddressObject, TelecomAddressDbRecord> {

        protected override TelecomAddressObject getRandomTestObject() {
            createdWithNullArg = new TelecomAddressObject(null);
            dbRecordType = typeof(TelecomAddressDbRecord);
            return GetRandom.Object<TelecomAddressObject>();
        }
    }
}
