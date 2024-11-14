using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAASecurity.Pages.Users
{

    [BindProperties]
    public class ManagementRoleModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagementRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public List<string> Roles { get; set; }
        [BindProperty]
        public IdentityUser? CurrentUser { get; set; }
        [BindProperty]
        public List<IdentityRole> AllRoles { get; set; }
        [BindProperty]
        public List<string> UserRole { get; set; }

        public async Task OnGet(string id)
        {
            CurrentUser = await _userManager.FindByIdAsync(id);
            UserRole = (await _userManager.GetRolesAsync(CurrentUser)).ToList();
            AllRoles = _roleManager.Roles.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentUser = await _userManager.FindByIdAsync(Id);
            UserRole = (await _userManager.GetRolesAsync(CurrentUser)).ToList();
            AllRoles = _roleManager.Roles.ToList();

            foreach (var item in AllRoles)
            {
                if (Roles.Contains(item.Name))
                {
                    if (!(await _userManager.IsInRoleAsync(CurrentUser, item.Name)))
                    {
                        await _userManager.AddToRoleAsync(CurrentUser, item.Name);
                    }
                }
                else
                {
                    if(await _userManager.IsInRoleAsync(CurrentUser, item.Name))
                    {
                        await _userManager.RemoveFromRoleAsync(CurrentUser, item.Name);
                    }
                }
            }

            return RedirectToPage("List");
        }
    }
}
