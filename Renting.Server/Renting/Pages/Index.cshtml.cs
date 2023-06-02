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


        public async Task<IActionResult> OnGetExport(CancellationToken ct)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            // Retrieve data from the database using Entity Framework Core
            var data = await _rentsService.GetRents(ct);


            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Create a worksheet
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Write column headers
                var properties = typeof(Rent).GetProperties();


                // Filter out properties that are lists
                var filteredProperties = properties
                    .Where(p => !p.PropertyType.IsGenericType || p.PropertyType.GetGenericTypeDefinition() != typeof(List<>))
                    .ToList();

                for (int i = 0; i < filteredProperties.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = filteredProperties[i].Name;
                }

                for (int row = 0; row < data.Count; row++)
                {
                    for (int col = 0; col < filteredProperties.Count; col++)
                    {
                        var propertyValue = filteredProperties[col].GetValue(data[row]);

                        
                        if (propertyValue is DateTime dateTimeValue) 
                        {
                            var formattedValue = dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");

                            worksheet.Cells[row + 2, col + 1].Value = formattedValue;
                        }
                        else if (propertyValue is NamedEntity referencedObject) 
                        {
                            var referencedProperty = typeof(NamedEntity).GetProperty("Name");
                            var referencedPropertyValue = referencedProperty?.GetValue(referencedObject);

                            worksheet.Cells[row + 2, col + 1].Value = referencedPropertyValue;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, col + 1].Value = propertyValue;
                        }
                    }
                }

                // Save the Excel file to a memory stream
                var stream = new MemoryStream(package.GetAsByteArray());

                // Set the response headers
                Response.Headers.Add("Content-Disposition", "attachment; filename=export.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                // Send the file as the response
                return File(stream, Response.ContentType);
            }
        }
    }
}

