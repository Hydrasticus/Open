using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Currency;
using Open.Domain.Currency;

namespace Open.Infra.Currency {

    public class CurrencyObjectsRepository : ICurrencyObjectsRepository {

        private readonly CurrencyDbContext db;

        public CurrencyObjectsRepository(CurrencyDbContext context) {
            db = context;
        }

        public async Task<CurrencyObject> GetObject(string id) {
            var o = await db.Currencies.FindAsync(id);
            return new CurrencyObject(o);
        }

        public async Task<PaginatedList<CurrencyObject>> GetObjectsList(string searchString = null,
            int? page = null,
            int? pageSize = null) {
            var currencies = from s in db.Currencies select s;

            if (!string.IsNullOrEmpty(searchString)) {
                searchString = searchString.ToLower();
                currencies = currencies.Where(
                    s => s.ID.ToLower().Contains(searchString)
                         || s.Name.ToLower().Contains(searchString)
                         || s.Code.ToLower().Contains(searchString)
                         || s.ValidFrom.ToString(CultureInfo.CurrentCulture).Contains(searchString)
                         || s.ValidTo.ToString(CultureInfo.CurrentCulture).Contains(searchString));
            }

            var list = await PaginatedList<CurrencyDbRecord>.CreateAsync(currencies.AsNoTracking(), page, pageSize);
            return new CurrencyObjectsList(list);
        }

        public async Task<CurrencyObject> AddObject(CurrencyObject o) {
            db.Currencies.Add(o.DbRecord);
            await db.SaveChangesAsync();
            return o;
        }

        public async void UpdateObject(CurrencyObject o) {
            db.Currencies.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async void DeleteObject(CurrencyObject o) {
            db.Currencies.Remove(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public bool IsInitialized() {
            db.Database.EnsureCreated();
            return db.Currencies.Any();
        }
    }
}
