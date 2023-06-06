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

namespace Renting.Pages.Customers
{
    [Authorize]
    public class IndexModel : RentsPageModel
    {
        private readonly CustomerService _customersService;

        public IndexModel(CustomerService rentsService)
        {
            _customersService = rentsService;
        }

        public List<DAL.Entities.Customer> Customers { get; set; } 

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var rents = await _customersService.GetCustomers();
                Customers = rents;
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Account/Login");
            }
        }

        public async Task<IActionResult> OnPostDelete(int? id, CancellationToken ct)
        {
            var res = await _customersService.DeleteCustomer(id);

            if (res)
                return RedirectToPage("/Customers/Index");
            else
                return NotFound();
        }
    }
}

