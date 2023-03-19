using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Renting.DAL;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Renting.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<Renting.DAL.Entities.Account> _userManager;
        private readonly SignInManager<Renting.DAL.Entities.Account> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly RentingDbContext _dbContext;

        public LoginModel(
            UserManager<Renting.DAL.Entities.Account> userManager,
            SignInManager<Renting.DAL.Entities.Account> signInManager,
            ILogger<LoginModel> logger,
            RentingDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var user = await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, Password, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
