using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class WebAddressObjectTests : DomainObjectTests<WebAddressObject, WebAddressDbRecord> {

        protected override WebAddressObject getRandomTestObject() {
            createdWithNullArg = new WebAddressObject(null);
            dbRecordType = typeof(WebAddressDbRecord);
            return GetRandom.Object<WebAddressObject>();
        }
    }
}
