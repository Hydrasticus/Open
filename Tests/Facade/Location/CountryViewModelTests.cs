using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Location;

namespace Open.Tests.Facade.Location {

    [TestClass]
    public class CountryViewModelTests : ViewModelTests<CountryViewModel, NamedViewModel> {

        protected override CountryViewModel getRandomTestObject() {
            return GetRandom.Object<CountryViewModel>();
        }

        [TestMethod]
        public void Alpha3CodeTest() {
            testReadWriteProperty(() => obj.Alpha3Code, x => obj.Alpha3Code = x);
        }

        [TestMethod]
        public void Alpha2CodeTest() {
            testReadWriteProperty(() => obj.Alpha2Code, x => obj.Alpha2Code = x);
        }
    }
}
