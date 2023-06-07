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

namespace Renting.Pages.Items
{
    public class ItemsService
    {
        private readonly RentingDbContext _context;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemsService(RentingDbContext context, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Item> GetItem(int id)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var item = await _context.Items
                .Include(x => x.Account)
                .Include(x => x.Category)
                .Include(x => x.Warehouse)
                .Include(x => x.CountryOfOrigin)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<List<Item>> GetItems()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var items = await _context.Items
                .Include(x => x.Account)
                .Include(x => x.Category)
                .Include(x => x.Warehouse)
                .Include(x => x.CountryOfOrigin)
                .Where(x => x.AccountId == user.Id)
                .ToListAsync();

            return items;
        }

        public async Task<bool> DeleteItem(int? id)
        {
            if (id == null)
                return false;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var item = await _context.Items
                .Include(x => x.Rents)
                .Include(x => x.Category)
                .Include(x => x.Warehouse)
                .Include(x => x.CountryOfOrigin)
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return false;

            _context.Items.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
