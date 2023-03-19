using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


using Renting.DAL;

using Microsoft.EntityFrameworkCore;

using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

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
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentsService(RentingDbContext context, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Rent> GetRent(int id, CancellationToken ct)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var rent = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.Seller)
                .Include(x => x.Account)
                .Include(x => x.Penalties)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            return rent;
        }

        public async Task<List<Rent>> GetRents(CancellationToken ct)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var rents = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.Seller)
                .Include(x => x.Account)
                .Include(x => x.Penalties)
                .Where(x => x.AccountId == user.Id)
                .ToListAsync();

            return rents;
        }

        public async Task<bool> DeleteRent(int? id, CancellationToken ct)
        {
            if (id == null)
                return false;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var rent = await _context.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.Seller)
                .Include(x => x.Account)
                .Include(x => x.Penalties)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rent == null)
                return false;

            _context.Rents.Remove(rent);

            await _context.SaveChangesAsync();

            return true;
        }

        //private async Task ValidateUser(Guid rentId, Guid accountId, CancellationToken ct)
        //{
        //    var id = await _context.Rents
        //        .Where(x => x.Id == rentId)
        //        .Select(x => x.Account.Id)
        //        .FirstOrDefaultAsync(ct);

        //    if (id != accountId.ToString())
        //        throw new ArgumentException("Forbidden");
        //}
    }
}
