using Renting.DAL;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Renting.Pages
{
    public class EditModel : RentsPageModel
    {
        private RentingDbContext _db;

        public EditModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Rent Rent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Rent = await _db.Rents
                .Include(c => c.Item)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Rent == null)
                return NotFound();

            ItemDropDownList(_db, Rent.ItemId);
            CustomerDropDownList(_db, Rent.CustomerId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var rent = await _db.Rents.FirstOrDefaultAsync(x => x.Id == Rent.Id);

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

            return Page();
        }
    }
}
