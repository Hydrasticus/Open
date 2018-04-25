using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Domain.Currency;
using Open.Facade.Currency;

namespace Open.Sentry.Controllers {

    public class CurrenciesController : Controller {

        private readonly ICurrencyObjectsRepository repository;
        public const string properties = "IsoCurrencySymbol, CurrencySymbol, Name, ValidFrom, ValidTo";

        public CurrenciesController(ICurrencyObjectsRepository r) {
            repository = r;
        }

        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
                ViewData["CurrentSort"] = sortOrder;
                ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["SortIsoCurrency"] = sortOrder == "isoCurrency" ? "isoCurrency_desc" : "isoCurrency";
                ViewData["SortCurrency"] = sortOrder == "currency" ? "currency_desc" : "currency";
                ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
                ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
                if (searchString != null) page = 1;
                else searchString = currentFilter;
                ViewData["CurrentFilter"] = searchString;
            
            var l = await repository.GetObjectsList(searchString, page);
            return View(new CurrencyViewModelsList(l, sortOrder));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(properties)] CurrencyViewModel c) {
            await validateId(c.IsoCurrencySymbol, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = CurrencyObjectFactory.Create(c.IsoCurrencySymbol, c.Name, c.CurrencySymbol, c.ValidFrom, c.ValidTo);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id) {
            var c = await repository.GetObject(id);
            return View(CurrencyViewModelFactory.Create(c));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] CurrencyViewModel c) {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.IsoCurrencySymbol);
            o.DbRecord.Name = c.Name;
            o.DbRecord.Code = c.CurrencySymbol;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            repository.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id) {
            var c = await repository.GetObject(id);
            return View(CurrencyViewModelFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await repository.GetObject(id);
            return View(CurrencyViewModelFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await repository.GetObject(id);
            repository.DeleteObject(c);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d) {
            if (await isIdInUse(id)) d.AddModelError(string.Empty, idIsInUseMessage(id));
        }

        private async Task<bool> isIdInUse(string id) {
            return (await repository.GetObject(id))?.DbRecord?.ID == id;
        }

        private static string idIsInUseMessage(string id) {
            var name = GetMember.DisplayName<CurrencyViewModel>(c => c.IsoCurrencySymbol);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}
