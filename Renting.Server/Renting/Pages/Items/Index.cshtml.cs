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

namespace Renting.Pages.Items
{
    [Authorize]
    public class IndexModel : RentsPageModel
    {
        private readonly ItemsService _customersService;

        public IndexModel(ItemsService rentsService)
        {
            _customersService = rentsService;
        }

        public List<Item> Items { get; set; } 

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var items = await _customersService.GetItems();
                Items = items;
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }
        }

        public async Task<IActionResult> OnPostDelete(int? id, CancellationToken ct)
        {
            var res = await _customersService.DeleteItem(id);

            if (res)
                return RedirectToPage("/Items/Index");
            else
                return NotFound();
        }
    }
}

