using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class GeographicAddressObjectTests : DomainObjectTests<GeographicAddressObject, GeographicAddressDbRecord> {

        protected override GeographicAddressObject getRandomTestObject() {
            createdWithNullArg = new GeographicAddressObject(null);
            dbRecordType = typeof(GeographicAddressDbRecord);
            return GetRandom.Object<GeographicAddressObject>();
        }
    }
}
