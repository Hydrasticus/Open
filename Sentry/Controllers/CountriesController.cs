using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Open.Infra;

namespace Open.Sentry.Controllers {
    public class CountriesController : Controller {
        private readonly CountryDbContext db;
        public CountriesController(CountryDbContext c) {
            db = c;
        }

        [Authorize]
        public async Task<IActionResult> Index() {
            return View(await db.Countries.ToListAsync());
        }
    }
}