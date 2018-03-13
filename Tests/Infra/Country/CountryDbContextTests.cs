using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Country;

namespace Open.Tests.Infra.Country {
 
    [TestClass]
    public class CountryDbContextTests : ObjectTests<CountryDbContext> {
    
        protected override CountryDbContext getRandomTestObject() {
            throw new System.NotImplementedException();
        }
    }
}
