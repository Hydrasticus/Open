﻿using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Location;
using Open.Sentry.Controllers;

namespace Open.Tests.Sentry.Controllers {

    [TestClass]
    public class CountriesControllerTests : AcceptanceTests {

        [TestMethod]
        public async Task IndexTestWhenLoggedOut() {
            var response = await client.GetAsync("/countries");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        //TODO: fix
        [TestMethod]
        public async Task IndexTestWhenLoggedIn() {
            Assert.Inconclusive();
            /*
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync("/countries");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(stringResponse.Contains("Countries"));*/
        }

        [TestMethod]
        public void RepositoryTest() {
            const string c = ", ";
            var b = new StringBuilder();
            b.Append(GetMember.Name<CountryViewModel>(m => m.Alpha3Code));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.Alpha2Code));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.Name));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.ValidFrom));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.ValidTo));
            Assert.AreEqual(b.ToString(), CountriesController.properties);
        }

        [TestMethod]
        public async Task CreateTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public async Task DeleteTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public async Task DetailsTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod]
        public async Task EditTest() {
            Assert.Inconclusive();
        }
    }
}
