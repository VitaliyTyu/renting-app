using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Renting.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Renting.DAL.Interfaces;
using System.Linq;
using Renting.Services;

namespace Renting.Pages.CountriesOfOrigin
{
    [Authorize]
    public class IndexModel : RentsPageModel
    {
        private readonly CountriesOfOriginService _sellersService;

        public IndexModel(CountriesOfOriginService sellersService)
        {
            _sellersService = sellersService;
        }

        public List<DAL.Entities.CountryOfOrigin> CountriesOfOrigin { get; set; } 

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var rents = await _sellersService.GetCountries();
                CountriesOfOrigin = rents;
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }
        }

        public async Task<IActionResult> OnPostDelete(int? id, CancellationToken ct)
        {
            var res = await _sellersService.DeleteCountry(id);

            if (res)
                return RedirectToPage("/CountriesOfOrigin/Index");
            else
                return NotFound();
        }
    }
}

