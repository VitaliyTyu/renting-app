using Renting.DAL;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace Renting.Pages
{
    [Authorize]
    public class CreateModel : RentsPageModel
    {
        private readonly RentingDbContext _db;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public Rent Rent { get; set; }

        public CreateModel(RentingDbContext db, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            ItemDropDownList(_db);
            CustomerDropDownList(_db);
            SellerDropDownList(_db);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                    Rent.Account = user;
                    await _db.Rents.AddAsync(Rent);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("/Index");
                }
                catch (Exception)
                {
                    return RedirectToPage("/Account/Login");
                }
            }

            ItemDropDownList(_db);
            CustomerDropDownList(_db);
            SellerDropDownList(_db);
            return Page();
        }
    }
}