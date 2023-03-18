using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Renting.DAL.Entities;

namespace Renting.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRentsService _rentsService;

        public IndexModel(IRentsService rentsService)
        {
            _rentsService = rentsService;
        }

        public List<Rent> Rents { get; set; }

        public async Task OnGet(CancellationToken ct)
        {
            Rents = await _rentsService.GetRents(ct);
        }

        public async Task<IActionResult> OnPostDelete(int? id, CancellationToken ct)
        {
            var res = await _rentsService.DeleteRent(id, ct);

            if (res)
                return RedirectToPage("Index");
            else
                return NotFound();

            //if (id == null)
            //    return NotFound();

            //var rent = await _db.Rents
            //    .Include(x => x.Penalties)
            //    .FirstOrDefaultAsync(x => x.Id == id);

            //if (rent == null)
            //    return NotFound();

            //_db.Rents.Remove(rent);

            //await _db.SaveChangesAsync();

            //return RedirectToPage("Index");
        }
    }
}