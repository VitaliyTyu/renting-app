using Renting.DAL;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Renting.Services;

namespace Renting.Pages.Customers
{
    [Authorize]
    public class EditModel : RentsPageModel
    {
        private RentingDbContext _db;
        private readonly CustomerService _customerService;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditModel(RentingDbContext db, CustomerService customerService, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _customerService = customerService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, CancellationToken ct)
        {
            if (id == null)
                return NotFound();

            try
            {
                Customer = await _customerService.GetCustomer(id.Value);
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }


            if (Customer == null)
                return NotFound();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                if (user == null)
                    return RedirectToPage("/Account/Login");

                var customer = await _customerService.GetCustomer(Customer.Id);

                if (customer == null)
                    return NotFound();

                customer.Name = Customer.Name;
                customer.Surname = Customer.Surname;
                customer.Age = Customer.Age;
                customer.Height = Customer.Height;
                customer.Weight = Customer.Weight;
                customer.ShoeSizeRu = Customer.ShoeSizeRu;
                customer.ClothingSizeRu = Customer.ClothingSizeRu;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Customers/Index");
            }

            return Page();
        }
    }
}
