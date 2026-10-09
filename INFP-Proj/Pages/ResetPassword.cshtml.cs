using INFP_Proj.Models;
using INFP_Proj.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace INFP_Proj.Pages
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;

        [BindProperty]
        public ResetPassword RPModel { get; set; }

        public ResetPasswordModel(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
            if (!HasPendingReset())
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!HasPendingReset()) return RedirectToPage("/Login");
            if (!ModelState.IsValid) return Page();

            string email = HttpContext.Session.GetString("ForcedResetEmail")!;
            string token = HttpContext.Session.GetString("ForcedResetToken")!;

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ClearSession();
                return RedirectToPage("/Login");
            }

            var result = await userManager.ResetPasswordAsync(user, token, RPModel.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page();
            }

            if (user.RequiresPasswordReset)
            {
                user.RequiresPasswordReset = false;
                await userManager.UpdateAsync(user);
            }

            ClearSession();
            return RedirectToPage("/Login");
        }

        private bool HasPendingReset()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("ForcedResetEmail")) &&
                   !string.IsNullOrEmpty(HttpContext.Session.GetString("ForcedResetToken"));
        }

        private void ClearSession()
        {
            HttpContext.Session.Remove("ForcedResetEmail");
            HttpContext.Session.Remove("ForcedResetToken");
        }
    }
}
