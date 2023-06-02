using Renting.DAL.Entities;
using Renting.DAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Renting.Services
{
    public class CountryOfOriginService
    {
        private readonly RentingDbContext _context;

        public CountryOfOriginService(RentingDbContext context)
        {
            _context = context;
        }

        public async Task<List<CountryOfOrigin>> GetAllCountriesOfOriginAsync()
        {
            return await _context.CountriesOfOrigin.ToListAsync();
        }

        public async Task<CountryOfOrigin> GetCountryOfOriginByIdAsync(int id)
        {
            return await _context.CountriesOfOrigin.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCountryOfOriginAsync(CountryOfOrigin countryOfOrigin)
        {
            await _context.CountriesOfOrigin.AddAsync(countryOfOrigin);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCountryOfOriginAsync(int id)
        {
            var countryOfOrigin = await _context.CountriesOfOrigin.FirstOrDefaultAsync(c => c.Id == id);
            if (countryOfOrigin != null)
            {
                _context.CountriesOfOrigin.Remove(countryOfOrigin);
                await _context.SaveChangesAsync();
            }
        }
    }
}
