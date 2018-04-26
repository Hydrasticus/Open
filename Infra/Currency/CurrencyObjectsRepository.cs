using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Money;

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
            int? pageIndex = null, int? pageSize = null) {
            var currencies = getCurrencies().Where(s => s.Contains(searchString)).AsNoTracking();
            var count = await currencies.CountAsync();
            var p = new RepositoryPage(count, pageIndex, pageSize);
            var items = await currencies.Skip(p.FirstItemIndex).Take(p.PageIndex).ToListAsync();
            
            return new CurrencyObjectsList(items, p);
        }

        private IQueryable<CurrencyDbRecord> getCurrencies() {
            return from s in db.Currencies select s;
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
