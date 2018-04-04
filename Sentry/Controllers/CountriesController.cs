using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Country;
using Open.Facade.Country;

namespace Open.Sentry.Controllers {

    public class CountriesController : Controller {

        private readonly ICountryObjectsRepository repository;
        public const string properties = "Alpha3Code, Alpha2Code, Name, ValidFrom, ValidTo";

        public CountriesController(ICountryObjectsRepository r) {
            repository = r;
        }

        [Authorize]
        public async Task<IActionResult> Index() {
            var l = await repository.GetObjectsList();
            return View(new CountryViewModelsList(l));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(properties)] CountryViewModel c) {
            if (!ModelState.IsValid) return View(c);
            var o = CountryObjectFactory.Create(c.Alpha3Code, c.Name, c.Alpha2Code, c.ValidFrom, c.ValidTo);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id) {
            var c = await repository.GetObject(id);
            return View(CountryViewModelFactory.Create(c));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] CountryViewModel c) {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.Alpha3Code);
            o.DbRecord.Name = c.Name;
            o.DbRecord.Code = c.Alpha2Code;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            repository.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public IActionResult Details() {
            return View(new CountryViewModel());
        }

        public IActionResult Delete() {
            return View(new CountryViewModel());
        }
    }
}