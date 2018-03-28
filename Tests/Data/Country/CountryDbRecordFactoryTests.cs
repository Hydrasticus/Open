using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Country;

namespace Open.Tests.Data.Country {

    [TestClass]
    public class CountryDbRecordFactoryTests : BaseTests {
        //TODO: fix tests

        private string id;
        private string name;
        private string code;
        private DateTime validFrom;
        private DateTime validTo;
        private CountryDbRecord r;

        private void initializeTestData() {
            var min = DateTime.Now.AddYears(-50);
            var max = DateTime.Now.AddYears(50);
            id = GetRandom.String();
            name = GetRandom.String();
            code = GetRandom.String();
            validFrom = GetRandom.DateTime(min, max);
            validTo = GetRandom.DateTime(validFrom, max);
        }

        private void validateResults(string i = Constants.Unspecified,
            string n = Constants.Unspecified,
            string c = Constants.Unspecified,
            DateTime? f = null,
            DateTime? t = null) {
            
            Assert.AreEqual(i, r.ID);
            Assert.AreEqual(n, r.Name);
            Assert.AreEqual(c, r.Code);
            Assert.AreEqual(f ?? DateTime.MinValue, r.ValidFrom);
            Assert.AreEqual(t ?? DateTime.MaxValue, r.ValidTo);
        }

        [TestMethod]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountryDbRecordFactory);
            initializeTestData();
        }

        [TestMethod]
        public void CreateTest() {
            r = CountryDbRecordFactory.Create(id, name, code, validFrom, validTo);
            validateResults(id, name, code, validFrom, validTo);
        }

        [TestMethod]
        public void CreateWithNullArgumentsTest() {
            r = CountryDbRecordFactory.Create(null, null, null);
            validateResults();
        }

        [TestMethod]
        public void CreateWithNullRegionInfoTest() {
            r = CountryDbRecordFactory.Create(null);
            validateResults();
        }

        [TestMethod]
        public void CreateWithRegionInfoTest() {
            var i = new RegionInfo("ee-EE");
            r = CountryDbRecordFactory.Create(i);
            validateResults(i.ThreeLetterISORegionName, i.DisplayName, i.TwoLetterISORegionName);
        }

        [TestMethod]
        public void CreateWithCodeOnlyTest() {
            r = CountryDbRecordFactory.Create(null, null, code);
            validateResults(code, code, code);
        }

        [TestMethod]
        public void CreateWithNameOnlyTest() {
            r = CountryDbRecordFactory.Create(null, name, null);
            validateResults(name, name);
        }

        [TestMethod]
        public void CreateValidFromGreaterThanValidToTest() {
            r = CountryDbRecordFactory.Create(id, name, code, validTo, validFrom);
            validateResults(id, name, code, validFrom, validTo);
        }
    }
}
