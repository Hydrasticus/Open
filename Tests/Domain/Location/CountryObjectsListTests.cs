using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location {

    [TestClass]
    public class CountryObjectsListTests : ObjectTests<CountryObjectsList> {
        
        //TODO: fix
        protected override CountryObjectsList getRandomTestObject() {
            var l = new List<CountryDbRecord>();
            SetRandom.Values(l);
            //return new CountryObjectsList(l);
            return null;
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryObjectsList(null, null));
        }
    }
}
