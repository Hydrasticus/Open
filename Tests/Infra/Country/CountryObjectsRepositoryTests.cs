using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;

namespace Tests.Infra.Country {

    [TestClass]
    public class CountryObjectsRepositoryTests {

        [TestMethod]
        public void CanCreateTest() {
            Assert.IsNotNull(new CountryObjectsRepository(null));
        }
    }
}
