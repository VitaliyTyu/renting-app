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

namespace Renting.Pages
{
    [Authorize]
    public class EditModel : RentsPageModel
    {
        private RentingDbContext _db;
        private readonly IRentsService _rentsService;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditModel(RentingDbContext db, IRentsService rentsService, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _rentsService = rentsService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Rent Rent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, CancellationToken ct)
        {
            if (id == null)
                return NotFound();

            try
            {
                Rent = await _rentsService.GetRent(id.Value, ct);
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }


            if (Rent == null)
                return NotFound();

            ItemDropDownList(_db, Rent.ItemId);
            CustomerDropDownList(_db, Rent.CustomerId);
            SellerDropDownList(_db, Rent.SellerId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                if (user == null)
                    return RedirectToPage("/Account/Login");

                var rent = await _db.Rents
                .Include(x => x.Item).ThenInclude(x => x.CountryOfOrigin)
                .Include(x => x.Item).ThenInclude(x => x.Warehouse)
                .Include(x => x.Item).ThenInclude(x => x.Category)
                .Include(x => x.Customer).ThenInclude(x => x.Discounts)
                .Include(x => x.Seller)
                .Include(x => x.Account)
                .Include(x => x.Penalties)
                .Where(x => x.AccountId == user.Id)
                .FirstOrDefaultAsync(x => x.Id == Rent.Id);

                if (rent == null)
                    return NotFound();

                rent.StartDate = Rent.StartDate;
                rent.ExpectedEndDate = Rent.ExpectedEndDate;
                rent.ActualEndDate = Rent.ActualEndDate;
                rent.CustomerId = Rent.CustomerId;
                rent.ItemId = Rent.ItemId;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            ItemDropDownList(_db);
            CustomerDropDownList(_db);
            SellerDropDownList(_db);

            return Page();
        }
    }
}
