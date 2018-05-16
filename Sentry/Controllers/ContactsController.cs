using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Facade.Location;

namespace Open.Sentry.Controllers {

    //TODO: fix, different than Lab17End
    public class ContactsController : Controller {

        private readonly IAddressObjectsRepository addresses;
        private readonly ITelecomDeviceRegistrationObjectsRepository deviceRegistrations;
        internal const string emailProperties = "ID, EmailAddress, AddressType, ValidFrom, ValidTo";
        internal const string webProperties = "ID, Url, AddressType, ValidFrom, ValidTo";
        internal const string telecomProperties =
            "ID, CountryCode, AreaCode, Number, Extension, NationalDirectDialingPrefix, DeviceType, AddressType, ValidFrom, ValidTo";
        internal const string adrProperties =
            "ID, AddressLine, City, RegionOrState, ZipOrPostalCode, AddressType, ValidFrom, ValidTo";

        public ContactsController(IAddressObjectsRepository a, ITelecomDeviceRegistrationObjectsRepository d) {
            addresses = a;
            deviceRegistrations = d;
        }

        public async Task<IActionResult> Index(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortAddressType"] = string.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["SortToString"] = sortOrder == "string" ? "string_desc" : "string";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            addresses.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            addresses.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            addresses.SearchString = searchString;
            addresses.PageIndex = page ?? 1;
            var l = await addresses.GetObjectsList();
            return View(new AddressViewModelsList(l));
        }

        private Func<AddressDbRecord, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.GetType().Name;
            if (sortOrder.StartsWith("string")) return x => x.GetType().Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            return x => x.Address;
        }

        public async Task<IActionResult> Delete(string id) {
            var c = await addresses.GetObject(id);

            switch (c) {
                    case WebAddressObject web:
                        return View("DeleteWeb", AddressViewModelFactory.Create(web) as WebPageAddressViewModel);
                    case EmailAddressObject email:
                        return View("DeleteEmail", AddressViewModelFactory.Create(email) as EMailAddressViewModel);
                    case TelecomAddressObject tel:
                        return View("DeleteTelecom", AddressViewModelFactory.Create(tel) as TelecomAddressViewModel);
                    case GeographicAddressObject adr:
                        await deviceRegistrations.LoadDevices(adr);
                        // ReSharper disable once Mvc.ViewNotResolved
                        return View("DeleteAddresses",
                            AddressViewModelFactory.Create(adr) as GeographicAddressViewModel);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await addresses.GetObject(id);
            await addresses.DeleteObject(c);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id) {
            var c = await addresses.GetObject(id);
            switch (c) {
                case WebAddressObject web:
                    return View("EditWeb", AddressViewModelFactory.Create(web) as WebPageAddressViewModel);
                case EmailAddressObject email:
                    return View("EditEmail", AddressViewModelFactory.Create(email) as EMailAddressViewModel);
                case TelecomAddressObject tel:
                    return View("EditTelecom", AddressViewModelFactory.Create(tel) as TelecomAddressViewModel);
            }

            return View("EditAddress", AddressViewModelFactory.Create(c) as GeographicAddressViewModel);
        }

        public async Task<IActionResult> Details(string id) {
            var c = await addresses.GetObject(id);
            switch (c) {
                case WebAddressObject web:
                    return View("DetailsWeb", AddressViewModelFactory.Create(web) as WebPageAddressViewModel);
                case EmailAddressObject email:
                    return View("DetailsEmail", AddressViewModelFactory.Create(email) as EMailAddressViewModel);
                case TelecomAddressObject tel:
                    await deviceRegistrations.LoadAddresses(tel);
                    return View("DetailsTelecom", AddressViewModelFactory.Create(tel) as TelecomAddressViewModel);
                case GeographicAddressObject adr:
                    await deviceRegistrations.LoadDevices(adr);
                    return View("DetailsAddress", AddressViewModelFactory.Create(adr) as GeographicAddressViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateWeb() {
            return View("CreateWeb", new WebPageAddressViewModel());
        }
        
        public IActionResult CreateEmail() {
            return View("CreateEmail", new EMailAddressViewModel());
        }
        
        public IActionResult CreateTelecom() {
            return View("CreateTelecom", new TelecomAddressViewModel());
        }
        
        public IActionResult CreateAddress() {
            return View("CreateAddress", new GeographicAddressViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWeb([Bind(webProperties)] WebPageAddressViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = AddressObjectFactory.CreateWeb(c.ID, c.Url, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(webProperties)] WebPageAddressViewModel c) {
            if (!ModelState.IsValid) return View("EditWeb", c);
            var o = await addresses.GetObject(c.ID) as WebAddressObject;
            if (o is null) return RedirectToAction("Index");
            o.DbRecord.Address = c.Url;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmail([Bind(emailProperties)] EMailAddressViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = AddressObjectFactory.CreateEmail(c.ID, c.EmailAddress, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(emailProperties)] EMailAddressViewModel c) {
            if (!ModelState.IsValid) return View("EditEmail", c);
            var o = await addresses.GetObject(c.ID) as EmailAddressObject;
            o.DbRecord.Address = c.EmailAddress;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }
    }
}
