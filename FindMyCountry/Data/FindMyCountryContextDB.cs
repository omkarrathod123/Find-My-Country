using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FindMyCountry.shared;

namespace FindMyCountry.Data
{
    public class FindMyCountryContextDB : DbContext
    {
        public FindMyCountryContextDB (DbContextOptions<FindMyCountryContextDB> options)
            : base(options)
        {
        }

        public DbSet<FindMyCountry.shared.Country> Country { get; set; } = default!;
        public DbSet<FindMyCountry.shared.City> City { get; set; } = default!;
    }
}
