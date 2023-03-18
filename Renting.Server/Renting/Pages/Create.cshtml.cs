using Renting.DAL;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Renting.Pages
{
    public class CreateModel : RentsPageModel
    {
        private readonly RentingDbContext _db;

        [BindProperty]
        public Rent Rent { get; set; }

        public CreateModel(RentingDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            ItemDropDownList(_db);
            CustomerDropDownList(_db);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _db.Rents.AddAsync(Rent);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            ItemDropDownList(_db);
            CustomerDropDownList(_db);
            return Page();
        }
    }
}