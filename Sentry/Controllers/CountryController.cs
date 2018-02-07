using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Country;
using Open.Facade.Country;

namespace Open.Sentry.Controllers {
    public class CountryController : Controller {
        private readonly ICountryObjectsRepository repository;

        public CountryController(ICountryObjectsRepository r) {
            repository = r;
        }

        [Authorize]
        public async Task<IActionResult> Index() {
            var l = await repository.GetObjectsList();
            return View(new CountryViewModelsList(l));
        }
    }
}