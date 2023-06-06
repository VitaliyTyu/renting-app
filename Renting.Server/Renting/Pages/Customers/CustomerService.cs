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

namespace Renting.Pages.Customers
{
    public class CustomerService
    {
        private readonly RentingDbContext _context;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(RentingDbContext context, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DAL.Entities.Customer> GetCustomer(int id)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var customer = await _context.Customers
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            return customer;
        }

        public async Task<List<DAL.Entities.Customer>> GetCustomers()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                throw new ArgumentException("Доступ закрыт");

            var customers = await _context.Customers
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .ToListAsync();

            return customers;
        }

        public async Task<bool> DeleteCustomer(int? id)
        {
            if (id == null)
                return false;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var customer = await _context.Customers
                .Include(x => x.Discounts)
                .Include(x => x.Rents)
                .Include(x => x.Account)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return false;

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
