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

namespace Renting.Pages.Warehouses
{
    [Authorize]
    public class EditModel : RentsPageModel
    {
        private RentingDbContext _db;
        private readonly WarehousesService _customerService;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditModel(RentingDbContext db, WarehousesService customerService, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _customerService = customerService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Warehouse Warehouses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, CancellationToken ct)
        {
            if (id == null)
                return NotFound();

            try
            {
                Warehouses = await _customerService.GetCountry(id.Value);
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }


            if (Warehouses == null)
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

                var customer = await _customerService.GetCountry(Warehouses.Id);

                if (customer == null)
                    return NotFound();

                customer.Name = Warehouses.Name;
                customer.Address = Warehouses.Address;

                await _db.SaveChangesAsync();

                return RedirectToPage("/Warehouses/Index");
            }

            return Page();
        }
    }
}
