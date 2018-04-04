using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Country;
using Open.Facade.Country;

namespace Open.Sentry.Controllers {
    
    public class CountriesController : Controller {
        
        private readonly ICountryObjectsRepository repository;

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

        public IActionResult Edit() {
            return View(new CountryViewModel());
        }

        public IActionResult Details() {
            return View(new CountryViewModel());
        }

        public IActionResult Delete() {
            return View(new CountryViewModel());
        }
    }
}