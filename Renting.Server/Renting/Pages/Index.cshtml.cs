using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Renting.Pages
{
    [Authorize]
    public class IndexModel : RentsPageModel
    {
        private readonly IRentsService _rentsService;

        public IndexModel(IRentsService rentsService)
        {
            _rentsService = rentsService;
        }

        // список договоров об аренде, которые используются на странице
        public List<Rent> Rents { get; set; } 

        public async Task<IActionResult> OnGetAsync(CancellationToken ct)
        {
            // получение договоров об аренде
            try
            {
                var rents = await _rentsService.GetRents(ct);
                Rents = rents;
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }
        }

        public async Task<IActionResult> OnPostDelete(int? id, CancellationToken ct)
        {
            // удаление договора об аренде
            var res = await _rentsService.DeleteRent(id, ct);

            if (res)
                return RedirectToPage("Index");
            else
                return NotFound();
        }
    }
}

