using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Country;

namespace Open.Infra.Country {

    public class CountryObjectsRepository : ICountryObjectsRepository {

        private readonly CountryDbContext db;

        public CountryObjectsRepository(CountryDbContext context) {
            db = context;
        }

        public async Task<CountryObject> GetObject(string id) {
            var o = await db.Countries.FindAsync(id);
            return new CountryObject(o);
        }

        public async Task<PaginatedList<CountryObject>> GetObjectsList(string searchString = null,
            int? pageIndex = null, int? pageSize = null) {
            var countries = getCountries().Where(s => s.Contains(searchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, pageIndex, pageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            
            return new CountryObjectsList(items, p);
        }

        private IQueryable<CountryDbRecord> getCountries() {
            return from s in db.Countries select s;
        }

        public async Task<CountryObject> AddObject(CountryObject o) {
            db.Countries.Add(o.DbRecord);
            await db.SaveChangesAsync();
            return o;
        }

        public async void UpdateObject(CountryObject o) {
            db.Countries.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async void DeleteObject(CountryObject o) {
            db.Countries.Remove(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public bool IsInitialized() {
            db.Database.EnsureCreated();
            return db.Countries.Any();
        }
    }
}
