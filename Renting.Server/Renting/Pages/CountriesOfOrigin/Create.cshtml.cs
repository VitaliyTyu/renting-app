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

namespace Renting.Pages.CountriesOfOrigin
{
    [Authorize]
    public class CreateModel : RentsPageModel
    {
        private readonly RentingDbContext _db;
        private readonly UserManager<DAL.Entities.Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public CountryOfOrigin CountriesOfOrigin { get; set; }

        public CreateModel(RentingDbContext db, UserManager<DAL.Entities.Account> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (user == null)
                return RedirectToPage("/Account/Login");


            try
            {
                CountriesOfOrigin.Account = user;
                await _db.CountriesOfOrigin.AddAsync(CountriesOfOrigin);
                await _db.SaveChangesAsync();
                return RedirectToPage("/CountriesOfOrigin/Index");
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }
}