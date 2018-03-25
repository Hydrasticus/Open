using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Country;
using Open.Domain.Country;

namespace Open.Tests.Domain.Country {

    [TestClass]
    public class CountryObjectsListTests : ObjectTests<CountryObjectsList> {
        
        protected override CountryObjectsList getRandomTestObject() {
            var l = new List<CountryDbRecord>();
            SetRandom.Values(l);
            return new CountryObjectsList(l);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryObjectsList(null));
        }
    }
}
