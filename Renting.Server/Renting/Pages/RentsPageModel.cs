using Renting.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Renting.Pages
{
    public class RentsPageModel : PageModel
    {
        public SelectList ItemNameSL { get; set; }
        public SelectList CustomerNameSL { get; set; }
        public SelectList SellerNameSL { get; set; }


        public void ItemDropDownList(RentingDbContext _context, object selectedValue = null)
        {
            var query = _context.Items.OrderBy(x => x.Name);

            ItemNameSL = new SelectList(query.AsNoTracking(),
                        "Id", "Name", selectedValue);
        }

        public void CustomerDropDownList(RentingDbContext _context, object selectedValue = null)
        {
            var query = _context.Customers.OrderBy(x => x.Surname);

            CustomerNameSL = new SelectList(query.AsNoTracking(),
                        "Id", "FullName", selectedValue);
        }

        public void SellerDropDownList(RentingDbContext _context, object selectedValue = null)
        {
            var query = _context.Sellers.OrderBy(x => x.Surname);

            SellerNameSL = new SelectList(query.AsNoTracking(),
                        "Id", "FullName", selectedValue);
        }
    }
}