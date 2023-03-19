using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Renting.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Renting.DAL.Entities.Account> _signInManager;

        public LogoutModel(SignInManager<Renting.DAL.Entities.Account> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Account/Login");
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToPage("/Index");
        //}
    }
}
