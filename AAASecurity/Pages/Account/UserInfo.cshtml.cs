using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAASecurity.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class UserInfoModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
