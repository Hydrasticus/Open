using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Location;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location {
 
    [TestClass]
    public class CountryViewModelsListTests : ObjectTests<CountryViewModelsList> {
        
        //TODO: see some other examples from Lab13/3
        protected override CountryViewModelsList getRandomTestObject() {
            var l = new List<CountryObject>();
            SetRandom.Values(l);
            //return new CountryViewModelsList(l);
            return null;
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryViewModelsList(null));
        }
    }
}
