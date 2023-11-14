using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public ForgotPasswordViewModel model { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return Page();
                };
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);

                var callbackurl = Url.Page("ResetPassword"
                    , "/Account/ResetPassword"
                    , new
                    {
                        userId = user.Id,
                        code
                    },
                    protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email
                    , "Your reset password link"
                    , $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackurl)}'>clicking here</a>.");

                return RedirectToPage("/Account/ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}