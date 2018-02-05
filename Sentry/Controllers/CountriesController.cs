using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Open.Sentry.Data;
using System.Threading.Tasks;

namespace Open.Sentry.Controllers {
    public class CountriesController : Controller {
        private readonly CountryContext db;
        public CountriesController(CountryContext c) {
            db = c;
        }

        [Authorize]
        public async Task<IActionResult> Index() {
            return View(await db.Countries.ToListAsync());
        }
    }
}