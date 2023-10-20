using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                    ,"/Account/ResetPassword"
                    , new
                    {
                        userId = user.Id,
                        code
                    });

                //await _emailSender.SendEmailAsync(model.Email
                //    , "Your reset password link"
                //    ,"Please reset your password by clicking here: <a href=\"" + callbackurl + "\"> link </a>");

                return LocalRedirect(callbackurl);
            }
            return Page();
        }
    }
}
