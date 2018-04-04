using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Open.Domain.Currency;
using Open.Facade.Currency;
using Open.Infra.Currency;

namespace Open.Sentry.Controllers {

    public class CurrenciesController : Controller {

        private readonly ICurrencyObjectsRepository repository;

        public CurrenciesController(ICurrencyObjectsRepository r) {
            repository = r;
        }

        public async Task<IActionResult> Index() {
            var l = await repository.GetObjectsList();
            return View(new CurrencyViewModelsList(l));
        }
    }
}