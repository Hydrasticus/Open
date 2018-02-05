using Microsoft.EntityFrameworkCore;
using Open.Sentry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Sentry.Data {
    public class CountryContext : DbContext {
        public CountryContext(DbContextOptions<CountryContext> o) : base(o) {}
        public DbSet<IsoCountry> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            b.Entity<IsoCountry>().ToTable("Country");
        }
    }
}
