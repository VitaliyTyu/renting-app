using Renting.DAL;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Renting.Pages
{
    public class EditModel : RentsPageModel
    {
        private RentingDbContext _db;
        private readonly IRentsService _rentsService;

        public EditModel(RentingDbContext db, IRentsService rentsService)
        {
            _db = db;
            _rentsService = rentsService;
        }

        [BindProperty]
        public Rent Rent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, CancellationToken ct)
        {
            if (id == null)
                return NotFound();

            Rent = await _rentsService.GetRent(id.Value, ct);

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
                var rent = await _db.Rents.FirstOrDefaultAsync(x => x.Id == Rent.Id);

                if (rent == null)
                    return NotFound();

                rent.StartDate = Rent.StartDate;
                rent.ExpectedEndDate = Rent.ExpectedEndDate;
                rent.ActualEndDate = Rent.ActualEndDate;
                rent.CustomerId = Rent.CustomerId;
                rent.ItemId = Rent.ItemId;
                rent.AccountId = Rent.AccountId;

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
