using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace INFP_Proj.Pages
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
