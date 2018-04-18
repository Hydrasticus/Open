﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Country;
using Open.Facade.Country;

namespace Open.Tests.Facade.Country {
 
    [TestClass]
    public class CountryViewModelsListTests : ObjectTests<CountryViewModelsList> {
        
        //TODO: fix
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
