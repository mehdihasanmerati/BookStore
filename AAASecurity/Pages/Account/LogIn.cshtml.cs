using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAASecurity.Pages.Account
{
    public class LogInModel(SignInManager<IdentityUser> signInManager) : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;

        [BindProperty, Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [BindProperty, Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty, Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        [BindProperty]
        public string? ReturnUrl { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, Password, true, true);

                if (result.Succeeded)
                {
                    return Redirect(ReturnUrl ?? "/Users/List");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                }
            }
            return Page();
        }
    }
}
