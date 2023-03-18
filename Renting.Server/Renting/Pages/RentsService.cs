using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


using Renting.DAL;

using Microsoft.EntityFrameworkCore;

using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Renting.Pages
{
    public interface IRentsService
    {
        Task<bool> DeleteRent(int? id, CancellationToken ct);
        Task<Rent> GetRent(int id, CancellationToken ct);
        Task<List<Rent>> GetRents(CancellationToken ct);
    }

    public class RentsService : IRentsService
    {
        private readonly RentingDbContext _context;

        public RentsService(RentingDbContext context)
        {
            _context = context;
        }

        public async Task<Rent> GetRent(int id, CancellationToken ct)
        {
            var rent = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rent == null)
                throw new ArgumentException("не найден");

            return rent;
        }

        public async Task<List<Rent>> GetRents(CancellationToken ct)
        {
            var rents = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.User)
                .Include(x => x.Penalties)
                .ToListAsync();

            return rents;
        }

        public async Task<bool> DeleteRent(int? id, CancellationToken ct)
        {
            if (id == null)
                return false;

            var rent = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.User)
                .Include(x => x.Penalties)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rent == null)
                return false;

            _context.Rents.Remove(rent);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
