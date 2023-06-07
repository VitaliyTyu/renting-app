﻿using Microsoft.AspNetCore.Mvc;
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

namespace Renting.Pages.Categories
{
    [Authorize]
    public class IndexModel : RentsPageModel
    {
        private readonly CategoriesService _sellersService;

        public IndexModel(CategoriesService sellersService)
        {
            _sellersService = sellersService;
        }

        public List<DAL.Entities.Category> Categories { get; set; } 

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var rents = await _sellersService.GetCountries();
                Categories = rents;
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
                return RedirectToPage("/Categories/Index");
            else
                return NotFound();
        }
    }
}

