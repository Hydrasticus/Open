using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Tests.Domain.Common;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class EmailAddressObjectTests : DomainObjectTests<EmailAddressObject, EmailAddressDbRecord> {

        protected override EmailAddressObject getRandomTestObject() {
            createdWithNullArg = new EmailAddressObject(null);
            dbRecordType = typeof(EmailAddressDbRecord);
            return GetRandom.Object<EmailAddressObject>();
        }
    }
}
