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

namespace Renting.Pages.Categories
{
    public class CategoriesService
    {
        private readonly RentingDbContext _context;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesService(RentingDbContext context, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Category> GetCountry(int id)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var coutriesOfOrigin = await _context.Categories
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            return coutriesOfOrigin;
        }

        public async Task<List<Category>> GetCountries()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var sellers = await _context.Categories
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .ToListAsync();

            return sellers;
        }

        public async Task<bool> DeleteCountry(int? id)
        {
            if (id == null)
                return false;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var seller = await _context.Categories
                .Include(x => x.Items)
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (seller == null)
                return false;

            _context.Categories.Remove(seller);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
