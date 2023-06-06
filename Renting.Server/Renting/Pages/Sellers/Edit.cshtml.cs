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

namespace Renting.Pages.Sellers
{
    [Authorize]
    public class EditModel : RentsPageModel
    {
        private RentingDbContext _db;
        private readonly SellerService _customerService;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditModel(RentingDbContext db, SellerService customerService, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _customerService = customerService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Seller Seller { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, CancellationToken ct)
        {
            if (id == null)
                return NotFound();

            try
            {
                Seller = await _customerService.GetSeller(id.Value);
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }


            if (Seller == null)
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

                var customer = await _customerService.GetSeller(Seller.Id);

                if (customer == null)
                    return NotFound();

                customer.Name = Seller.Name;
                customer.Surname = Seller.Surname;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Sellers/Index");
            }

            return Page();
        }
    }
}
