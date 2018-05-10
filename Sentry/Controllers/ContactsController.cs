using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Facade.Location;

namespace Open.Sentry.Controllers {

    //TODO: fix
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
            return View(AddressViewModelFactory.Create(c));
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
                case WebPageAddressDbRecord _:
                    return View("EditWeb", AddressViewModelFactory.Create(c) as WebPageAddressViewModel);
                case EmailAddressDbRecord _:
                    return View("EditEmail", AddressViewModelFactory.Create(c) as EMailAddressViewModel);
                case TelecomAddressDbRecord _:
                    return View("EditTelecom", AddressViewModelFactory.Create(c) as TelecomAddressViewModel);
            }

            return View("EditAddress", AddressViewModelFactory.Create(c) as GeographicAddressViewModel);
        }

        public async Task<IActionResult> Details(string id) {
            var c = await addresses.GetObject(id);
            switch (c) {
                case GeographicAddressDbRecord adr:
                    await deviceRegistrations.LoadDevices(
                        AddressObjectFactory.Create(adr) as GeographicAddressObject);
                    break;
                case TelecomAddressDbRecord tel:
                    await deviceRegistrations.LoadAddresses(
                        AddressObjectFactory.Create(tel) as TelecomAddressObject);
                    break;
            }

            return View(AddressViewModelFactory.Create(c));
        }
    }
}
